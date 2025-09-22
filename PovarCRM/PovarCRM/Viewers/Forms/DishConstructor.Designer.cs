using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PovarCRM.Models;
using PovarCRM.Models.Views;
using PovarCRM.UIcontrollers;
using PovarCRM.UIelements;

namespace PovarCRM.Viewers.Forms
{
    partial class DishConstructor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        public void InitDependencies(DishConstructorController controller)
        {
            var data = controller.InitData();

            this.dataGridView1.DataSource = data.recipeViews;
            this.units = data.Units;
            this.products = data.Products;
            this.creatingDish = data.newDish;

            //для выпадающего списка продуктов
            colProduct.DataSource = this.products;
            colProduct.Name = "DishProductNaming";
            colProduct.DisplayMember = nameof(DishProduct.Naming);
            colProduct.ValueMember = nameof(DishProduct.Naming);
           
        }
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            button2 = new Button();
            button1 = new Button();
            splitContainer5 = new SplitContainer();
            label5 = new Label();
            dataGridView1 = new DataGridView();
            ((ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((ISupportInitialize)splitContainer5).BeginInit();
            splitContainer5.Panel1.SuspendLayout();
            splitContainer5.Panel2.SuspendLayout();
            splitContainer5.SuspendLayout();
            ((ISupportInitialize)dataGridView1).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer5);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 113;
            splitContainer1.TabIndex = 0;
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
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
            splitContainer2.Panel1.Controls.Add(button2);
            splitContainer2.Panel1.Controls.Add(button1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Paint += splitContainer2_Panel2_Paint;
            splitContainer2.Size = new Size(113, 450);
            splitContainer2.SplitterDistance = 77;
            splitContainer2.TabIndex = 0;
            // 
            // button2
            // 
            button2.Location = new Point(3, 41);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 1;
            button2.Text = "Denied";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Complete";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
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
            splitContainer5.Panel1.Controls.Add(label5);
            splitContainer5.Panel1.Paint += splitContainer5_Panel1_Paint;
            // 
            // splitContainer5.Panel2
            // 
            splitContainer5.Panel2.Controls.Add(dataGridView1);
            splitContainer5.Size = new Size(683, 450);
            splitContainer5.SplitterDistance = 31;
            splitContainer5.TabIndex = 0;
            splitContainer5.SplitterMoved += splitContainer5_SplitterMoved;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Top;
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(60, 20);
            label5.TabIndex = 0;
            label5.Text = "Recipes";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(683, 415);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            dataGridView1.CellValidating += dataGridView1_CellValidating;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.DefaultValuesNeeded += dataGridView1_DefaultValuesNeeded;
            dataGridView1.RowValidating += dataGridView1_RowValidating;
            // 
            // DishConstructor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "DishConstructor";
            Text = "DishConstructor";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            ((ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer5.Panel1.ResumeLayout(false);
            splitContainer5.Panel1.PerformLayout();
            splitContainer5.Panel2.ResumeLayout(false);
            ((ISupportInitialize)splitContainer5).EndInit();
            splitContainer5.ResumeLayout(false);
            ((ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private Button button2;
        private Button button1;
        private SplitContainer splitContainer5;
        private Label label5;
        private DataGridView dataGridView1;

        private Dish creatingDish;
        private DishConstructorController controller;
       // private BindingList<DishRecipeView> bindingListRecipes;
        private BindingListEx<Unit> units;
        private BindingListEx<DishProduct> products = new BindingListEx<DishProduct>();

        DataGridViewComboBoxColumn colProduct = new DataGridViewComboBoxColumn();

        private bool isCompleted = false;
        public bool IsCompleted { get => isCompleted; }
    }
}