namespace InventoryApp.WinForms
{
    partial class SalesViewerForm
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
            dtFrom = new DateTimePicker();
            dtTo = new DateTimePicker();
            cmbClient = new ComboBox();
            btnSearch = new Button();
            gridSales = new DataGridView();
            gridDetails = new DataGridView();
            lbFrom = new Label();
            lbTo = new Label();
            lbClient = new Label();
            lblTotalVentas = new Label();
            lbSales = new Label();
            lbDetails = new Label();
            lbSalesTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)gridSales).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridDetails).BeginInit();
            SuspendLayout();
            // 
            // dtFrom
            // 
            dtFrom.Format = DateTimePickerFormat.Short;
            dtFrom.Location = new Point(32, 137);
            dtFrom.Name = "dtFrom";
            dtFrom.Size = new Size(162, 27);
            dtFrom.TabIndex = 0;
            // 
            // dtTo
            // 
            dtTo.Format = DateTimePickerFormat.Short;
            dtTo.Location = new Point(32, 208);
            dtTo.Name = "dtTo";
            dtTo.Size = new Size(162, 27);
            dtTo.TabIndex = 1;
            // 
            // cmbClient
            // 
            cmbClient.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClient.FormattingEnabled = true;
            cmbClient.Location = new Point(32, 307);
            cmbClient.Name = "cmbClient";
            cmbClient.Size = new Size(250, 28);
            cmbClient.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(34, 465);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Buscar";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // gridSales
            // 
            gridSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridSales.Location = new Point(417, 77);
            gridSales.Name = "gridSales";
            gridSales.RowHeadersWidth = 51;
            gridSales.Size = new Size(869, 207);
            gridSales.TabIndex = 4;
            // 
            // gridDetails
            // 
            gridDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridDetails.Location = new Point(417, 349);
            gridDetails.Name = "gridDetails";
            gridDetails.RowHeadersWidth = 51;
            gridDetails.Size = new Size(869, 234);
            gridDetails.TabIndex = 5;
            // 
            // lbFrom
            // 
            lbFrom.AutoSize = true;
            lbFrom.Location = new Point(32, 104);
            lbFrom.Name = "lbFrom";
            lbFrom.Size = new Size(31, 20);
            lbFrom.TabIndex = 6;
            lbFrom.Text = "De:";
            // 
            // lbTo
            // 
            lbTo.AutoSize = true;
            lbTo.Location = new Point(32, 176);
            lbTo.Name = "lbTo";
            lbTo.Size = new Size(50, 20);
            lbTo.TabIndex = 7;
            lbTo.Text = "Hasta:";
            // 
            // lbClient
            // 
            lbClient.AutoSize = true;
            lbClient.Location = new Point(32, 274);
            lbClient.Name = "lbClient";
            lbClient.Size = new Size(55, 20);
            lbClient.TabIndex = 8;
            lbClient.Text = "Cliente";
            // 
            // lblTotalVentas
            // 
            lblTotalVentas.AutoSize = true;
            lblTotalVentas.Font = new Font("Segoe UI", 16F);
            lblTotalVentas.Location = new Point(966, 9);
            lblTotalVentas.Name = "lblTotalVentas";
            lblTotalVentas.Size = new Size(90, 37);
            lblTotalVentas.TabIndex = 9;
            lblTotalVentas.Text = "label4";
            // 
            // lbSales
            // 
            lbSales.AutoSize = true;
            lbSales.Location = new Point(417, 43);
            lbSales.Name = "lbSales";
            lbSales.Size = new Size(52, 20);
            lbSales.TabIndex = 10;
            lbSales.Text = "Ventas";
            // 
            // lbDetails
            // 
            lbDetails.AutoSize = true;
            lbDetails.Location = new Point(417, 315);
            lbDetails.Name = "lbDetails";
            lbDetails.Size = new Size(125, 20);
            lbDetails.TabIndex = 11;
            lbDetails.Text = "Detalle de Ventas";
            // 
            // lbSalesTitle
            // 
            lbSalesTitle.AutoSize = true;
            lbSalesTitle.Font = new Font("Segoe UI", 18F);
            lbSalesTitle.Location = new Point(34, 9);
            lbSalesTitle.Name = "lbSalesTitle";
            lbSalesTitle.Size = new Size(248, 41);
            lbSalesTitle.TabIndex = 12;
            lbSalesTitle.Text = "Detalle de Ventas";
            // 
            // SalesViewerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1298, 595);
            Controls.Add(lbSalesTitle);
            Controls.Add(lbDetails);
            Controls.Add(lbSales);
            Controls.Add(lblTotalVentas);
            Controls.Add(lbClient);
            Controls.Add(lbTo);
            Controls.Add(lbFrom);
            Controls.Add(gridDetails);
            Controls.Add(gridSales);
            Controls.Add(btnSearch);
            Controls.Add(cmbClient);
            Controls.Add(dtTo);
            Controls.Add(dtFrom);
            Name = "SalesViewerForm";
            Text = "SalesViewerForm";
            Load += SalesViewerForm_Load;
            ((System.ComponentModel.ISupportInitialize)gridSales).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridDetails).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtFrom;
        private DateTimePicker dtTo;
        private ComboBox cmbClient;
        private Button btnSearch;
        private DataGridView gridSales;
        private DataGridView gridDetails;
        private Label lbFrom;
        private Label lbTo;
        private Label lbClient;
        private Label lblTotalVentas;
        private Label lbSales;
        private Label lbDetails;
        private Label lbSalesTitle;
    }
}