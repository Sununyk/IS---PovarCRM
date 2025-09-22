using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PovarCRM.Models;
using PovarCRM.Models.Views;
using PovarCRM.Repositories;
using PovarCRM.UIcontrollers;
using PovarCRM.Viewers.Forms;

namespace PovarCRM.Viewers.UserControlls
{
    public partial class DishMenu : UserControl
    {
        public DishMenu()
        {
            InitializeComponent();

            dishTable.AutoGenerateColumns = false;
            dishTable.AllowUserToAddRows = false;   // не даёт добавлять строки
            dishTable.AllowUserToDeleteRows = false;


            // dataGridView2.AutoGenerateColumns = false;
            dataGridView2.AllowUserToAddRows = false;   // не даёт добавлять строки
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AutoGenerateColumns = false;


            dishTable.Columns.AddRange(
            new DataGridViewTextBoxColumn()
            {
                Name = "DishId",
                HeaderText = "Id",
                DataPropertyName = "Id"
            },
            new DataGridViewTextBoxColumn()
            {
                HeaderText = "Блюдо",
                DataPropertyName = "Naming"
            },
            new DataGridViewTextBoxColumn()
            {
                HeaderText = "Цена",
                DataPropertyName = "Cost",
                DefaultCellStyle = { Format = "C2" } // красиво форматирует как валюту
            },
            new DataGridViewTextBoxColumn()
            {
                Name = "Weight",
                HeaderText = "Вес",
                DataPropertyName = "Weight"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = "DishType",
                HeaderText = "Тип",
                DataPropertyName = "DishType"
            });
            dishTable.Columns[0].Visible = false;




            dataGridView2.Columns.Clear();
            // Наименование продукта
            var colProduct = new DataGridViewTextBoxColumn
            {
                HeaderText = "Продукт",
                DataPropertyName = nameof(DishRecipeView.DishProductNaming),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dataGridView2.Columns.Add(colProduct);

            // Количество
            var colCount = new DataGridViewTextBoxColumn
            {
                HeaderText = "Количество",
                DataPropertyName = nameof(DishRecipeView.CountOfUnits),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dataGridView2.Columns.Add(colCount);

            // Единица измерения
            var colUnit = new DataGridViewTextBoxColumn
            {
                HeaderText = "Ед. изм.",
                DataPropertyName = nameof(DishRecipeView.UnitNaming),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dataGridView2.Columns.Add(colUnit);

            // Вес
            var colWeight = new DataGridViewTextBoxColumn
            {
                HeaderText = "Вес",
                DataPropertyName = nameof(DishRecipeView.Weight),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dataGridView2.Columns.Add(colWeight);


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
        // int selectedDishRow = -1;
        private void button2_Click(object sender, EventArgs e)
        {
            var yesno = new ConfirmationForm();
            bool flag = false;
            if (yesno.ShowDialog() == DialogResult.OK)
            {
            }
            flag = yesno.YesOrNo ?? false;
            if (dishTable.SelectedRows.Count > 0 && flag)
            {
                this.controller.Unit.Dishes.Delete((int)dishTable.SelectedRows[0].Cells[0].Value);
                this.controller.UpdateState();
            }
            else
            {
                MessageBox.Show("No one selected Rows");
            }
        }

        private void radioButtonList1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.controller == null)
                return;

            var id = Convert.ToInt32(dishTable[0, e.RowIndex].Value);
            if (id != 0)
            {
                if (id > -1)
                {
                    this.controller.UpdateRecipes(id);
                    this.button3.Enabled = true;
                    this.button2.Enabled = true;
                }
                else
                {
                    this.button3.Enabled = false;
                    this.button2.Enabled = false;
                }
            }

            //selectedDishRow = e.RowIndex;
        }

        private void splitContainer3_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            DishCreator dishCreator = new DishCreator(this.controller.Unit, controller.initDishes(), controller.initDishTypeList());

            dishCreator.ShowDialog();

            this.controller.UpdateState();

            using (var menu = new DishConstructor())
            {
                var controller = this.controller.BuildDishConstructorConstroller();
                controller.AddUpdateMember(this.controller);

                menu.InitDependencies(controller);
                menu.ShowDialog();


            }




        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer5_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        //private void UpdateExistDishParam(Dish newDish)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
