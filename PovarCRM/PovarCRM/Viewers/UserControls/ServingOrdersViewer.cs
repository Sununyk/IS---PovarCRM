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
    public partial class ServingOrdersViewer : UserControl
    {
        public ServingOrdersViewer()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Layout(object sender, LayoutEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button clicked!");
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var form = new ConfirmationForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Здесь будет выполнение кода после того, как форма закроется с OK
                    if (form.YesOrNo == false)
                        return;

                }
            }
        }

        private void CompleteButton_Click(object sender, EventArgs e)
        {
            using (var form = new ConfirmationForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Здесь будет выполнение кода после того, как форма закроется с OK
                    if (form.YesOrNo == false)
                        return;

                }
            }
        }
    }
}
