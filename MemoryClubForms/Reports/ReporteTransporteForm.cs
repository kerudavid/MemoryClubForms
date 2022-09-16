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
using System.Globalization;

namespace MemoryClubForms.Reports
{
    public partial class ReporteTransporteForm : Form
    {
        CultureInfo ci = new CultureInfo("en-US");
        public ReporteTransporteForm()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            string fdesde = this.dtpDesde.Value.ToString("MM/dd/yyyy", ci);
            string fhasta = this.dtpHasta.Value.ToString("MM/dd/yyyy", ci);

            ReporteTransporteBO reporTranspBO = new ReporteTransporteBO();
            List<ReporteTransporteModel> rtmList = new List<ReporteTransporteModel>();
            rtmList = reporTranspBO.LoadReporteTransporte(fdesde, fhasta);

            if (rtmList.Count > 0)
            {
                //asigno la lista al reporte
                ReportDataSource rds = new ReportDataSource("ReporteTransporte", rtmList);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "MemoryClubForms.Reports.ReporteTransporte.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                //añado los parámetros
                ReportParameter[] reportParameters = new ReportParameter[2];
                //reportParameters[0] = new ReportParameter("NombreParametro", "VALOR DE TU PARAMETRO", false); EJEMPLO
                reportParameters[0] = new ReportParameter("ReportDesde", fdesde, false);
                reportParameters[1] = new ReportParameter("ReportHasta", fhasta, false);

                this.reportViewer1.LocalReport.DataSources.Add(rds);
                //envio los parametros
                reportViewer1.LocalReport.SetParameters(reportParameters);

                this.reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("No se encontraron datos de Transporte para el periodo seleccionado");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReporteTransporteForm_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
