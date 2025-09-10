using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PovarCRM.UIcontrollers;

namespace PovarCRM.Viewers
{
    public partial class Menu : Form
    {
        public Menu(MenuController controller)
        {
            InitializeComponent();

            this.controller = controller;
            this.commandManagerViewer1.InitDependency(controller.CommandManager);
            this.orderConstructorViewer1.InitDependecies(controller.OrderConstructor);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void orderConstructorViewer1_Load(object sender, EventArgs e)
        {

        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.controller.Close(false);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.controller.UpdateState();
            //this.controller.Close(true);
            //this.Close();
        }
    }
}
