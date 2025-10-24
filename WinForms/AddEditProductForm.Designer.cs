namespace InventoryApp.WinForms
{
    partial class AddEditProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbName = new Label();
            lbPrice = new Label();
            lbStock = new Label();
            txtNombre = new TextBox();
            numPrecio = new NumericUpDown();
            numStock = new NumericUpDown();
            btnOk = new Button();
            btnCancel = new Button();
            lbProducts = new Label();
            ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            SuspendLayout();
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Location = new Point(46, 79);
            lbName.Name = "lbName";
            lbName.Size = new Size(64, 20);
            lbName.TabIndex = 0;
            lbName.Text = "Nombre";
            // 
            // lbPrice
            // 
            lbPrice.AutoSize = true;
            lbPrice.Location = new Point(46, 135);
            lbPrice.Name = "lbPrice";
            lbPrice.Size = new Size(50, 20);
            lbPrice.TabIndex = 1;
            lbPrice.Text = "Precio";
            // 
            // lbStock
            // 
            lbStock.AutoSize = true;
            lbStock.Location = new Point(46, 194);
            lbStock.Name = "lbStock";
            lbStock.Size = new Size(45, 20);
            lbStock.TabIndex = 2;
            lbStock.Text = "Stock";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(211, 77);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(230, 27);
            txtNombre.TabIndex = 3;
            // 
            // numPrecio
            // 
            numPrecio.DecimalPlaces = 2;
            numPrecio.Location = new Point(207, 137);
            numPrecio.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPrecio.Name = "numPrecio";
            numPrecio.Size = new Size(150, 27);
            numPrecio.TabIndex = 4;
            // 
            // numStock
            // 
            numStock.Location = new Point(207, 192);
            numStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numStock.Name = "numStock";
            numStock.Size = new Size(150, 27);
            numStock.TabIndex = 5;
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(214, 319);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(94, 29);
            btnOk.TabIndex = 6;
            btnOk.Text = "Aceptar";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(379, 319);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // lbProducts
            // 
            lbProducts.AutoSize = true;
            lbProducts.Font = new Font("Segoe UI", 18F);
            lbProducts.Location = new Point(46, 9);
            lbProducts.Name = "lbProducts";
            lbProducts.Size = new Size(153, 41);
            lbProducts.TabIndex = 8;
            lbProducts.Text = "Productos";
            // 
            // AddEditProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbProducts);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(numStock);
            Controls.Add(numPrecio);
            Controls.Add(txtNombre);
            Controls.Add(lbStock);
            Controls.Add(lbPrice);
            Controls.Add(lbName);
            Name = "AddEditProductForm";
            Text = "AddEditProductForm";
            ((System.ComponentModel.ISupportInitialize)numPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbName;
        private Label lbPrice;
        private Label lbStock;
        private TextBox txtNombre;
        private NumericUpDown numPrecio;
        private NumericUpDown numStock;
        private Button btnOk;
        private Button btnCancel;
        private Label lbProducts;
    }
}