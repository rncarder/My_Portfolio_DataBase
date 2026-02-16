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
            label1 = new Label();
            txtSeasonName = new TextBox();
            addSeasonBtn = new Button();
            label2 = new Label();
            txtSeasonNum = new TextBox();
            label3 = new Label();
            commitBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 118);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // txtSeasonName
            // 
            txtSeasonName.Location = new Point(124, 118);
            txtSeasonName.Name = "txtSeasonName";
            txtSeasonName.Size = new Size(125, 27);
            txtSeasonName.TabIndex = 1;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 88);
            label2.Name = "label2";
            label2.Size = new Size(88, 20);
            label2.TabIndex = 3;
            label2.Text = "SeasonNum";
            // 
            // txtSeasonNum
            // 
            txtSeasonNum.Location = new Point(124, 85);
            txtSeasonNum.Name = "txtSeasonNum";
            txtSeasonNum.Size = new Size(125, 27);
            txtSeasonNum.TabIndex = 0;
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
            // seasonForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(commitBtn);
            Controls.Add(label3);
            Controls.Add(txtSeasonNum);
            Controls.Add(label2);
            Controls.Add(addSeasonBtn);
            Controls.Add(txtSeasonName);
            Controls.Add(label1);
            Name = "seasonForm";
            Text = "seasonForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSeasonName;
        private Button addSeasonBtn;
        private Label label2;
        private TextBox txtSeasonNum;
        private Label label3;
        private Button commitBtn;
    }
}