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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdAsistencia = new System.Windows.Forms.DataGridView();
            this.id_asistencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_mod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNombreVista = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbxNombresClientes = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.dtmFecha = new System.Windows.Forms.DateTimePicker();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.txtObservciones = new System.Windows.Forms.TextBox();
            this.cbxSucursal = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.btnElimMasivo = new System.Windows.Forms.Button();
            this.cbxEstadoCliente = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnReiniciarFiltro = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ckbFiltrarFechas = new System.Windows.Forms.CheckBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtmHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.cbxFiltroNombreCliente = new System.Windows.Forms.ComboBox();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.lblAction = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnEditar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new MemoryClubForms.Botones_Personalizados.OurButton();
            this.label11 = new System.Windows.Forms.Label();
            this.tbxCliente = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdAsistencia)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlFiltro.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdAsistencia
            // 
            this.grdAsistencia.AllowUserToAddRows = false;
            this.grdAsistencia.AllowUserToDeleteRows = false;
            this.grdAsistencia.AllowUserToResizeRows = false;
            this.grdAsistencia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAsistencia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdAsistencia.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdAsistencia.BackgroundColor = System.Drawing.Color.White;
            this.grdAsistencia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdAsistencia.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdAsistencia.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAsistencia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdAsistencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAsistencia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_asistencia,
            this.id_cliente,
            this.nombre_cliente,
            this.fecha,
            this.hora,
            this.observaciones,
            this.sucursal,
            this.usuario,
            this.fecha_mod});
            this.grdAsistencia.EnableHeadersVisualStyles = false;
            this.grdAsistencia.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(213)))), ((int)(((byte)(232)))));
            this.grdAsistencia.Location = new System.Drawing.Point(3, 281);
            this.grdAsistencia.Name = "grdAsistencia";
            this.grdAsistencia.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAsistencia.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdAsistencia.RowHeadersVisible = false;
            this.grdAsistencia.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(213)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Navy;
            this.grdAsistencia.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdAsistencia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAsistencia.Size = new System.Drawing.Size(912, 313);
            this.grdAsistencia.TabIndex = 1;
            this.grdAsistencia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EnviarInfo_Clicked);
            // 
            // id_asistencia
            // 
            this.id_asistencia.HeaderText = "ID Asistencia";
            this.id_asistencia.Name = "id_asistencia";
            this.id_asistencia.Visible = false;
            // 
            // id_cliente
            // 
            this.id_cliente.HeaderText = "Id Cliente";
            this.id_cliente.Name = "id_cliente";
            this.id_cliente.Visible = false;
            // 
            // nombre_cliente
            // 
            this.nombre_cliente.HeaderText = "Nombre Cliente";
            this.nombre_cliente.Name = "nombre_cliente";
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha (m/d/a)";
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
            // sucursal
            // 
            this.sucursal.HeaderText = "Sucursal";
            this.sucursal.Name = "sucursal";
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
            // panel2
            // 
            this.panel2.Controls.Add(this.lblNombreVista);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(196, 41);
            this.panel2.TabIndex = 5;
            // 
            // lblNombreVista
            // 
            this.lblNombreVista.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNombreVista.AutoSize = true;
            this.lblNombreVista.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreVista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNombreVista.Location = new System.Drawing.Point(79, 9);
            this.lblNombreVista.Name = "lblNombreVista";
            this.lblNombreVista.Size = new System.Drawing.Size(92, 22);
            this.lblNombreVista.TabIndex = 3;
            this.lblNombreVista.Text = "Asistencia";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MemoryClubForms.Properties.Resources.Asistencia_1;
            this.pictureBox1.Location = new System.Drawing.Point(23, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // cbxNombresClientes
            // 
            this.cbxNombresClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNombresClientes.FormattingEnabled = true;
            this.cbxNombresClientes.Location = new System.Drawing.Point(3, 30);
            this.cbxNombresClientes.Name = "cbxNombresClientes";
            this.cbxNombresClientes.Size = new System.Drawing.Size(172, 21);
            this.cbxNombresClientes.TabIndex = 6;
            this.cbxNombresClientes.SelectionChangeCommitted += new System.EventHandler(this.cbxNombresClientes_SelectionChangeCommitted);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.DarkBlue;
            this.btnGuardar.Enabled = false;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(3, 79);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(171)))), ((int)(((byte)(142)))));
            this.btnEliminar.FlatAppearance.BorderSize = 2;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.Snow;
            this.btnEliminar.Location = new System.Drawing.Point(3, 6);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Clicked);
            // 
            // btnInsertar
            // 
            this.btnInsertar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btnInsertar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(171)))), ((int)(((byte)(142)))));
            this.btnInsertar.FlatAppearance.BorderSize = 2;
            this.btnInsertar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertar.ForeColor = System.Drawing.Color.White;
            this.btnInsertar.Location = new System.Drawing.Point(3, 3);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(75, 23);
            this.btnInsertar.TabIndex = 11;
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.UseVisualStyleBackColor = false;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // dtmFecha
            // 
            this.dtmFecha.Enabled = false;
            this.dtmFecha.Location = new System.Drawing.Point(191, 30);
            this.dtmFecha.Name = "dtmFecha";
            this.dtmFecha.Size = new System.Drawing.Size(200, 20);
            this.dtmFecha.TabIndex = 12;
            // 
            // txtHora
            // 
            this.txtHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtHora.Enabled = false;
            this.txtHora.Location = new System.Drawing.Point(423, 76);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(53, 20);
            this.txtHora.TabIndex = 23;
            // 
            // txtObservciones
            // 
            this.txtObservciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtObservciones.Enabled = false;
            this.txtObservciones.Location = new System.Drawing.Point(487, 76);
            this.txtObservciones.Name = "txtObservciones";
            this.txtObservciones.Size = new System.Drawing.Size(306, 20);
            this.txtObservciones.TabIndex = 24;
            // 
            // cbxSucursal
            // 
            this.cbxSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSucursal.FormattingEnabled = true;
            this.cbxSucursal.Location = new System.Drawing.Point(7, 85);
            this.cbxSucursal.Name = "cbxSucursal";
            this.cbxSucursal.Size = new System.Drawing.Size(61, 21);
            this.cbxSucursal.TabIndex = 25;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.pnlFiltro);
            this.panel1.Controls.Add(this.pnlActions);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 275);
            this.panel1.TabIndex = 0;
            // 
            // pnlFiltro
            // 
            this.pnlFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltro.Controls.Add(this.btnElimMasivo);
            this.pnlFiltro.Controls.Add(this.cbxEstadoCliente);
            this.pnlFiltro.Controls.Add(this.label9);
            this.pnlFiltro.Controls.Add(this.btnReiniciarFiltro);
            this.pnlFiltro.Controls.Add(this.label5);
            this.pnlFiltro.Controls.Add(this.ckbFiltrarFechas);
            this.pnlFiltro.Controls.Add(this.cbxSucursal);
            this.pnlFiltro.Controls.Add(this.btnFiltrar);
            this.pnlFiltro.Controls.Add(this.label8);
            this.pnlFiltro.Controls.Add(this.label7);
            this.pnlFiltro.Controls.Add(this.label6);
            this.pnlFiltro.Controls.Add(this.dtmHasta);
            this.pnlFiltro.Controls.Add(this.dtpDesde);
            this.pnlFiltro.Controls.Add(this.cbxFiltroNombreCliente);
            this.pnlFiltro.Location = new System.Drawing.Point(6, 45);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(905, 114);
            this.pnlFiltro.TabIndex = 6;
            // 
            // btnElimMasivo
            // 
            this.btnElimMasivo.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnElimMasivo.Enabled = false;
            this.btnElimMasivo.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnElimMasivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnElimMasivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnElimMasivo.ForeColor = System.Drawing.Color.White;
            this.btnElimMasivo.Location = new System.Drawing.Point(803, 88);
            this.btnElimMasivo.Name = "btnElimMasivo";
            this.btnElimMasivo.Size = new System.Drawing.Size(75, 23);
            this.btnElimMasivo.TabIndex = 35;
            this.btnElimMasivo.Text = "Eliminar M.";
            this.btnElimMasivo.UseVisualStyleBackColor = false;
            this.btnElimMasivo.Visible = false;
            this.btnElimMasivo.Click += new System.EventHandler(this.btnElimMasivo_Click);
            // 
            // cbxEstadoCliente
            // 
            this.cbxEstadoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEstadoCliente.FormattingEnabled = true;
            this.cbxEstadoCliente.Location = new System.Drawing.Point(172, 41);
            this.cbxEstadoCliente.Name = "cbxEstadoCliente";
            this.cbxEstadoCliente.Size = new System.Drawing.Size(121, 21);
            this.cbxEstadoCliente.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(169, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 17);
            this.label9.TabIndex = 33;
            this.label9.Text = "Estado Cliente";
            // 
            // btnReiniciarFiltro
            // 
            this.btnReiniciarFiltro.BackColor = System.Drawing.Color.Maroon;
            this.btnReiniciarFiltro.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.btnReiniciarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReiniciarFiltro.ForeColor = System.Drawing.SystemColors.Info;
            this.btnReiniciarFiltro.Location = new System.Drawing.Point(819, 10);
            this.btnReiniciarFiltro.Name = "btnReiniciarFiltro";
            this.btnReiniciarFiltro.Size = new System.Drawing.Size(75, 23);
            this.btnReiniciarFiltro.TabIndex = 11;
            this.btnReiniciarFiltro.Text = "Reiniciar";
            this.btnReiniciarFiltro.UseVisualStyleBackColor = false;
            this.btnReiniciarFiltro.Click += new System.EventHandler(this.btnReiniciarFiltro_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 17);
            this.label5.TabIndex = 30;
            this.label5.Text = "Sucursal";
            // 
            // ckbFiltrarFechas
            // 
            this.ckbFiltrarFechas.AutoSize = true;
            this.ckbFiltrarFechas.Location = new System.Drawing.Point(314, 68);
            this.ckbFiltrarFechas.Name = "ckbFiltrarFechas";
            this.ckbFiltrarFechas.Size = new System.Drawing.Size(107, 17);
            this.ckbFiltrarFechas.TabIndex = 32;
            this.ckbFiltrarFechas.Text = "Filtrar con fechas";
            this.ckbFiltrarFechas.UseVisualStyleBackColor = true;
            this.ckbFiltrarFechas.CheckedChanged += new System.EventHandler(this.cbkFechasChanged);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.DarkBlue;
            this.btnFiltrar.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(819, 41);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 11;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(520, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 17);
            this.label8.TabIndex = 31;
            this.label8.Text = "Hasta:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(312, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 17);
            this.label7.TabIndex = 30;
            this.label7.Text = "Desde:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(37, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 17);
            this.label6.TabIndex = 28;
            this.label6.Text = "Clientes";
            // 
            // dtmHasta
            // 
            this.dtmHasta.Enabled = false;
            this.dtmHasta.Location = new System.Drawing.Point(514, 41);
            this.dtmHasta.Name = "dtmHasta";
            this.dtmHasta.Size = new System.Drawing.Size(200, 20);
            this.dtmHasta.TabIndex = 29;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Enabled = false;
            this.dtpDesde.Location = new System.Drawing.Point(306, 41);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde.TabIndex = 28;
            // 
            // cbxFiltroNombreCliente
            // 
            this.cbxFiltroNombreCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFiltroNombreCliente.FormattingEnabled = true;
            this.cbxFiltroNombreCliente.Location = new System.Drawing.Point(7, 41);
            this.cbxFiltroNombreCliente.Name = "cbxFiltroNombreCliente";
            this.cbxFiltroNombreCliente.Size = new System.Drawing.Size(155, 21);
            this.cbxFiltroNombreCliente.TabIndex = 28;
            // 
            // pnlActions
            // 
            this.pnlActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlActions.BackColor = System.Drawing.Color.White;
            this.pnlActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlActions.Controls.Add(this.lblAction);
            this.pnlActions.Controls.Add(this.panel6);
            this.pnlActions.Controls.Add(this.panel5);
            this.pnlActions.Controls.Add(this.panel4);
            this.pnlActions.Controls.Add(this.label4);
            this.pnlActions.Controls.Add(this.label3);
            this.pnlActions.Controls.Add(this.txtObservciones);
            this.pnlActions.Controls.Add(this.txtHora);
            this.pnlActions.Location = new System.Drawing.Point(6, 165);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(905, 107);
            this.pnlActions.TabIndex = 2;
            // 
            // lblAction
            // 
            this.lblAction.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAction.AutoSize = true;
            this.lblAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAction.ForeColor = System.Drawing.Color.Navy;
            this.lblAction.Location = new System.Drawing.Point(414, 4);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(0, 25);
            this.lblAction.TabIndex = 32;
            this.lblAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.dtmFecha);
            this.panel6.Controls.Add(this.cbxNombresClientes);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Location = new System.Drawing.Point(10, 45);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(406, 61);
            this.panel6.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Clientes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(241, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "Fecha Ingreso";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.btnCancel);
            this.panel5.Controls.Add(this.btnEliminar);
            this.panel5.Controls.Add(this.btnGuardar);
            this.panel5.Location = new System.Drawing.Point(799, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(82, 107);
            this.panel5.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Maroon;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.Info;
            this.btnCancel.Location = new System.Drawing.Point(3, 44);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.btnInsertar);
            this.panel4.Controls.Add(this.btnEditar);
            this.panel4.Location = new System.Drawing.Point(564, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 34);
            this.panel4.TabIndex = 6;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(171)))), ((int)(((byte)(142)))));
            this.btnEditar.FlatAppearance.BorderSize = 2;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(122, 3);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 9;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEdit_Clicked);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(531, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 17);
            this.label4.TabIndex = 29;
            this.label4.Text = "Observaciones";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(422, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 28;
            this.label3.Text = "Hora";
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
            this.btnClose.Location = new System.Drawing.Point(814, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 32);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Cerrar";
            this.btnClose.TextColor = System.Drawing.Color.White;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Clicked);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(28, 177);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 17);
            this.label11.TabIndex = 56;
            this.label11.Text = "Cliente:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxCliente
            // 
            this.tbxCliente.Enabled = false;
            this.tbxCliente.Location = new System.Drawing.Point(87, 175);
            this.tbxCliente.Name = "tbxCliente";
            this.tbxCliente.Size = new System.Drawing.Size(277, 20);
            this.tbxCliente.TabIndex = 57;
            this.tbxCliente.TextChanged += new System.EventHandler(this.tbxCliente_TextChanged);
            // 
            // AsistenciaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(918, 593);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbxCliente);
            this.Controls.Add(this.grdAsistencia);
            this.Controls.Add(this.panel1);
            this.Name = "AsistenciaForm";
            this.Text = "AsistenciaForm";
            this.Load += new System.EventHandler(this.AsistenciaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdAsistencia)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlFiltro.ResumeLayout(false);
            this.pnlFiltro.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlActions.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView grdAsistencia;
        private Botones_Personalizados.OurButton btnClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblNombreVista;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbxNombresClientes;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.DateTimePicker dtmFecha;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.TextBox txtObservciones;
        private System.Windows.Forms.ComboBox cbxSucursal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Panel pnlFiltro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtmHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.ComboBox cbxFiltroNombreCliente;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.CheckBox ckbFiltrarFechas;
        private System.Windows.Forms.Button btnReiniciarFiltro;
        private System.Windows.Forms.ComboBox cbxEstadoCliente;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_asistencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn observaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn sucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_mod;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbxCliente;
        private System.Windows.Forms.Button btnElimMasivo;
    }
}