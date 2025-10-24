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
    public partial class SalesViewerForm : Form
    {
        private readonly ISalesQueryRepository _repo;
        private readonly BindingSource _bsSales = new();
        private readonly BindingSource _bsDetails = new();
        private DataTable _tSales = new();
        private DataTable _tDetails = new();


        public SalesViewerForm(ISalesQueryRepository repo)
        {
            InitializeComponent();
            _repo = repo;

            btnSearch.Click += btnSearch_Click;
            gridSales.SelectionChanged += gridSales_SelectionChanged;
            //this.Load += SalesViewerForm_Load;
        }

        private async void SalesViewerForm_Load(object? sender, EventArgs e)
        {
            dtFrom.Value = DateTime.Today.AddDays(-30);
            dtTo.Value = DateTime.Today;

            var clientes = await _repo.GetClientsForFilterAsync();
            clientes.Insert(0, new InventoryApp.Domain.Client { Id = 0, Nombre = "(Todos)" });
            cmbClient.DisplayMember = "Nombre";
            cmbClient.ValueMember = "Id";
            cmbClient.DataSource = clientes;

            SetupGrids();
            await LoadSalesAsync();
        }


        private static DataTable BuildSalesSchema()
        {
            var t = new DataTable("sales");
            t.Columns.Add("id", typeof(int));
            t.Columns.Add("fecha", typeof(DateTime));
            t.Columns.Add("cliente", typeof(string));
            t.Columns.Add("total", typeof(decimal));
            return t;
        }
        private static DataTable BuildDetailsSchema()
        {
            var t = new DataTable("details");
            t.Columns.Add("producto", typeof(string));
            t.Columns.Add("cantidad", typeof(int));
            t.Columns.Add("precio", typeof(decimal));
            t.Columns.Add("subtotal", typeof(decimal));
            return t;
        }


        private bool _isBinding = false;

        private async Task LoadSalesAsync()
        {
            _isBinding = true;

            _tSales = BuildSalesSchema();
            var from = dtFrom.Value.Date;
            var to = dtTo.Value.Date.AddDays(1);

            int? clientId = null;
            if (cmbClient.SelectedItem is InventoryApp.Domain.Client c && c.Id != 0)
                clientId = c.Id;

            var data = await _repo.GetSalesAsync(from, to, clientId);

            foreach (var s in data)
            {
                var r = _tSales.NewRow();
                r["id"] = s.Id;
                r["fecha"] = s.Fecha;
                r["cliente"] = s.ClienteNombre;
                r["total"] = s.Total;
                _tSales.Rows.Add(r);
            }
            _tSales.AcceptChanges();

            _bsSales.DataSource = _tSales;
            gridSales.DataSource = _bsSales;

            var total = data.Sum(x => x.Total);
            if (lblTotalVentas != null) lblTotalVentas.Text = $"Total mostrado: {total:N2}";

            _isBinding = false;
            await LoadDetailsFromSelectionAsync();
        }

        private async void gridSales_SelectionChanged(object? s, EventArgs e)
        {
            if (_isBinding) return;
            await LoadDetailsFromSelectionAsync();
        }

        private async void btnSearch_Click(object? s, EventArgs e) => await LoadSalesAsync();



        private async Task LoadDetailsFromSelectionAsync()
        {
            _tDetails = BuildDetailsSchema();

            if (gridSales.CurrentRow?.DataBoundItem is DataRowView drv)
            {
                int saleId = Convert.ToInt32(drv.Row["id"]);
                var items = await _repo.GetSaleDetailsAsync(saleId);
                foreach (var d in items)
                {
                    var r = _tDetails.NewRow();
                    r["producto"] = d.ProductoNombre;
                    r["cantidad"] = d.Cantidad;
                    r["precio"] = d.Precio;
                    r["subtotal"] = d.Subtotal;
                    _tDetails.Rows.Add(r);
                }
                _tDetails.AcceptChanges();
            }

            _bsDetails.DataSource = _tDetails;
            gridDetails.DataSource = _bsDetails;
        }

        private void SetupGrids()
        {
            // Ventas
            gridSales.ReadOnly = true;
            gridSales.AllowUserToAddRows = false;
            gridSales.AllowUserToDeleteRows = false;
            gridSales.MultiSelect = false;
            gridSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridSales.AutoGenerateColumns = true;
            gridSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Detalle de Ventas
            gridDetails.ReadOnly = true;
            gridDetails.AllowUserToAddRows = false;
            gridDetails.AllowUserToDeleteRows = false;
            gridDetails.MultiSelect = false;
            gridDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridDetails.AutoGenerateColumns = true;
            gridDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            gridSales.DataBindingComplete += (s, e) =>
            {
                if (gridSales.Columns["id"] is DataGridViewColumn c0) { c0.HeaderText = "ID"; c0.Width = 70; }
                if (gridSales.Columns["fecha"] is DataGridViewColumn c1) c1.HeaderText = "Fecha";
                if (gridSales.Columns["cliente"] is DataGridViewColumn c2) c2.HeaderText = "Cliente";
                if (gridSales.Columns["total"] is DataGridViewColumn c3) { c3.HeaderText = "Total"; c3.DefaultCellStyle.Format = "N2"; }
            };
            gridDetails.DataBindingComplete += (s, e) =>
            {
                if (gridDetails.Columns["producto"] is DataGridViewColumn d0) d0.HeaderText = "Producto";
                if (gridDetails.Columns["cantidad"] is DataGridViewColumn d1) d1.HeaderText = "Cant.";
                if (gridDetails.Columns["precio"] is DataGridViewColumn d2) { d2.HeaderText = "Precio"; d2.DefaultCellStyle.Format = "N2"; }
                if (gridDetails.Columns["subtotal"] is DataGridViewColumn d3) { d3.HeaderText = "Subtotal"; d3.DefaultCellStyle.Format = "N2"; }
            };
        }



        private void btnSalesViewer_Click(object sender, EventArgs e)
        {
            var f = new SalesViewerForm(new SalesQueryRepository());
            f.ShowDialog(this);
        }





    }
}
