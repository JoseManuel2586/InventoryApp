using InventoryApp.Domain;
using InventoryApp.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryApp.WinForms
{
    public partial class ClientsInlineForm : Form
    {
        private readonly IClientRepository _repo;
        private readonly BindingSource _bs = new();
        private DataTable _table = new();
        public ClientsInlineForm(IClientRepository repo)
        {
            InitializeComponent();
            _repo = repo;
            
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
        }
        private async void ClientsInlineForm_Load(object sender, EventArgs e)
        {
            await LoadTableAsync();
            SetupGrid();
        }
        private static DataTable BuildSchema()
        {
            var t = new DataTable("cliente");
            var cId = t.Columns.Add("id", typeof(int));
            cId.AllowDBNull = true;

            t.Columns.Add("nombre", typeof(string));
            t.Columns.Add("nit", typeof(string));
            t.Columns.Add("mail", typeof(string));
            t.Columns.Add("tel", typeof(string));
            t.Columns.Add("dir", typeof(string));

            return t;
        }
        private async Task LoadTableAsync()
        {
            _table = BuildSchema();
            var clientes = await _repo.GetAllAsync();
            foreach (var c in clientes)
            {
                var r = _table.NewRow();
                r["id"] = c.Id;
                r["nombre"] = c.Nombre;
                r["nit"] = c.Nit;
                r["mail"] = c.Email;
                r["tel"] = c.Telefono;
                r["dir"] = c.Direccion;
                _table.Rows.Add(r);
            }
            _table.AcceptChanges();
            _bs.DataSource = _table;
            dataGridClients.DataSource = _bs;
        }

        private void SetupGrid()
        {
            dataGridClients.ReadOnly = true;
            dataGridClients.AllowUserToAddRows = false;
            dataGridClients.AllowUserToDeleteRows = false;
            dataGridClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridClients.MultiSelect = false;
            dataGridClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dataGridClients.Columns["id"] is DataGridViewColumn idCol)
            {
                idCol.HeaderText = "ID";
                idCol.Width = 70;
            }
            if (dataGridClients.Columns["nombre"] is DataGridViewColumn col1) col1.HeaderText = "Nombre";
            if (dataGridClients.Columns["nit"] is DataGridViewColumn col2) col2.HeaderText = "NIT";
            if (dataGridClients.Columns["mail"] is DataGridViewColumn col3) col3.HeaderText = "Correo";
            if (dataGridClients.Columns["tel"] is DataGridViewColumn col4) col4.HeaderText = "Teléfono";
            if (dataGridClients.Columns["dir"] is DataGridViewColumn col5) col5.HeaderText = "Dirección";
        }

        private async Task RefreshDataAsync() => await LoadTableAsync();

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using var dlg = new AddEditClientForm();
            dlg.Text = "Agregar Cliente";
            if(dlg.ShowDialog(this) == DialogResult.OK)
            {
                var c = dlg.BuildClient();
                try
                {
                    int newId = await _repo.InsertAsync(c);
                    MessageBox.Show($"Cliente creado con ID #{newId}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await RefreshDataAsync();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error al guardar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridClients.CurrentRow?.DataBoundItem is not DataRowView drv)
            {
                MessageBox.Show("Selecciona un cliente.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = drv.Row;
            int id = Convert.ToInt32(row["id"]);

            var c = await _repo.GetByIdAsync(id) ?? new Client
            {
                Id = id,
                Nombre = row["nombre"]?.ToString() ?? "",
                Nit = row["nit"]?.ToString() ?? "",
                Email = row["mail"]?.ToString() ?? "",
                Telefono = row["tel"]?.ToString() ?? "",
                Direccion = row["dir"]?.ToString() ?? ""
            };

            using var dlg = new AddEditClientForm();
            dlg.LoadFromClient(c);

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                var edit = dlg.BuildClient();
                try
                {
                    var ok = await _repo.UpdateAsync(edit);
                    MessageBox.Show(ok ? "Cambios guardados." : "No se pudo actualizar.",
                        ok ? "Éxito" : "Aviso",
                        MessageBoxButtons.OK, ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                    await RefreshDataAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar Cliente: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridClients.CurrentRow?.DataBoundItem is not DataRowView drv) return;
            int id = Convert.ToInt32(drv.Row["id"]);

            if (MessageBox.Show($"¿Eliminar el Cliente #{id}?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                var ok = await _repo.DeleteAsync(id);
                MessageBox.Show(ok ? "Cliente eliminado." : "No se pudo eliminar.",
                    ok ? "Éxito" : "Aviso",
                    MessageBoxButtons.OK, ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                await RefreshDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar Cliente: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
}
