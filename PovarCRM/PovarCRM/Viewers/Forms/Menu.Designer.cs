namespace PovarCRM.Viewers
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            label1 = new Label();
            pictureBox1 = new PictureBox();
            checkedListBox1 = new CheckedListBox();
            splitContainer2 = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            label2 = new Label();
            CountDish = new Label();
            ModeLabel = new Label();
            DishCountResourse = new Label();
            PortionsLabel = new Label();
            PortionsResourse = new Label();
            MenuPickerTable = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MenuPickerTable).BeginInit();
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
            splitContainer1.Panel1.BackColor = Color.DarkGray;
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(checkedListBox1);
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            splitContainer1.Panel1.ForeColor = Color.DarkGray;
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 195;
            splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(40, 10);
            label1.Name = "label1";
            label1.Size = new Size(98, 25);
            label1.TabIndex = 3;
            label1.Text = "Dish types";
            label1.Click += label1_Click_1;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.BackColor = Color.DimGray;
            pictureBox1.Image = Properties.Resources.BusketImag_1_;
            pictureBox1.Location = new Point(-28, 253);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(254, 239);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // checkedListBox1
            // 
            checkedListBox1.BackColor = Color.DarkGray;
            checkedListBox1.BorderStyle = BorderStyle.None;
            checkedListBox1.Font = new Font("Segoe UI", 11F);
            checkedListBox1.ForeColor = SystemColors.Menu;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "Halam", "Balam", "Data", "Mata" });
            checkedListBox1.Location = new Point(12, 61);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(150, 108);
            checkedListBox1.TabIndex = 2;
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
            splitContainer2.Panel1.BackColor = SystemColors.ControlDark;
            splitContainer2.Panel1.Controls.Add(tableLayoutPanel1);
            splitContainer2.Panel1.ForeColor = SystemColors.Control;
            splitContainer2.Panel1.Paint += splitContainer2_Panel1_Paint;
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(MenuPickerTable);
            splitContainer2.Size = new Size(601, 450);
            splitContainer2.SplitterDistance = 57;
            splitContainer2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 8;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 9F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 61F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 135F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 116F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 82F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 76F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 28F));
            tableLayoutPanel1.Controls.Add(label2, 1, 0);
            tableLayoutPanel1.Controls.Add(CountDish, 4, 0);
            tableLayoutPanel1.Controls.Add(ModeLabel, 3, 0);
            tableLayoutPanel1.Controls.Add(DishCountResourse, 5, 0);
            tableLayoutPanel1.Controls.Add(PortionsLabel, 6, 0);
            tableLayoutPanel1.Controls.Add(PortionsResourse, 7, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(0, 10, 0, 0);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(601, 57);
            tableLayoutPanel1.TabIndex = 3;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 10);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 0;
            label2.Text = "Mode :";
            // 
            // CountDish
            // 
            CountDish.AutoSize = true;
            CountDish.Location = new Point(208, 10);
            CountDish.Name = "CountDish";
            CountDish.Size = new Size(109, 20);
            CountDish.TabIndex = 2;
            CountDish.Text = "Dish positions :";
            // 
            // ModeLabel
            // 
            ModeLabel.AutoSize = true;
            ModeLabel.Location = new Point(71, 10);
            ModeLabel.Margin = new Padding(1, 0, 3, 0);
            ModeLabel.Name = "ModeLabel";
            ModeLabel.Size = new Size(85, 20);
            ModeLabel.TabIndex = 1;
            ModeLabel.Text = "MenuMode";
            // 
            // DishCountResourse
            // 
            DishCountResourse.AutoSize = true;
            DishCountResourse.Location = new Point(324, 10);
            DishCountResourse.Name = "DishCountResourse";
            DishCountResourse.Size = new Size(63, 20);
            DishCountResourse.TabIndex = 3;
            DishCountResourse.Text = "Number";
            // 
            // PortionsLabel
            // 
            PortionsLabel.AutoSize = true;
            PortionsLabel.Location = new Point(406, 10);
            PortionsLabel.Name = "PortionsLabel";
            PortionsLabel.Size = new Size(69, 20);
            PortionsLabel.TabIndex = 4;
            PortionsLabel.Text = "Portions :";
            // 
            // PortionsResourse
            // 
            PortionsResourse.AutoSize = true;
            PortionsResourse.Location = new Point(482, 10);
            PortionsResourse.Name = "PortionsResourse";
            PortionsResourse.Size = new Size(41, 20);
            PortionsResourse.TabIndex = 5;
            PortionsResourse.Text = "Num";
            // 
            // MenuPickerTable
            // 
            MenuPickerTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MenuPickerTable.Dock = DockStyle.Fill;
            MenuPickerTable.Location = new Point(0, 0);
            MenuPickerTable.Name = "MenuPickerTable";
            MenuPickerTable.RowHeadersWidth = 51;
            MenuPickerTable.Size = new Size(601, 389);
            MenuPickerTable.TabIndex = 0;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "Menu";
            Text = "Menu";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)MenuPickerTable).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private PictureBox pictureBox1;
        private Label label1;
        private DataGridView MenuPickerTable;
        private SplitContainer splitContainer2;
        private TableLayoutPanel tableLayoutPanel1;
        private Label CountDish;
        private Label ModeLabel;
        private Label label2;
        private Label DishCountResourse;
        private Label PortionsLabel;
        private Label PortionsResourse;
        public CheckedListBox checkedListBox1;
    }
}