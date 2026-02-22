namespace AHSDataEntry
{
    partial class seasonForm
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
            lblSeasonName = new Label();
            txtSeasonName = new TextBox();
            addSeasonBtn = new Button();
            lblSeasonNum = new Label();
            txtSeasonNum = new TextBox();
            label3 = new Label();
            commitBtn = new Button();
            bufferDash = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)bufferDash).BeginInit();
            SuspendLayout();
            // 
            // lblSeasonName
            // 
            lblSeasonName.AutoSize = true;
            lblSeasonName.Location = new Point(69, 118);
            lblSeasonName.Name = "lblSeasonName";
            lblSeasonName.Size = new Size(49, 20);
            lblSeasonName.TabIndex = 0;
            lblSeasonName.Text = "Name";
            // 
            // txtSeasonName
            // 
            txtSeasonName.Location = new Point(124, 118);
            txtSeasonName.Name = "txtSeasonName";
            txtSeasonName.Size = new Size(125, 27);
            txtSeasonName.TabIndex = 1;
            txtSeasonName.KeyPress += UIHelper.Alpha_KeyPress;
            // 
            // addSeasonBtn
            // 
            addSeasonBtn.Location = new Point(30, 151);
            addSeasonBtn.Name = "addSeasonBtn";
            addSeasonBtn.Size = new Size(133, 29);
            addSeasonBtn.TabIndex = 2;
            addSeasonBtn.Text = "Add to Buffer";
            addSeasonBtn.UseVisualStyleBackColor = true;
            addSeasonBtn.Click += addSeason_Click;
            // 
            // lblSeasonNum
            // 
            lblSeasonNum.AutoSize = true;
            lblSeasonNum.Location = new Point(30, 88);
            lblSeasonNum.Name = "lblSeasonNum";
            lblSeasonNum.Size = new Size(88, 20);
            lblSeasonNum.TabIndex = 3;
            lblSeasonNum.Text = "SeasonNum";
            // 
            // txtSeasonNum
            // 
            txtSeasonNum.Location = new Point(124, 85);
            txtSeasonNum.Name = "txtSeasonNum";
            txtSeasonNum.Size = new Size(125, 27);
            txtSeasonNum.TabIndex = 0;
            txtSeasonNum.KeyPress += UIHelper.Digit_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20F);
            label3.Location = new Point(30, 24);
            label3.Name = "label3";
            label3.Size = new Size(197, 46);
            label3.TabIndex = 5;
            label3.Text = "Add Season";
            // 
            // commitBtn
            // 
            commitBtn.Location = new Point(180, 151);
            commitBtn.Name = "commitBtn";
            commitBtn.Size = new Size(94, 29);
            commitBtn.TabIndex = 4;
            commitBtn.Text = "commit";
            commitBtn.UseVisualStyleBackColor = true;
            commitBtn.Click += commitBtn_Click;
            // 
            // bufferDash
            // 
            bufferDash.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            bufferDash.Location = new Point(2, 310);
            bufferDash.Name = "bufferDash";
            bufferDash.RowHeadersWidth = 51;
            bufferDash.Size = new Size(791, 142);
            bufferDash.TabIndex = 6;
            bufferDash.CellClick += bufferDash_CellClick;
            // 
            // seasonForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(bufferDash);
            Controls.Add(commitBtn);
            Controls.Add(label3);
            Controls.Add(txtSeasonNum);
            Controls.Add(lblSeasonNum);
            Controls.Add(addSeasonBtn);
            Controls.Add(txtSeasonName);
            Controls.Add(lblSeasonName);
            Name = "seasonForm";
            Text = "seasonForm";
            ((System.ComponentModel.ISupportInitialize)bufferDash).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSeasonName;
        private TextBox txtSeasonName;
        private Button addSeasonBtn;
        private Label lblSeasonNum;
        private TextBox txtSeasonNum;
        private Label label3;
        private Button commitBtn;
        private DataGridView bufferDash;
    }
}