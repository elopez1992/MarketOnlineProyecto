namespace MarketOnline
{
    partial class VistaDeClientes
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtpFechaCreacion = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbPagos = new System.Windows.Forms.ComboBox();
            this.cmbDescuento = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rbInactivas = new System.Windows.Forms.RadioButton();
            this.rbActivas = new System.Windows.Forms.RadioButton();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.DGVDatos = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Controls.Add(this.dtpFechaCreacion);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.chkEstado);
            this.panel4.Location = new System.Drawing.Point(256, 143);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(409, 35);
            this.panel4.TabIndex = 97;
            // 
            // dtpFechaCreacion
            // 
            this.dtpFechaCreacion.Enabled = false;
            this.dtpFechaCreacion.Location = new System.Drawing.Point(177, 7);
            this.dtpFechaCreacion.Name = "dtpFechaCreacion";
            this.dtpFechaCreacion.Size = new System.Drawing.Size(219, 20);
            this.dtpFechaCreacion.TabIndex = 55;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(89, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 27);
            this.label9.TabIndex = 53;
            this.label9.Text = "F. Creacion";
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEstado.Location = new System.Drawing.Point(9, 3);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(73, 31);
            this.chkEstado.TabIndex = 54;
            this.chkEstado.Text = "Activo";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(642, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 27);
            this.label10.TabIndex = 96;
            this.label10.Text = "C. Pagos";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(611, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 27);
            this.label11.TabIndex = 95;
            this.label11.Text = "G. Descuento";
            // 
            // cmbPagos
            // 
            this.cmbPagos.FormattingEnabled = true;
            this.cmbPagos.Location = new System.Drawing.Point(715, 99);
            this.cmbPagos.Name = "cmbPagos";
            this.cmbPagos.Size = new System.Drawing.Size(138, 21);
            this.cmbPagos.TabIndex = 94;
            // 
            // cmbDescuento
            // 
            this.cmbDescuento.FormattingEnabled = true;
            this.cmbDescuento.Location = new System.Drawing.Point(715, 67);
            this.cmbDescuento.Name = "cmbDescuento";
            this.cmbDescuento.Size = new System.Drawing.Size(138, 21);
            this.cmbDescuento.TabIndex = 93;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(303, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 27);
            this.label12.TabIndex = 92;
            this.label12.Text = "Nombres";
            // 
            // txtNombres
            // 
            this.txtNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombres.Location = new System.Drawing.Point(382, 61);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(220, 26);
            this.txtNombres.TabIndex = 91;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Dubai", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label13.Location = new System.Drawing.Point(2, -1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(132, 54);
            this.label13.TabIndex = 90;
            this.label13.Text = "Clientes";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(304, 93);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 27);
            this.label14.TabIndex = 89;
            this.label14.Text = "Apellidos";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(31, 94);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 27);
            this.label15.TabIndex = 88;
            this.label15.Text = "Codigo";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(15, 61);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(73, 27);
            this.label16.TabIndex = 87;
            this.label16.Text = "Cliente Id";
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.Location = new System.Drawing.Point(382, 94);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(220, 26);
            this.txtApellido.TabIndex = 86;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(94, 94);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(173, 26);
            this.txtCodigo.TabIndex = 85;
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(94, 62);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(173, 26);
            this.txtID.TabIndex = 84;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel5.Controls.Add(this.rbInactivas);
            this.panel5.Controls.Add(this.rbActivas);
            this.panel5.Controls.Add(this.rbTodos);
            this.panel5.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(12, 225);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(259, 45);
            this.panel5.TabIndex = 83;
            // 
            // rbInactivas
            // 
            this.rbInactivas.AutoSize = true;
            this.rbInactivas.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rbInactivas.Location = new System.Drawing.Point(167, 7);
            this.rbInactivas.Name = "rbInactivas";
            this.rbInactivas.Size = new System.Drawing.Size(87, 31);
            this.rbInactivas.TabIndex = 15;
            this.rbInactivas.Text = "Inactivas";
            this.rbInactivas.UseVisualStyleBackColor = false;
            this.rbInactivas.CheckedChanged += new System.EventHandler(this.rbInactivas_CheckedChanged);
            // 
            // rbActivas
            // 
            this.rbActivas.AutoSize = true;
            this.rbActivas.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rbActivas.Location = new System.Drawing.Point(83, 7);
            this.rbActivas.Name = "rbActivas";
            this.rbActivas.Size = new System.Drawing.Size(78, 31);
            this.rbActivas.TabIndex = 14;
            this.rbActivas.Text = "Activas";
            this.rbActivas.UseVisualStyleBackColor = false;
            this.rbActivas.CheckedChanged += new System.EventHandler(this.rbActivas_CheckedChanged);
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Location = new System.Drawing.Point(8, 7);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(69, 31);
            this.rbTodos.TabIndex = 13;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todas";
            this.rbTodos.UseVisualStyleBackColor = true;
            this.rbTodos.CheckedChanged += new System.EventHandler(this.rbTodos_CheckedChanged);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel6.Controls.Add(this.btnEliminar);
            this.panel6.Controls.Add(this.btnGuardar);
            this.panel6.Location = new System.Drawing.Point(663, 216);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(190, 54);
            this.panel6.TabIndex = 82;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.OrangeRed;
            this.btnEliminar.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(5, 9);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(88, 38);
            this.btnEliminar.TabIndex = 14;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Chartreuse;
            this.btnGuardar.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(99, 9);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(88, 38);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // DGVDatos
            // 
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            this.DGVDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.DGVDatos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.DGVDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVDatos.DefaultCellStyle = dataGridViewCellStyle15;
            this.DGVDatos.Location = new System.Drawing.Point(12, 276);
            this.DGVDatos.Name = "DGVDatos";
            this.DGVDatos.Size = new System.Drawing.Size(841, 204);
            this.DGVDatos.TabIndex = 81;
            this.DGVDatos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVDatos_CellDoubleClick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // VistaDeClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(865, 492);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbPagos);
            this.Controls.Add(this.cmbDescuento);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.DGVDatos);
            this.Name = "VistaDeClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VistaDeClientes";
            this.Load += new System.EventHandler(this.VistaDeClientes_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker dtpFechaCreacion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbPagos;
        private System.Windows.Forms.ComboBox cmbDescuento;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton rbInactivas;
        private System.Windows.Forms.RadioButton rbActivas;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView DGVDatos;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}