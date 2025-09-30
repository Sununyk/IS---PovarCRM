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
using PovarCRM.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace PovarCRM.Viewers.Forms
{
    public partial class DishConstructor : Form
    {
        public DishConstructor()
        {
            InitializeComponent();
            // Очищаем авто-созданные колонки
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();



            // Создаём колонку для Id блюда
            var dishIdColumn = new DataGridViewTextBoxColumn();
            dishIdColumn.Name = "DishId";
            dishIdColumn.HeaderText = "DishId";
            dishIdColumn.DataPropertyName = "DishId"; // если есть привязка к модели
            dishIdColumn.Visible = false; // скрыта от пользователя

            // Создаём колонку для Id продукта
            var productIdColumn = new DataGridViewTextBoxColumn();
            productIdColumn.Name = "DishProductId";
            productIdColumn.HeaderText = "DishProductId";
            productIdColumn.DataPropertyName = "DishProductId";
            productIdColumn.Visible = false;

            // Добавляем в dataGridView1
            dataGridView1.Columns.Add(dishIdColumn);
            dataGridView1.Columns.Add(productIdColumn);


            // Колонка: Название продукта
            colProduct.DataPropertyName = "DishProductNaming";
            colProduct.HeaderText = "Название ингредиента";

            dataGridView1.Columns.Add(colProduct);

            // Колонка: Кол-во единиц
            var colCount = new DataGridViewTextBoxColumn();
            colCount.DataPropertyName = "CountOfUnits";
            colCount.HeaderText = "Кол-во";
            colCount.Name = "CountOfUnits";

            dataGridView1.Columns.Add(colCount);

            // Колонка: Единица измерения (ComboBox)
            var colUnit = new DataGridViewTextBoxColumn();
            colUnit.DataPropertyName = "UnitNaming";
            colUnit.HeaderText = "Ед. изм.";
            colUnit.Name = "Units";
            colUnit.ReadOnly = true;


            dataGridView1.Columns.Add(colUnit);

            // Колонка: Вес
            var colWeight = new DataGridViewTextBoxColumn();
            colWeight.DataPropertyName = "Weight";
            colWeight.HeaderText = "Вес (гр.)";
            dataGridView1.Columns.Add(colWeight);
            colWeight.ReadOnly = true;

            // Привязываем список моделей
            // например, если у тебя есть коллекция recipeViews
            // dataGridView1.DataSource = recipeViews;
        }

        private void splitContainer4_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer5_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void splitContainer5_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
        }

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var dgv = sender as DataGridView;
            var row = dgv.Rows[e.RowIndex];

            // Проверяем "Продукт"
            var productCell = row.Cells["DishProductNaming"];
            if (string.IsNullOrWhiteSpace(Convert.ToString(productCell.Value)))
            {
                MessageBox.Show("Поле 'Название ингредиента' обязательно для заполнения");
                e.Cancel = true;
                return; // сразу выходим, чтобы не показывать несколько MessageBox подряд
            }

            // Проверяем Units (чтобы не было null)
            var unitsCell = row.Cells["Units"];
            if (unitsCell.Value == null)
            {
                MessageBox.Show("You cannot complete adding without DishType input value of new recipe");
                e.Cancel = true;
            }





        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["CountOfUnits"].Value = 1.0f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isCompleted = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isCompleted = false;
            Close();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            //if (row.Cells["DishId"].Value == null)
            //    return;
            //if ((int)row.Cells["DishId"].Value != null || (int)row.Cells["DishId"].Value <= 0 )
            //    row.Cells["DishId"].Value = this.creatingDish.Id;

        }
    }
}
