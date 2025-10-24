using InventoryApp.Domain;
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
    public partial class AddEditClientForm : Form
    {
        public int? ClientId { get; private set; }
        public AddEditClientForm()
        {
            InitializeComponent();
            this.Text = "Cliente";
        }
        public void LoadFromClient(Client c)
        {
            ClientId = c.Id;
            txtNombre.Text = c.Nombre;
            txtNit.Text = c.Nit;
            txtEmail.Text = c.Email;
            txtTelefono.Text = c.Telefono;
            txtDireccion.Text = c.Direccion;
            this.Text = $"Editar cliente #{c.Id}";
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre debe ser obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }
            var email = txtEmail.Text.Trim();
            if (email.Length > 0 && !IsValidEmail(email))
            {
                MessageBox.Show("Correo inválido.", "Valiadación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }
            if (txtTelefono.Text.Length > 0 && txtTelefono.Text.Length < 7)
            {
                MessageBox.Show("Teléfono demasiado corto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }
        }
        public Client BuildClient()
        {
            return new Client
            {
                Id = ClientId ?? 0,
                Nombre = txtNombre.Text.Trim(),
                Nit = txtNit.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
            };
        }
        private static bool IsValidEmail(string email)
        {
            try
            {
                var _ = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch { return false; }
        }


    }
}
