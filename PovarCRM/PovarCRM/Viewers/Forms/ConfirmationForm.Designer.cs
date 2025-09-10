namespace PovarCRM.Viewers
{
    partial class ConfirmationForm
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
        public bool? YesOrNo {  get; set; }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            Title = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            DeniedButton = new Button();
            ConfirmButton = new Button();
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
            splitContainer1.Panel1.Controls.Add(Title);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel1);
            splitContainer1.Size = new Size(564, 299);
            splitContainer1.SplitterDistance = 154;
            splitContainer1.TabIndex = 0;
            // 
            // Title
            // 
            Title.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Title.AutoSize = true;
            Title.Location = new Point(207, 73);
            Title.Name = "Title";
            Title.Size = new Size(138, 20);
            Title.TabIndex = 0;
            Title.Text = "Execute command?";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.52988F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 82.47012F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 105F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 184F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 44F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 84F));
            tableLayoutPanel1.Controls.Add(DeniedButton, 3, 1);
            tableLayoutPanel1.Controls.Add(ConfirmButton, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 45.37037F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 54.62963F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.Size = new Size(564, 141);
            tableLayoutPanel1.TabIndex = 1;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // DeniedButton
            // 
            DeniedButton.BackColor = Color.Red;
            DeniedButton.Dock = DockStyle.Fill;
            DeniedButton.Location = new Point(338, 52);
            DeniedButton.Name = "DeniedButton";
            DeniedButton.Size = new Size(178, 53);
            DeniedButton.TabIndex = 3;
            DeniedButton.Text = "No";
            DeniedButton.UseVisualStyleBackColor = false;
            DeniedButton.Click += DeniedButton_Click;
            // 
            // ConfirmButton
            // 
            ConfirmButton.BackColor = Color.LimeGreen;
            ConfirmButton.Dock = DockStyle.Fill;
            ConfirmButton.Location = new Point(43, 52);
            ConfirmButton.Name = "ConfirmButton";
            ConfirmButton.Size = new Size(184, 53);
            ConfirmButton.TabIndex = 2;
            ConfirmButton.Text = "Yes";
            ConfirmButton.UseVisualStyleBackColor = false;
            ConfirmButton.Click += ConfirmButton_Click;
            // 
            // ConfirmationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(564, 299);
            Controls.Add(splitContainer1);
            Name = "ConfirmationForm";
            Text = "ConfirmationForm";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label Title;
        private TableLayoutPanel tableLayoutPanel1;
        private Button DeniedButton;
        private Button ConfirmButton;
    }
}