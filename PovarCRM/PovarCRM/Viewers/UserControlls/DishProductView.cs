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

namespace PovarCRM.Viewers.UserControlls
{
    public partial class DishProductView : UserControl
    {
        public DishProductView()
        {
            InitializeComponent();
            UnitTable.AutoGenerateColumns = true;
            DishProductTable.AutoGenerateColumns = false;
            DishProductTable.Columns.Clear();
            //DishProductTable.AllowUserToDeleteRows = false;

            // Id — скрытый
            var idCol = new DataGridViewTextBoxColumn
            {
                Name = "IdColumn",
                DataPropertyName = "Id",
                HeaderText = "Id",
                Visible = false
            };
            DishProductTable.Columns.Add(idCol);


            // Название
            var namingCol = new DataGridViewTextBoxColumn
            {
                Name = "NamingColumn",
                DataPropertyName = "Naming",
                HeaderText = "Название",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            DishProductTable.Columns.Add(namingCol);

            // Стоимость
            var costCol = new DataGridViewTextBoxColumn
            {
                Name = "CostColumn",
                DataPropertyName = "Cost",
                HeaderText = "Цена",
                DefaultCellStyle = { Format = "C2" } // формат валюты
            };
            DishProductTable.Columns.Add(costCol);


            // Вес
            var weightCol = new DataGridViewTextBoxColumn
            {
                Name = "WeightColumn",
                DataPropertyName = "Weight",
                HeaderText = "Вес"
            };
            DishProductTable.Columns.Add(weightCol);

            // Вес
            var unitId = new DataGridViewTextBoxColumn
            {
                Name = "UnitId",
                DataPropertyName = "UnitId",
                HeaderText = "Вес",
                Visible = false
            };
            DishProductTable.Columns.Add(unitId);
        }

        private void splitContainer3_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.UpdateState();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.UpdateState();
        }

        private void DishProductTable_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            int? validatingUnitId = (int?)this.DishProductTable.Rows[e.RowIndex].Cells["UnitId"].Value;
            if (validatingUnitId == null || validatingUnitId == 0)
            {
                e.Cancel = true; // не разрешаем сохранить
                MessageBox.Show("Вы выбрали не сохраненную единицу измерения");
            }
        }

        private void DishProductTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
