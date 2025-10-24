using InventoryApp.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryApp.WinForms
{
    public partial class AddEditProductForm : Form
    {
        public int? ProductId { get; private set; }
        public AddEditProductForm()
        {
            InitializeComponent();

            numPrecio.Minimum = 0; numPrecio.DecimalPlaces = 2;
            numStock.Minimum = 0;
        }
        public void LoadFromProduct(Product p)
        {
            ProductId = p.Id;
            txtNombre.Text = p.Nombre;
            numPrecio.Value = p.Precio < 0 ? 0 : p.Precio;
            numStock.Value = p.Stock < 0 ? 0 : p.Stock;
            this.Text = $"Editar producto # {p.Id}";
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Es obligatorio colocar nombre", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }
            if (numPrecio.Value < 0 || numStock.Value < 0)
            {
                MessageBox.Show("El Precio y el Stock deben ser mayores a cero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }
        }
        public Product BuildProduct()
        {
            return new Product
            {
                Id = ProductId ?? 0,
                Nombre = txtNombre.Text.Trim(),
                Precio = numPrecio.Value,
                Stock = (int)numStock.Value
            };
        }

    }
}
