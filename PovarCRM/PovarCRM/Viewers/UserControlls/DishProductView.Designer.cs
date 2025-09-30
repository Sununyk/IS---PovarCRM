using PovarCRM.UIcontrollers;
using PovarCRM.UIcontrollers.UImembers;

namespace PovarCRM.Viewers.UserControlls
{
    partial class DishProductView : IUpdateObserver
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        public void InitDependency(DishProductController controller)
        {
            button1.Click += (s, e) => this.onUpdateState();
            button2.Click += (s, e) => this.onUpdateState();
            DishProductTable.DataSource = controller.GetDishViewProducts();
            UnitTable.DataSource = controller.GetUnits();

            this.AddUpdateMember(controller);
            //UpdateState();

            // Единица измерения (ComboBox)
            var unitCol = new DataGridViewComboBoxColumn
            {
                Name = "UnitColumn",
                DataPropertyName = "UnitId", // <-- именно здесь Id блюда
                HeaderText = "Ед. изм.",
                DisplayMember = "Naming",
                ValueMember = "Id",
                DataSource = controller.GetUnits()
            };
            //работа с комбобокс в таблице
            unitCol.DataSource = controller.GetUnits();
            DishProductTable.Columns.Add(unitCol);

            DishProductTable.Columns["IdColumn"].Visible = false;
        }


        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            button1 = new Button();
            label1 = new Label();
            DishProductTable = new DataGridView();
            splitContainer3 = new SplitContainer();
            button2 = new Button();
            label2 = new Label();
            UnitTable = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DishProductTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UnitTable).BeginInit();
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
            splitContainer1.Panel2.Controls.Add(splitContainer3);
            splitContainer1.Size = new Size(690, 557);
            splitContainer1.SplitterDistance = 343;
            splitContainer1.TabIndex = 0;
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
            splitContainer2.Panel1.Controls.Add(button1);
            splitContainer2.Panel1.Controls.Add(label1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(DishProductTable);
            splitContainer2.Size = new Size(343, 557);
            splitContainer2.SplitterDistance = 44;
            splitContainer2.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(246, 11);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "Update";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 0;
            label1.Text = "DishProduct";
            // 
            // DishProductTable
            // 
            DishProductTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DishProductTable.Dock = DockStyle.Fill;
            DishProductTable.Location = new Point(0, 0);
            DishProductTable.Name = "DishProductTable";
            DishProductTable.RowHeadersWidth = 51;
            DishProductTable.Size = new Size(343, 509);
            DishProductTable.TabIndex = 0;
            DishProductTable.CellContentClick += DishProductTable_CellContentClick;
            DishProductTable.RowValidating += DishProductTable_RowValidating;
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
            splitContainer3.Panel1.Controls.Add(button2);
            splitContainer3.Panel1.Controls.Add(label2);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(UnitTable);
            splitContainer3.Size = new Size(343, 557);
            splitContainer3.SplitterDistance = 43;
            splitContainer3.TabIndex = 0;
            splitContainer3.SplitterMoved += splitContainer3_SplitterMoved;
            // 
            // button2
            // 
            button2.Location = new Point(246, 11);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 1;
            button2.Text = "Update";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(36, 20);
            label2.TabIndex = 0;
            label2.Text = "Unit";
            // 
            // UnitTable
            // 
            UnitTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            UnitTable.Dock = DockStyle.Fill;
            UnitTable.Location = new Point(0, 0);
            UnitTable.Name = "UnitTable";
            UnitTable.RowHeadersWidth = 51;
            UnitTable.Size = new Size(343, 510);
            UnitTable.TabIndex = 0;
            // 
            // DishProductView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "DishProductView";
            Size = new Size(690, 557);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DishProductTable).EndInit();
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel1.PerformLayout();
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)UnitTable).EndInit();
            ResumeLayout(false);
        }

        public void UpdateState()
        {
            ObserverStateUpdated?.Invoke();
        }

        public void AddUpdateMember(IUpdateMember member)
        {
            this.ObserverStateUpdated += member.onUpdateState;
        }

        public void onUpdateState()
        {

            UpdateState();
        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private Button button1;
        private Label label1;
        private Button button2;
        private Label label2;
        private DataGridView DishProductTable;
        private DataGridView UnitTable;

        public event UpdateState ObserverStateUpdated;
    }
}
