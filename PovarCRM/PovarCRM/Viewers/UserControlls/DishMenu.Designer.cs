using System.ComponentModel;
using PovarCRM.Models;
using PovarCRM.Models.Views;
using PovarCRM.UIcontrollers;
using PovarCRM.UIelements;

namespace PovarCRM.Viewers.UserControlls
{
    partial class DishMenu
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public void InitDependecies(DishMenuController controller)
        {
            this.controller = controller;
            //data extract
            dishList = controller.initDishes();
            dishRecipeViewList = controller.initDishRecipeView();
            dishTypeList = controller.initDishTypeList();
            
            //data binding
            radioButtonList1.InitDataSourse(dishTypeList.ToList<object>());
            dishTable.DataSource = dishList;
            dataGridView2.DataSource = dishRecipeViewList;


            //filtering
            radioButtonList1.SelectedRowIdChanged += (sender, command, rowId) => { 
                dishList.ApplyFilter((dish) => {
                    if (dish.DishTypeId == null)
                        return false;
                    if (rowId < 0)
                        return true;
                    
                    if(dish.DishType == null)
                    {
                        dish.DishType = this.controller.Unit.DishTypes.GetByID(dish.DishTypeId ?? 1);
                    }
                    if (dish.DishType.Naming == this.dishTypeList[rowId].Naming)
                        return true;
                    else
                        return false;
                });
                dishList.ResetFilter();
            };
            this.controller.UpdateState();

            dishTable.Columns[0].Visible = false;

        }
        
        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            dishTable = new DataGridView();
            dataGridView2 = new DataGridView();
            label2 = new Label();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            splitContainer3 = new SplitContainer();
            splitContainer4 = new SplitContainer();
            button2 = new Button();
            button3 = new Button();
            splitContainer5 = new SplitContainer();
            label3 = new Label();
            button1 = new Button();
            radioButtonList1 = new PovarCRM.Viewers.UserControls.RadioButtonList();
            ((ISupportInitialize)dishTable).BeginInit();
            ((ISupportInitialize)dataGridView2).BeginInit();
            ((ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
            ((ISupportInitialize)splitContainer5).BeginInit();
            splitContainer5.Panel1.SuspendLayout();
            splitContainer5.Panel2.SuspendLayout();
            splitContainer5.SuspendLayout();
            SuspendLayout();
            // 
            // dishTable
            // 
            dishTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dishTable.Dock = DockStyle.Fill;
            dishTable.Location = new Point(0, 0);
            dishTable.Name = "dishTable";
            dishTable.RowHeadersWidth = 51;
            dishTable.Size = new Size(246, 475);
            dishTable.TabIndex = 0;
            dishTable.CellContentClick += dataGridView1_CellContentClick;
            dishTable.RowEnter += dataGridView1_RowEnter;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Location = new Point(0, 0);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(325, 474);
            dataGridView2.TabIndex = 1;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(115, 7);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 3;
            label2.Text = "DishRecipe";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(button1);
            splitContainer1.Panel2.Controls.Add(radioButtonList1);
            splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitContainer1.Size = new Size(745, 513);
            splitContainer1.SplitterDistance = 575;
            splitContainer1.TabIndex = 4;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(splitContainer5);
            splitContainer2.Size = new Size(575, 513);
            splitContainer2.SplitterDistance = 246;
            splitContainer2.TabIndex = 0;
            splitContainer2.SplitterMoved += splitContainer2_SplitterMoved;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            splitContainer3.Orientation = Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(dishTable);
            splitContainer3.Size = new Size(246, 513);
            splitContainer3.SplitterDistance = 34;
            splitContainer3.TabIndex = 5;
            splitContainer3.SplitterMoved += splitContainer3_SplitterMoved;
            // 
            // splitContainer4
            // 
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.Location = new Point(0, 0);
            splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(button2);
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(button3);
            splitContainer4.Size = new Size(246, 34);
            splitContainer4.SplitterDistance = 120;
            splitContainer4.TabIndex = 0;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Fill;
            button2.Enabled = false;
            button2.Location = new Point(0, 0);
            button2.Name = "button2";
            button2.Size = new Size(120, 34);
            button2.TabIndex = 3;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Fill;
            button3.Location = new Point(0, 0);
            button3.Name = "button3";
            button3.Size = new Size(122, 34);
            button3.TabIndex = 4;
            button3.Text = "Update";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // splitContainer5
            // 
            splitContainer5.Dock = DockStyle.Fill;
            splitContainer5.Location = new Point(0, 0);
            splitContainer5.Name = "splitContainer5";
            splitContainer5.Orientation = Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            splitContainer5.Panel1.Controls.Add(label2);
            // 
            // splitContainer5.Panel2
            // 
            splitContainer5.Panel2.Controls.Add(dataGridView2);
            splitContainer5.Size = new Size(325, 513);
            splitContainer5.SplitterDistance = 35;
            splitContainer5.TabIndex = 4;
            splitContainer5.SplitterMoved += splitContainer5_SplitterMoved;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(3, 166);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 2;
            label3.Text = "Dish Types";
            // 
            // button1
            // 
            button1.Location = new Point(3, -1);
            button1.Name = "button1";
            button1.Size = new Size(163, 75);
            button1.TabIndex = 1;
            button1.Text = "Add Dish";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // radioButtonList1
            // 
            radioButtonList1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            radioButtonList1.Location = new Point(2, 189);
            radioButtonList1.Name = "radioButtonList1";
            radioButtonList1.Size = new Size(161, 321);
            radioButtonList1.TabIndex = 0;
            radioButtonList1.Load += radioButtonList1_Load;
            // 
            // DishMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "DishMenu";
            Size = new Size(745, 513);
            ((ISupportInitialize)dishTable).EndInit();
            ((ISupportInitialize)dataGridView2).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel2.ResumeLayout(false);
            ((ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            splitContainer5.Panel1.ResumeLayout(false);
            splitContainer5.Panel1.PerformLayout();
            splitContainer5.Panel2.ResumeLayout(false);
            ((ISupportInitialize)splitContainer5).EndInit();
            splitContainer5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DishMenuController controller;

        private DataGridView dishTable;
        private BindingListEx<Dish> dishList;
        private DataGridView dataGridView2;
        private BindingListEx<DishRecipeView> dishRecipeViewList;
        private UserControls.RadioButtonList radioButtonList1;
        private List<DishType> dishTypeList;
        private Label label2;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private Label label3;
        private Button button1;
        
        //private List<DishType> dishTypeList;

        private Button button2;
        private Button button3;
        private SplitContainer splitContainer3;
        private SplitContainer splitContainer4;
        private SplitContainer splitContainer5;
    }
}
