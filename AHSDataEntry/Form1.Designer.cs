namespace AHSDataEntry
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
            SeasonBtn = new Button();
            epBtn = new Button();
            castBtn = new Button();
            CharBtn = new Button();
            loginBtn = new Button();
            SuspendLayout();
            // 
            // SeasonBtn
            // 
            SeasonBtn.Location = new Point(30, 48);
            SeasonBtn.Name = "SeasonBtn";
            SeasonBtn.Size = new Size(164, 29);
            SeasonBtn.TabIndex = 2;
            SeasonBtn.Text = "Add Season";
            SeasonBtn.UseVisualStyleBackColor = true;
            SeasonBtn.Click += seasonBtn_click;
            // 
            // epBtn
            // 
            epBtn.Location = new Point(30, 83);
            epBtn.Name = "epBtn";
            epBtn.Size = new Size(164, 29);
            epBtn.TabIndex = 3;
            epBtn.Text = "Add Episode";
            epBtn.UseVisualStyleBackColor = true;
            epBtn.Click += epBtn_click;
            // 
            // castBtn
            // 
            castBtn.Location = new Point(30, 118);
            castBtn.Name = "castBtn";
            castBtn.Size = new Size(164, 29);
            castBtn.TabIndex = 4;
            castBtn.Text = "Add Cast";
            castBtn.UseVisualStyleBackColor = true;
            castBtn.Click += castBtn_click;
            // 
            // CharBtn
            // 
            CharBtn.Location = new Point(30, 153);
            CharBtn.Name = "CharBtn";
            CharBtn.Size = new Size(164, 29);
            CharBtn.TabIndex = 5;
            CharBtn.Text = "Add Character";
            CharBtn.UseVisualStyleBackColor = true;
            CharBtn.Click += charBtn_click;
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(45, 12);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(94, 29);
            loginBtn.TabIndex = 7;
            loginBtn.Text = "login";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(loginBtn);
            Controls.Add(CharBtn);
            Controls.Add(castBtn);
            Controls.Add(epBtn);
            Controls.Add(SeasonBtn);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion
        private Button SeasonBtn;
        private Button epBtn;
        private Button castBtn;
        private Button CharBtn;
        private Button loginBtn;
    }
}
