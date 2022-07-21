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
            this.btnClose = new MemoryClubForms.Botones_Personalizados.OurButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNombreVista = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFiltros = new System.Windows.Forms.Button();
            this.btnActions = new System.Windows.Forms.Button();
            this.btnAlimentos = new System.Windows.Forms.Button();
            this.btnSalud = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxFiltroRuta = new System.Windows.Forms.ComboBox();
            this.cbxFiltroSector = new System.Windows.Forms.ComboBox();
            this.cbxFiltroSucursal = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbxFiltroEstadoCliente = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReiniciarFiltro = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxFiltroNombreTransp = new System.Windows.Forms.ComboBox();
            this.grdCliente = new System.Windows.Forms.DataGridView();
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
            this.pariente_transp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toma_transp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_transportista = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.AutoScroll = true;
            this.pnlPrincipal.Controls.Add(this.pnlFiltro);
            this.pnlPrincipal.Controls.Add(this.panel1);
            this.pnlPrincipal.Controls.Add(this.btnClose);
            this.pnlPrincipal.Controls.Add(this.panel2);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 0);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(918, 248);
            this.pnlPrincipal.TabIndex = 0;
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
            // btnFiltros
            // 
            this.btnFiltros.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltros.ForeColor = System.Drawing.Color.White;
            this.btnFiltros.Location = new System.Drawing.Point(0, -1);
            this.btnFiltros.Name = "btnFiltros";
            this.btnFiltros.Size = new System.Drawing.Size(138, 48);
            this.btnFiltros.TabIndex = 8;
            this.btnFiltros.Text = "Filtrar";
            this.btnFiltros.UseVisualStyleBackColor = false;
            // 
            // btnActions
            // 
            this.btnActions.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnActions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActions.ForeColor = System.Drawing.Color.White;
            this.btnActions.Location = new System.Drawing.Point(144, 0);
            this.btnActions.Name = "btnActions";
            this.btnActions.Size = new System.Drawing.Size(138, 48);
            this.btnActions.TabIndex = 9;
            this.btnActions.Text = "Insertar/Editar/Eliminar";
            this.btnActions.UseVisualStyleBackColor = false;
            // 
            // btnAlimentos
            // 
            this.btnAlimentos.BackColor = System.Drawing.Color.DarkCyan;
            this.btnAlimentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlimentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlimentos.ForeColor = System.Drawing.Color.White;
            this.btnAlimentos.Location = new System.Drawing.Point(288, -1);
            this.btnAlimentos.Name = "btnAlimentos";
            this.btnAlimentos.Size = new System.Drawing.Size(138, 48);
            this.btnAlimentos.TabIndex = 10;
            this.btnAlimentos.Text = "Alimentos";
            this.btnAlimentos.UseVisualStyleBackColor = false;
            // 
            // btnSalud
            // 
            this.btnSalud.BackColor = System.Drawing.Color.DarkCyan;
            this.btnSalud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalud.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalud.ForeColor = System.Drawing.Color.White;
            this.btnSalud.Location = new System.Drawing.Point(432, -1);
            this.btnSalud.Name = "btnSalud";
            this.btnSalud.Size = new System.Drawing.Size(138, 48);
            this.btnSalud.TabIndex = 11;
            this.btnSalud.Text = "Salud";
            this.btnSalud.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnFiltros);
            this.panel1.Controls.Add(this.btnSalud);
            this.panel1.Controls.Add(this.btnActions);
            this.panel1.Controls.Add(this.btnAlimentos);
            this.panel1.Location = new System.Drawing.Point(205, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(574, 49);
            this.panel1.TabIndex = 12;
            // 
            // pnlFiltro
            // 
            this.pnlFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltro.AutoScroll = true;
            this.pnlFiltro.Controls.Add(this.label8);
            this.pnlFiltro.Controls.Add(this.label7);
            this.pnlFiltro.Controls.Add(this.cbxFiltroRuta);
            this.pnlFiltro.Controls.Add(this.cbxFiltroSector);
            this.pnlFiltro.Controls.Add(this.cbxFiltroSucursal);
            this.pnlFiltro.Controls.Add(this.label13);
            this.pnlFiltro.Controls.Add(this.cbxFiltroEstadoCliente);
            this.pnlFiltro.Controls.Add(this.label3);
            this.pnlFiltro.Controls.Add(this.btnReiniciarFiltro);
            this.pnlFiltro.Controls.Add(this.btnFiltrar);
            this.pnlFiltro.Controls.Add(this.label6);
            this.pnlFiltro.Controls.Add(this.cbxFiltroNombreTransp);
            this.pnlFiltro.Location = new System.Drawing.Point(0, 58);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(918, 190);
            this.pnlFiltro.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(180, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 17);
            this.label8.TabIndex = 45;
            this.label8.Text = "Sector";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(338, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 17);
            this.label7.TabIndex = 44;
            this.label7.Text = "Ruta";
            // 
            // cbxFiltroRuta
            // 
            this.cbxFiltroRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFiltroRuta.FormattingEnabled = true;
            this.cbxFiltroRuta.Location = new System.Drawing.Point(341, 46);
            this.cbxFiltroRuta.Name = "cbxFiltroRuta";
            this.cbxFiltroRuta.Size = new System.Drawing.Size(121, 21);
            this.cbxFiltroRuta.TabIndex = 43;
            // 
            // cbxFiltroSector
            // 
            this.cbxFiltroSector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFiltroSector.FormattingEnabled = true;
            this.cbxFiltroSector.Location = new System.Drawing.Point(183, 46);
            this.cbxFiltroSector.Name = "cbxFiltroSector";
            this.cbxFiltroSector.Size = new System.Drawing.Size(121, 21);
            this.cbxFiltroSector.TabIndex = 42;
            // 
            // cbxFiltroSucursal
            // 
            this.cbxFiltroSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFiltroSucursal.FormattingEnabled = true;
            this.cbxFiltroSucursal.Location = new System.Drawing.Point(501, 46);
            this.cbxFiltroSucursal.Name = "cbxFiltroSucursal";
            this.cbxFiltroSucursal.Size = new System.Drawing.Size(121, 21);
            this.cbxFiltroSucursal.TabIndex = 41;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(652, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 17);
            this.label13.TabIndex = 40;
            this.label13.Text = "Estado";
            this.label13.Visible = false;
            // 
            // cbxFiltroEstadoCliente
            // 
            this.cbxFiltroEstadoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFiltroEstadoCliente.Enabled = false;
            this.cbxFiltroEstadoCliente.FormattingEnabled = true;
            this.cbxFiltroEstadoCliente.Location = new System.Drawing.Point(655, 46);
            this.cbxFiltroEstadoCliente.Name = "cbxFiltroEstadoCliente";
            this.cbxFiltroEstadoCliente.Size = new System.Drawing.Size(121, 21);
            this.cbxFiltroEstadoCliente.TabIndex = 39;
            this.cbxFiltroEstadoCliente.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(498, 12);
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
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 17);
            this.label6.TabIndex = 28;
            this.label6.Text = "Transportista";
            // 
            // cbxFiltroNombreTransp
            // 
            this.cbxFiltroNombreTransp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFiltroNombreTransp.FormattingEnabled = true;
            this.cbxFiltroNombreTransp.Location = new System.Drawing.Point(5, 46);
            this.cbxFiltroNombreTransp.Name = "cbxFiltroNombreTransp";
            this.cbxFiltroNombreTransp.Size = new System.Drawing.Size(121, 21);
            this.cbxFiltroNombreTransp.TabIndex = 28;
            // 
            // grdCliente
            // 
            this.grdCliente.AllowUserToAddRows = false;
            this.grdCliente.AllowUserToDeleteRows = false;
            this.grdCliente.AllowUserToResizeColumns = false;
            this.grdCliente.AllowUserToResizeRows = false;
            this.grdCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.pariente_transp,
            this.direccion,
            this.toma_transp,
            this.id_transportista,
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
            this.grdCliente.Location = new System.Drawing.Point(0, 249);
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
            this.grdCliente.Size = new System.Drawing.Size(918, 281);
            this.grdCliente.TabIndex = 6;
            // 
            // id_Cliente
            // 
            this.id_Cliente.HeaderText = "Id Cliente";
            this.id_Cliente.Name = "id_Cliente";
            // 
            // Cedula
            // 
            this.Cedula.HeaderText = "Cédula";
            this.Cedula.Name = "Cedula";
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Apodo
            // 
            this.Apodo.HeaderText = "Apodo";
            this.Apodo.Name = "Apodo";
            // 
            // fecha_ingreso
            // 
            this.fecha_ingreso.HeaderText = "Fecha Ingreso";
            this.fecha_ingreso.Name = "fecha_ingreso";
            // 
            // fecha_free
            // 
            this.fecha_free.HeaderText = "Fecha Free";
            this.fecha_free.Name = "fecha_free";
            // 
            // Sexo
            // 
            this.Sexo.HeaderText = "Sexo";
            this.Sexo.Name = "Sexo";
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            // 
            // Aula
            // 
            this.Aula.HeaderText = "Aula";
            this.Aula.Name = "Aula";
            // 
            // Dia_nacimiento
            // 
            this.Dia_nacimiento.HeaderText = "Día Nacimiento";
            this.Dia_nacimiento.Name = "Dia_nacimiento";
            // 
            // mes_nacimiento
            // 
            this.mes_nacimiento.HeaderText = "Mes Nacimiento";
            this.mes_nacimiento.Name = "mes_nacimiento";
            // 
            // anio_nacimiento
            // 
            this.anio_nacimiento.HeaderText = "Año Nacimiento";
            this.anio_nacimiento.Name = "anio_nacimiento";
            // 
            // telefono
            // 
            this.telefono.HeaderText = "Teléfono";
            this.telefono.Name = "telefono";
            // 
            // nombre_contacto
            // 
            this.nombre_contacto.HeaderText = "Nombre Contacto";
            this.nombre_contacto.Name = "nombre_contacto";
            // 
            // parentesco_contacto
            // 
            this.parentesco_contacto.HeaderText = "Parentesco Contacto";
            this.parentesco_contacto.Name = "parentesco_contacto";
            // 
            // telefono_contacto
            // 
            this.telefono_contacto.HeaderText = "Teléfono Contacto";
            this.telefono_contacto.Name = "telefono_contacto";
            // 
            // celular_contacto
            // 
            this.celular_contacto.HeaderText = "Celular Contacto";
            this.celular_contacto.Name = "celular_contacto";
            // 
            // encargado_pago
            // 
            this.encargado_pago.HeaderText = "Encargado Pago";
            this.encargado_pago.Name = "encargado_pago";
            // 
            // parentesco_pago
            // 
            this.parentesco_pago.HeaderText = "Parentesco Pago";
            this.parentesco_pago.Name = "parentesco_pago";
            // 
            // telefono_pago
            // 
            this.telefono_pago.HeaderText = "Teléfono Pago";
            this.telefono_pago.Name = "telefono_pago";
            // 
            // cedula_pago
            // 
            this.cedula_pago.HeaderText = "Cédula Pago";
            this.cedula_pago.Name = "cedula_pago";
            // 
            // celular_pago
            // 
            this.celular_pago.HeaderText = "Celular Pago";
            this.celular_pago.Name = "celular_pago";
            // 
            // email_pago
            // 
            this.email_pago.HeaderText = "Email Pago";
            this.email_pago.Name = "email_pago";
            // 
            // medio_pago
            // 
            this.medio_pago.HeaderText = "Medio Pago";
            this.medio_pago.Name = "medio_pago";
            // 
            // pariente_transp
            // 
            this.pariente_transp.HeaderText = "Pariente Transporte";
            this.pariente_transp.Name = "pariente_transp";
            // 
            // direccion
            // 
            this.direccion.HeaderText = "Dirección";
            this.direccion.Name = "direccion";
            // 
            // toma_transp
            // 
            this.toma_transp.HeaderText = "Toma Transporte";
            this.toma_transp.Name = "toma_transp";
            // 
            // id_transportista
            // 
            this.id_transportista.HeaderText = "Id Transportista";
            this.id_transportista.Name = "id_transportista";
            // 
            // retirarse_solo
            // 
            this.retirarse_solo.HeaderText = "Retirarse Solo";
            this.retirarse_solo.Name = "retirarse_solo";
            // 
            // nombre_factu
            // 
            this.nombre_factu.HeaderText = "Nombre Factura";
            this.nombre_factu.Name = "nombre_factu";
            // 
            // cedula_factu
            // 
            this.cedula_factu.HeaderText = "Cédula Factura";
            this.cedula_factu.Name = "cedula_factu";
            // 
            // direccion_factu
            // 
            this.direccion_factu.HeaderText = "Dirección Factura";
            this.direccion_factu.Name = "direccion_factu";
            // 
            // email_factu
            // 
            this.email_factu.HeaderText = "Email Factura";
            this.email_factu.Name = "email_factu";
            // 
            // sucursal
            // 
            this.sucursal.HeaderText = "Sucursal";
            this.sucursal.Name = "sucursal";
            // 
            // obseracion
            // 
            this.obseracion.HeaderText = "Observación";
            this.obseracion.Name = "obseracion";
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
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlFiltro.ResumeLayout(false);
            this.pnlFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCliente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblNombreVista;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Botones_Personalizados.OurButton btnClose;
        private System.Windows.Forms.Button btnFiltros;
        private System.Windows.Forms.Button btnSalud;
        private System.Windows.Forms.Button btnAlimentos;
        private System.Windows.Forms.Button btnActions;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlFiltro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxFiltroRuta;
        private System.Windows.Forms.ComboBox cbxFiltroSector;
        private System.Windows.Forms.ComboBox cbxFiltroSucursal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbxFiltroEstadoCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReiniciarFiltro;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxFiltroNombreTransp;
        private System.Windows.Forms.DataGridView grdCliente;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn pariente_transp;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn toma_transp;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_transportista;
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