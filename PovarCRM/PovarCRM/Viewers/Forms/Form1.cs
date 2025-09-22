using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using PovarCRM.Models;
using PovarCRM.UIcontrollers;
using PovarCRM.Viewers;
using PovarCRM.Viewers.UserControlls;

namespace PovarCRM
{
    public partial class Form1 : Form
    {
        BindingList<OrderCheck> binCtrlOrderChecks;
        CheckListViewController checkListController;
        ServingOrdersController servingOrdersController1;
        DishMenuController dishMenuController1;

        public Form1(CheckListViewController checkListController)
        {

            InitializeComponent();
            // Временно создаёт "пустой" объект, чтобы дизайнер не падал
            //this.checkListController = null!;
            // this.binCtrlOrderChecks = new BindingList<OrderCheck>();
            this.checkListController = checkListController;
            this.checkListController.InitListBoxController(listBox1, comboBox1, button3, button1);

            this.binCtrlOrderChecks = this.checkListController.GetBinControllingList;



            // Дополнительно: если нужно привязать биндинг к DataGridView
            dataGridView1.DataSource = binCtrlOrderChecks;
            dataGridView1.ReadOnly = true;

            //ServingOrdersPart
            servingOrdersController1 = new ServingOrdersController();
            servingOrdersViewer1.InitController(servingOrdersController1);

            //DishMenu Part
            dishMenuController1 = new DishMenuController();
            dishMenu1.InitDependecies(dishMenuController1);


        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            this.checkListController.HighestNumDishesConstraint = (int)numericUpDown2.Value;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.checkListController.StartDatePoint = dateTimePicker1.Value;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            this.checkListController.LowerNumItemConstraint = (int)numericUpDown5.Value;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                button3.Visible = true;
            }
            else
            {
                button3.Visible = false;
            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            this.checkListController.EndDatePoint = dateTimePicker2.Value;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            this.checkListController.LowerMoneyConstraint = numericUpDown3.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.checkListController.HighestMoneyConstraint = numericUpDown1.Value;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            this.checkListController.LowerNumDishesConstraint = (int)numericUpDown4.Value;
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            this.checkListController.HighestNumItemConstraint = (int)numericUpDown6.Value;
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            this.checkListController.CheckId = (int)numericUpDown7.Value;
        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            this.checkListController.ClientName = textBox1.Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                numericUpDown7.Enabled = true;
            }
            else
            {
                numericUpDown7.Enabled = false;
                numericUpDown7.Value = -1;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                this.textBox1.Enabled = true;
            }
            else
            {
                this.textBox1.Text = null;
                this.textBox1.Enabled = false;
            }
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    this.checkListController.AddFromComboBoxToListBox((Dish)comboBox1.SelectedItem);
        //}

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.checkListController._DishPicker.DeleteFromListBox();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            //this.checkListController.UpdateListComboBox();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {

        }

        private void mainTabControl_Selected(object sender, TabControlEventArgs e)
        {
            checkListController.UpdateState();
        }

        private void label11_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OrdersDataTable_Click(object sender, EventArgs e)
        {
            Label label = new Label();
            label.Text = "Give me love";
            label.Visible = true;
        }

        private void OrdersDataTable_RowDividerDoubleClick(object sender, DataGridViewRowDividerDoubleClickEventArgs e)
        {

        }

        private void OrdersDataTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage4_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        private void servingOrdersViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (mainTabControl.SelectedTab.Text == "Serving orders")
                this.servingOrdersController1?.onUpdateState();

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
        }
    }
}