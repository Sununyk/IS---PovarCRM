using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PovarCRM.Viewers.UserControls
{
    public partial class CommandManagerViewer
    {

        public CommandManagerViewer()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            if (this.IsDisposed || tableLayoutPanel1.IsDisposed) return;

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.controller != null)
            {
                controller.Undo();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.controller != null)
            {
                controller.Redo();
            }
        }
    }
}
