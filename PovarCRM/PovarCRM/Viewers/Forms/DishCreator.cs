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
using PovarCRM.UIcontrollers;
using PovarCRM.UIelements;
using PovarCRM.Viewers.UserControlls;

namespace PovarCRM.Viewers.Forms
{
    public partial class DishCreator : Form
    {
        public DishCreator(UnitOfWork unit, BindingListEx<Dish> dishes, List<DishType> dishTypes)
        {
            InitializeComponent();
            this.unit = unit;

            numericUpDown1.DecimalPlaces = 2;   // количество знаков после запятой
            numericUpDown1.Minimum = 0;         // минимальное значение
            numericUpDown1.Maximum = 1000;      // максимальное значение
            numericUpDown1.Increment = 0.1M;

            this.listDishes = dishes;
            this.dishTypes = dishTypes.ToList();

            comboBox1.DataSource = this.dishTypes.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.CreatNewDish();
            this.Close();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text.Length <= 2)
            {
                e.Cancel = true;
                MessageBox.Show("Name length must be more 2");
            }
            else if(listDishes.ToList<Dish>().Find(
                x => {if(x.Naming == textBox1.Text)
                        return true; 
                    return false; }) != null)
            {
                e.Cancel = true;
                MessageBox.Show("This name yeat existing");
            }
        }
        private Dish creatingDish;
        private BindingListEx<Dish>? listDishes = null;
        private List<DishType>? dishTypes = null;
    }
}
