using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PovarCRM.Viewers
{
    public partial class ConfirmationForm : Form
    {
        public ConfirmationForm()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            this.YesOrNo = true;
            this.Close();
        }

        private void DeniedButton_Click(object sender, EventArgs e)
        {
            this.YesOrNo = false;
            this.Close();
        }
    }
}
