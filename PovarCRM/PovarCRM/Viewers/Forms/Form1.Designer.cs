using System.ComponentModel;
using System.Windows.Forms.VisualStyles;
using PovarCRM.Models;
using PovarCRM.UIcontrollers;
using PovarCRM.Viewers;

namespace PovarCRM
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            flowLayoutPanel1 = new FlowLayoutPanel();
            FinanceAnalyz = new Button();
            button2 = new Button();
            button4 = new Button();
            mainTabControl = new TabControl();
            tabPage1 = new TabPage();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            textBox1 = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            listBox1 = new ListBox();
            label10 = new Label();
            splitContainer2 = new SplitContainer();
            button1 = new Button();
            button3 = new Button();
            comboBox1 = new ComboBox();
            Choise_items = new Label();
            numericUpDown7 = new NumericUpDown();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            label9 = new Label();
            dateTimePicker2 = new DateTimePicker();
            label2 = new Label();
            label6 = new Label();
            numericUpDown4 = new NumericUpDown();
            label4 = new Label();
            numericUpDown2 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            numericUpDown1 = new NumericUpDown();
            label3 = new Label();
            numericUpDown6 = new NumericUpDown();
            numericUpDown5 = new NumericUpDown();
            label5 = new Label();
            label8 = new Label();
            label7 = new Label();
            dataGridView1 = new DataGridView();
            tabPage2 = new TabPage();
            button5 = new Button();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            servingOrdersViewer1 = new ServingOrdersViewer();
            label11 = new Label();
            ((ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            mainTabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((ISupportInitialize)numericUpDown7).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((ISupportInitialize)numericUpDown4).BeginInit();
            ((ISupportInitialize)numericUpDown2).BeginInit();
            ((ISupportInitialize)numericUpDown3).BeginInit();
            ((ISupportInitialize)numericUpDown1).BeginInit();
            ((ISupportInitialize)numericUpDown6).BeginInit();
            ((ISupportInitialize)numericUpDown5).BeginInit();
            ((ISupportInitialize)dataGridView1).BeginInit();
            tabPage2.SuspendLayout();
            tabPage4.SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(flowLayoutPanel1);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(mainTabControl);
            splitContainer1.Size = new Size(1356, 765);
            splitContainer1.SplitterDistance = 190;
            splitContainer1.TabIndex = 0;
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(FinanceAnalyz);
            flowLayoutPanel1.Controls.Add(button2);
            flowLayoutPanel1.Controls.Add(button4);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(10, 10, 0, 0);
            flowLayoutPanel1.Size = new Size(190, 765);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // FinanceAnalyz
            // 
            FinanceAnalyz.Location = new Point(13, 13);
            FinanceAnalyz.Name = "FinanceAnalyz";
            FinanceAnalyz.Size = new Size(152, 29);
            FinanceAnalyz.TabIndex = 1;
            FinanceAnalyz.Text = "FinanceAnalyz";
            FinanceAnalyz.UseVisualStyleBackColor = true;
            FinanceAnalyz.Click += button2_Click;
            // 
            // button2
            // 
            button2.Location = new Point(13, 48);
            button2.Name = "button2";
            button2.Size = new Size(152, 29);
            button2.TabIndex = 3;
            button2.Text = "Menu Control";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button4
            // 
            button4.Location = new Point(13, 83);
            button4.Name = "button4";
            button4.Size = new Size(152, 29);
            button4.TabIndex = 4;
            button4.Text = "Workers";
            button4.UseVisualStyleBackColor = true;
            // 
            // mainTabControl
            // 
            mainTabControl.Controls.Add(tabPage1);
            mainTabControl.Controls.Add(tabPage2);
            mainTabControl.Controls.Add(tabPage3);
            mainTabControl.Controls.Add(tabPage4);
            mainTabControl.Dock = DockStyle.Fill;
            mainTabControl.Location = new Point(0, 0);
            mainTabControl.Name = "mainTabControl";
            mainTabControl.SelectedIndex = 0;
            mainTabControl.Size = new Size(1162, 765);
            mainTabControl.TabIndex = 0;
            mainTabControl.Selected += mainTabControl_Selected;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(checkBox2);
            tabPage1.Controls.Add(checkBox1);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(tableLayoutPanel1);
            tabPage1.Controls.Add(numericUpDown7);
            tabPage1.Controls.Add(tableLayoutPanel2);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1154, 732);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "FInanceAnalyz";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Font = new Font("Bahnschrift Condensed", 11F);
            checkBox2.Location = new Point(648, 322);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(153, 27);
            checkBox2.TabIndex = 32;
            checkBox2.Text = "Find by ClientName";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Bahnschrift Condensed", 11F);
            checkBox1.Location = new Point(465, 322);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(136, 27);
            checkBox1.TabIndex = 30;
            checkBox1.Text = "Find Check by ID";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(648, 352);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(152, 27);
            textBox1.TabIndex = 29;
            textBox1.TextChanged += textBox1_TextChanged_1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(listBox1, 0, 1);
            tableLayoutPanel1.Controls.Add(label10, 0, 0);
            tableLayoutPanel1.Controls.Add(splitContainer2, 0, 4);
            tableLayoutPanel1.Controls.Add(comboBox1, 0, 3);
            tableLayoutPanel1.Controls.Add(Choise_items, 0, 2);
            tableLayoutPanel1.Location = new Point(465, 404);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.708334F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 82.2916641F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tableLayoutPanel1.Size = new Size(205, 291);
            tableLayoutPanel1.TabIndex = 28;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint_1;
            // 
            // listBox1
            // 
            listBox1.AllowDrop = true;
            listBox1.FormattingEnabled = true;
            listBox1.Items.AddRange(new object[] { "" });
            listBox1.Location = new Point(3, 27);
            listBox1.Name = "listBox1";
            listBox1.SelectionMode = SelectionMode.MultiSimple;
            listBox1.Size = new Size(199, 104);
            listBox1.Sorted = true;
            listBox1.TabIndex = 10;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged_1;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Bahnschrift Condensed", 12F);
            label10.Location = new Point(3, 0);
            label10.Name = "label10";
            label10.Size = new Size(175, 24);
            label10.TabIndex = 22;
            label10.Text = "Required dishes in check\r\n";
            label10.Click += label10_Click;
            // 
            // splitContainer2
            // 
            splitContainer2.Location = new Point(3, 205);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(button1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(button3);
            splitContainer2.Size = new Size(199, 49);
            splitContainer2.SplitterDistance = 73;
            splitContainer2.TabIndex = 34;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkSlateGray;
            button1.Dock = DockStyle.Fill;
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(73, 49);
            button1.TabIndex = 34;
            button1.Text = "Clear";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // button3
            // 
            button3.BackColor = Color.DeepSkyBlue;
            button3.Dock = DockStyle.Fill;
            button3.ForeColor = SystemColors.ActiveCaptionText;
            button3.Location = new Point(0, 0);
            button3.Name = "button3";
            button3.Size = new Size(122, 49);
            button3.TabIndex = 33;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = false;
            button3.Visible = false;
            button3.Click += button3_Click;
            // 
            // comboBox1
            // 
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(3, 167);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(199, 28);
            comboBox1.Sorted = true;
            comboBox1.TabIndex = 33;
            comboBox1.DropDown += comboBox1_DropDown;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1.Click += comboBox1_Click;
            // 
            // Choise_items
            // 
            Choise_items.AutoSize = true;
            Choise_items.Dock = DockStyle.Fill;
            Choise_items.Location = new Point(3, 138);
            Choise_items.Name = "Choise_items";
            Choise_items.Size = new Size(199, 26);
            Choise_items.TabIndex = 33;
            Choise_items.Text = "Choise the items";
            // 
            // numericUpDown7
            // 
            numericUpDown7.Enabled = false;
            numericUpDown7.Location = new Point(465, 352);
            numericUpDown7.Maximum = new decimal(new int[] { -402653184, -1613725636, 54210108, 0 });
            numericUpDown7.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            numericUpDown7.Name = "numericUpDown7";
            numericUpDown7.Size = new Size(152, 27);
            numericUpDown7.TabIndex = 26;
            numericUpDown7.Value = new decimal(new int[] { 1, 0, 0, int.MinValue });
            numericUpDown7.ValueChanged += numericUpDown7_ValueChanged;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel2.Controls.Add(label5, 0, 0);
            tableLayoutPanel2.Location = new Point(465, 67);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 13.92405F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 86.07595F));
            tableLayoutPanel2.Size = new Size(510, 238);
            tableLayoutPanel2.TabIndex = 24;
            tableLayoutPanel2.Paint += tableLayoutPanel2_Paint;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel3.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.740612F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.8122864F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.4471F));
            tableLayoutPanel3.Controls.Add(dateTimePicker1, 1, 1);
            tableLayoutPanel3.Controls.Add(label1, 1, 0);
            tableLayoutPanel3.Controls.Add(label9, 0, 4);
            tableLayoutPanel3.Controls.Add(dateTimePicker2, 2, 1);
            tableLayoutPanel3.Controls.Add(label2, 2, 0);
            tableLayoutPanel3.Controls.Add(label6, 0, 1);
            tableLayoutPanel3.Controls.Add(numericUpDown4, 1, 3);
            tableLayoutPanel3.Controls.Add(label4, 0, 3);
            tableLayoutPanel3.Controls.Add(numericUpDown2, 2, 3);
            tableLayoutPanel3.Controls.Add(numericUpDown3, 1, 2);
            tableLayoutPanel3.Controls.Add(numericUpDown1, 2, 2);
            tableLayoutPanel3.Controls.Add(label3, 0, 2);
            tableLayoutPanel3.Controls.Add(numericUpDown6, 2, 4);
            tableLayoutPanel3.Controls.Add(numericUpDown5, 1, 4);
            tableLayoutPanel3.Location = new Point(4, 37);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 5;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 32.9411774F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 67.05882F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel3.Size = new Size(502, 197);
            tableLayoutPanel3.TabIndex = 0;
            tableLayoutPanel3.Paint += tableLayoutPanel3_Paint;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm";
            dateTimePicker1.Dock = DockStyle.Fill;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(163, 28);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(167, 27);
            dateTimePicker1.TabIndex = 3;
            dateTimePicker1.Value = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold);
            label1.Location = new Point(163, 1);
            label1.Name = "label1";
            label1.Size = new Size(42, 16);
            label1.TabIndex = 13;
            label1.Text = "From";
            label1.Click += label1_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(4, 163);
            label9.Name = "label9";
            label9.Size = new Size(93, 20);
            label9.TabIndex = 21;
            label9.Text = "Dishes count";
            label9.Click += label9_Click;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "dd.MM.yyyy HH:mm";
            dateTimePicker2.Dock = DockStyle.Fill;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(337, 28);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(161, 27);
            dateTimePicker2.TabIndex = 4;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(337, 1);
            label2.Name = "label2";
            label2.Size = new Size(26, 16);
            label2.TabIndex = 14;
            label2.Text = "To";
            label2.Click += label2_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Narrow", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.Location = new Point(4, 25);
            label6.Name = "label6";
            label6.Size = new Size(76, 22);
            label6.TabIndex = 18;
            label6.Text = "Date Time";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label6.Click += label6_Click;
            // 
            // numericUpDown4
            // 
            numericUpDown4.Dock = DockStyle.Fill;
            numericUpDown4.Location = new Point(163, 132);
            numericUpDown4.Maximum = new decimal(new int[] { -1, -1, -1, 0 });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(167, 27);
            numericUpDown4.TabIndex = 12;
            numericUpDown4.ValueChanged += numericUpDown4_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(4, 129);
            label4.Name = "label4";
            label4.Size = new Size(91, 20);
            label4.TabIndex = 16;
            label4.Text = "Dish portion";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Dock = DockStyle.Fill;
            numericUpDown2.Location = new Point(337, 132);
            numericUpDown2.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(161, 27);
            numericUpDown2.TabIndex = 8;
            numericUpDown2.Value = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // numericUpDown3
            // 
            numericUpDown3.Dock = DockStyle.Fill;
            numericUpDown3.Location = new Point(163, 77);
            numericUpDown3.Maximum = new decimal(new int[] { -1, -1, -1, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(167, 27);
            numericUpDown3.TabIndex = 11;
            numericUpDown3.ValueChanged += numericUpDown3_ValueChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Dock = DockStyle.Fill;
            numericUpDown1.Location = new Point(337, 77);
            numericUpDown1.Maximum = new decimal(new int[] { -1, -1, -1, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(161, 27);
            numericUpDown1.TabIndex = 7;
            numericUpDown1.Value = new decimal(new int[] { -1, -1, -1, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 74);
            label3.Name = "label3";
            label3.Size = new Size(91, 20);
            label3.TabIndex = 15;
            label3.Text = "Total money";
            label3.Click += label3_Click;
            // 
            // numericUpDown6
            // 
            numericUpDown6.Dock = DockStyle.Fill;
            numericUpDown6.Location = new Point(337, 166);
            numericUpDown6.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            numericUpDown6.Name = "numericUpDown6";
            numericUpDown6.Size = new Size(161, 27);
            numericUpDown6.TabIndex = 26;
            numericUpDown6.Value = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            numericUpDown6.ValueChanged += numericUpDown6_ValueChanged;
            // 
            // numericUpDown5
            // 
            numericUpDown5.Dock = DockStyle.Fill;
            numericUpDown5.Location = new Point(163, 166);
            numericUpDown5.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(167, 27);
            numericUpDown5.TabIndex = 25;
            numericUpDown5.ValueChanged += numericUpDown5_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(4, 1);
            label5.Name = "label5";
            label5.Size = new Size(108, 24);
            label5.TabIndex = 17;
            label5.Text = "Range filtering";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label5.Click += label5_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(743, 209);
            label8.Name = "label8";
            label8.Size = new Size(25, 20);
            label8.TabIndex = 20;
            label8.Text = "To";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F);
            label7.Location = new Point(528, 19);
            label7.Name = "label7";
            label7.Size = new Size(193, 32);
            label7.TabIndex = 19;
            label7.Text = "Filter parameters";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(31, 32);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(396, 600);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(button5);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1154, 732);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Menu Control";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Click += tabPage2_Click;
            // 
            // button5
            // 
            button5.Location = new Point(115, 190);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 0;
            button5.Text = "button5";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1154, 732);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Workers";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(servingOrdersViewer1);
            tabPage4.Controls.Add(label11);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1154, 732);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Serving orders";
            tabPage4.UseVisualStyleBackColor = true;
            tabPage4.Click += tabPage4_Click;
            tabPage4.Enter += tabPage4_Enter;
            // 
            // servingOrdersViewer1
            // 
            servingOrdersViewer1.Dock = DockStyle.Fill;
            servingOrdersViewer1.Location = new Point(0, 0);
            servingOrdersViewer1.Name = "servingOrdersViewer1";
            servingOrdersViewer1.Size = new Size(1154, 732);
            servingOrdersViewer1.TabIndex = 2;
            servingOrdersViewer1.Load += servingOrdersViewer1_Load;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(37, 28);
            label11.Name = "label11";
            label11.Size = new Size(53, 20);
            label11.TabIndex = 1;
            label11.Text = "Orders";
            label11.Click += label11_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1356, 765);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            mainTabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((ISupportInitialize)numericUpDown7).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ((ISupportInitialize)numericUpDown4).EndInit();
            ((ISupportInitialize)numericUpDown2).EndInit();
            ((ISupportInitialize)numericUpDown3).EndInit();
            ((ISupportInitialize)numericUpDown1).EndInit();
            ((ISupportInitialize)numericUpDown6).EndInit();
            ((ISupportInitialize)numericUpDown5).EndInit();
            ((ISupportInitialize)dataGridView1).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button FinanceAnalyz;
        private Button button2;
        private Button button4;
        public TabControl mainTabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private DataGridView dataGridView1;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown3;
        private Label label1;
        private NumericUpDown numericUpDown4;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label7;
        private Label label10;
        private Label label9;
        private Label label8;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private NumericUpDown numericUpDown6;
        private NumericUpDown numericUpDown5;
        private NumericUpDown numericUpDown7;
        private TableLayoutPanel tableLayoutPanel1;
        private ListBox listBox1;
        private TextBox textBox1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private ComboBox comboBox1;
        private Button button3;
        private Label Choise_items;
        private SplitContainer splitContainer2;
        private Button button1;
        private TabPage tabPage4;
        private Label label11;
        private ServingOrdersViewer servingOrdersViewer1;
        private Button button5;
    }
}
