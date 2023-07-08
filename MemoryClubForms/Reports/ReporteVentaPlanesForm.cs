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
    //Presenta los planes de dos meses y un mes anterior a hoy
    public partial class ReporteVentaPlanesForm : Form
    {
        CultureInfo ci = new CultureInfo("en-US");
        public ReporteVentaPlanesForm()
        {
            InitializeComponent();
        }

        private void ReporteVentaPlanesForm_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            ckbFiltrarFechas.Checked = false;
            dtpHasta.Enabled = false;
            dtpDesde.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            string fdesde = "";
            string fhasta = "";
            if (ckbFiltrarFechas.Checked == true)
            {
                fdesde = this.dtpDesde.Value.ToString("MM/dd/yyyy", ci);
                fhasta = this.dtpHasta.Value.ToString("MM/dd/yyyy", ci);
            }

            string estado = "";
            if (rbtn_vigentes.Checked)
            {
                estado = "VIGENTE";
            }
            if (rbtn_todos.Checked)
            {
                estado = "";
            }

            if (fdesde == "" & fhasta == "" & estado == "")
            {
                MessageBox.Show("Debe seleccionar un periodo de fechas y/o cambiar el estado a VIGENTES");
                return;
            }
            
            //genero la lista desde la consulta ventas planes anteriores
            ReporteVtaMesBO reporteVentasBO = new ReporteVtaMesBO();
            List<ReporteVtaMesAntModel> repVtaMesAntList = new List<ReporteVtaMesAntModel>();
            repVtaMesAntList = reporteVentasBO.LoadReporteVtaMesAnt(fdesde, fhasta, estado);

            if (repVtaMesAntList.Count > 0)
            {
                //asigno la lista al reporte vtas penúltimo plan
                ReportDataSource rds = new ReportDataSource("ReporteVtaMesAnt", repVtaMesAntList);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "MemoryClubForms.Reports.ReporteVtaMesAnt.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();
                //añado los parámetros
                ReportParameter[] reportParameters = new ReportParameter[3];
                //reportParameters[0] = new ReportParameter("NombreParametro", "VALOR DE TU PARAMETRO", false); EJEMPLO
                reportParameters[0] = new ReportParameter("ReportDesde", fdesde, false);
                reportParameters[1] = new ReportParameter("ReportHasta", fhasta, false);
                reportParameters[2] = new ReportParameter("ReportEstado", estado, false);
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                //envio los parametros
                reportViewer1.LocalReport.SetParameters(reportParameters);
                this.reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("No se encontraron datos de los Planes anteriores");
            }

            //genero la lista desde la consulta del último plan del periodo
            List<ReporteVentasModel> reporteventasList = new List<ReporteVentasModel>();
            reporteventasList = reporteVentasBO.LoadReporteVentas(fdesde, fhasta, estado);
            
            if (reporteventasList.Count > 0)
            { 
                //asigno la lista al reporte vtas de los últimos planes
                ReportDataSource aux = new ReportDataSource("ReporteVentas", reporteventasList);
                this.reportViewer2.LocalReport.ReportEmbeddedResource = "MemoryClubForms.Reports.ReporteVentas.rdlc";
                this.reportViewer2.LocalReport.DataSources.Clear();
                //añado los parámetros
                ReportParameter[] reportParameters2 = new ReportParameter[3];
                //reportParameters[0] = new ReportParameter("NombreParametro", "VALOR DE TU PARAMETRO", false); EJEMPLO
                reportParameters2[0] = new ReportParameter("ReportDesde", fdesde, false);
                reportParameters2[1] = new ReportParameter("ReportHasta", fhasta, false);
                reportParameters2[2] = new ReportParameter("ReportEstado", estado, false);
                this.reportViewer2.LocalReport.DataSources.Add(aux);
                //envio los parametros
                reportViewer2.LocalReport.SetParameters(reportParameters2);
                this.reportViewer2.RefreshReport();               
            }
            else
            {
                MessageBox.Show("No se encontraron datos de los Planes en el Periodo Solicitado");
            }
        }

        private void ckbFiltrarFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbFiltrarFechas.Checked)
            {
                dtpHasta.Enabled = true;
                dtpDesde.Enabled = true;
            }
            else
            {
                dtpHasta.Enabled = false;
                dtpDesde.Enabled = false;
            }
        }

        private void rbtn_todos_CheckedChanged(object sender, EventArgs e)
        {
            rbtn_vigentes.Checked = false;
        }

        private void rbtn_vigentes_CheckedChanged(object sender, EventArgs e)
        {
            rbtn_todos.Checked = false;
        }
    }
}
