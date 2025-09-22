using System.Windows.Forms;
using PovarCRM.Models;
using PovarCRM.Models.Views;
using PovarCRM.UIcontrollers;
using PovarCRM.UIcontrollers.UImembers;
using PovarCRM.UIelements;

namespace PovarCRM.Viewers.UserControls
{
    partial class OrderConstructorViewer : IUpdateMember
    {
        public event BindingListEx<DishView>.FilterChanged filterChanged;
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public void InitDependecies(OrderConstructorController controller)
        {
            this.controller = controller;
            controller.AddUpdateMember(this);
            //DishTypesList.DataBindings.Add("Text", controller.InitDishTypes(), "Naming");
            
            dishTypes = controller.InitDishTypes();
            radioButtonList1.InitDataSourse(controller.InitDishTypes().ToList<object>());
            //radioButtonList1.RadioButtonClickedCommand += dishTypes.OnViewCommandPackToExec;

            DishRecipeViews.DataSource = controller.InitDishRecipeViews();

            dishViewsFilter = controller.InitDishViews();
            this.filterChanged += dishViewsFilter.OnFilterChange;
            DishViews.DataSource = dishViewsFilter;
            DishViews.CellValidating += controller.InitDishViews().OnValueValidating;

            label3.Text = controller.NewOrderCheck.ToString();


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
            splitContainer1 = new SplitContainer();
            splitContainer3 = new SplitContainer();
            label1 = new Label();
            radioButtonList1 = new RadioButtonList();
            splitContainer2 = new SplitContainer();
            label3 = new Label();
            label2 = new Label();
            Dishes = new TabControl();
            tabPage1 = new TabPage();
            DishViews = new DataGridView();
            tabPage2 = new TabPage();
            DishRecipeViews = new DataGridView();
            Column1 = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            Dishes.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DishViews).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DishRecipeViews).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(505, 411);
            splitContainer1.SplitterDistance = 168;
            splitContainer1.TabIndex = 0;
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
            splitContainer3.Panel1.Controls.Add(label1);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(radioButtonList1);
            splitContainer3.Size = new Size(168, 411);
            splitContainer3.SplitterDistance = 101;
            splitContainer3.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 37);
            label1.Name = "label1";
            label1.Size = new Size(96, 20);
            label1.TabIndex = 0;
            label1.Text = "DishChapters";
            label1.Click += label1_Click;
            // 
            // radioButtonList1
            // 
            radioButtonList1.Location = new Point(3, 3);
            radioButtonList1.Name = "radioButtonList1";
            radioButtonList1.Size = new Size(167, 188);
            radioButtonList1.TabIndex = 0;
            radioButtonList1.SelectedIndexChanged += radioButtonList1_SelectedIndexChanged;
            radioButtonList1.Load += radioButtonList1_Load;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(label3);
            splitContainer2.Panel1.Controls.Add(label2);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(Dishes);
            splitContainer2.Size = new Size(333, 411);
            splitContainer2.SplitterDistance = 87;
            splitContainer2.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(110, 37);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 1;
            label3.Text = "label3";
            label3.Click += label3_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 37);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 0;
            label2.Text = "New orderID:";
            label2.Click += label2_Click;
            // 
            // Dishes
            // 
            Dishes.Controls.Add(tabPage1);
            Dishes.Controls.Add(tabPage2);
            Dishes.Dock = DockStyle.Fill;
            Dishes.Location = new Point(0, 0);
            Dishes.Name = "Dishes";
            Dishes.SelectedIndex = 0;
            Dishes.Size = new Size(333, 320);
            Dishes.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(DishViews);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(325, 287);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Dishes";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // DishViews
            // 
            DishViews.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DishViews.Dock = DockStyle.Fill;
            DishViews.Location = new Point(3, 3);
            DishViews.Name = "DishViews";
            DishViews.RowHeadersWidth = 51;
            DishViews.Size = new Size(319, 281);
            DishViews.TabIndex = 0;
            DishViews.CellClick += DishViews_CellClick;
            DishViews.CellContentClick += DishViews_CellContentClick;
            DishViews.RowEnter += DishViews_RowEnter;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(DishRecipeViews);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(325, 287);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Ingredients";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // DishRecipeViews
            // 
            DishRecipeViews.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DishRecipeViews.Dock = DockStyle.Fill;
            DishRecipeViews.Location = new Point(3, 3);
            DishRecipeViews.Name = "DishRecipeViews";
            DishRecipeViews.RowHeadersWidth = 51;
            DishRecipeViews.Size = new Size(319, 281);
            DishRecipeViews.TabIndex = 0;
            // 
            // Column1
            // 
            Column1.HeaderText = "Column1";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
            // 
            // OrderConstructorViewer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "OrderConstructorViewer";
            Size = new Size(505, 411);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel1.PerformLayout();
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            Dishes.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DishViews).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DishRecipeViews).EndInit();
            ResumeLayout(false);
        }

        public void onUpdateState()
        {
            //DishViews.DataSource = null;
            //DishViews.DataSource = dishViewsFilter;
        }

        #endregion


        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private Label label1;
        private Label label2;
        private TabControl Dishes;
        private TabPage tabPage1;
        private TabPage tabPage2;

        private DataGridView DishViews;
        private BindingListEx<DishView> dishViewsFilter;

        private DataGridView DishRecipeViews;
        private OrderConstructorController? controller;

        private Label label3;
        private DataGridViewButtonColumn Column1;
        private RadioButtonList radioButtonList1;

        private BindingListEx<DishType> dishTypes;
        private int selectedDishTypeId;
    }
}
