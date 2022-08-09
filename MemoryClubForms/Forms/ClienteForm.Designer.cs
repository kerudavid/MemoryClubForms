namespace MemoryClubForms.Forms
{
    partial class ClienteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClienteForm));
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.lblRegistroSeleccionado = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.ckbFiltrarFechas = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxAnio = new System.Windows.Forms.TextBox();
            this.tbxMes = new System.Windows.Forms.TextBox();
            this.tbxDia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtmFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxFiltroMedioPago = new System.Windows.Forms.ComboBox();
            this.cbxFiltroTransportista = new System.Windows.Forms.ComboBox();
            this.cbxFiltroSucursal = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbxFiltroEstadoCliente = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReiniciarFiltro = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnSalud = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAlimentos = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNombreVista = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grdCliente = new System.Windows.Forms.DataGridView();
            this.tbxFiltroCedula = new System.Windows.Forms.TextBox();
            this.tbxFiltroNombre = new System.Windows.Forms.TextBox();
            this.tbxFiltroApodo = new System.Windows.Forms.TextBox();
            this.btnClose = new MemoryClubForms.Botones_Personalizados.OurButton();
            this.id_Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_ingreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_free = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dia_nacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mes_nacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anio_nacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_contacto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parentesco_contacto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono_contacto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.celular_contacto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.encargado_pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parentesco_pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono_pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cedula_pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.celular_pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email_pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medio_pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frecuencia_pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pariente_transp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toma_transp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_transportista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_transp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retirarse_solo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_factu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cedula_factu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion_factu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email_factu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obseracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_mod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPrincipal.SuspendLayout();
            this.pnlFiltro.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.AutoScroll = true;
            this.pnlPrincipal.Controls.Add(this.lblRegistroSeleccionado);
            this.pnlPrincipal.Controls.Add(this.label12);
            this.pnlPrincipal.Controls.Add(this.pnlFiltro);
            this.pnlPrincipal.Controls.Add(this.panel1);
            this.pnlPrincipal.Controls.Add(this.btnClose);
            this.pnlPrincipal.Controls.Add(this.panel2);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 0);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(918, 271);
            this.pnlPrincipal.TabIndex = 0;
            // 
            // lblRegistroSeleccionado
            // 
            this.lblRegistroSeleccionado.AutoSize = true;
            this.lblRegistroSeleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistroSeleccionado.Location = new System.Drawing.Point(366, 65);
            this.lblRegistroSeleccionado.Name = "lblRegistroSeleccionado";
            this.lblRegistroSeleccionado.Size = new System.Drawing.Size(61, 17);
            this.lblRegistroSeleccionado.TabIndex = 61;
            this.lblRegistroSeleccionado.Text = "Ninguno";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label12.Location = new System.Drawing.Point(202, 65);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(158, 17);
            this.label12.TabIndex = 60;
            this.label12.Text = "Registro Seleccionado: ";
            // 
            // pnlFiltro
            // 
            this.pnlFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltro.AutoScroll = true;
            this.pnlFiltro.Controls.Add(this.tbxFiltroApodo);
            this.pnlFiltro.Controls.Add(this.tbxFiltroNombre);
            this.pnlFiltro.Controls.Add(this.tbxFiltroCedula);
            this.pnlFiltro.Controls.Add(this.ckbFiltrarFechas);
            this.pnlFiltro.Controls.Add(this.label11);
            this.pnlFiltro.Controls.Add(this.label10);
            this.pnlFiltro.Controls.Add(this.label9);
            this.pnlFiltro.Controls.Add(this.label5);
            this.pnlFiltro.Controls.Add(this.tbxAnio);
            this.pnlFiltro.Controls.Add(this.tbxMes);
            this.pnlFiltro.Controls.Add(this.tbxDia);
            this.pnlFiltro.Controls.Add(this.label4);
            this.pnlFiltro.Controls.Add(this.dtmFecha);
            this.pnlFiltro.Controls.Add(this.label2);
            this.pnlFiltro.Controls.Add(this.label1);
            this.pnlFiltro.Controls.Add(this.label8);
            this.pnlFiltro.Controls.Add(this.label7);
            this.pnlFiltro.Controls.Add(this.cbxFiltroMedioPago);
            this.pnlFiltro.Controls.Add(this.cbxFiltroTransportista);
            this.pnlFiltro.Controls.Add(this.cbxFiltroSucursal);
            this.pnlFiltro.Controls.Add(this.label13);
            this.pnlFiltro.Controls.Add(this.cbxFiltroEstadoCliente);
            this.pnlFiltro.Controls.Add(this.label3);
            this.pnlFiltro.Controls.Add(this.btnReiniciarFiltro);
            this.pnlFiltro.Controls.Add(this.btnFiltrar);
            this.pnlFiltro.Controls.Add(this.label6);
            this.pnlFiltro.Location = new System.Drawing.Point(0, 98);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(918, 173);
            this.pnlFiltro.TabIndex = 13;
            // 
            // ckbFiltrarFechas
            // 
            this.ckbFiltrarFechas.AutoSize = true;
            this.ckbFiltrarFechas.Location = new System.Drawing.Point(431, 72);
            this.ckbFiltrarFechas.Name = "ckbFiltrarFechas";
            this.ckbFiltrarFechas.Size = new System.Drawing.Size(107, 17);
            this.ckbFiltrarFechas.TabIndex = 59;
            this.ckbFiltrarFechas.Text = "Filtrar con fechas";
            this.ckbFiltrarFechas.UseVisualStyleBackColor = true;
            this.ckbFiltrarFechas.CheckedChanged += new System.EventHandler(this.ckbFiltrarFechas_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(374, 122);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 17);
            this.label11.TabIndex = 58;
            this.label11.Text = "Año";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(260, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 17);
            this.label10.TabIndex = 57;
            this.label10.Text = "Mes";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(145, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 17);
            this.label9.TabIndex = 56;
            this.label9.Text = "Día";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(260, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 17);
            this.label5.TabIndex = 55;
            this.label5.Text = "Fecha Nacimiento";
            // 
            // tbxAnio
            // 
            this.tbxAnio.Location = new System.Drawing.Point(376, 149);
            this.tbxAnio.Name = "tbxAnio";
            this.tbxAnio.Size = new System.Drawing.Size(80, 20);
            this.tbxAnio.TabIndex = 54;
            // 
            // tbxMes
            // 
            this.tbxMes.Location = new System.Drawing.Point(263, 149);
            this.tbxMes.Name = "tbxMes";
            this.tbxMes.Size = new System.Drawing.Size(80, 20);
            this.tbxMes.TabIndex = 53;
            // 
            // tbxDia
            // 
            this.tbxDia.Location = new System.Drawing.Point(148, 149);
            this.tbxDia.Name = "tbxDia";
            this.tbxDia.Size = new System.Drawing.Size(80, 20);
            this.tbxDia.TabIndex = 52;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(428, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 17);
            this.label4.TabIndex = 51;
            this.label4.Text = "Fecha Ingreso";
            // 
            // dtmFecha
            // 
            this.dtmFecha.Enabled = false;
            this.dtmFecha.Location = new System.Drawing.Point(431, 46);
            this.dtmFecha.Name = "dtmFecha";
            this.dtmFecha.Size = new System.Drawing.Size(200, 20);
            this.dtmFecha.TabIndex = 50;
            this.dtmFecha.Value = new System.DateTime(2022, 7, 21, 23, 10, 36, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(260, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 49;
            this.label2.Text = "Apodo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(121, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 47;
            this.label1.Text = "Nombre";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(507, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 17);
            this.label8.TabIndex = 45;
            this.label8.Text = "Transportista";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(655, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 17);
            this.label7.TabIndex = 44;
            this.label7.Text = "Medio Pago";
            // 
            // cbxFiltroMedioPago
            // 
            this.cbxFiltroMedioPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFiltroMedioPago.FormattingEnabled = true;
            this.cbxFiltroMedioPago.Location = new System.Drawing.Point(658, 149);
            this.cbxFiltroMedioPago.Name = "cbxFiltroMedioPago";
            this.cbxFiltroMedioPago.Size = new System.Drawing.Size(121, 21);
            this.cbxFiltroMedioPago.TabIndex = 43;
            // 
            // cbxFiltroTransportista
            // 
            this.cbxFiltroTransportista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFiltroTransportista.FormattingEnabled = true;
            this.cbxFiltroTransportista.Location = new System.Drawing.Point(510, 149);
            this.cbxFiltroTransportista.Name = "cbxFiltroTransportista";
            this.cbxFiltroTransportista.Size = new System.Drawing.Size(121, 21);
            this.cbxFiltroTransportista.TabIndex = 42;
            // 
            // cbxFiltroSucursal
            // 
            this.cbxFiltroSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFiltroSucursal.FormattingEnabled = true;
            this.cbxFiltroSucursal.Location = new System.Drawing.Point(5, 149);
            this.cbxFiltroSucursal.Name = "cbxFiltroSucursal";
            this.cbxFiltroSucursal.Size = new System.Drawing.Size(121, 21);
            this.cbxFiltroSucursal.TabIndex = 41;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(651, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 17);
            this.label13.TabIndex = 40;
            this.label13.Text = "Estado";
            // 
            // cbxFiltroEstadoCliente
            // 
            this.cbxFiltroEstadoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFiltroEstadoCliente.FormattingEnabled = true;
            this.cbxFiltroEstadoCliente.Location = new System.Drawing.Point(654, 45);
            this.cbxFiltroEstadoCliente.Name = "cbxFiltroEstadoCliente";
            this.cbxFiltroEstadoCliente.Size = new System.Drawing.Size(121, 21);
            this.cbxFiltroEstadoCliente.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 38;
            this.label3.Text = "Sucursal";
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
            this.btnReiniciarFiltro.TabIndex = 11;
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
            this.btnFiltrar.Location = new System.Drawing.Point(816, 46);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 11;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 17);
            this.label6.TabIndex = 28;
            this.label6.Text = "Cédula";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.btnInsertar);
            this.panel1.Controls.Add(this.btnSalud);
            this.panel1.Controls.Add(this.btnEditar);
            this.panel1.Controls.Add(this.btnAlimentos);
            this.panel1.Location = new System.Drawing.Point(205, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(612, 49);
            this.panel1.TabIndex = 12;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Navy;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(203, -1);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(89, 48);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnInsertar
            // 
            this.btnInsertar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnInsertar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertar.ForeColor = System.Drawing.Color.White;
            this.btnInsertar.Location = new System.Drawing.Point(0, -1);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(102, 48);
            this.btnInsertar.TabIndex = 8;
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.UseVisualStyleBackColor = false;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // btnSalud
            // 
            this.btnSalud.BackColor = System.Drawing.Color.DarkCyan;
            this.btnSalud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalud.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalud.ForeColor = System.Drawing.Color.White;
            this.btnSalud.Location = new System.Drawing.Point(471, -2);
            this.btnSalud.Name = "btnSalud";
            this.btnSalud.Size = new System.Drawing.Size(138, 48);
            this.btnSalud.TabIndex = 11;
            this.btnSalud.Text = "Salud";
            this.btnSalud.UseVisualStyleBackColor = false;
            this.btnSalud.Click += new System.EventHandler(this.btnSalud_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(108, -2);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(89, 48);
            this.btnEditar.TabIndex = 9;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAlimentos
            // 
            this.btnAlimentos.BackColor = System.Drawing.Color.DarkCyan;
            this.btnAlimentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlimentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlimentos.ForeColor = System.Drawing.Color.White;
            this.btnAlimentos.Location = new System.Drawing.Point(317, -1);
            this.btnAlimentos.Name = "btnAlimentos";
            this.btnAlimentos.Size = new System.Drawing.Size(138, 48);
            this.btnAlimentos.TabIndex = 10;
            this.btnAlimentos.Text = "Alimentos";
            this.btnAlimentos.UseVisualStyleBackColor = false;
            this.btnAlimentos.Click += new System.EventHandler(this.btnAlimentos_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblNombreVista);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(170, 48);
            this.panel2.TabIndex = 6;
            // 
            // lblNombreVista
            // 
            this.lblNombreVista.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNombreVista.AutoSize = true;
            this.lblNombreVista.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreVista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNombreVista.Location = new System.Drawing.Point(89, 14);
            this.lblNombreVista.Name = "lblNombreVista";
            this.lblNombreVista.Size = new System.Drawing.Size(66, 22);
            this.lblNombreVista.TabIndex = 3;
            this.lblNombreVista.Text = "Cliente";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MemoryClubForms.Properties.Resources.usuario;
            this.pictureBox1.Location = new System.Drawing.Point(23, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // grdCliente
            // 
            this.grdCliente.AllowUserToAddRows = false;
            this.grdCliente.AllowUserToDeleteRows = false;
            this.grdCliente.AllowUserToResizeColumns = false;
            this.grdCliente.AllowUserToResizeRows = false;
            this.grdCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdCliente.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdCliente.BackgroundColor = System.Drawing.Color.White;
            this.grdCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdCliente.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdCliente.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCliente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_Cliente,
            this.Cedula,
            this.Nombre,
            this.Apodo,
            this.fecha_ingreso,
            this.fecha_free,
            this.Sexo,
            this.Estado,
            this.Aula,
            this.Dia_nacimiento,
            this.mes_nacimiento,
            this.anio_nacimiento,
            this.telefono,
            this.nombre_contacto,
            this.parentesco_contacto,
            this.telefono_contacto,
            this.celular_contacto,
            this.encargado_pago,
            this.parentesco_pago,
            this.telefono_pago,
            this.cedula_pago,
            this.celular_pago,
            this.email_pago,
            this.medio_pago,
            this.frecuencia_pago,
            this.pariente_transp,
            this.direccion,
            this.toma_transp,
            this.id_transportista,
            this.nombre_transp,
            this.retirarse_solo,
            this.nombre_factu,
            this.cedula_factu,
            this.direccion_factu,
            this.email_factu,
            this.sucursal,
            this.obseracion,
            this.usuario,
            this.fecha_mod});
            this.grdCliente.EnableHeadersVisualStyles = false;
            this.grdCliente.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(213)))), ((int)(((byte)(232)))));
            this.grdCliente.Location = new System.Drawing.Point(0, 277);
            this.grdCliente.Name = "grdCliente";
            this.grdCliente.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCliente.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdCliente.RowHeadersVisible = false;
            this.grdCliente.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(213)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy;
            this.grdCliente.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCliente.Size = new System.Drawing.Size(918, 253);
            this.grdCliente.TabIndex = 6;
            this.grdCliente.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Row_Clicked);
            // 
            // tbxFiltroCedula
            // 
            this.tbxFiltroCedula.Location = new System.Drawing.Point(5, 46);
            this.tbxFiltroCedula.Name = "tbxFiltroCedula";
            this.tbxFiltroCedula.Size = new System.Drawing.Size(113, 20);
            this.tbxFiltroCedula.TabIndex = 60;
            // 
            // tbxFiltroNombre
            // 
            this.tbxFiltroNombre.Location = new System.Drawing.Point(124, 46);
            this.tbxFiltroNombre.Name = "tbxFiltroNombre";
            this.tbxFiltroNombre.Size = new System.Drawing.Size(121, 20);
            this.tbxFiltroNombre.TabIndex = 61;
            // 
            // tbxFiltroApodo
            // 
            this.tbxFiltroApodo.Location = new System.Drawing.Point(263, 46);
            this.tbxFiltroApodo.Name = "tbxFiltroApodo";
            this.tbxFiltroApodo.Size = new System.Drawing.Size(121, 20);
            this.tbxFiltroApodo.TabIndex = 62;
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
            this.btnClose.Location = new System.Drawing.Point(823, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 32);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Cerrar";
            this.btnClose.TextColor = System.Drawing.Color.White;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // id_Cliente
            // 
            this.id_Cliente.HeaderText = "Id Cliente";
            this.id_Cliente.Name = "id_Cliente";
            this.id_Cliente.Width = 80;
            // 
            // Cedula
            // 
            this.Cedula.HeaderText = "Cédula";
            this.Cedula.Name = "Cedula";
            this.Cedula.Width = 66;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 74;
            // 
            // Apodo
            // 
            this.Apodo.HeaderText = "Apodo";
            this.Apodo.Name = "Apodo";
            this.Apodo.Width = 66;
            // 
            // fecha_ingreso
            // 
            this.fecha_ingreso.HeaderText = "Fecha Ingreso";
            this.fecha_ingreso.Name = "fecha_ingreso";
            this.fecha_ingreso.Width = 104;
            // 
            // fecha_free
            // 
            this.fecha_free.HeaderText = "Fecha Free";
            this.fecha_free.Name = "fecha_free";
            this.fecha_free.Width = 86;
            // 
            // Sexo
            // 
            this.Sexo.HeaderText = "Sexo";
            this.Sexo.Name = "Sexo";
            this.Sexo.Width = 56;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Width = 65;
            // 
            // Aula
            // 
            this.Aula.HeaderText = "Aula";
            this.Aula.Name = "Aula";
            this.Aula.Width = 54;
            // 
            // Dia_nacimiento
            // 
            this.Dia_nacimiento.HeaderText = "Día Nacimiento";
            this.Dia_nacimiento.Name = "Dia_nacimiento";
            this.Dia_nacimiento.Width = 104;
            // 
            // mes_nacimiento
            // 
            this.mes_nacimiento.HeaderText = "Mes Nacimiento";
            this.mes_nacimiento.Name = "mes_nacimiento";
            this.mes_nacimiento.Width = 107;
            // 
            // anio_nacimiento
            // 
            this.anio_nacimiento.HeaderText = "Año Nacimiento";
            this.anio_nacimiento.Name = "anio_nacimiento";
            this.anio_nacimiento.Width = 107;
            // 
            // telefono
            // 
            this.telefono.HeaderText = "Teléfono";
            this.telefono.Name = "telefono";
            this.telefono.Width = 76;
            // 
            // nombre_contacto
            // 
            this.nombre_contacto.HeaderText = "Nombre Contacto";
            this.nombre_contacto.Name = "nombre_contacto";
            this.nombre_contacto.Width = 114;
            // 
            // parentesco_contacto
            // 
            this.parentesco_contacto.HeaderText = "Parentesco Contacto";
            this.parentesco_contacto.Name = "parentesco_contacto";
            this.parentesco_contacto.Width = 127;
            // 
            // telefono_contacto
            // 
            this.telefono_contacto.HeaderText = "Teléfono Contacto";
            this.telefono_contacto.Name = "telefono_contacto";
            this.telefono_contacto.Width = 116;
            // 
            // celular_contacto
            // 
            this.celular_contacto.HeaderText = "Celular Contacto";
            this.celular_contacto.Name = "celular_contacto";
            this.celular_contacto.Width = 107;
            // 
            // encargado_pago
            // 
            this.encargado_pago.HeaderText = "Encargado Pago";
            this.encargado_pago.Name = "encargado_pago";
            this.encargado_pago.Width = 106;
            // 
            // parentesco_pago
            // 
            this.parentesco_pago.HeaderText = "Parentesco Pago";
            this.parentesco_pago.Name = "parentesco_pago";
            this.parentesco_pago.Width = 108;
            // 
            // telefono_pago
            // 
            this.telefono_pago.HeaderText = "Teléfono Pago";
            this.telefono_pago.Name = "telefono_pago";
            this.telefono_pago.Width = 97;
            // 
            // cedula_pago
            // 
            this.cedula_pago.HeaderText = "Cédula Pago";
            this.cedula_pago.Name = "cedula_pago";
            this.cedula_pago.Width = 88;
            // 
            // celular_pago
            // 
            this.celular_pago.HeaderText = "Celular Pago";
            this.celular_pago.Name = "celular_pago";
            this.celular_pago.Width = 88;
            // 
            // email_pago
            // 
            this.email_pago.HeaderText = "Email Pago";
            this.email_pago.Name = "email_pago";
            this.email_pago.Width = 82;
            // 
            // medio_pago
            // 
            this.medio_pago.HeaderText = "Medio Pago";
            this.medio_pago.Name = "medio_pago";
            this.medio_pago.Width = 86;
            // 
            // frecuencia_pago
            // 
            this.frecuencia_pago.HeaderText = "Frecuencia de pago";
            this.frecuencia_pago.Name = "frecuencia_pago";
            this.frecuencia_pago.Width = 97;
            // 
            // pariente_transp
            // 
            this.pariente_transp.HeaderText = "Pariente Transporte";
            this.pariente_transp.Name = "pariente_transp";
            this.pariente_transp.Width = 121;
            // 
            // direccion
            // 
            this.direccion.HeaderText = "Dirección";
            this.direccion.Name = "direccion";
            this.direccion.Width = 81;
            // 
            // toma_transp
            // 
            this.toma_transp.HeaderText = "Toma Transporte";
            this.toma_transp.Name = "toma_transp";
            this.toma_transp.Width = 109;
            // 
            // id_transportista
            // 
            this.id_transportista.HeaderText = "Id Transportista";
            this.id_transportista.Name = "id_transportista";
            this.id_transportista.Width = 103;
            // 
            // nombre_transp
            // 
            this.nombre_transp.HeaderText = "Nombre Transp";
            this.nombre_transp.Name = "nombre_transp";
            this.nombre_transp.Width = 103;
            // 
            // retirarse_solo
            // 
            this.retirarse_solo.HeaderText = "Retirarse Solo";
            this.retirarse_solo.Name = "retirarse_solo";
            this.retirarse_solo.Width = 94;
            // 
            // nombre_factu
            // 
            this.nombre_factu.HeaderText = "Nombre Factura";
            this.nombre_factu.Name = "nombre_factu";
            this.nombre_factu.Width = 106;
            // 
            // cedula_factu
            // 
            this.cedula_factu.HeaderText = "Cédula Factura";
            this.cedula_factu.Name = "cedula_factu";
            this.cedula_factu.Width = 99;
            // 
            // direccion_factu
            // 
            this.direccion_factu.HeaderText = "Dirección Factura";
            this.direccion_factu.Name = "direccion_factu";
            this.direccion_factu.Width = 113;
            // 
            // email_factu
            // 
            this.email_factu.HeaderText = "Email Factura";
            this.email_factu.Name = "email_factu";
            this.email_factu.Width = 93;
            // 
            // sucursal
            // 
            this.sucursal.HeaderText = "Sucursal";
            this.sucursal.Name = "sucursal";
            this.sucursal.Width = 75;
            // 
            // obseracion
            // 
            this.obseracion.HeaderText = "Observación";
            this.obseracion.Name = "obseracion";
            this.obseracion.Width = 96;
            // 
            // usuario
            // 
            this.usuario.HeaderText = "Usuario";
            this.usuario.Name = "usuario";
            this.usuario.Width = 70;
            // 
            // fecha_mod
            // 
            this.fecha_mod.HeaderText = "Fecha Modificación";
            this.fecha_mod.Name = "fecha_mod";
            this.fecha_mod.Width = 122;
            // 
            // ClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(918, 593);
            this.Controls.Add(this.grdCliente);
            this.Controls.Add(this.pnlPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClienteForm";
            this.Text = "ClienteForm";
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.pnlFiltro.ResumeLayout(false);
            this.pnlFiltro.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCliente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblNombreVista;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Botones_Personalizados.OurButton btnClose;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnSalud;
        private System.Windows.Forms.Button btnAlimentos;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlFiltro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxFiltroMedioPago;
        private System.Windows.Forms.ComboBox cbxFiltroTransportista;
        private System.Windows.Forms.ComboBox cbxFiltroSucursal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbxFiltroEstadoCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReiniciarFiltro;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView grdCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtmFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxAnio;
        private System.Windows.Forms.TextBox tbxMes;
        private System.Windows.Forms.TextBox tbxDia;
        private System.Windows.Forms.CheckBox ckbFiltrarFechas;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblRegistroSeleccionado;
        private System.Windows.Forms.TextBox tbxFiltroCedula;
        private System.Windows.Forms.TextBox tbxFiltroApodo;
        private System.Windows.Forms.TextBox tbxFiltroNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_ingreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_free;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dia_nacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn mes_nacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn anio_nacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_contacto;
        private System.Windows.Forms.DataGridViewTextBoxColumn parentesco_contacto;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono_contacto;
        private System.Windows.Forms.DataGridViewTextBoxColumn celular_contacto;
        private System.Windows.Forms.DataGridViewTextBoxColumn encargado_pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn parentesco_pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono_pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn cedula_pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn celular_pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn email_pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn medio_pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn frecuencia_pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn pariente_transp;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn toma_transp;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_transportista;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_transp;
        private System.Windows.Forms.DataGridViewTextBoxColumn retirarse_solo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_factu;
        private System.Windows.Forms.DataGridViewTextBoxColumn cedula_factu;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion_factu;
        private System.Windows.Forms.DataGridViewTextBoxColumn email_factu;
        private System.Windows.Forms.DataGridViewTextBoxColumn sucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn obseracion;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_mod;
    }
}