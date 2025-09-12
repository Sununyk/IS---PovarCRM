using System.Runtime.CompilerServices;
using PovarCRM.UIcontrollers;

namespace PovarCRM.Viewers
{
    public partial class ServingOrdersViewer : UserControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        
        public void InitController(UIcontrollers.ServingOrdersController controller)
        {
            if (controller == null)
                return;

            this.controller = controller;
            ordersTable.DataSource = this.controller.initOrderCheckList();
            itemsTable.DataSource = this.controller.initItemViewList();
            this.IngredientsTable.DataSource = this.controller.initRecipeViewList();

        }
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
            ordersTable = new DataGridView();
            itemsTable = new DataGridView();
            label1 = new Label();
            ItemsView = new TabControl();
            tabPage1 = new TabPage();
            IngredientsView = new TabPage();
            IngredientsTable = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            splitContainer1 = new SplitContainer();
            label2 = new Label();
            splitContainer2 = new SplitContainer();
            DeniedButton = new Button();
            CompleteButton = new Button();
            NewOrderButton = new Button();
            ((System.ComponentModel.ISupportInitialize)ordersTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)itemsTable).BeginInit();
            ItemsView.SuspendLayout();
            tabPage1.SuspendLayout();
            IngredientsView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)IngredientsTable).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // ordersTable
            // 
            ordersTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ordersTable.Dock = DockStyle.Fill;
            ordersTable.Location = new Point(0, 0);
            ordersTable.Name = "ordersTable";
            ordersTable.RowHeadersWidth = 51;
            ordersTable.Size = new Size(272, 493);
            ordersTable.TabIndex = 0;
            ordersTable.CellContentClick += dataGridView1_CellContentClick_1;
            ordersTable.CellDoubleClick += dataGridView1_CellDoubleClick;
            ordersTable.RowEnter += ordersTable_RowEnter;
            ordersTable.Paint += ordersTable_Paint;
            ordersTable.Layout += dataGridView1_Layout;
            // 
            // itemsTable
            // 
            itemsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            itemsTable.Dock = DockStyle.Fill;
            itemsTable.Location = new Point(3, 3);
            itemsTable.Name = "itemsTable";
            itemsTable.RowHeadersWidth = 51;
            itemsTable.Size = new Size(322, 494);
            itemsTable.TabIndex = 1;
            itemsTable.CellContentClick += dataGridView2_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(176, 14);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 2;
            label1.Text = "Orders";
            // 
            // ItemsView
            // 
            ItemsView.Controls.Add(tabPage1);
            ItemsView.Controls.Add(IngredientsView);
            ItemsView.Dock = DockStyle.Fill;
            ItemsView.Location = new Point(281, 3);
            ItemsView.Name = "ItemsView";
            ItemsView.SelectedIndex = 0;
            ItemsView.Size = new Size(336, 533);
            ItemsView.TabIndex = 5;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(itemsTable);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(328, 500);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Items";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // IngredientsView
            // 
            IngredientsView.Controls.Add(IngredientsTable);
            IngredientsView.Location = new Point(4, 29);
            IngredientsView.Name = "IngredientsView";
            IngredientsView.Padding = new Padding(3);
            IngredientsView.Size = new Size(328, 500);
            IngredientsView.TabIndex = 1;
            IngredientsView.Text = "Ingredients";
            IngredientsView.UseVisualStyleBackColor = true;
            // 
            // IngredientsTable
            // 
            IngredientsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            IngredientsTable.Dock = DockStyle.Fill;
            IngredientsTable.Location = new Point(3, 3);
            IngredientsTable.Name = "IngredientsTable";
            IngredientsTable.RowHeadersWidth = 51;
            IngredientsTable.Size = new Size(322, 494);
            IngredientsTable.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44.8336258F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55.1663742F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 251F));
            tableLayoutPanel1.Controls.Add(splitContainer1, 0, 0);
            tableLayoutPanel1.Controls.Add(ItemsView, 1, 0);
            tableLayoutPanel1.Controls.Add(splitContainer2, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(872, 539);
            tableLayoutPanel1.TabIndex = 7;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(ordersTable);
            splitContainer1.Size = new Size(272, 533);
            splitContainer1.SplitterDistance = 36;
            splitContainer1.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 0;
            label2.Text = "Orders";
            label2.Click += label2_Click;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(623, 3);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(DeniedButton);
            splitContainer2.Panel1.Controls.Add(CompleteButton);
            splitContainer2.Panel1.Controls.Add(NewOrderButton);
            splitContainer2.Panel1.Paint += splitContainer2_Panel1_Paint;
            splitContainer2.Size = new Size(246, 533);
            splitContainer2.SplitterDistance = 90;
            splitContainer2.TabIndex = 7;
            // 
            // DeniedButton
            // 
            DeniedButton.Dock = DockStyle.Bottom;
            DeniedButton.Location = new Point(0, 7);
            DeniedButton.Name = "DeniedButton";
            DeniedButton.Size = new Size(246, 29);
            DeniedButton.TabIndex = 2;
            DeniedButton.Text = "Denied Order";
            DeniedButton.UseVisualStyleBackColor = true;
            DeniedButton.Click += button3_Click;
            // 
            // CompleteButton
            // 
            CompleteButton.Dock = DockStyle.Bottom;
            CompleteButton.Location = new Point(0, 36);
            CompleteButton.Name = "CompleteButton";
            CompleteButton.Size = new Size(246, 29);
            CompleteButton.TabIndex = 1;
            CompleteButton.Text = "Complete Order";
            CompleteButton.UseVisualStyleBackColor = true;
            CompleteButton.Click += CompleteButton_Click;
            // 
            // NewOrderButton
            // 
            NewOrderButton.Dock = DockStyle.Bottom;
            NewOrderButton.Location = new Point(0, 65);
            NewOrderButton.Name = "NewOrderButton";
            NewOrderButton.Size = new Size(246, 25);
            NewOrderButton.TabIndex = 0;
            NewOrderButton.Text = "New Order";
            NewOrderButton.UseVisualStyleBackColor = true;
            NewOrderButton.Click += button1_Click_1;
            // 
            // ServingOrdersViewer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "ServingOrdersViewer";
            Size = new Size(872, 539);
            ((System.ComponentModel.ISupportInitialize)ordersTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)itemsTable).EndInit();
            ItemsView.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            IngredientsView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)IngredientsTable).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion



        private DataGridView ordersTable;
        private DataGridView itemsTable;
        private DataGridView ingredients;
        private UIcontrollers.ServingOrdersController controller;
        private Label label1;
        private TabControl ItemsView;
        private TabPage tabPage1;
        private TabPage IngredientsView;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private Label label2;
        private Button NewOrderButton;
        private Button DeniedButton;
        private Button CompleteButton;
        public TableLayoutPanel tableLayoutPanel1;
        private DataGridView IngredientsTable;

        private int selectedDishId = -1;
    }
}
