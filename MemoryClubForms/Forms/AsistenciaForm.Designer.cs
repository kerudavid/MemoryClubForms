namespace MemoryClubForms.Forms
{
    partial class AsistenciaForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNombreVista = new System.Windows.Forms.Label();
            this.btnClose = new MemoryClubForms.Botones_Personalizados.OurButton();
            this.grdAsistencia = new System.Windows.Forms.DataGridView();
            this.id_asistencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_mod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAsistencia)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblNombreVista);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 136);
            this.panel1.TabIndex = 0;
            // 
            // lblNombreVista
            // 
            this.lblNombreVista.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNombreVista.AutoSize = true;
            this.lblNombreVista.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreVista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNombreVista.Location = new System.Drawing.Point(411, 9);
            this.lblNombreVista.Name = "lblNombreVista";
            this.lblNombreVista.Size = new System.Drawing.Size(92, 22);
            this.lblNombreVista.TabIndex = 3;
            this.lblNombreVista.Text = "Asistencia";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Maroon;
            this.btnClose.BackgroundColor = System.Drawing.Color.Maroon;
            this.btnClose.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnClose.BorderRadius = 17;
            this.btnClose.BorderSize = 0;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(801, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 32);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Cerrar";
            this.btnClose.TextColor = System.Drawing.Color.White;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Clicked);
            // 
            // grdAsistencia
            // 
            this.grdAsistencia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAsistencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAsistencia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_asistencia,
            this.nombre_cliente,
            this.fecha,
            this.hora,
            this.observaciones,
            this.usuario,
            this.fecha_mod});
            this.grdAsistencia.Location = new System.Drawing.Point(12, 142);
            this.grdAsistencia.Name = "grdAsistencia";
            this.grdAsistencia.Size = new System.Drawing.Size(894, 407);
            this.grdAsistencia.TabIndex = 1;
            // 
            // id_asistencia
            // 
            this.id_asistencia.HeaderText = "ID Asistencia";
            this.id_asistencia.Name = "id_asistencia";
            // 
            // nombre_cliente
            // 
            this.nombre_cliente.HeaderText = "Nombre Cliente";
            this.nombre_cliente.Name = "nombre_cliente";
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            // 
            // hora
            // 
            this.hora.HeaderText = "Hora";
            this.hora.Name = "hora";
            // 
            // observaciones
            // 
            this.observaciones.HeaderText = "Observaciones";
            this.observaciones.Name = "observaciones";
            // 
            // usuario
            // 
            this.usuario.HeaderText = "Usuario";
            this.usuario.Name = "usuario";
            // 
            // fecha_mod
            // 
            this.fecha_mod.HeaderText = "Fecha Modificación";
            this.fecha_mod.Name = "fecha_mod";
            // 
            // AsistenciaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(918, 593);
            this.Controls.Add(this.grdAsistencia);
            this.Controls.Add(this.panel1);
            this.Name = "AsistenciaForm";
            this.Text = "AsistenciaForm";
            this.Load += new System.EventHandler(this.AsistenciaForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAsistencia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView grdAsistencia;
        private Botones_Personalizados.OurButton btnClose;
        private System.Windows.Forms.Label lblNombreVista;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_asistencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn observaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_mod;
    }
}