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
    public partial class InsertarClienteForm : Form
    {
        public InsertarClienteForm()
        {
            InitializeComponent();
        }
        public void LoadInformation()
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
