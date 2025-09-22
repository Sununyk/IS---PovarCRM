using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Identity.Client;
using PovarCRM.Models;
using PovarCRM.Repositories;
using PovarCRM.Repositories.CommandsLogic;
using PovarCRM.UIcontrollers;
using PovarCRM.UIcontrollers.UImembers;
using PovarCRM.Viewers.Forms;

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
            string clientName = "";

            using (var form = new ConfirmAndInputForm())
            {
                form.KeyDown += (object obj, KeyEventArgs args) => {
                    if (args.KeyCode == Keys.Enter) clientName = form.ClientNaming;
                };
                if (form.ShowDialog() == DialogResult.OK)
                {
                }

            }

            int newOrderId = this.controller.CreatOrderCheck(clientName);

            MenuController controller = new MenuController(this.controller.Unit, UIcontrollers.MenuMode.OrderConstructor, newOrderId);
            controller.AddUpdateMember(this.controller);


            using (Menu menu = new Menu(controller))
            {
                if (menu.ShowDialog() == DialogResult.OK)
                {
                    // Здесь будет выполнение кода после того, как форма закроется с OK
                    //Сохраняем временный контекст в настоящий контекст
                    this.controller.Unit.Save();

                }
            }

            if (!controller.OrderComplete)
                this.controller.Unit.OrderChecks.Delete(this.controller.Unit.OrderChecks.GetByID(newOrderId));
            this.controller.Unit.Save(); 
        }
        //private void button1_Click_1(object sender, EventArgs e)
        //{
        //    // Создаём новый поток для другой формы
        //    Thread thread = new(args =>
        //    {
        //        if (args is UIcontrollers.MenuThreadArguments menuArgs)
        //        {
        //            MenuController controller = new MenuController(UIcontrollers.MenuMode.OrderConstructor);
        //            controller.SubscribeContextMembers(menuArgs.ContextMembers);

        //            Menu menu = new Menu(controller);
        //            Application.Run(menu); // Запускаем цикл сообщений для этой формы
        //        }
        //    });
        //    thread.SetApartmentState(ApartmentState.STA);

        //    List<(SynchronizationContext, IUpdateMember)> contextMember = new List<(SynchronizationContext, IUpdateMember)> {(SynchronizationContext.Current, (IUpdateMember)this.controller)};

        //    MenuThreadArguments args = new MenuThreadArguments { 
        //        ContextMembers = contextMember,
        //    };
        //    thread.Start(args);
        //}

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

        private void ordersTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ordersTable_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (ordersTable.Rows.Count <= 0)
                return;

            this.selectedDishId = (int)ordersTable[0, e.RowIndex].Value;
            this.controller.onSelectedOrderId(selectedDishId);
            try
            {
                itemsTable.Columns["DishWeight"].DefaultCellStyle.Format = "0\" грамм\"";
            }
            catch (Exception ex) { }
        }
    }
}
