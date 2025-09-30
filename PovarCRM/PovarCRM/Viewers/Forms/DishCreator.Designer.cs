using PovarCRM.Models;

namespace PovarCRM.Viewers.Forms
{
    partial class DishCreator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public void CreatNewDish()
        {
            if (textBox1.Text == null)
                return;
            if (numericUpDown1.Value == null)
                numericUpDown1.Value = (decimal)0.25;
            DishType dishType = unit.DishTypes.GetCollection().ToList().
                Where(dishType => dishType.Naming == comboBox1.Text).FirstOrDefault();

            this.creatingDish = new Dish
            {
                Naming = textBox1.Text,
                DishTypeId = dishType.Id,
                Markup = (float)numericUpDown1.Value
            };

            this.listDishes.Insert(0, this.creatingDish);

            isCompleted = true;
        }
        protected override void OnClosed(EventArgs e)
        {
            if (!isCompleted)
            {
                if (this.creatingDish != null)
                {
                    this.listDishes.Remove(this.creatingDish);
                }
            }
            base.OnClosed(e);
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
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(45, 88);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 0;
            textBox1.Validating += textBox1_Validating;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(435, 88);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 1;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(231, 88);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(247, 9);
            label1.Name = "label1";
            label1.Size = new Size(120, 20);
            label1.TabIndex = 3;
            label1.Text = "Required Params";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 70);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 4;
            label2.Text = "Dish Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(231, 65);
            label3.Name = "label3";
            label3.Size = new Size(136, 20);
            label3.TabIndex = 5;
            label3.Text = "Markup Percentage";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(435, 65);
            label4.Name = "label4";
            label4.Size = new Size(73, 20);
            label4.TabIndex = 6;
            label4.Text = "Dish Type";
            // 
            // button1
            // 
            button1.Location = new Point(501, 5);
            button1.Name = "button1";
            button1.Size = new Size(104, 40);
            button1.TabIndex = 7;
            button1.Text = "Complete";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // DishCreator
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(617, 215);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericUpDown1);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Name = "DishCreator";
            Text = "DishCreator";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private ComboBox comboBox1;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;

        private UnitOfWork unit;
        private Button button1;

        public bool isCompleted = false;
    }
}