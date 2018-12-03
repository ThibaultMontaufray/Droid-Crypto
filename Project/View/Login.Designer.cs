namespace Droid.Cryptographie
{
    partial class Login
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
            this.labelLogin = new System.Windows.Forms.Label();
            this.checkBoxLearnMode = new System.Windows.Forms.CheckBox();
            this.buttonPost = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.textBoxKeyFrequenceDetection1 = new TextBoxKeyFrequenceDetection();
            this.SuspendLayout();
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(12, 38);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(33, 13);
            this.labelLogin.TabIndex = 0;
            this.labelLogin.Text = "Login";
            // 
            // checkBoxLearnMode
            // 
            this.checkBoxLearnMode.AutoSize = true;
            this.checkBoxLearnMode.Checked = true;
            this.checkBoxLearnMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLearnMode.Location = new System.Drawing.Point(15, 12);
            this.checkBoxLearnMode.Name = "checkBoxLearnMode";
            this.checkBoxLearnMode.Size = new System.Drawing.Size(90, 17);
            this.checkBoxLearnMode.TabIndex = 4;
            this.checkBoxLearnMode.Text = "Register profil";
            this.checkBoxLearnMode.UseVisualStyleBackColor = true;
            this.checkBoxLearnMode.CheckedChanged += new System.EventHandler(this.checkBoxLearnMode_CheckedChanged);
            // 
            // buttonPost
            // 
            this.buttonPost.Location = new System.Drawing.Point(202, 61);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(75, 23);
            this.buttonPost.TabIndex = 5;
            this.buttonPost.Text = "Register";
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(12, 66);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(0, 13);
            this.labelResult.TabIndex = 6;
            // 
            // textBoxKeyFrequenceDetection1
            // 
            this.textBoxKeyFrequenceDetection1.Learning = true;
            this.textBoxKeyFrequenceDetection1.Location = new System.Drawing.Point(51, 35);
            this.textBoxKeyFrequenceDetection1.Name = "textBoxKeyFrequenceDetection1";
            this.textBoxKeyFrequenceDetection1.Size = new System.Drawing.Size(226, 20);
            this.textBoxKeyFrequenceDetection1.TabIndex = 7;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 92);
            this.Controls.Add(this.textBoxKeyFrequenceDetection1);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.buttonPost);
            this.Controls.Add(this.checkBoxLearnMode);
            this.Controls.Add(this.labelLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.CheckBox checkBoxLearnMode;
        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.Label labelResult;
        private TextBoxKeyFrequenceDetection textBoxKeyFrequenceDetection1;
    }
}