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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.pnlActions = new System.Windows.Forms.Panel();
            this.lblAction = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnEditar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new MemoryClubForms.Botones_Personalizados.OurButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdAsistencia)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.grdAsistencia.AllowUserToResizeColumns = false;
            this.grdAsistencia.AllowUserToResizeRows = false;
            this.grdAsistencia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAsistencia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdAsistencia.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdAsistencia.BackgroundColor = System.Drawing.Color.White;
            this.grdAsistencia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdAsistencia.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdAsistencia.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAsistencia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            this.grdAsistencia.Location = new System.Drawing.Point(12, 281);
            this.grdAsistencia.Name = "grdAsistencia";
            this.grdAsistencia.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAsistencia.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdAsistencia.RowHeadersVisible = false;
            this.grdAsistencia.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(213)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy;
            this.grdAsistencia.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdAsistencia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAsistencia.Size = new System.Drawing.Size(894, 300);
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
            this.cbxNombresClientes.Location = new System.Drawing.Point(3, 33);
            this.cbxNombresClientes.Name = "cbxNombresClientes";
            this.cbxNombresClientes.Size = new System.Drawing.Size(121, 21);
            this.cbxNombresClientes.TabIndex = 6;
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
            this.dtmFecha.Location = new System.Drawing.Point(130, 33);
            this.dtmFecha.Name = "dtmFecha";
            this.dtmFecha.Size = new System.Drawing.Size(200, 20);
            this.dtmFecha.TabIndex = 12;
            // 
            // txtHora
            // 
            this.txtHora.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtHora.Location = new System.Drawing.Point(344, 80);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(52, 20);
            this.txtHora.TabIndex = 23;
            // 
            // txtObservciones
            // 
            this.txtObservciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservciones.Location = new System.Drawing.Point(484, 80);
            this.txtObservciones.Name = "txtObservciones";
            this.txtObservciones.Size = new System.Drawing.Size(291, 20);
            this.txtObservciones.TabIndex = 24;
            // 
            // cbxSucursal
            // 
            this.cbxSucursal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbxSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSucursal.FormattingEnabled = true;
            this.cbxSucursal.Location = new System.Drawing.Point(414, 80);
            this.cbxSucursal.Name = "cbxSucursal";
            this.cbxSucursal.Size = new System.Drawing.Size(50, 21);
            this.cbxSucursal.TabIndex = 25;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.pnlActions);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 275);
            this.panel1.TabIndex = 0;
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
            this.pnlActions.Controls.Add(this.label5);
            this.pnlActions.Controls.Add(this.cbxSucursal);
            this.pnlActions.Controls.Add(this.panel4);
            this.pnlActions.Controls.Add(this.label4);
            this.pnlActions.Controls.Add(this.label3);
            this.pnlActions.Controls.Add(this.txtObservciones);
            this.pnlActions.Controls.Add(this.txtHora);
            this.pnlActions.Location = new System.Drawing.Point(12, 165);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(894, 107);
            this.pnlActions.TabIndex = 2;
            // 
            // lblAction
            // 
            this.lblAction.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAction.AutoSize = true;
            this.lblAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAction.ForeColor = System.Drawing.Color.Navy;
            this.lblAction.Location = new System.Drawing.Point(409, 4);
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
            this.panel6.Location = new System.Drawing.Point(3, 46);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(335, 61);
            this.panel6.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Clientes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(180, 4);
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
            this.panel5.Location = new System.Drawing.Point(800, 0);
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
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(411, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 17);
            this.label5.TabIndex = 30;
            this.label5.Text = "Sucursal";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.btnInsertar);
            this.panel4.Controls.Add(this.btnEditar);
            this.panel4.Location = new System.Drawing.Point(578, 3);
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
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(532, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 17);
            this.label4.TabIndex = 29;
            this.label4.Text = "Observaciones";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(341, 51);
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
            ((System.ComponentModel.ISupportInitialize)(this.grdAsistencia)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlActions.ResumeLayout(false);
            this.pnlActions.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView grdAsistencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_asistencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn observaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn sucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_mod;
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
    }
}