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
    public partial class FormReporteClientePlan : Form
    {
        CultureInfo ci = new CultureInfo("en-US");
        public FormReporteClientePlan()
        {
            InitializeComponent();
        }

        public void FormReporteClientePlan_Load(object sender, EventArgs e)
        {                     
            this.reportViewer1.RefreshReport();
            this.txbNombre.Text = "TODOS";
        }


         private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            string fdesde = this.dtpDesde.Value.ToString("MM/dd/yyyy", ci);
            string fhasta = this.dtpHasta.Value.ToString("MM/dd/yyyy", ci);
            string Pcliente = this.txbNombre.Text.Trim();

            //genero la lista desde la consulta
            ReporteClientePlanBO reporcliplanBO = new ReporteClientePlanBO();
            List<ReporteVentasModel> rcplist = new List<ReporteVentasModel>();
            rcplist = reporcliplanBO.LoadReporteClientePlan(fdesde, fhasta, Pcliente);

            if (rcplist.Count > 0)
            {
                //asigno la lista al reporte vtas de los últimos planes
                ReportDataSource rds = new ReportDataSource("ReporteClientePlan", rcplist);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "MemoryClubForms.Reports.ReporteClientePlan.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();
                //añado los parámetros
                ReportParameter[] reportParameters = new ReportParameter[3];
                //reportParameters[0] = new ReportParameter("NombreParametro", "VALOR DE TU PARAMETRO", false); EJEMPLO
                reportParameters[0] = new ReportParameter("ReportDesde", fdesde, false);
                reportParameters[1] = new ReportParameter("ReportHasta", fhasta, false);
                reportParameters[2] = new ReportParameter("ReportCliente", Pcliente, false);
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                //envio los parametros
                reportViewer1.LocalReport.SetParameters(reportParameters);
                this.reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("No se encontró información en el Periodo Solicitado");
            }                   
                       
        }
    }
}
