namespace AHSQuery
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CmbTables = new ComboBox();
            dgv = new DataGridView();
            refreshBtn = new Button();
            searchBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // CmbTables
            // 
            CmbTables.FormattingEnabled = true;
            CmbTables.Location = new Point(288, 24);
            CmbTables.Name = "CmbTables";
            CmbTables.Size = new Size(151, 28);
            CmbTables.TabIndex = 0;
            CmbTables.SelectionChangeCommitted += Cmb_Select_Commit;
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Location = new Point(48, 81);
            dgv.Name = "dgv";
            dgv.RowHeadersWidth = 51;
            dgv.Size = new Size(619, 313);
            dgv.TabIndex = 4;
            // 
            // refreshBtn
            // 
            refreshBtn.Image = Properties.Resources.refresh_2_16;
            refreshBtn.Location = new Point(472, 24);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(32, 29);
            refreshBtn.TabIndex = 7;
            refreshBtn.UseVisualStyleBackColor = true;
            refreshBtn.Click += refreshBtn_Click;
            // 
            // searchBox
            // 
            searchBox.Location = new Point(48, 26);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(209, 27);
            searchBox.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(searchBox);
            Controls.Add(refreshBtn);
            Controls.Add(dgv);
            Controls.Add(CmbTables);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox CmbTables;
        private DataGridView dgv;
        private Button refreshBtn;
        private TextBox searchBox;
    }
}
