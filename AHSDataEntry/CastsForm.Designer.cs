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
            label1 = new Label();
            commitCastBtn = new Button();
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
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 68);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 2;
            label1.Text = "Name";
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
            // CastsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(commitCastBtn);
            Controls.Add(label1);
            Controls.Add(txtCastName);
            Controls.Add(button1);
            Name = "CastsForm";
            Text = "CastsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox txtCastName;
        private Label label1;
        private Button commitCastBtn;
    }
}