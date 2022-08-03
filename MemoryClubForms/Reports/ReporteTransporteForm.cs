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
    public partial class ReporteTransporteForm : Form
    {
        public ReporteTransporteForm()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            string fdesde = this.dtpDesde.Value.ToString("dd/MM/yyyy");
            string fhasta = this.dtpHasta.Value.ToString("dd/MM/yyyy");

            ReporteTransporteBO reporTranspBO = new ReporteTransporteBO();
            List<ReporteTransporteModel> rtmList = new List<ReporteTransporteModel>();
            rtmList = reporTranspBO.LoadReporteTransporte(fdesde, fhasta);

            if (rtmList.Count > 0)
            {
                //asigno la lista al reporte
                ReportDataSource rds = new ReportDataSource("ReporteTransporte", rtmList);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "MemoryClubForms.Reports.ReporteTransporte.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rds);
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
