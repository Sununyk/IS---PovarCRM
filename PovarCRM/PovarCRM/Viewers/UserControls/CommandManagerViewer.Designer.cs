using Microsoft.EntityFrameworkCore.Migrations;
using PovarCRM.UIcontrollers.PageRouter;

namespace PovarCRM.Viewers.UserControls
{
    partial class CommandManagerViewer
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            button3 = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(55, 28);
            button1.TabIndex = 0;
            button1.Text = "<-";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(64, 3);
            button2.Name = "button2";
            button2.Size = new Size(57, 28);
            button2.TabIndex = 1;
            button2.Text = "home";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.06468F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.7683F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.16702F));
            tableLayoutPanel1.Controls.Add(button2, 1, 0);
            tableLayoutPanel1.Controls.Add(button3, 2, 0);
            tableLayoutPanel1.Controls.Add(button1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(187, 34);
            tableLayoutPanel1.TabIndex = 2;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // button3
            // 
            button3.Location = new Point(127, 3);
            button3.Name = "button3";
            button3.Size = new Size(57, 28);
            button3.TabIndex = 2;
            button3.Text = "->";
            button3.UseVisualStyleBackColor = true;
            // 
            // CommandManagerController
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "CommandManagerController";
            Size = new Size(187, 34);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        //событие которое обрабатывает выполнение всех команд в PageRouter 
        //подпишет сам PageRouter
        public void onCommandExec(object sender, ICommand command)
        {
            controller
        }

        private Button button1;
        private Button button2;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button3;

        private CommandManagerViewer controller;
    }
}
