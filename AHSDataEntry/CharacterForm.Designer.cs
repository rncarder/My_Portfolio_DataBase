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
            lblCharName = new Label();
            lblCastPicker = new Label();
            cmbSeasonList1 = new ComboBox();
            cmbSeasonList2 = new ComboBox();
            lblSeason1 = new Label();
            lblSeason2 = new Label();
            charAddToBufferBtn = new Button();
            txtEpNum = new TextBox();
            lblNumOfEps1 = new Label();
            txtEp2 = new TextBox();
            lblNumOfEps2 = new Label();
            commitBtn = new Button();
            OpenCastPanel = new Button();
            panel = new Panel();
            pnlTxtSeasonNum = new TextBox();
            pnlLblSeasonNum = new Label();
            pnlLblName = new Label();
            PnlTxtName = new TextBox();
            pnlAddBtn = new Button();
            OpenSeasonPanel = new Button();
            charDashBoard = new DataGridView();
            panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)charDashBoard).BeginInit();
            SuspendLayout();
            // 
            // txtcharName
            // 
            txtcharName.Location = new Point(92, 31);
            txtcharName.Name = "txtcharName";
            txtcharName.Size = new Size(125, 27);
            txtcharName.TabIndex = 0;
            // 
            // cmbCastList
            // 
            cmbCastList.FormattingEnabled = true;
            cmbCastList.Location = new Point(92, 64);
            cmbCastList.Name = "cmbCastList";
            cmbCastList.Size = new Size(151, 28);
            cmbCastList.TabIndex = 1;
            // 
            // lblCharName
            // 
            lblCharName.AutoSize = true;
            lblCharName.Location = new Point(37, 38);
            lblCharName.Name = "lblCharName";
            lblCharName.Size = new Size(49, 20);
            lblCharName.TabIndex = 2;
            lblCharName.Text = "Name";
            // 
            // lblCastPicker
            // 
            lblCastPicker.AutoSize = true;
            lblCastPicker.Location = new Point(37, 72);
            lblCastPicker.Name = "lblCastPicker";
            lblCastPicker.Size = new Size(37, 20);
            lblCastPicker.TabIndex = 3;
            lblCastPicker.Text = "Cast";
            // 
            // cmbSeasonList1
            // 
            cmbSeasonList1.FormattingEnabled = true;
            cmbSeasonList1.Location = new Point(92, 104);
            cmbSeasonList1.Name = "cmbSeasonList1";
            cmbSeasonList1.Size = new Size(151, 28);
            cmbSeasonList1.TabIndex = 2;
            // 
            // cmbSeasonList2
            // 
            cmbSeasonList2.FormattingEnabled = true;
            cmbSeasonList2.Location = new Point(92, 171);
            cmbSeasonList2.Name = "cmbSeasonList2";
            cmbSeasonList2.Size = new Size(151, 28);
            cmbSeasonList2.TabIndex = 4;
            // 
            // lblSeason1
            // 
            lblSeason1.AutoSize = true;
            lblSeason1.Location = new Point(12, 110);
            lblSeason1.Name = "lblSeason1";
            lblSeason1.Size = new Size(64, 20);
            lblSeason1.TabIndex = 6;
            lblSeason1.Text = "Season1";
            // 
            // lblSeason2
            // 
            lblSeason2.AutoSize = true;
            lblSeason2.Location = new Point(12, 174);
            lblSeason2.Name = "lblSeason2";
            lblSeason2.Size = new Size(64, 20);
            lblSeason2.TabIndex = 7;
            lblSeason2.Text = "Season2";
            // 
            // charAddToBufferBtn
            // 
            charAddToBufferBtn.Location = new Point(22, 256);
            charAddToBufferBtn.Name = "charAddToBufferBtn";
            charAddToBufferBtn.Size = new Size(136, 29);
            charAddToBufferBtn.TabIndex = 6;
            charAddToBufferBtn.Text = "Add to Buffer";
            charAddToBufferBtn.UseVisualStyleBackColor = true;
            charAddToBufferBtn.Click += CharAddToBuffer_click;
            // 
            // txtEpNum
            // 
            txtEpNum.Location = new Point(164, 138);
            txtEpNum.Name = "txtEpNum";
            txtEpNum.Size = new Size(43, 27);
            txtEpNum.TabIndex = 3;
            // 
            // lblNumOfEps1
            // 
            lblNumOfEps1.AutoSize = true;
            lblNumOfEps1.Location = new Point(12, 141);
            lblNumOfEps1.Name = "lblNumOfEps1";
            lblNumOfEps1.Size = new Size(146, 20);
            lblNumOfEps1.TabIndex = 10;
            lblNumOfEps1.Text = "Number Of Episodes";
            // 
            // txtEp2
            // 
            txtEp2.Location = new Point(174, 208);
            txtEp2.Name = "txtEp2";
            txtEp2.Size = new Size(43, 27);
            txtEp2.TabIndex = 5;
            // 
            // lblNumOfEps2
            // 
            lblNumOfEps2.AutoSize = true;
            lblNumOfEps2.Location = new Point(12, 211);
            lblNumOfEps2.Name = "lblNumOfEps2";
            lblNumOfEps2.Size = new Size(146, 20);
            lblNumOfEps2.TabIndex = 12;
            lblNumOfEps2.Text = "Number Of Episodes";
            // 
            // commitBtn
            // 
            commitBtn.Location = new Point(174, 256);
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
            OpenCastPanel.Location = new Point(249, 64);
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
            pnlTxtSeasonNum.Location = new Point(131, 88);
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
            OpenSeasonPanel.Location = new Point(249, 104);
            OpenSeasonPanel.Name = "OpenSeasonPanel";
            OpenSeasonPanel.Size = new Size(36, 29);
            OpenSeasonPanel.TabIndex = 16;
            OpenSeasonPanel.Text = "+";
            OpenSeasonPanel.UseVisualStyleBackColor = false;
            OpenSeasonPanel.Click += OpenSeasonPanel_Click;
            // 
            // charDashBoard
            // 
            charDashBoard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            charDashBoard.Location = new Point(3, 291);
            charDashBoard.Name = "charDashBoard";
            charDashBoard.RowHeadersWidth = 51;
            charDashBoard.Size = new Size(282, 168);
            charDashBoard.TabIndex = 17;
            charDashBoard.CellClick += charDashBoard_CellClick;
            // 
            // CharacterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 465);
            Controls.Add(charDashBoard);
            Controls.Add(OpenSeasonPanel);
            Controls.Add(panel);
            Controls.Add(OpenCastPanel);
            Controls.Add(commitBtn);
            Controls.Add(lblNumOfEps2);
            Controls.Add(txtEp2);
            Controls.Add(lblNumOfEps1);
            Controls.Add(txtEpNum);
            Controls.Add(charAddToBufferBtn);
            Controls.Add(lblSeason2);
            Controls.Add(lblSeason1);
            Controls.Add(cmbSeasonList2);
            Controls.Add(cmbSeasonList1);
            Controls.Add(lblCastPicker);
            Controls.Add(lblCharName);
            Controls.Add(cmbCastList);
            Controls.Add(txtcharName);
            Name = "CharacterForm";
            Text = "CharacterForm";
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)charDashBoard).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtcharName;
        private ComboBox cmbCastList;
        private Label lblCharName;
        private Label lblCastPicker;
        private ComboBox cmbSeasonList1;
        private ComboBox cmbSeasonList2;
        private Label lblSeason1;
        private Label lblSeason2;
        private Button charAddToBufferBtn;
        private TextBox txtEpNum;
        private Label lblNumOfEps1;
        private TextBox txtEp2;
        private Label lblNumOfEps2;
        private Button commitBtn;
        private Button OpenCastPanel;
        private Panel panel;
        private TextBox pnlTxtSeasonNum;
        private Label pnlLblSeasonNum;
        private Label pnlLblName;
        private TextBox PnlTxtName;
        private Button pnlAddBtn;
        private Button OpenSeasonPanel;
        private DataGridView charDashBoard;
    }
}