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
    public partial class FormReporteClientePlan : Form
    {
        public FormReporteClientePlan()
        {
            InitializeComponent();
        }

        public void FormReporteClientePlan_Load(object sender, EventArgs e)
        {
            ReporteClientePlanBO reporcliplan = new ReporteClientePlanBO();
            List<ReporteClientePlanModel> rcplist = new List<ReporteClientePlanModel>();
            rcplist = reporcliplan.LoadReporteClientePlan();

            ReportDataSource rds = new ReportDataSource("ReporteClientePlan", rcplist);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MemoryClubForms.Reports.ReporteClientePlan.rdlc";
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
