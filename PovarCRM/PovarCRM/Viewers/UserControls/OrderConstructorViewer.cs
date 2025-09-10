using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PovarCRM.Models.Views;

namespace PovarCRM.Viewers.UserControls
{
    public partial class OrderConstructorViewer : UserControl
    {
        public OrderConstructorViewer()
        {
            InitializeComponent();

            // запрещает редактировать содержимое
            DishViews.AllowUserToAddRows = false;   // не даёт добавлять строки
            DishViews.AllowUserToDeleteRows = false;

            DishViews.AutoGenerateColumns = false;
            DishViews.Columns.AddRange(new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Номер",
                    DataPropertyName = "Id",
                    Visible = false
                },
                new DataGridViewButtonColumn()
                {
                    HeaderText = "Добавить",
                    Text = "+",
                    UseColumnTextForButtonValue = true,
                    Width = 50
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Блюдо",
                    DataPropertyName = "Naming"
                },
                new DataGridViewCheckBoxColumn()
                {
                    Name = "Picked",
                    HeaderText = "Включено в чек",
                    DataPropertyName = "Picked"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "Count",
                    HeaderText = "Количество",
                    DataPropertyName = "Count",
                    ValueType = typeof(int)
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
                }
            });
            DishViews.CellClick += DishViewsButton_CellClick;
            foreach (DataGridViewColumn col in DishViews.Columns)
            {
                col.ReadOnly = true; // все запретить
            }
            DishViews.Columns["Picked"].ReadOnly = false;
            DishViews.Columns["Count"].ReadOnly = false;

            ////ОБработка исключения блюда из чека
            DishViews.CellValueChanged += (object obj, DataGridViewCellEventArgs arg) =>
            {
                //Смотрим изменился ли флаг
                if (DishViews.Columns[arg.ColumnIndex].DataPropertyName == "Picked" &&
                DishViews[arg.ColumnIndex, arg.RowIndex].Value is bool flag)
                {
                    if (!flag)
                    {
                        DishViews.CurrentCell = DishViews["Count", arg.RowIndex];
                        DishViews.BeginEdit(true);

                        DishViews["Count", arg.RowIndex].Value = 0;
                        //DishViews["Picked", arg.RowIndex].Value = false;
                        DishViews.NotifyCurrentCellDirty(true);
                        DishViews.EndEdit();
                    }
                    //else
                    //{
                    //    DishViews["Count", arg.RowIndex].Value = 1;
                    //}
                    //DishViews.NotifyCurrentCellDirty(true);
                    //DishViews.EndEdit();
                }
            };
            //DishViews.CellValidating += (object obj, DataGridViewCellValidatingEventArgs arg) =>
            //{
            //    //Смотрим изменился ли флаг
            //    if (DishViews.Columns[arg.ColumnIndex].DataPropertyName == "Count")
            //    {
            //        if (!(bool)DishViews["Picked", arg.RowIndex].Value) {
            //            if (arg.FormattedValue is int count)
            //                count = 0;
            //        }
            //        //else
            //        //{
            //        //    DishViews["Count", arg.RowIndex].Value = 1;
            //        //}
            //        //DishViews.NotifyCurrentCellDirty(true);
            //        //DishViews.EndEdit();
            //    }
            //};
        }

        // Обработчик клика на кнопку строки
        private void DishViewsButton_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DishViews.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                if (DishViews["Count", e.RowIndex].Value is int countOfCell)
                {
                    if (DishViews["Picked", e.RowIndex].Value is bool flag)
                    {

                        if (flag)
                        {
                            DishViews.CurrentCell = DishViews["Count", e.RowIndex];
                            DishViews.BeginEdit(true);
                            DishViews["Count", e.RowIndex].Value = countOfCell + 1;
                            DishViews.NotifyCurrentCellDirty(true);
                            DishViews.EndEdit();
                        }
                        else
                        {


                            ////активируем ячейку только перед последним изменением
                            DishViews.CurrentCell = DishViews["Picked", e.RowIndex];
                            //DishViews.BeginEdit(true);

                            //DishViews.NotifyCurrentCellDirty(true);
                            //DishViews.EndEdit();

                            DishViews["Picked", e.RowIndex].Value = true;
                            DishViews["Count", e.RowIndex].Value = 1;
                            //DishViews.CurrentCell = DishViews["Count", e.RowIndex];
                            ////DishViews.BeginEdit(true);

                            ////DishViews.NotifyCurrentCellDirty(true);
                            ////DishViews.EndEdit();

                            //DishViews["Count", e.RowIndex].Value = 1;
                        }
                    }

                }

            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DishViews_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.controller == null)
                return;

            var id = Convert.ToInt32(DishViews[0, e.RowIndex].Value);
            if (id != 0)
            {
                if (id > -1)
                    this.controller.UpdateDishRecipe(id);
            }
            //this.DishViews["Picked", e.RowIndex].Value = true;
        }

        private void DishTypesList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DishViews_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            this.DishViews["Picked", 0].Value = true;
        }

        private void DishViews_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
