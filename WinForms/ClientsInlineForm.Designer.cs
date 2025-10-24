namespace InventoryApp.WinForms
{
    partial class ClientsInlineForm
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
            dataGridClients = new DataGridView();
            lbClientes = new Label();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridClients).BeginInit();
            SuspendLayout();
            // 
            // dataGridClients
            // 
            dataGridClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridClients.Location = new Point(1, 225);
            dataGridClients.Name = "dataGridClients";
            dataGridClients.RowHeadersWidth = 51;
            dataGridClients.Size = new Size(1302, 364);
            dataGridClients.TabIndex = 0;
            // 
            // lbClientes
            // 
            lbClientes.AutoSize = true;
            lbClientes.Font = new Font("Segoe UI", 27.75F);
            lbClientes.Location = new Point(22, 31);
            lbClientes.Name = "lbClientes";
            lbClientes.Size = new Size(191, 62);
            lbClientes.TabIndex = 1;
            lbClientes.Text = "Clientes";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(885, 164);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Agregar";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(1031, 164);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 29);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Editar";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(1171, 164);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Eliminar";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // ClientsInlineForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1303, 589);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(lbClientes);
            Controls.Add(dataGridClients);
            Name = "ClientsInlineForm";
            Text = "CustomerInlineForm";
            Load += ClientsInlineForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridClients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridClients;
        private Label lbClientes;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
    }
}