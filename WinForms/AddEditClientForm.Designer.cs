namespace InventoryApp.WinForms
{
    partial class AddEditClientForm
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
            lbClients = new Label();
            txtNombre = new TextBox();
            txtNit = new TextBox();
            txtEmail = new TextBox();
            txtTelefono = new TextBox();
            txtDireccion = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            lbNombre = new Label();
            lbNit = new Label();
            lbEmail = new Label();
            lbTelefono = new Label();
            lbDireccion = new Label();
            SuspendLayout();
            // 
            // lbClients
            // 
            lbClients.AutoSize = true;
            lbClients.Font = new Font("Segoe UI", 18F);
            lbClients.Location = new Point(50, 22);
            lbClients.Name = "lbClients";
            lbClients.Size = new Size(123, 41);
            lbClients.TabIndex = 0;
            lbClients.Text = "Clientes";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(198, 98);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(277, 27);
            txtNombre.TabIndex = 1;
            // 
            // txtNit
            // 
            txtNit.Location = new Point(198, 143);
            txtNit.Name = "txtNit";
            txtNit.Size = new Size(175, 27);
            txtNit.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(198, 194);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(277, 27);
            txtEmail.TabIndex = 3;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(198, 245);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(175, 27);
            txtTelefono.TabIndex = 4;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(198, 304);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(277, 27);
            txtDireccion.TabIndex = 5;
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(198, 384);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(94, 29);
            btnOK.TabIndex = 6;
            btnOK.Text = "Aceptar";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(488, 384);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // lbNombre
            // 
            lbNombre.AutoSize = true;
            lbNombre.Location = new Point(50, 105);
            lbNombre.Name = "lbNombre";
            lbNombre.Size = new Size(64, 20);
            lbNombre.TabIndex = 8;
            lbNombre.Text = "Nombre";
            // 
            // lbNit
            // 
            lbNit.AutoSize = true;
            lbNit.Location = new Point(50, 150);
            lbNit.Name = "lbNit";
            lbNit.Size = new Size(29, 20);
            lbNit.TabIndex = 9;
            lbNit.Text = "Nit";
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.Location = new Point(50, 201);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(46, 20);
            lbEmail.TabIndex = 10;
            lbEmail.Text = "Email";
            // 
            // lbTelefono
            // 
            lbTelefono.AutoSize = true;
            lbTelefono.Location = new Point(50, 252);
            lbTelefono.Name = "lbTelefono";
            lbTelefono.Size = new Size(67, 20);
            lbTelefono.TabIndex = 11;
            lbTelefono.Text = "Teléfono";
            // 
            // lbDireccion
            // 
            lbDireccion.AutoSize = true;
            lbDireccion.Location = new Point(50, 311);
            lbDireccion.Name = "lbDireccion";
            lbDireccion.Size = new Size(72, 20);
            lbDireccion.TabIndex = 12;
            lbDireccion.Text = "Dirección";
            // 
            // AddEditClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbDireccion);
            Controls.Add(lbTelefono);
            Controls.Add(lbEmail);
            Controls.Add(lbNit);
            Controls.Add(lbNombre);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(txtDireccion);
            Controls.Add(txtTelefono);
            Controls.Add(txtEmail);
            Controls.Add(txtNit);
            Controls.Add(txtNombre);
            Controls.Add(lbClients);
            Name = "AddEditClientForm";
            Text = "AddEditClientForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbClients;
        private TextBox txtNombre;
        private TextBox txtNit;
        private TextBox txtEmail;
        private TextBox txtTelefono;
        private TextBox txtDireccion;
        private Button btnOK;
        private Button btnCancel;
        private Label lbNombre;
        private Label lbNit;
        private Label lbEmail;
        private Label lbTelefono;
        private Label lbDireccion;
    }
}