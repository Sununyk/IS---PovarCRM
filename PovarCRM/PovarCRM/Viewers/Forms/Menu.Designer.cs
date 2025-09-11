using System.Runtime.CompilerServices;
using PovarCRM.UIcontrollers;

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
            tableLayoutPanel1 = new TableLayoutPanel();
            commandManagerViewer1 = new PovarCRM.Viewers.UserControls.CommandManagerViewer();
            button1 = new Button();
            label3 = new Label();
            orderConstructorViewer1 = new PovarCRM.Viewers.UserControls.OrderConstructorViewer();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(orderConstructorViewer1);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 47;
            splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.Controls.Add(commandManagerViewer1, 0, 0);
            tableLayoutPanel1.Controls.Add(button1, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(800, 47);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // commandManagerViewer1
            // 
            commandManagerViewer1.Location = new Point(3, 3);
            commandManagerViewer1.Name = "commandManagerViewer1";
            commandManagerViewer1.Size = new Size(137, 41);
            commandManagerViewer1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(635, 3);
            button1.Name = "button1";
            button1.Padding = new Padding(10, 0, 10, 0);
            button1.Size = new Size(162, 41);
            button1.TabIndex = 3;
            button1.Text = "Complete";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(498, 96);
            label3.Name = "label3";
            label3.Size = new Size(214, 20);
            label3.TabIndex = 4;
            label3.Text = "Press to finished order creation";
            // 
            // orderConstructorViewer1
            // 
            orderConstructorViewer1.Dock = DockStyle.Fill;
            orderConstructorViewer1.Location = new Point(0, 0);
            orderConstructorViewer1.Name = "orderConstructorViewer1";
            orderConstructorViewer1.Size = new Size(800, 399);
            orderConstructorViewer1.TabIndex = 0;
            orderConstructorViewer1.Load += orderConstructorViewer1_Load;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "Menu";
            Text = "Menu";
            FormClosed += Menu_FormClosed;
            Load += Menu_Load;
            KeyDown += Menu_KeyDown;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        

        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private UserControls.CommandManagerViewer commandManagerViewer1;
         Label MenuMode;
        private UserControls.OrderConstructorViewer orderConstructorViewer1;
        private MenuController controller;

        private Button button1;
        private Label label3;
    }
}