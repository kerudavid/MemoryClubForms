namespace MemoryClubForms.Forms
{
    partial class TransporteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransporteForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.tbxCliente = new System.Windows.Forms.TextBox();
            this.lblAction = new System.Windows.Forms.Label();
            this.dtmFecha = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxTransportista = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbxEntradaSalida = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxNombresClientes = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtObservciones = new System.Windows.Forms.TextBox();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.btnElimMasivo = new System.Windows.Forms.Button();
            this.ckbFiltrarFechas = new System.Windows.Forms.CheckBox();
            this.rbtnOtros = new System.Windows.Forms.RadioButton();
            this.rbtnRecorrido = new System.Windows.Forms.RadioButton();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cbxFiltroTransportista = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbxFiltroEstadoCliente = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxFiltroHorarios = new System.Windows.Forms.ComboBox();
            this.cbxFiltroTipoCli = new System.Windows.Forms.ComboBox();
            this.cbxFiltroSucursal = new System.Windows.Forms.ComboBox();
            this.btnReiniciarFiltro = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtmHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.cbxFiltroNombreCliente = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNombreVista = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new MemoryClubForms.Botones_Personalizados.OurButton();
            this.grdTransporte = new System.Windows.Forms.DataGridView();
            this.Id_transporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fk_id_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_transportista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_Transportista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Entrada_salida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_mod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlFiltro.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransporte)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.pnlActions);
            this.panel1.Controls.Add(this.pnlFiltro);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 334);
            this.panel1.TabIndex = 2;
            // 
            // pnlActions
            // 
            this.pnlActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlActions.BackColor = System.Drawing.Color.White;
            this.pnlActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlActions.Controls.Add(this.label16);
            this.pnlActions.Controls.Add(this.tbxCliente);
            this.pnlActions.Controls.Add(this.lblAction);
            this.pnlActions.Controls.Add(this.dtmFecha);
            this.pnlActions.Controls.Add(this.label5);
            this.pnlActions.Controls.Add(this.panel6);
            this.pnlActions.Controls.Add(this.panel5);
            this.pnlActions.Controls.Add(this.panel4);
            this.pnlActions.Controls.Add(this.label10);
            this.pnlActions.Controls.Add(this.label11);
            this.pnlActions.Controls.Add(this.txtObservciones);
            this.pnlActions.Controls.Add(this.txtHora);
            this.pnlActions.Location = new System.Drawing.Point(10, 188);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(894, 143);
            this.pnlActions.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(16, 8);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 17);
            this.label16.TabIndex = 0;
            this.label16.Text = "Cliente:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxCliente
            // 
            this.tbxCliente.Enabled = false;
            this.tbxCliente.Location = new System.Drawing.Point(75, 6);
            this.tbxCliente.Name = "tbxCliente";
            this.tbxCliente.Size = new System.Drawing.Size(277, 20);
            this.tbxCliente.TabIndex = 1;
            this.tbxCliente.TextChanged += new System.EventHandler(this.tbxCliente_TextChanged);
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
            // dtmFecha
            // 
            this.dtmFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtmFecha.Enabled = false;
            this.dtmFecha.Location = new System.Drawing.Point(12, 113);
            this.dtmFecha.Name = "dtmFecha";
            this.dtmFecha.Size = new System.Drawing.Size(200, 20);
            this.dtmFecha.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Fecha Ingreso";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.cbxTransportista);
            this.panel6.Controls.Add(this.label12);
            this.panel6.Controls.Add(this.cbxEntradaSalida);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.cbxNombresClientes);
            this.panel6.Location = new System.Drawing.Point(6, 32);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(508, 58);
            this.panel6.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(232, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Transportista";
            // 
            // cbxTransportista
            // 
            this.cbxTransportista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTransportista.FormattingEnabled = true;
            this.cbxTransportista.Location = new System.Drawing.Point(235, 28);
            this.cbxTransportista.Name = "cbxTransportista";
            this.cbxTransportista.Size = new System.Drawing.Size(121, 21);
            this.cbxTransportista.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(372, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "Entrada/Salida";
            // 
            // cbxEntradaSalida
            // 
            this.cbxEntradaSalida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEntradaSalida.FormattingEnabled = true;
            this.cbxEntradaSalida.Location = new System.Drawing.Point(375, 28);
            this.cbxEntradaSalida.Name = "cbxEntradaSalida";
            this.cbxEntradaSalida.Size = new System.Drawing.Size(121, 21);
            this.cbxEntradaSalida.Sorted = true;
            this.cbxEntradaSalida.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Clientes";
            // 
            // cbxNombresClientes
            // 
            this.cbxNombresClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNombresClientes.FormattingEnabled = true;
            this.cbxNombresClientes.Location = new System.Drawing.Point(6, 28);
            this.cbxNombresClientes.Name = "cbxNombresClientes";
            this.cbxNombresClientes.Size = new System.Drawing.Size(213, 21);
            this.cbxNombresClientes.TabIndex = 0;
            this.cbxNombresClientes.SelectionChangeCommitted += new System.EventHandler(this.cbxNombresClientes_SelectionChangeCommitted);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.btnCancel);
            this.panel5.Controls.Add(this.btnEliminar);
            this.panel5.Controls.Add(this.btnGuardar);
            this.panel5.Location = new System.Drawing.Point(800, 7);
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
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.btnEliminar.TabIndex = 0;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
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
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.btnInsertar);
            this.panel4.Controls.Add(this.btnEditar);
            this.panel4.Location = new System.Drawing.Point(585, 7);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 34);
            this.panel4.TabIndex = 6;
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
            this.btnInsertar.TabIndex = 0;
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.UseVisualStyleBackColor = false;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
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
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(308, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Observaciones";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(237, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Hora";
            // 
            // txtObservciones
            // 
            this.txtObservciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtObservciones.Enabled = false;
            this.txtObservciones.Location = new System.Drawing.Point(311, 113);
            this.txtObservciones.Name = "txtObservciones";
            this.txtObservciones.Size = new System.Drawing.Size(423, 20);
            this.txtObservciones.TabIndex = 4;
            // 
            // txtHora
            // 
            this.txtHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtHora.Enabled = false;
            this.txtHora.Location = new System.Drawing.Point(234, 113);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(52, 20);
            this.txtHora.TabIndex = 3;
            // 
            // pnlFiltro
            // 
            this.pnlFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltro.Controls.Add(this.btnElimMasivo);
            this.pnlFiltro.Controls.Add(this.ckbFiltrarFechas);
            this.pnlFiltro.Controls.Add(this.rbtnOtros);
            this.pnlFiltro.Controls.Add(this.rbtnRecorrido);
            this.pnlFiltro.Controls.Add(this.rbtnTodos);
            this.pnlFiltro.Controls.Add(this.label15);
            this.pnlFiltro.Controls.Add(this.label14);
            this.pnlFiltro.Controls.Add(this.cbxFiltroTransportista);
            this.pnlFiltro.Controls.Add(this.label13);
            this.pnlFiltro.Controls.Add(this.cbxFiltroEstadoCliente);
            this.pnlFiltro.Controls.Add(this.label3);
            this.pnlFiltro.Controls.Add(this.label2);
            this.pnlFiltro.Controls.Add(this.label1);
            this.pnlFiltro.Controls.Add(this.cbxFiltroHorarios);
            this.pnlFiltro.Controls.Add(this.cbxFiltroTipoCli);
            this.pnlFiltro.Controls.Add(this.cbxFiltroSucursal);
            this.pnlFiltro.Controls.Add(this.btnReiniciarFiltro);
            this.pnlFiltro.Controls.Add(this.btnFiltrar);
            this.pnlFiltro.Controls.Add(this.label8);
            this.pnlFiltro.Controls.Add(this.label7);
            this.pnlFiltro.Controls.Add(this.label6);
            this.pnlFiltro.Controls.Add(this.dtmHasta);
            this.pnlFiltro.Controls.Add(this.dtpDesde);
            this.pnlFiltro.Controls.Add(this.cbxFiltroNombreCliente);
            this.pnlFiltro.Location = new System.Drawing.Point(10, 50);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(894, 139);
            this.pnlFiltro.TabIndex = 0;
            // 
            // btnElimMasivo
            // 
            this.btnElimMasivo.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnElimMasivo.Enabled = false;
            this.btnElimMasivo.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnElimMasivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnElimMasivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnElimMasivo.ForeColor = System.Drawing.Color.White;
            this.btnElimMasivo.Location = new System.Drawing.Point(804, 107);
            this.btnElimMasivo.Name = "btnElimMasivo";
            this.btnElimMasivo.Size = new System.Drawing.Size(75, 23);
            this.btnElimMasivo.TabIndex = 14;
            this.btnElimMasivo.Text = "Eliminar M.";
            this.btnElimMasivo.UseVisualStyleBackColor = false;
            this.btnElimMasivo.Visible = false;
            this.btnElimMasivo.Click += new System.EventHandler(this.btnElimMasivo_Click);
            // 
            // ckbFiltrarFechas
            // 
            this.ckbFiltrarFechas.AutoSize = true;
            this.ckbFiltrarFechas.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.ckbFiltrarFechas.Location = new System.Drawing.Point(16, 10);
            this.ckbFiltrarFechas.Name = "ckbFiltrarFechas";
            this.ckbFiltrarFechas.Size = new System.Drawing.Size(107, 17);
            this.ckbFiltrarFechas.TabIndex = 0;
            this.ckbFiltrarFechas.Text = "Filtrar con fechas";
            this.ckbFiltrarFechas.UseVisualStyleBackColor = true;
            this.ckbFiltrarFechas.CheckedChanged += new System.EventHandler(this.ckbFiltrarFechas_CheckedChanged);
            // 
            // rbtnOtros
            // 
            this.rbtnOtros.AutoSize = true;
            this.rbtnOtros.Location = new System.Drawing.Point(269, 49);
            this.rbtnOtros.Name = "rbtnOtros";
            this.rbtnOtros.Size = new System.Drawing.Size(50, 17);
            this.rbtnOtros.TabIndex = 5;
            this.rbtnOtros.TabStop = true;
            this.rbtnOtros.Text = "Otros";
            this.rbtnOtros.UseVisualStyleBackColor = true;
            // 
            // rbtnRecorrido
            // 
            this.rbtnRecorrido.AutoSize = true;
            this.rbtnRecorrido.Location = new System.Drawing.Point(188, 49);
            this.rbtnRecorrido.Name = "rbtnRecorrido";
            this.rbtnRecorrido.Size = new System.Drawing.Size(76, 17);
            this.rbtnRecorrido.TabIndex = 46;
            this.rbtnRecorrido.TabStop = true;
            this.rbtnRecorrido.Text = "Recorridos";
            this.rbtnRecorrido.UseVisualStyleBackColor = true;
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Location = new System.Drawing.Point(128, 49);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 4;
            this.rbtnTodos.TabStop = true;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(13, 49);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(113, 17);
            this.label15.TabIndex = 0;
            this.label15.Text = "Tipo transporte: ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(273, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 17);
            this.label14.TabIndex = 0;
            this.label14.Text = "Transportista";
            // 
            // cbxFiltroTransportista
            // 
            this.cbxFiltroTransportista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFiltroTransportista.FormattingEnabled = true;
            this.cbxFiltroTransportista.Location = new System.Drawing.Point(276, 109);
            this.cbxFiltroTransportista.Name = "cbxFiltroTransportista";
            this.cbxFiltroTransportista.Size = new System.Drawing.Size(121, 21);
            this.cbxFiltroTransportista.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(415, 91);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 17);
            this.label13.TabIndex = 0;
            this.label13.Text = "Estado Cliente";
            // 
            // cbxFiltroEstadoCliente
            // 
            this.cbxFiltroEstadoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFiltroEstadoCliente.FormattingEnabled = true;
            this.cbxFiltroEstadoCliente.Location = new System.Drawing.Point(418, 109);
            this.cbxFiltroEstadoCliente.Name = "cbxFiltroEstadoCliente";
            this.cbxFiltroEstadoCliente.Size = new System.Drawing.Size(121, 21);
            this.cbxFiltroEstadoCliente.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(192, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Sucursal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(394, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Entrada/Salida";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(558, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo cliente";
            // 
            // cbxFiltroHorarios
            // 
            this.cbxFiltroHorarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFiltroHorarios.Enabled = false;
            this.cbxFiltroHorarios.FormattingEnabled = true;
            this.cbxFiltroHorarios.Location = new System.Drawing.Point(397, 58);
            this.cbxFiltroHorarios.Name = "cbxFiltroHorarios";
            this.cbxFiltroHorarios.Size = new System.Drawing.Size(98, 21);
            this.cbxFiltroHorarios.TabIndex = 11;
            this.cbxFiltroHorarios.Visible = false;
            // 
            // cbxFiltroTipoCli
            // 
            this.cbxFiltroTipoCli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFiltroTipoCli.FormattingEnabled = true;
            this.cbxFiltroTipoCli.Location = new System.Drawing.Point(561, 109);
            this.cbxFiltroTipoCli.Name = "cbxFiltroTipoCli";
            this.cbxFiltroTipoCli.Size = new System.Drawing.Size(121, 21);
            this.cbxFiltroTipoCli.TabIndex = 6;
            // 
            // cbxFiltroSucursal
            // 
            this.cbxFiltroSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFiltroSucursal.FormattingEnabled = true;
            this.cbxFiltroSucursal.Location = new System.Drawing.Point(195, 109);
            this.cbxFiltroSucursal.Name = "cbxFiltroSucursal";
            this.cbxFiltroSucursal.Size = new System.Drawing.Size(60, 21);
            this.cbxFiltroSucursal.TabIndex = 8;
            // 
            // btnReiniciarFiltro
            // 
            this.btnReiniciarFiltro.BackColor = System.Drawing.Color.Maroon;
            this.btnReiniciarFiltro.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.btnReiniciarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReiniciarFiltro.ForeColor = System.Drawing.SystemColors.Info;
            this.btnReiniciarFiltro.Location = new System.Drawing.Point(816, 9);
            this.btnReiniciarFiltro.Name = "btnReiniciarFiltro";
            this.btnReiniciarFiltro.Size = new System.Drawing.Size(75, 23);
            this.btnReiniciarFiltro.TabIndex = 12;
            this.btnReiniciarFiltro.Text = "Reiniciar";
            this.btnReiniciarFiltro.UseVisualStyleBackColor = false;
            this.btnReiniciarFiltro.Click += new System.EventHandler(this.btnReiniciarFiltro_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.DarkBlue;
            this.btnFiltrar.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(816, 43);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 13;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(436, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Hasta:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(156, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Desde:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Clientes";
            // 
            // dtmHasta
            // 
            this.dtmHasta.Enabled = false;
            this.dtmHasta.Location = new System.Drawing.Point(497, 7);
            this.dtmHasta.Name = "dtmHasta";
            this.dtmHasta.Size = new System.Drawing.Size(200, 20);
            this.dtmHasta.TabIndex = 3;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Enabled = false;
            this.dtpDesde.Location = new System.Drawing.Point(215, 7);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde.TabIndex = 2;
            // 
            // cbxFiltroNombreCliente
            // 
            this.cbxFiltroNombreCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFiltroNombreCliente.FormattingEnabled = true;
            this.cbxFiltroNombreCliente.Location = new System.Drawing.Point(11, 109);
            this.cbxFiltroNombreCliente.Name = "cbxFiltroNombreCliente";
            this.cbxFiltroNombreCliente.Size = new System.Drawing.Size(164, 21);
            this.cbxFiltroNombreCliente.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblNombreVista);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 48);
            this.panel2.TabIndex = 0;
            // 
            // lblNombreVista
            // 
            this.lblNombreVista.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNombreVista.AutoSize = true;
            this.lblNombreVista.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreVista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNombreVista.Location = new System.Drawing.Point(89, 14);
            this.lblNombreVista.Name = "lblNombreVista";
            this.lblNombreVista.Size = new System.Drawing.Size(98, 22);
            this.lblNombreVista.TabIndex = 0;
            this.lblNombreVista.Text = "Transporte";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MemoryClubForms.Properties.Resources.Transporte2;
            this.pictureBox1.Location = new System.Drawing.Point(23, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
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
            this.btnClose.Location = new System.Drawing.Point(814, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 32);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Cerrar";
            this.btnClose.TextColor = System.Drawing.Color.White;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Clicked);
            // 
            // grdTransporte
            // 
            this.grdTransporte.AllowUserToAddRows = false;
            this.grdTransporte.AllowUserToDeleteRows = false;
            this.grdTransporte.AllowUserToResizeRows = false;
            this.grdTransporte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTransporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdTransporte.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdTransporte.BackgroundColor = System.Drawing.Color.White;
            this.grdTransporte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdTransporte.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdTransporte.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdTransporte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdTransporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTransporte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_transporte,
            this.Fk_id_cliente,
            this.nombre_cliente,
            this.Tipo_cliente,
            this.fecha,
            this.Hora,
            this.Id_transportista,
            this.nombre_Transportista,
            this.Entrada_salida,
            this.observaciones,
            this.sucursal,
            this.usuario,
            this.fecha_mod,
            this.Estado});
            this.grdTransporte.EnableHeadersVisualStyles = false;
            this.grdTransporte.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(213)))), ((int)(((byte)(232)))));
            this.grdTransporte.Location = new System.Drawing.Point(3, 340);
            this.grdTransporte.Name = "grdTransporte";
            this.grdTransporte.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdTransporte.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdTransporte.RowHeadersVisible = false;
            this.grdTransporte.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(213)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy;
            this.grdTransporte.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdTransporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTransporte.Size = new System.Drawing.Size(912, 250);
            this.grdTransporte.TabIndex = 3;
            this.grdTransporte.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Row_Clicked);
            // 
            // Id_transporte
            // 
            this.Id_transporte.HeaderText = "ID Transporte";
            this.Id_transporte.Name = "Id_transporte";
            this.Id_transporte.Visible = false;
            // 
            // Fk_id_cliente
            // 
            this.Fk_id_cliente.HeaderText = "Id Cliente";
            this.Fk_id_cliente.Name = "Fk_id_cliente";
            this.Fk_id_cliente.Visible = false;
            // 
            // nombre_cliente
            // 
            this.nombre_cliente.FillWeight = 82.08122F;
            this.nombre_cliente.HeaderText = "Nombre Cliente";
            this.nombre_cliente.Name = "nombre_cliente";
            // 
            // Tipo_cliente
            // 
            this.Tipo_cliente.FillWeight = 82.08122F;
            this.Tipo_cliente.HeaderText = "Tipo Cliente";
            this.Tipo_cliente.Name = "Tipo_cliente";
            // 
            // fecha
            // 
            this.fecha.FillWeight = 82.08122F;
            this.fecha.HeaderText = "Fecha (m/d/a)";
            this.fecha.Name = "fecha";
            // 
            // Hora
            // 
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            // 
            // Id_transportista
            // 
            this.Id_transportista.FillWeight = 82.08122F;
            this.Id_transportista.HeaderText = "TransportistaId";
            this.Id_transportista.Name = "Id_transportista";
            this.Id_transportista.Visible = false;
            // 
            // nombre_Transportista
            // 
            this.nombre_Transportista.FillWeight = 82.08122F;
            this.nombre_Transportista.HeaderText = "Nombre Trspta.";
            this.nombre_Transportista.Name = "nombre_Transportista";
            // 
            // Entrada_salida
            // 
            this.Entrada_salida.FillWeight = 82.08122F;
            this.Entrada_salida.HeaderText = "Entrada/Salida";
            this.Entrada_salida.Name = "Entrada_salida";
            // 
            // observaciones
            // 
            this.observaciones.FillWeight = 82.08122F;
            this.observaciones.HeaderText = "Observaciones";
            this.observaciones.Name = "observaciones";
            // 
            // sucursal
            // 
            this.sucursal.FillWeight = 82.08122F;
            this.sucursal.HeaderText = "Sucursal";
            this.sucursal.Name = "sucursal";
            // 
            // usuario
            // 
            this.usuario.FillWeight = 82.08122F;
            this.usuario.HeaderText = "Usuario";
            this.usuario.Name = "usuario";
            this.usuario.Visible = false;
            // 
            // fecha_mod
            // 
            this.fecha_mod.FillWeight = 82.08122F;
            this.fecha_mod.HeaderText = "Fecha Modificación";
            this.fecha_mod.Name = "fecha_mod";
            this.fecha_mod.Visible = false;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            // 
            // TransporteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(918, 593);
            this.Controls.Add(this.grdTransporte);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TransporteForm";
            this.Text = "TransporteForm";
            this.panel1.ResumeLayout(false);
            this.pnlActions.ResumeLayout(false);
            this.pnlActions.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnlFiltro.ResumeLayout(false);
            this.pnlFiltro.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransporte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.DateTimePicker dtmFecha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbxEntradaSalida;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxNombresClientes;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtObservciones;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.Panel pnlFiltro;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbxFiltroEstadoCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxFiltroHorarios;
        private System.Windows.Forms.ComboBox cbxFiltroTipoCli;
        private System.Windows.Forms.ComboBox cbxFiltroSucursal;
        private System.Windows.Forms.Button btnReiniciarFiltro;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtmHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.ComboBox cbxFiltroNombreCliente;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblNombreVista;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Botones_Personalizados.OurButton btnClose;
        private System.Windows.Forms.DataGridView grdTransporte;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbxFiltroTransportista;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxTransportista;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RadioButton rbtnOtros;
        private System.Windows.Forms.RadioButton rbtnRecorrido;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.CheckBox ckbFiltrarFechas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_transporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fk_id_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_transportista;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_Transportista;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entrada_salida;
        private System.Windows.Forms.DataGridViewTextBoxColumn observaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn sucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_mod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbxCliente;
        private System.Windows.Forms.Button btnElimMasivo;
    }
}