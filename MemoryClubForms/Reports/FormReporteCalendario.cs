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
    //gestiona lista de días tomados y reservados por cliente
    public partial class FormReporteCalendario : Form
    {
        public FormReporteCalendario()
        {
            InitializeComponent();
        }

        private void FormReporteCalendario_Load(object sender, EventArgs e)
        { 
            //genero la lista desde la consulta
            ReporteCalendarioBO reporteCalenBO = new ReporteCalendarioBO();
            List<ReporteCalendarioModel> repCalenList = new List<ReporteCalendarioModel>();
            repCalenList = reporteCalenBO.LoadReporteCalendario();

            //asigno la lista al reporte
            ReportDataSource rds = new ReportDataSource("ReporteCalendario", repCalenList);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MemoryClubForms.Reports.ReporteCalendario.rdlc";
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
