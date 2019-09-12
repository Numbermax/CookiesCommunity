namespace CakeComunity
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.loginInput = new System.Windows.Forms.TextBox();
            this.passwordInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butLogin = new System.Windows.Forms.Button();
            this.siginBut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // loginInput
            // 
            this.loginInput.Location = new System.Drawing.Point(35, 132);
            this.loginInput.Name = "loginInput";
            this.loginInput.Size = new System.Drawing.Size(375, 22);
            this.loginInput.TabIndex = 1;
            this.loginInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // passwordInput
            // 
            this.passwordInput.Location = new System.Drawing.Point(35, 212);
            this.passwordInput.Name = "passwordInput";
            this.passwordInput.Size = new System.Drawing.Size(375, 22);
            this.passwordInput.TabIndex = 3;
            this.passwordInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // butLogin
            // 
            this.butLogin.Location = new System.Drawing.Point(109, 266);
            this.butLogin.Name = "butLogin";
            this.butLogin.Size = new System.Drawing.Size(205, 33);
            this.butLogin.TabIndex = 4;
            this.butLogin.Text = "Login";
            this.butLogin.UseVisualStyleBackColor = true;
            this.butLogin.Click += new System.EventHandler(this.ButLogin_Click);
            // 
            // siginBut
            // 
            this.siginBut.Location = new System.Drawing.Point(109, 305);
            this.siginBut.Name = "siginBut";
            this.siginBut.Size = new System.Drawing.Size(205, 33);
            this.siginBut.TabIndex = 5;
            this.siginBut.Text = "Sign ";
            this.siginBut.UseVisualStyleBackColor = true;
            this.siginBut.Click += new System.EventHandler(this.SiginBut_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 636);
            this.Controls.Add(this.siginBut);
            this.Controls.Add(this.butLogin);
            this.Controls.Add(this.passwordInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.loginInput);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox loginInput;
        private System.Windows.Forms.TextBox passwordInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butLogin;
        private System.Windows.Forms.Button siginBut;
    }
}

