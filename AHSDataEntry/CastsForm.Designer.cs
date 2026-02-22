namespace AHSDataEntry
{
    partial class CastsForm
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
            button1 = new Button();
            txtCastName = new TextBox();
            lblCastName = new Label();
            commitCastBtn = new Button();
            CastDashBoard = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)CastDashBoard).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(22, 114);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "Enter";
            button1.UseVisualStyleBackColor = true;
            button1.Click += addCastBtn_click;
            // 
            // txtCastName
            // 
            txtCastName.Location = new Point(77, 65);
            txtCastName.Name = "txtCastName";
            txtCastName.Size = new Size(125, 27);
            txtCastName.TabIndex = 0;
            txtCastName.KeyPress += UIHelper.Alpha_KeyPress;
            // 
            // lblCastName
            // 
            lblCastName.AutoSize = true;
            lblCastName.Location = new Point(22, 72);
            lblCastName.Name = "lblCastName";
            lblCastName.Size = new Size(49, 20);
            lblCastName.TabIndex = 2;
            lblCastName.Text = "Name";
            // 
            // commitCastBtn
            // 
            commitCastBtn.Location = new Point(148, 114);
            commitCastBtn.Name = "commitCastBtn";
            commitCastBtn.Size = new Size(94, 29);
            commitCastBtn.TabIndex = 2;
            commitCastBtn.Text = "commit";
            commitCastBtn.UseVisualStyleBackColor = true;
            commitCastBtn.Click += commitCastBtn_Click;
            // 
            // CastDashBoard
            // 
            CastDashBoard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CastDashBoard.Location = new Point(22, 310);
            CastDashBoard.Name = "CastDashBoard";
            CastDashBoard.RowHeadersWidth = 51;
            CastDashBoard.Size = new Size(300, 128);
            CastDashBoard.TabIndex = 3;
            CastDashBoard.CellClick += CastDashBoard_CellClick;
            // 
            // CastsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CastDashBoard);
            Controls.Add(commitCastBtn);
            Controls.Add(lblCastName);
            Controls.Add(txtCastName);
            Controls.Add(button1);
            Name = "CastsForm";
            Text = "CastsForm";
            ((System.ComponentModel.ISupportInitialize)CastDashBoard).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox txtCastName;
        private Label lblCastName;
        private Button commitCastBtn;
        private DataGridView CastDashBoard;
    }
}