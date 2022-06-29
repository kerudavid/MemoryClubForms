using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryClubForms.Forms
{
    public partial class CateringForm : Form
    {
        public CateringForm()
        {
            InitializeComponent();
        }

        private void btnClose_Clicked(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
