namespace MemoryClubForms.Reports
{
    partial class ReporteVentaPlanesForm
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnCargar = new System.Windows.Forms.Button();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.btnClose = new MemoryClubForms.Botones_Personalizados.OurButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtn_vigentes = new System.Windows.Forms.RadioButton();
            this.rbtn_todos = new System.Windows.Forms.RadioButton();
            this.ckbFiltrarFechas = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoScroll = true;
            this.reportViewer1.Location = new System.Drawing.Point(0, 31);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(394, 561);
            this.reportViewer1.TabIndex = 0;
            // 
            // reportViewer2
            // 
            this.reportViewer2.AutoScroll = true;
            this.reportViewer2.Location = new System.Drawing.Point(394, 31);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(522, 561);
            this.reportViewer2.TabIndex = 6;
            // 
            // btnCargar
            // 
            this.btnCargar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnCargar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCargar.Location = new System.Drawing.Point(785, 0);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(57, 27);
            this.btnCargar.TabIndex = 11;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(401, 4);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpHasta.TabIndex = 10;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(155, 4);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde.TabIndex = 9;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHasta.Location = new System.Drawing.Point(357, 7);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(44, 13);
            this.lblHasta.TabIndex = 8;
            this.lblHasta.Text = "Hasta:";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesde.Location = new System.Drawing.Point(110, 7);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(47, 13);
            this.lblDesde.TabIndex = 7;
            this.lblDesde.Text = "Desde:";
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
            this.btnClose.Location = new System.Drawing.Point(850, -1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(64, 28);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Cerrar";
            this.btnClose.TextColor = System.Drawing.Color.White;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(610, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Estado:";
            // 
            // rbtn_vigentes
            // 
            this.rbtn_vigentes.AutoSize = true;
            this.rbtn_vigentes.Checked = true;
            this.rbtn_vigentes.Location = new System.Drawing.Point(658, 6);
            this.rbtn_vigentes.Name = "rbtn_vigentes";
            this.rbtn_vigentes.Size = new System.Drawing.Size(66, 17);
            this.rbtn_vigentes.TabIndex = 13;
            this.rbtn_vigentes.TabStop = true;
            this.rbtn_vigentes.Text = "Vigentes";
            this.rbtn_vigentes.UseVisualStyleBackColor = true;
            this.rbtn_vigentes.CheckedChanged += new System.EventHandler(this.rbtn_vigentes_CheckedChanged);
            // 
            // rbtn_todos
            // 
            this.rbtn_todos.AutoSize = true;
            this.rbtn_todos.Location = new System.Drawing.Point(726, 6);
            this.rbtn_todos.Name = "rbtn_todos";
            this.rbtn_todos.Size = new System.Drawing.Size(55, 17);
            this.rbtn_todos.TabIndex = 14;
            this.rbtn_todos.Text = "Todos";
            this.rbtn_todos.UseVisualStyleBackColor = true;
            this.rbtn_todos.CheckedChanged += new System.EventHandler(this.rbtn_todos_CheckedChanged);
            // 
            // ckbFiltrarFechas
            // 
            this.ckbFiltrarFechas.AutoSize = true;
            this.ckbFiltrarFechas.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ckbFiltrarFechas.Location = new System.Drawing.Point(4, 6);
            this.ckbFiltrarFechas.Name = "ckbFiltrarFechas";
            this.ckbFiltrarFechas.Size = new System.Drawing.Size(107, 17);
            this.ckbFiltrarFechas.TabIndex = 33;
            this.ckbFiltrarFechas.Text = "Filtrar con fechas";
            this.ckbFiltrarFechas.UseVisualStyleBackColor = true;
            this.ckbFiltrarFechas.CheckedChanged += new System.EventHandler(this.ckbFiltrarFechas_CheckedChanged);
            // 
            // ReporteVentaPlanesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 593);
            this.Controls.Add(this.ckbFiltrarFechas);
            this.Controls.Add(this.rbtn_todos);
            this.Controls.Add(this.rbtn_vigentes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.lblDesde);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.reportViewer2);
            this.Name = "ReporteVentaPlanesForm";
            this.Text = "ReporteVentaPlanes";
            this.Load += new System.EventHandler(this.ReporteVentaPlanesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Botones_Personalizados.OurButton btnClose;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtn_vigentes;
        private System.Windows.Forms.RadioButton rbtn_todos;
        private System.Windows.Forms.CheckBox ckbFiltrarFechas;
    }
}