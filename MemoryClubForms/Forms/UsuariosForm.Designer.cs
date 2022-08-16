namespace MemoryClubForms.Forms
{
    partial class UsuariosForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNombreVista = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxDescripcion = new System.Windows.Forms.TextBox();
            this.lblAction = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cbxNivel = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxClave = new System.Windows.Forms.TextBox();
            this.cbxEstado = new System.Windows.Forms.ComboBox();
            this.tbxUsuario = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.cbxSucursal = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtObservciones = new System.Windows.Forms.TextBox();
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.cbxFiltroEstado = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxFiltroSucursal = new System.Windows.Forms.ComboBox();
            this.btnReiniciarFiltro = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.grdUsuario = new System.Windows.Forms.DataGridView();
            this.Id_usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_mod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new MemoryClubForms.Botones_Personalizados.OurButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlActions.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pnlActions);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 341);
            this.panel1.TabIndex = 0;
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
            this.lblNombreVista.Size = new System.Drawing.Size(72, 22);
            this.lblNombreVista.TabIndex = 0;
            this.lblNombreVista.Text = "Usuario";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MemoryClubForms.Properties.Resources.usuario2;
            this.pictureBox1.Location = new System.Drawing.Point(23, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pnlActions
            // 
            this.pnlActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlActions.BackColor = System.Drawing.Color.White;
            this.pnlActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlActions.Controls.Add(this.label2);
            this.pnlActions.Controls.Add(this.tbxDescripcion);
            this.pnlActions.Controls.Add(this.lblAction);
            this.pnlActions.Controls.Add(this.panel6);
            this.pnlActions.Controls.Add(this.panel5);
            this.pnlActions.Controls.Add(this.panel4);
            this.pnlActions.Controls.Add(this.cbxSucursal);
            this.pnlActions.Controls.Add(this.label10);
            this.pnlActions.Controls.Add(this.label11);
            this.pnlActions.Controls.Add(this.txtObservciones);
            this.pnlActions.Location = new System.Drawing.Point(12, 136);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(903, 180);
            this.pnlActions.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(88, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Descripción";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbxDescripcion
            // 
            this.tbxDescripcion.Enabled = false;
            this.tbxDescripcion.Location = new System.Drawing.Point(10, 136);
            this.tbxDescripcion.MaxLength = 80;
            this.tbxDescripcion.Name = "tbxDescripcion";
            this.tbxDescripcion.Size = new System.Drawing.Size(238, 20);
            this.tbxDescripcion.TabIndex = 5;
            // 
            // lblAction
            // 
            this.lblAction.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAction.AutoSize = true;
            this.lblAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAction.ForeColor = System.Drawing.Color.Navy;
            this.lblAction.Location = new System.Drawing.Point(413, 4);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(0, 25);
            this.lblAction.TabIndex = 32;
            this.lblAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cbxNivel);
            this.panel6.Controls.Add(this.lblEstado);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.tbxClave);
            this.panel6.Controls.Add(this.cbxEstado);
            this.panel6.Controls.Add(this.tbxUsuario);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Location = new System.Drawing.Point(10, 41);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(774, 61);
            this.panel6.TabIndex = 0;
            // 
            // cbxNivel
            // 
            this.cbxNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNivel.FormattingEnabled = true;
            this.cbxNivel.Location = new System.Drawing.Point(286, 28);
            this.cbxNivel.Name = "cbxNivel";
            this.cbxNivel.Size = new System.Drawing.Size(308, 21);
            this.cbxNivel.TabIndex = 3;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(632, 6);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(52, 17);
            this.lblEstado.TabIndex = 0;
            this.lblEstado.Text = "Estado";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblEstado.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(200, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clave";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbxClave
            // 
            this.tbxClave.Enabled = false;
            this.tbxClave.Location = new System.Drawing.Point(164, 28);
            this.tbxClave.MaxLength = 20;
            this.tbxClave.Name = "tbxClave";
            this.tbxClave.Size = new System.Drawing.Size(115, 20);
            this.tbxClave.TabIndex = 2;
            // 
            // cbxEstado
            // 
            this.cbxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEstado.Enabled = false;
            this.cbxEstado.FormattingEnabled = true;
            this.cbxEstado.Location = new System.Drawing.Point(614, 28);
            this.cbxEstado.Name = "cbxEstado";
            this.cbxEstado.Size = new System.Drawing.Size(89, 21);
            this.cbxEstado.TabIndex = 4;
            this.cbxEstado.Visible = false;
            // 
            // tbxUsuario
            // 
            this.tbxUsuario.Enabled = false;
            this.tbxUsuario.Location = new System.Drawing.Point(9, 28);
            this.tbxUsuario.MaxLength = 20;
            this.tbxUsuario.Name = "tbxUsuario";
            this.tbxUsuario.ShortcutsEnabled = false;
            this.tbxUsuario.Size = new System.Drawing.Size(148, 20);
            this.tbxUsuario.TabIndex = 1;
            this.tbxUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxUsuario_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(350, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Nivel";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(55, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Usuario";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.btnCancel);
            this.panel5.Controls.Add(this.btnEliminar);
            this.panel5.Controls.Add(this.btnGuardar);
            this.panel5.Location = new System.Drawing.Point(809, 0);
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
            this.btnCancel.TabIndex = 11;
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
            this.btnEliminar.TabIndex = 10;
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
            this.btnGuardar.TabIndex = 12;
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
            this.panel4.Location = new System.Drawing.Point(587, 3);
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
            this.btnInsertar.TabIndex = 8;
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
            this.btnEditar.TabIndex = 9;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // cbxSucursal
            // 
            this.cbxSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSucursal.FormattingEnabled = true;
            this.cbxSucursal.Location = new System.Drawing.Point(273, 136);
            this.cbxSucursal.Name = "cbxSucursal";
            this.cbxSucursal.Size = new System.Drawing.Size(69, 21);
            this.cbxSucursal.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(501, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Observaciones";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(276, 117);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Sucursal";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtObservciones
            // 
            this.txtObservciones.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtObservciones.Enabled = false;
            this.txtObservciones.Location = new System.Drawing.Point(361, 137);
            this.txtObservciones.MaxLength = 50;
            this.txtObservciones.Name = "txtObservciones";
            this.txtObservciones.Size = new System.Drawing.Size(382, 20);
            this.txtObservciones.TabIndex = 7;
            // 
            // pnlFiltro
            // 
            this.pnlFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltro.BackColor = System.Drawing.Color.White;
            this.pnlFiltro.Controls.Add(this.label13);
            this.pnlFiltro.Controls.Add(this.cbxFiltroEstado);
            this.pnlFiltro.Controls.Add(this.label3);
            this.pnlFiltro.Controls.Add(this.cbxFiltroSucursal);
            this.pnlFiltro.Controls.Add(this.btnReiniciarFiltro);
            this.pnlFiltro.Controls.Add(this.btnFiltrar);
            this.pnlFiltro.Location = new System.Drawing.Point(12, 54);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(894, 77);
            this.pnlFiltro.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(350, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 17);
            this.label13.TabIndex = 0;
            this.label13.Text = "Estado";
            // 
            // cbxFiltroEstado
            // 
            this.cbxFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFiltroEstado.FormattingEnabled = true;
            this.cbxFiltroEstado.Location = new System.Drawing.Point(316, 36);
            this.cbxFiltroEstado.Name = "cbxFiltroEstado";
            this.cbxFiltroEstado.Size = new System.Drawing.Size(121, 21);
            this.cbxFiltroEstado.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(186, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Sucursal";
            // 
            // cbxFiltroSucursal
            // 
            this.cbxFiltroSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFiltroSucursal.FormattingEnabled = true;
            this.cbxFiltroSucursal.Location = new System.Drawing.Point(157, 36);
            this.cbxFiltroSucursal.Name = "cbxFiltroSucursal";
            this.cbxFiltroSucursal.Size = new System.Drawing.Size(121, 21);
            this.cbxFiltroSucursal.TabIndex = 13;
            // 
            // btnReiniciarFiltro
            // 
            this.btnReiniciarFiltro.BackColor = System.Drawing.Color.Maroon;
            this.btnReiniciarFiltro.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.btnReiniciarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReiniciarFiltro.ForeColor = System.Drawing.SystemColors.Info;
            this.btnReiniciarFiltro.Location = new System.Drawing.Point(816, 11);
            this.btnReiniciarFiltro.Name = "btnReiniciarFiltro";
            this.btnReiniciarFiltro.Size = new System.Drawing.Size(75, 23);
            this.btnReiniciarFiltro.TabIndex = 15;
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
            this.btnFiltrar.Location = new System.Drawing.Point(816, 45);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 16;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // grdUsuario
            // 
            this.grdUsuario.AllowUserToAddRows = false;
            this.grdUsuario.AllowUserToDeleteRows = false;
            this.grdUsuario.AllowUserToResizeColumns = false;
            this.grdUsuario.AllowUserToResizeRows = false;
            this.grdUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdUsuario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdUsuario.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdUsuario.BackgroundColor = System.Drawing.Color.White;
            this.grdUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdUsuario.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdUsuario.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdUsuario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_usuario,
            this.usuario,
            this.clave,
            this.nivel,
            this.descripcion,
            this.Estado,
            this.sucursal,
            this.observaciones,
            this.fecha_mod});
            this.grdUsuario.EnableHeadersVisualStyles = false;
            this.grdUsuario.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(213)))), ((int)(((byte)(232)))));
            this.grdUsuario.Location = new System.Drawing.Point(12, 348);
            this.grdUsuario.Name = "grdUsuario";
            this.grdUsuario.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdUsuario.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdUsuario.RowHeadersVisible = false;
            this.grdUsuario.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(213)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy;
            this.grdUsuario.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdUsuario.Size = new System.Drawing.Size(894, 233);
            this.grdUsuario.StandardTab = true;
            this.grdUsuario.TabIndex = 10;
            this.grdUsuario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Row_Clicked);
            // 
            // Id_usuario
            // 
            this.Id_usuario.HeaderText = "ID Usuario";
            this.Id_usuario.Name = "Id_usuario";
            this.Id_usuario.Visible = false;
            // 
            // usuario
            // 
            this.usuario.FillWeight = 82.08122F;
            this.usuario.HeaderText = "Usuario";
            this.usuario.Name = "usuario";
            // 
            // clave
            // 
            this.clave.FillWeight = 82.08122F;
            this.clave.HeaderText = "Clave";
            this.clave.Name = "clave";
            // 
            // nivel
            // 
            this.nivel.FillWeight = 82.08122F;
            this.nivel.HeaderText = "Nivel";
            this.nivel.Name = "nivel";
            // 
            // descripcion
            // 
            this.descripcion.FillWeight = 82.08122F;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            // 
            // sucursal
            // 
            this.sucursal.FillWeight = 82.08122F;
            this.sucursal.HeaderText = "Sucursal";
            this.sucursal.Name = "sucursal";
            // 
            // observaciones
            // 
            this.observaciones.FillWeight = 82.08122F;
            this.observaciones.HeaderText = "Observaciones";
            this.observaciones.Name = "observaciones";
            // 
            // fecha_mod
            // 
            this.fecha_mod.FillWeight = 82.08122F;
            this.fecha_mod.HeaderText = "Fecha Modificación";
            this.fecha_mod.Name = "fecha_mod";
            this.fecha_mod.Visible = false;
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
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Cerrar";
            this.btnClose.TextColor = System.Drawing.Color.White;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // UsuariosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(918, 593);
            this.Controls.Add(this.grdUsuario);
            this.Controls.Add(this.pnlFiltro);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.Name = "UsuariosForm";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlActions.ResumeLayout(false);
            this.pnlActions.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnlFiltro.ResumeLayout(false);
            this.pnlFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsuario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblNombreVista;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Botones_Personalizados.OurButton btnClose;
        private System.Windows.Forms.Panel pnlFiltro;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbxFiltroEstado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxFiltroSucursal;
        private System.Windows.Forms.Button btnReiniciarFiltro;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxDescripcion;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxClave;
        private System.Windows.Forms.ComboBox cbxEstado;
        private System.Windows.Forms.TextBox tbxUsuario;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxSucursal;
        private System.Windows.Forms.Label label4;
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
        private System.Windows.Forms.DataGridView grdUsuario;
        private System.Windows.Forms.ComboBox cbxNivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn sucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn observaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_mod;
    }
}