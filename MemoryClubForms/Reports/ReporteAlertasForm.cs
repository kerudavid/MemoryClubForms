using MemoryClubForms.Models;
using MemoryClubForms.BusinessBO;
using MemoryClubForms.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;



namespace MemoryClubForms.Reports
{
    //gestiona reporte de alertas
    public partial class ReporteAlertasForm : Form
    {
        public ReporteAlertasForm()
        {
            InitializeComponent();
        }

        public void ReporteAlertasForm_Load(object sender, EventArgs e)
        {
            //genero la lista desde la consulta
            ReporteAlertasBO reporteAlertasBO = new ReporteAlertasBO();
            List<ReporteAlertasModel> repalertasList = new List<ReporteAlertasModel>();
            repalertasList = reporteAlertasBO.LoadReporteAlertas();

            //asigno la lista al reporte
            ReportDataSource rds = new ReportDataSource("ReporteAlertas", repalertasList);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MemoryClubForms.Reports.ReporteAlertas.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
