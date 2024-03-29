﻿namespace MemoryClubForms.Forms
{
    partial class HomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.menuBarra = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asistenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cateringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colaboradoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transportistasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alimentaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saludToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteCateringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteTransporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteAsistenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parámetrosSistemasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alertaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.menuBarra.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBarra
            // 
            this.menuBarra.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuBarra.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.gestiónToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.sistemaToolStripMenuItem,
            this.alertaToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem});
            this.menuBarra.Location = new System.Drawing.Point(0, 0);
            this.menuBarra.Name = "menuBarra";
            this.menuBarra.Size = new System.Drawing.Size(934, 29);
            this.menuBarra.TabIndex = 1;
            this.menuBarra.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imprimirToolStripMenuItem,
            this.cerrarToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(75, 25);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.Image = global::MemoryClubForms.Properties.Resources.imprimir;
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.imprimirToolStripMenuItem.Text = "Imprimir";
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Image = global::MemoryClubForms.Properties.Resources.close;
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.cerrarToolStripMenuItem.Text = "Cerrar";
            // 
            // gestiónToolStripMenuItem
            // 
            this.gestiónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asistenciaToolStripMenuItem,
            this.cateringToolStripMenuItem,
            this.transporteToolStripMenuItem,
            this.colaboradoresToolStripMenuItem,
            this.transportistasToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.planToolStripMenuItem});
            this.gestiónToolStripMenuItem.Name = "gestiónToolStripMenuItem";
            this.gestiónToolStripMenuItem.Size = new System.Drawing.Size(75, 25);
            this.gestiónToolStripMenuItem.Text = "Gestión";
            // 
            // asistenciaToolStripMenuItem
            // 
            this.asistenciaToolStripMenuItem.Image = global::MemoryClubForms.Properties.Resources.Asistencia_1;
            this.asistenciaToolStripMenuItem.Name = "asistenciaToolStripMenuItem";
            this.asistenciaToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.asistenciaToolStripMenuItem.Text = "Asistencia ";
            this.asistenciaToolStripMenuItem.Click += new System.EventHandler(this.asistenciaToolStripMenuItem_Click);
            // 
            // cateringToolStripMenuItem
            // 
            this.cateringToolStripMenuItem.Image = global::MemoryClubForms.Properties.Resources.restaurante;
            this.cateringToolStripMenuItem.Name = "cateringToolStripMenuItem";
            this.cateringToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.cateringToolStripMenuItem.Text = "Catering";
            this.cateringToolStripMenuItem.Click += new System.EventHandler(this.cateringToolStripMenuItem_Click);
            // 
            // transporteToolStripMenuItem
            // 
            this.transporteToolStripMenuItem.Image = global::MemoryClubForms.Properties.Resources.Transporte2;
            this.transporteToolStripMenuItem.Name = "transporteToolStripMenuItem";
            this.transporteToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.transporteToolStripMenuItem.Text = "Transporte";
            this.transporteToolStripMenuItem.Click += new System.EventHandler(this.transporteToolStripMenuItem_Click);
            // 
            // colaboradoresToolStripMenuItem
            // 
            this.colaboradoresToolStripMenuItem.Image = global::MemoryClubForms.Properties.Resources.user;
            this.colaboradoresToolStripMenuItem.Name = "colaboradoresToolStripMenuItem";
            this.colaboradoresToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.colaboradoresToolStripMenuItem.Text = "Colaboradores";
            this.colaboradoresToolStripMenuItem.Click += new System.EventHandler(this.colaboradoresToolStripMenuItem_Click);
            // 
            // transportistasToolStripMenuItem
            // 
            this.transportistasToolStripMenuItem.Image = global::MemoryClubForms.Properties.Resources.Transporte1;
            this.transportistasToolStripMenuItem.Name = "transportistasToolStripMenuItem";
            this.transportistasToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.transportistasToolStripMenuItem.Text = "Transportistas";
            this.transportistasToolStripMenuItem.Click += new System.EventHandler(this.transportistasToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alimentaciónToolStripMenuItem,
            this.saludToolStripMenuItem});
            this.clientesToolStripMenuItem.Image = global::MemoryClubForms.Properties.Resources.usuario;
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // alimentaciónToolStripMenuItem
            // 
            this.alimentaciónToolStripMenuItem.Image = global::MemoryClubForms.Properties.Resources.manzana;
            this.alimentaciónToolStripMenuItem.Name = "alimentaciónToolStripMenuItem";
            this.alimentaciónToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.alimentaciónToolStripMenuItem.Text = "Alimentación";
            this.alimentaciónToolStripMenuItem.Click += new System.EventHandler(this.alimentaciónToolStripMenuItem_Click);
            // 
            // saludToolStripMenuItem
            // 
            this.saludToolStripMenuItem.Image = global::MemoryClubForms.Properties.Resources.salud;
            this.saludToolStripMenuItem.Name = "saludToolStripMenuItem";
            this.saludToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.saludToolStripMenuItem.Text = "Salud";
            this.saludToolStripMenuItem.Click += new System.EventHandler(this.saludToolStripMenuItem_Click);
            // 
            // planToolStripMenuItem
            // 
            this.planToolStripMenuItem.Image = global::MemoryClubForms.Properties.Resources.planificacion;
            this.planToolStripMenuItem.Name = "planToolStripMenuItem";
            this.planToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.planToolStripMenuItem.Text = "Plan";
            this.planToolStripMenuItem.Click += new System.EventHandler(this.planToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reporteCateringToolStripMenuItem,
            this.reporteTransporteToolStripMenuItem,
            this.reporteClientesToolStripMenuItem,
            this.reporteAsistenciaToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(84, 25);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // reporteCateringToolStripMenuItem
            // 
            this.reporteCateringToolStripMenuItem.Image = global::MemoryClubForms.Properties.Resources.restaurante;
            this.reporteCateringToolStripMenuItem.Name = "reporteCateringToolStripMenuItem";
            this.reporteCateringToolStripMenuItem.Size = new System.Drawing.Size(339, 26);
            this.reporteCateringToolStripMenuItem.Text = "Reporte Catering";
            this.reporteCateringToolStripMenuItem.Click += new System.EventHandler(this.reporteCateringToolStripMenuItem_Click);
            // 
            // reporteTransporteToolStripMenuItem
            // 
            this.reporteTransporteToolStripMenuItem.Image = global::MemoryClubForms.Properties.Resources.Transporte2;
            this.reporteTransporteToolStripMenuItem.Name = "reporteTransporteToolStripMenuItem";
            this.reporteTransporteToolStripMenuItem.Size = new System.Drawing.Size(339, 26);
            this.reporteTransporteToolStripMenuItem.Text = "Reporte Transporte";
            this.reporteTransporteToolStripMenuItem.Click += new System.EventHandler(this.reporteTransporteToolStripMenuItem_Click);
            // 
            // reporteClientesToolStripMenuItem
            // 
            this.reporteClientesToolStripMenuItem.Image = global::MemoryClubForms.Properties.Resources.usuario;
            this.reporteClientesToolStripMenuItem.Name = "reporteClientesToolStripMenuItem";
            this.reporteClientesToolStripMenuItem.Size = new System.Drawing.Size(339, 26);
            this.reporteClientesToolStripMenuItem.Text = "Reporte Clientes";
            this.reporteClientesToolStripMenuItem.Click += new System.EventHandler(this.reporteClientesToolStripMenuItem_Click);
            // 
            // reporteAsistenciaToolStripMenuItem
            // 
            this.reporteAsistenciaToolStripMenuItem.Image = global::MemoryClubForms.Properties.Resources.Asistencia_1;
            this.reporteAsistenciaToolStripMenuItem.Name = "reporteAsistenciaToolStripMenuItem";
            this.reporteAsistenciaToolStripMenuItem.Size = new System.Drawing.Size(339, 26);
            this.reporteAsistenciaToolStripMenuItem.Text = "Reporte Mensual de Ventas de Planes";
            this.reporteAsistenciaToolStripMenuItem.Click += new System.EventHandler(this.reporteAsistenciaToolStripMenuItem_Click);
            // 
            // sistemaToolStripMenuItem
            // 
            this.sistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuarioSistemaToolStripMenuItem,
            this.parámetrosSistemasToolStripMenuItem});
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            this.sistemaToolStripMenuItem.Size = new System.Drawing.Size(77, 25);
            this.sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // usuarioSistemaToolStripMenuItem
            // 
            this.usuarioSistemaToolStripMenuItem.Image = global::MemoryClubForms.Properties.Resources.usuario2;
            this.usuarioSistemaToolStripMenuItem.Name = "usuarioSistemaToolStripMenuItem";
            this.usuarioSistemaToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.usuarioSistemaToolStripMenuItem.Text = "Usuario Sistema";
            this.usuarioSistemaToolStripMenuItem.Click += new System.EventHandler(this.usuarioSistemaToolStripMenuItem_Click);
            // 
            // parámetrosSistemasToolStripMenuItem
            // 
            this.parámetrosSistemasToolStripMenuItem.Image = global::MemoryClubForms.Properties.Resources.editar__1_;
            this.parámetrosSistemasToolStripMenuItem.Name = "parámetrosSistemasToolStripMenuItem";
            this.parámetrosSistemasToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.parámetrosSistemasToolStripMenuItem.Text = "Parámetros Sistemas";
            this.parámetrosSistemasToolStripMenuItem.Click += new System.EventHandler(this.parámetrosSistemasToolStripMenuItem_Click);
            // 
            // alertaToolStripMenuItem
            // 
            this.alertaToolStripMenuItem.Image = global::MemoryClubForms.Properties.Resources.Alerta;
            this.alertaToolStripMenuItem.Name = "alertaToolStripMenuItem";
            this.alertaToolStripMenuItem.Size = new System.Drawing.Size(79, 25);
            this.alertaToolStripMenuItem.Text = "Alerta";
            this.alertaToolStripMenuItem.Click += new System.EventHandler(this.alertaToolStripMenuItem_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Image = global::MemoryClubForms.Properties.Resources.cerrarS1;
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(132, 25);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(563, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "User";
            // 
            // panelContenedor
            // 
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 29);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(934, 632);
            this.panelContenedor.TabIndex = 4;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(934, 661);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.menuBarra);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuBarra;
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú ";
            this.Load += new System.EventHandler(this.LoadHomeForm);
            this.menuBarra.ResumeLayout(false);
            this.menuBarra.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuBarra;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alertaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem asistenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cateringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transporteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colaboradoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transportistasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteAsistenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteCateringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteTransporteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuarioSistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parámetrosSistemasToolStripMenuItem;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alimentaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saludToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planToolStripMenuItem;
    }
}