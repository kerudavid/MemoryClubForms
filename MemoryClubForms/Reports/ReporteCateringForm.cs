
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
    public partial class ReporteCateringForm : Form
    {
        public ReporteCateringForm()
        {
            InitializeComponent();
        }

        private void ReporteCateringForm_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            string fdesde = this.dtpDesde.Value.ToString("dd/MM/yyyy");
            string fhasta = this.dtpHasta.Value.ToString("dd/MM/yyyy");

            ReporteCateringBO reporCateBO = new ReporteCateringBO();
            List<ReporteCateringModel> rcmList = new List<ReporteCateringModel>();
            rcmList = reporCateBO.LoadReporteCatering(fdesde, fhasta);

            if (rcmList.Count > 0)
            {
                //asigno la lista al reporte
                ReportDataSource rds = new ReportDataSource("ReporteCatering", rcmList);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "MemoryClubForms.Reports.ReporteCatering.rdlc";
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
                MessageBox.Show("No se encontraron datos de Catering para el periodo seleccionado");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
