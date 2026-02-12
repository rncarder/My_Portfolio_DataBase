namespace AHSDataEntry
{
    partial class CharacterForm
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
            txtcharName = new TextBox();
            cmbCastList = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            cmbSeasonList1 = new ComboBox();
            cmbSeasonList2 = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            charAddBtn = new Button();
            txtEpNum = new TextBox();
            label5 = new Label();
            txtEp2 = new TextBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // txtcharName
            // 
            txtcharName.Location = new Point(92, 71);
            txtcharName.Name = "txtcharName";
            txtcharName.Size = new Size(125, 27);
            txtcharName.TabIndex = 0;
            // 
            // cmbCastList
            // 
            cmbCastList.FormattingEnabled = true;
            cmbCastList.Location = new Point(92, 104);
            cmbCastList.Name = "cmbCastList";
            cmbCastList.Size = new Size(151, 28);
            cmbCastList.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 71);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 2;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 107);
            label2.Name = "label2";
            label2.Size = new Size(37, 20);
            label2.TabIndex = 3;
            label2.Text = "Cast";
            // 
            // cmbSeasonList1
            // 
            cmbSeasonList1.FormattingEnabled = true;
            cmbSeasonList1.Location = new Point(92, 138);
            cmbSeasonList1.Name = "cmbSeasonList1";
            cmbSeasonList1.Size = new Size(151, 28);
            cmbSeasonList1.TabIndex = 2;
            // 
            // cmbSeasonList2
            // 
            cmbSeasonList2.FormattingEnabled = true;
            cmbSeasonList2.Location = new Point(92, 174);
            cmbSeasonList2.Name = "cmbSeasonList2";
            cmbSeasonList2.Size = new Size(151, 28);
            cmbSeasonList2.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 138);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 6;
            label3.Text = "Season1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 174);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 7;
            label4.Text = "Season2";
            // 
            // charAddBtn
            // 
            charAddBtn.Location = new Point(92, 208);
            charAddBtn.Name = "charAddBtn";
            charAddBtn.Size = new Size(94, 29);
            charAddBtn.TabIndex = 6;
            charAddBtn.Text = "button1";
            charAddBtn.UseVisualStyleBackColor = true;
            charAddBtn.Click += charAddBtn_click;
            // 
            // txtEpNum
            // 
            txtEpNum.Location = new Point(402, 134);
            txtEpNum.Name = "txtEpNum";
            txtEpNum.Size = new Size(43, 27);
            txtEpNum.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(249, 141);
            label5.Name = "label5";
            label5.Size = new Size(146, 20);
            label5.TabIndex = 10;
            label5.Text = "Number Of Episodes";
            // 
            // txtEp2
            // 
            txtEp2.Location = new Point(402, 174);
            txtEp2.Name = "txtEp2";
            txtEp2.Size = new Size(43, 27);
            txtEp2.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(250, 177);
            label6.Name = "label6";
            label6.Size = new Size(146, 20);
            label6.TabIndex = 12;
            label6.Text = "Number Of Episodes";
            // 
            // CharacterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(txtEp2);
            Controls.Add(label5);
            Controls.Add(txtEpNum);
            Controls.Add(charAddBtn);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cmbSeasonList2);
            Controls.Add(cmbSeasonList1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbCastList);
            Controls.Add(txtcharName);
            Name = "CharacterForm";
            Text = "CharacterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtcharName;
        private ComboBox cmbCastList;
        private Label label1;
        private Label label2;
        private ComboBox cmbSeasonList1;
        private ComboBox cmbSeasonList2;
        private Label label3;
        private Label label4;
        private Button charAddBtn;
        private TextBox txtEpNum;
        private Label label5;
        private TextBox txtEp2;
        private Label label6;
    }
}