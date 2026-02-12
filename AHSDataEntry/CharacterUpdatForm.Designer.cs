namespace AHSDataEntry
{
    partial class CharacterUpdatForm
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
            cmbCharNameSelect = new ComboBox();
            cmbCastEdit = new ComboBox();
            label1 = new Label();
            cmbSeason1Edit = new ComboBox();
            cmbSeason2Edit = new ComboBox();
            txtEp1Edit = new TextBox();
            txtEp2Edit = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            CharEditBtn = new Button();
            label7 = new Label();
            cmbRemoveChar = new ComboBox();
            RemoveCharBtn = new Button();
            txtCharNameEdit = new TextBox();
            label8 = new Label();
            SuspendLayout();
            // 
            // cmbCharNameSelect
            // 
            cmbCharNameSelect.FormattingEnabled = true;
            cmbCharNameSelect.Location = new Point(109, 12);
            cmbCharNameSelect.Name = "cmbCharNameSelect";
            cmbCharNameSelect.Size = new Size(151, 28);
            cmbCharNameSelect.TabIndex = 0;
            // 
            // cmbCastEdit
            // 
            cmbCastEdit.FormattingEnabled = true;
            cmbCastEdit.Location = new Point(109, 46);
            cmbCastEdit.Name = "cmbCastEdit";
            cmbCastEdit.Size = new Size(151, 28);
            cmbCastEdit.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 20);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 2;
            label1.Text = "Name";
            // 
            // cmbSeason1Edit
            // 
            cmbSeason1Edit.FormattingEnabled = true;
            cmbSeason1Edit.Location = new Point(109, 80);
            cmbSeason1Edit.Name = "cmbSeason1Edit";
            cmbSeason1Edit.Size = new Size(151, 28);
            cmbSeason1Edit.TabIndex = 3;
            // 
            // cmbSeason2Edit
            // 
            cmbSeason2Edit.FormattingEnabled = true;
            cmbSeason2Edit.Location = new Point(109, 114);
            cmbSeason2Edit.Name = "cmbSeason2Edit";
            cmbSeason2Edit.Size = new Size(151, 28);
            cmbSeason2Edit.TabIndex = 4;
            // 
            // txtEp1Edit
            // 
            txtEp1Edit.Location = new Point(379, 81);
            txtEp1Edit.Name = "txtEp1Edit";
            txtEp1Edit.Size = new Size(125, 27);
            txtEp1Edit.TabIndex = 5;
            // 
            // txtEp2Edit
            // 
            txtEp2Edit.Location = new Point(379, 115);
            txtEp2Edit.Name = "txtEp2Edit";
            txtEp2Edit.Size = new Size(125, 27);
            txtEp2Edit.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 46);
            label2.Name = "label2";
            label2.Size = new Size(37, 20);
            label2.TabIndex = 7;
            label2.Text = "Cast";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 83);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 8;
            label3.Text = "Season1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 118);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 9;
            label4.Text = "Season2";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(266, 83);
            label5.Name = "label5";
            label5.Size = new Size(102, 20);
            label5.TabIndex = 10;
            label5.Text = "Number of Ep";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(266, 117);
            label6.Name = "label6";
            label6.Size = new Size(102, 20);
            label6.TabIndex = 11;
            label6.Text = "Number of Ep";
            // 
            // CharEditBtn
            // 
            CharEditBtn.Location = new Point(514, 118);
            CharEditBtn.Name = "CharEditBtn";
            CharEditBtn.Size = new Size(94, 29);
            CharEditBtn.TabIndex = 12;
            CharEditBtn.Text = "Enter";
            CharEditBtn.UseVisualStyleBackColor = true;
            CharEditBtn.Click += charEditBtn_click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 20F);
            label7.Location = new Point(180, 226);
            label7.Name = "label7";
            label7.Size = new Size(234, 46);
            label7.TabIndex = 13;
            label7.Text = "Remove At ID ";
            label7.Visible = false;
            // 
            // cmbRemoveChar
            // 
            cmbRemoveChar.FormattingEnabled = true;
            cmbRemoveChar.Location = new Point(180, 289);
            cmbRemoveChar.Name = "cmbRemoveChar";
            cmbRemoveChar.Size = new Size(151, 28);
            cmbRemoveChar.TabIndex = 14;
            cmbRemoveChar.Visible = false;
            // 
            // RemoveCharBtn
            // 
            RemoveCharBtn.Location = new Point(349, 288);
            RemoveCharBtn.Name = "RemoveCharBtn";
            RemoveCharBtn.Size = new Size(94, 29);
            RemoveCharBtn.TabIndex = 15;
            RemoveCharBtn.Text = "Remove";
            RemoveCharBtn.UseVisualStyleBackColor = true;
            RemoveCharBtn.Visible = false;
            RemoveCharBtn.Click += removeCharBtn_click;
            // 
            // txtCharNameEdit
            // 
            txtCharNameEdit.Location = new Point(135, 152);
            txtCharNameEdit.Name = "txtCharNameEdit";
            txtCharNameEdit.Size = new Size(125, 27);
            txtCharNameEdit.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(29, 155);
            label8.Name = "label8";
            label8.Size = new Size(79, 20);
            label8.TabIndex = 17;
            label8.Text = "Edit Name";
            // 
            // CharacterUpdatForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label8);
            Controls.Add(txtCharNameEdit);
            Controls.Add(RemoveCharBtn);
            Controls.Add(cmbRemoveChar);
            Controls.Add(label7);
            Controls.Add(CharEditBtn);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtEp2Edit);
            Controls.Add(txtEp1Edit);
            Controls.Add(cmbSeason2Edit);
            Controls.Add(cmbSeason1Edit);
            Controls.Add(label1);
            Controls.Add(cmbCastEdit);
            Controls.Add(cmbCharNameSelect);
            Name = "CharacterUpdatForm";
            Text = "CharacterUpdatForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCharNameSelect;
        private ComboBox cmbCastEdit;
        private Label label1;
        private ComboBox cmbSeason1Edit;
        private ComboBox cmbSeason2Edit;
        private TextBox txtEp1Edit;
        private TextBox txtEp2Edit;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button CharEditBtn;
        private Label label7;
        private ComboBox cmbRemoveChar;
        private Button RemoveCharBtn;
        private TextBox txtCharNameEdit;
        private Label label8;
    }
}