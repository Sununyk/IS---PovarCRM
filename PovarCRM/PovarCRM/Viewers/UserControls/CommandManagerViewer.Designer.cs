using Microsoft.EntityFrameworkCore.Migrations;
using PovarCRM.Repositories.CommandsLogic;
using PovarCRM.UIcontrollers;

namespace PovarCRM.Viewers.UserControls
{
    partial class CommandManagerViewer : UserControl
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandManagerViewer));
            button1 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            button3 = new Button();
            notifyIcon1 = new NotifyIcon(components);
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Dock = DockStyle.Left;
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(53, 28);
            button1.TabIndex = 0;
            button1.Text = "<-";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.06468F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.7683F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(button1, 0, 0);
            tableLayoutPanel1.Controls.Add(button3, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(140, 34);
            tableLayoutPanel1.TabIndex = 2;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Right;
            button3.Location = new Point(62, 3);
            button3.Name = "button3";
            button3.Size = new Size(54, 28);
            button3.TabIndex = 2;
            button3.Text = "->";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            button3.MouseMove += button3_MouseMove;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // CommandManagerViewer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "CommandManagerViewer";
            Size = new Size(140, 34);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        //событие которое обрабатывает выполнение всех команд в PageRouter 
        //подпишет сам PageRouter
        public void onCommandExec(object sender, ICommand command)
        {
            controller.Execute(command);
        }
        public void onCommandUndo(object sender, ICommand command)
        {
            controller.Execute(command);
        }
        public void onCommandRedo(object sender, ICommand command)
        {
            controller.Execute(command);
        }
        //Инициализация зависимостей и разрешение на Visible
        public void InitDependency(CommandManagerController controller)
        {
            this.controller = controller;
        }


        private Button button1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button3;

        private CommandManagerController? controller = null;
        private NotifyIcon notifyIcon1;
    }
}
