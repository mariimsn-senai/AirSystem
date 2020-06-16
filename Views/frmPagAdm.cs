using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirSystem2.Views
{
    public partial class frmPagAdm : Form
    {
        public frmPagAdm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmListarUsuarios().ShowDialog();
        }

        private void frmPagAdm_Load(object sender, EventArgs e)
        {

        }
    }
}
