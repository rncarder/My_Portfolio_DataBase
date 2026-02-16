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
            charAddToBufferBtn = new Button();
            txtEpNum = new TextBox();
            label5 = new Label();
            txtEp2 = new TextBox();
            label6 = new Label();
            commitBtn = new Button();
            OpenCastPanel = new Button();
            panel = new Panel();
            pnlTxtSeasonNum = new TextBox();
            pnlLblSeasonNum = new Label();
            pnlLblName = new Label();
            PnlTxtName = new TextBox();
            pnlAddBtn = new Button();
            OpenSeasonPanel = new Button();
            panel.SuspendLayout();
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
            cmbSeasonList2.Location = new Point(92, 217);
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
            label4.Location = new Point(22, 220);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 7;
            label4.Text = "Season2";
            // 
            // charAddToBufferBtn
            // 
            charAddToBufferBtn.Location = new Point(22, 306);
            charAddToBufferBtn.Name = "charAddToBufferBtn";
            charAddToBufferBtn.Size = new Size(136, 29);
            charAddToBufferBtn.TabIndex = 6;
            charAddToBufferBtn.Text = "Add to Buffer";
            charAddToBufferBtn.UseVisualStyleBackColor = true;
            charAddToBufferBtn.Click += CharAddToBuffer_click;
            // 
            // txtEpNum
            // 
            txtEpNum.Location = new Point(174, 174);
            txtEpNum.Name = "txtEpNum";
            txtEpNum.Size = new Size(43, 27);
            txtEpNum.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 181);
            label5.Name = "label5";
            label5.Size = new Size(146, 20);
            label5.TabIndex = 10;
            label5.Text = "Number Of Episodes";
            // 
            // txtEp2
            // 
            txtEp2.Location = new Point(174, 253);
            txtEp2.Name = "txtEp2";
            txtEp2.Size = new Size(43, 27);
            txtEp2.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 263);
            label6.Name = "label6";
            label6.Size = new Size(146, 20);
            label6.TabIndex = 12;
            label6.Text = "Number Of Episodes";
            // 
            // commitBtn
            // 
            commitBtn.Location = new Point(174, 306);
            commitBtn.Name = "commitBtn";
            commitBtn.Size = new Size(94, 29);
            commitBtn.TabIndex = 13;
            commitBtn.Text = "commit";
            commitBtn.UseVisualStyleBackColor = true;
            commitBtn.Click += commitBtn_Click;
            // 
            // OpenCastPanel
            // 
            OpenCastPanel.BackColor = SystemColors.ControlText;
            OpenCastPanel.Font = new Font("Rockwell Extra Bold", 10F, FontStyle.Bold);
            OpenCastPanel.ForeColor = SystemColors.ActiveCaption;
            OpenCastPanel.Location = new Point(251, 106);
            OpenCastPanel.Name = "OpenCastPanel";
            OpenCastPanel.Size = new Size(36, 29);
            OpenCastPanel.TabIndex = 14;
            OpenCastPanel.Text = "+";
            OpenCastPanel.UseVisualStyleBackColor = false;
            OpenCastPanel.Click += OpenCastPanel_Click;
            // 
            // panel
            // 
            panel.Controls.Add(pnlTxtSeasonNum);
            panel.Controls.Add(pnlLblSeasonNum);
            panel.Controls.Add(pnlLblName);
            panel.Controls.Add(PnlTxtName);
            panel.Controls.Add(pnlAddBtn);
            panel.Location = new Point(322, 12);
            panel.Name = "panel";
            panel.Size = new Size(380, 233);
            panel.TabIndex = 15;
            panel.Visible = false;
            // 
            // pnlTxtSeasonNum
            // 
            pnlTxtSeasonNum.Location = new Point(131, 91);
            pnlTxtSeasonNum.Name = "pnlTxtSeasonNum";
            pnlTxtSeasonNum.Size = new Size(125, 27);
            pnlTxtSeasonNum.TabIndex = 7;
            // 
            // pnlLblSeasonNum
            // 
            pnlLblSeasonNum.AutoSize = true;
            pnlLblSeasonNum.Location = new Point(11, 95);
            pnlLblSeasonNum.Name = "pnlLblSeasonNum";
            pnlLblSeasonNum.Size = new Size(114, 20);
            pnlLblSeasonNum.TabIndex = 3;
            pnlLblSeasonNum.Text = "Season Number";
            // 
            // pnlLblName
            // 
            pnlLblName.AutoSize = true;
            pnlLblName.Location = new Point(76, 132);
            pnlLblName.Name = "pnlLblName";
            pnlLblName.Size = new Size(49, 20);
            pnlLblName.TabIndex = 2;
            pnlLblName.Text = "Name";
            // 
            // PnlTxtName
            // 
            PnlTxtName.Location = new Point(131, 129);
            PnlTxtName.Name = "PnlTxtName";
            PnlTxtName.Size = new Size(125, 27);
            PnlTxtName.TabIndex = 8;
            // 
            // pnlAddBtn
            // 
            pnlAddBtn.Location = new Point(76, 169);
            pnlAddBtn.Name = "pnlAddBtn";
            pnlAddBtn.Size = new Size(166, 29);
            pnlAddBtn.TabIndex = 9;
            pnlAddBtn.Text = "Add to Buffer";
            pnlAddBtn.UseVisualStyleBackColor = true;
            pnlAddBtn.Click += pnlAddBtn_Click;
            // 
            // OpenSeasonPanel
            // 
            OpenSeasonPanel.BackColor = SystemColors.ActiveCaptionText;
            OpenSeasonPanel.Font = new Font("Rockwell Extra Bold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OpenSeasonPanel.ForeColor = SystemColors.HotTrack;
            OpenSeasonPanel.Location = new Point(251, 144);
            OpenSeasonPanel.Name = "OpenSeasonPanel";
            OpenSeasonPanel.Size = new Size(36, 29);
            OpenSeasonPanel.TabIndex = 16;
            OpenSeasonPanel.Text = "+";
            OpenSeasonPanel.UseVisualStyleBackColor = false;
            OpenSeasonPanel.Click += OpenSeasonPanel_Click;
            // 
            // CharacterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(OpenSeasonPanel);
            Controls.Add(panel);
            Controls.Add(OpenCastPanel);
            Controls.Add(commitBtn);
            Controls.Add(label6);
            Controls.Add(txtEp2);
            Controls.Add(label5);
            Controls.Add(txtEpNum);
            Controls.Add(charAddToBufferBtn);
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
            panel.ResumeLayout(false);
            panel.PerformLayout();
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
        private Button charAddToBufferBtn;
        private TextBox txtEpNum;
        private Label label5;
        private TextBox txtEp2;
        private Label label6;
        private Button commitBtn;
        private Button OpenCastPanel;
        private Panel panel;
        private TextBox pnlTxtSeasonNum;
        private Label pnlLblSeasonNum;
        private Label pnlLblName;
        private TextBox PnlTxtName;
        private Button pnlAddBtn;
        private Button OpenSeasonPanel;
    }
}