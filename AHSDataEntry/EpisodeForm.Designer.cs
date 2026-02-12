namespace AHSDataEntry
{
    partial class EpisodeForm
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
            txtEpName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            cmbSeasonList = new ComboBox();
            addEpBtn = new Button();
            label3 = new Label();
            label4 = new Label();
            cmbDeleteEpList = new ComboBox();
            label5 = new Label();
            epRemoveBtn = new Button();
            SuspendLayout();
            // 
            // txtEpName
            // 
            txtEpName.Location = new Point(103, 75);
            txtEpName.Name = "txtEpName";
            txtEpName.Size = new Size(125, 27);
            txtEpName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 82);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 1;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 118);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
            label2.TabIndex = 2;
            label2.Text = "Season";
            // 
            // cmbSeasonList
            // 
            cmbSeasonList.FormattingEnabled = true;
            cmbSeasonList.Location = new Point(103, 109);
            cmbSeasonList.Name = "cmbSeasonList";
            cmbSeasonList.Size = new Size(151, 28);
            cmbSeasonList.TabIndex = 3;
            // 
            // addEpBtn
            // 
            addEpBtn.Location = new Point(269, 109);
            addEpBtn.Name = "addEpBtn";
            addEpBtn.Size = new Size(94, 29);
            addEpBtn.TabIndex = 4;
            addEpBtn.Text = "Enter";
            addEpBtn.UseVisualStyleBackColor = true;
            addEpBtn.Click += addEpBtn_click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 25F);
            label3.Location = new Point(37, 9);
            label3.Name = "label3";
            label3.Size = new Size(260, 57);
            label3.TabIndex = 5;
            label3.Text = "Add Episode";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 20F);
            label4.Location = new Point(37, 163);
            label4.Name = "label4";
            label4.Size = new Size(244, 46);
            label4.TabIndex = 6;
            label4.Text = "Delete Episode";
            label4.Visible = false;
            // 
            // cmbDeleteEpList
            // 
            cmbDeleteEpList.FormattingEnabled = true;
            cmbDeleteEpList.Location = new Point(103, 228);
            cmbDeleteEpList.Name = "cmbDeleteEpList";
            cmbDeleteEpList.Size = new Size(151, 28);
            cmbDeleteEpList.TabIndex = 7;
            cmbDeleteEpList.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(43, 231);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 8;
            label5.Text = "Name";
            label5.Visible = false;
            // 
            // epRemoveBtn
            // 
            epRemoveBtn.Location = new Point(269, 227);
            epRemoveBtn.Name = "epRemoveBtn";
            epRemoveBtn.Size = new Size(94, 29);
            epRemoveBtn.TabIndex = 9;
            epRemoveBtn.Text = "Delete";
            epRemoveBtn.UseVisualStyleBackColor = true;
            epRemoveBtn.Visible = false;
            // 
            // EpisodeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(epRemoveBtn);
            Controls.Add(label5);
            Controls.Add(cmbDeleteEpList);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(addEpBtn);
            Controls.Add(cmbSeasonList);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtEpName);
            Name = "EpisodeForm";
            Text = "EpisodeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEpName;
        private Label label1;
        private Label label2;
        private ComboBox cmbSeasonList;
        private Button addEpBtn;
        private Label label3;
        private Label label4;
        private ComboBox cmbDeleteEpList;
        private Label label5;
        private Button epRemoveBtn;
    }
}