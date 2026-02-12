namespace AHSDataEntry
{
    partial class LoginForm
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
            loginEnterBtn = new Button();
            txtUserName = new TextBox();
            txtPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // loginEnterBtn
            // 
            loginEnterBtn.Location = new Point(21, 118);
            loginEnterBtn.Name = "loginEnterBtn";
            loginEnterBtn.Size = new Size(94, 29);
            loginEnterBtn.TabIndex = 0;
            loginEnterBtn.Text = "Enter";
            loginEnterBtn.UseVisualStyleBackColor = true;
            loginEnterBtn.Click += loginEnterBtn_click;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(12, 32);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(125, 27);
            txtUserName.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(12, 85);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(125, 27);
            txtPassword.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 9);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 3;
            label1.Text = "User Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 62);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 4;
            label2.Text = "Password";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(346, 174);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtUserName);
            Controls.Add(loginEnterBtn);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button loginEnterBtn;
        private TextBox txtUserName;
        private TextBox txtPassword;
        private Label label1;
        private Label label2;
    }
}