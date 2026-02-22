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
            lblEpName = new Label();
            lblEpSeason = new Label();
            cmbSeasonList = new ComboBox();
            addEpBtn = new Button();
            label3 = new Label();
            EpsCommitBtn = new Button();
            openSsnPnl = new Button();
            panel = new Panel();
            lblEpPnlSeasonName = new Label();
            lblEpPnlSeasonNum = new Label();
            txtSeasonName = new TextBox();
            txtSeasonNum = new TextBox();
            addSeasonBtn = new Button();
            episodeDash = new DataGridView();
            seasonDash = new DataGridView();
            panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)episodeDash).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seasonDash).BeginInit();
            SuspendLayout();
            // 
            // txtEpName
            // 
            txtEpName.Location = new Point(103, 75);
            txtEpName.Name = "txtEpName";
            txtEpName.Size = new Size(125, 27);
            txtEpName.TabIndex = 0;
            txtEpName.KeyPress += UIHelper.Alpha_KeyPress;
            // 
            // lblEpName
            // 
            lblEpName.AutoSize = true;
            lblEpName.Location = new Point(37, 82);
            lblEpName.Name = "lblEpName";
            lblEpName.Size = new Size(49, 20);
            lblEpName.TabIndex = 1;
            lblEpName.Text = "Name";
            // 
            // lblEpSeason
            // 
            lblEpSeason.AutoSize = true;
            lblEpSeason.Location = new Point(37, 118);
            lblEpSeason.Name = "lblEpSeason";
            lblEpSeason.Size = new Size(56, 20);
            lblEpSeason.TabIndex = 2;
            lblEpSeason.Text = "Season";
            // 
            // cmbSeasonList
            // 
            cmbSeasonList.FormattingEnabled = true;
            cmbSeasonList.Location = new Point(103, 109);
            cmbSeasonList.Name = "cmbSeasonList";
            cmbSeasonList.Size = new Size(151, 28);
            cmbSeasonList.TabIndex = 1;
            // 
            // addEpBtn
            // 
            addEpBtn.Location = new Point(37, 143);
            addEpBtn.Name = "addEpBtn";
            addEpBtn.Size = new Size(124, 29);
            addEpBtn.TabIndex = 2;
            addEpBtn.Text = "Add To Buffer";
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
            // EpsCommitBtn
            // 
            EpsCommitBtn.Location = new Point(203, 143);
            EpsCommitBtn.Name = "EpsCommitBtn";
            EpsCommitBtn.Size = new Size(94, 29);
            EpsCommitBtn.TabIndex = 3;
            EpsCommitBtn.Text = "commit";
            EpsCommitBtn.UseVisualStyleBackColor = true;
            EpsCommitBtn.Click += EpsCommitBtn_Click;
            // 
            // openSsnPnl
            // 
            openSsnPnl.BackColor = SystemColors.ActiveCaptionText;
            openSsnPnl.Font = new Font("Rockwell Extra Bold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            openSsnPnl.ForeColor = SystemColors.Highlight;
            openSsnPnl.Location = new Point(269, 109);
            openSsnPnl.Name = "openSsnPnl";
            openSsnPnl.Size = new Size(34, 29);
            openSsnPnl.TabIndex = 4;
            openSsnPnl.Text = "+";
            openSsnPnl.UseVisualStyleBackColor = false;
            openSsnPnl.Click += openSsnPnl_Click;
            // 
            // panel
            // 
            panel.Controls.Add(lblEpPnlSeasonName);
            panel.Controls.Add(lblEpPnlSeasonNum);
            panel.Controls.Add(txtSeasonName);
            panel.Controls.Add(txtSeasonNum);
            panel.Controls.Add(addSeasonBtn);
            panel.Location = new Point(399, 47);
            panel.Name = "panel";
            panel.Size = new Size(258, 153);
            panel.TabIndex = 12;
            panel.Visible = false;
            // 
            // lblEpPnlSeasonName
            // 
            lblEpPnlSeasonName.AutoSize = true;
            lblEpPnlSeasonName.Location = new Point(19, 54);
            lblEpPnlSeasonName.Name = "lblEpPnlSeasonName";
            lblEpPnlSeasonName.Size = new Size(100, 20);
            lblEpPnlSeasonName.TabIndex = 4;
            lblEpPnlSeasonName.Text = "Season Name";
            // 
            // lblEpPnlSeasonNum
            // 
            lblEpPnlSeasonNum.AutoSize = true;
            lblEpPnlSeasonNum.Location = new Point(3, 28);
            lblEpPnlSeasonNum.Name = "lblEpPnlSeasonNum";
            lblEpPnlSeasonNum.Size = new Size(114, 20);
            lblEpPnlSeasonNum.TabIndex = 3;
            lblEpPnlSeasonNum.Text = "Season Number";
            // 
            // txtSeasonName
            // 
            txtSeasonName.Location = new Point(125, 54);
            txtSeasonName.Name = "txtSeasonName";
            txtSeasonName.Size = new Size(125, 27);
            txtSeasonName.TabIndex = 6;
            txtSeasonName.KeyPress += UIHelper.Alpha_KeyPress;
            // 
            // txtSeasonNum
            // 
            txtSeasonNum.Location = new Point(125, 21);
            txtSeasonNum.Name = "txtSeasonNum";
            txtSeasonNum.Size = new Size(125, 27);
            txtSeasonNum.TabIndex = 5;
            txtSeasonNum.KeyPress += UIHelper.Digit_KeyPress;
            // 
            // addSeasonBtn
            // 
            addSeasonBtn.Location = new Point(84, 96);
            addSeasonBtn.Name = "addSeasonBtn";
            addSeasonBtn.Size = new Size(94, 29);
            addSeasonBtn.TabIndex = 7;
            addSeasonBtn.Text = "Enter";
            addSeasonBtn.UseVisualStyleBackColor = true;
            addSeasonBtn.Click += addSeasonBtn_Click;
            // 
            // episodeDash
            // 
            episodeDash.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            episodeDash.Location = new Point(12, 312);
            episodeDash.Name = "episodeDash";
            episodeDash.RowHeadersWidth = 51;
            episodeDash.Size = new Size(300, 126);
            episodeDash.TabIndex = 13;
            // 
            // seasonDash
            // 
            seasonDash.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            seasonDash.Location = new Point(370, 312);
            seasonDash.Name = "seasonDash";
            seasonDash.RowHeadersWidth = 51;
            seasonDash.Size = new Size(300, 126);
            seasonDash.TabIndex = 14;
            // 
            // EpisodeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(seasonDash);
            Controls.Add(episodeDash);
            Controls.Add(panel);
            Controls.Add(openSsnPnl);
            Controls.Add(EpsCommitBtn);
            Controls.Add(label3);
            Controls.Add(addEpBtn);
            Controls.Add(cmbSeasonList);
            Controls.Add(lblEpSeason);
            Controls.Add(lblEpName);
            Controls.Add(txtEpName);
            Name = "EpisodeForm";
            Text = "EpisodeForm";
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)episodeDash).EndInit();
            ((System.ComponentModel.ISupportInitialize)seasonDash).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEpName;
        private Label lblEpName;
        private Label lblEpSeason;
        private ComboBox cmbSeasonList;
        private Button addEpBtn;
        private Label label3;
        private Button EpsCommitBtn;
        private Button openSsnPnl;
        private Panel panel;
        private Button addSeasonBtn;
        private Label lblEpPnlSeasonName;
        private Label lblEpPnlSeasonNum;
        private TextBox txtSeasonName;
        private TextBox txtSeasonNum;
        private DataGridView episodeDash;
        private DataGridView seasonDash;
    }
}