/*
 * Created by SharpDevelop.
 * User: Amos
 * Date: 10/08/2011
 * Time: 09:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Droid_cryptographie
{
	partial class CryptoGUI
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonEncrypt = new System.Windows.Forms.Button();
			this.buttonDecrypt = new System.Windows.Forms.Button();
			this.buttonCrack = new System.Windows.Forms.Button();
			this.labelCesar1 = new System.Windows.Forms.Label();
			this.groupBoxCesar = new System.Windows.Forms.GroupBox();
			this.radioButtonCesar = new System.Windows.Forms.RadioButton();
			this.trackBarCesar1 = new System.Windows.Forms.TrackBar();
			this.textBoxCesar1 = new System.Windows.Forms.TextBox();
			this.groupBoxVigenere = new System.Windows.Forms.GroupBox();
			this.radioButtonVigenere = new System.Windows.Forms.RadioButton();
			this.textBoxVigenere1 = new System.Windows.Forms.TextBox();
			this.labelVigenere1 = new System.Windows.Forms.Label();
			this.groupBoxRSA = new System.Windows.Forms.GroupBox();
			this.radioButtonRSA = new System.Windows.Forms.RadioButton();
			this.textBoxRSA1 = new System.Windows.Forms.TextBox();
			this.labelRSA1 = new System.Windows.Forms.Label();
			this.groupBoxCesar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarCesar1)).BeginInit();
			this.groupBoxVigenere.SuspendLayout();
			this.groupBoxRSA.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonEncrypt
			// 
			this.buttonEncrypt.Location = new System.Drawing.Point(365, 201);
			this.buttonEncrypt.Name = "buttonEncrypt";
			this.buttonEncrypt.Size = new System.Drawing.Size(94, 24);
			this.buttonEncrypt.TabIndex = 0;
			this.buttonEncrypt.Text = "Chiffrer";
			this.buttonEncrypt.UseVisualStyleBackColor = true;
			this.buttonEncrypt.Click += new System.EventHandler(this.ButtonEncryptClick);
			// 
			// buttonDecrypt
			// 
			this.buttonDecrypt.Location = new System.Drawing.Point(272, 201);
			this.buttonDecrypt.Name = "buttonDecrypt";
			this.buttonDecrypt.Size = new System.Drawing.Size(87, 24);
			this.buttonDecrypt.TabIndex = 1;
			this.buttonDecrypt.Text = "Déchiffrer";
			this.buttonDecrypt.UseVisualStyleBackColor = true;
			this.buttonDecrypt.Click += new System.EventHandler(this.ButtonDecryptClick);
			// 
			// buttonCrack
			// 
			this.buttonCrack.Enabled = false;
			this.buttonCrack.Location = new System.Drawing.Point(188, 201);
			this.buttonCrack.Name = "buttonCrack";
			this.buttonCrack.Size = new System.Drawing.Size(78, 24);
			this.buttonCrack.TabIndex = 2;
			this.buttonCrack.Text = "Cracker";
			this.buttonCrack.UseVisualStyleBackColor = true;
			this.buttonCrack.Click += new System.EventHandler(this.ButtonCrackClick);
			// 
			// labelCesar1
			// 
			this.labelCesar1.ForeColor = System.Drawing.Color.Black;
			this.labelCesar1.Location = new System.Drawing.Point(29, 25);
			this.labelCesar1.Name = "labelCesar1";
			this.labelCesar1.Size = new System.Drawing.Size(141, 18);
			this.labelCesar1.TabIndex = 3;
			this.labelCesar1.Text = "Clef :";
			// 
			// groupBoxCesar
			// 
			this.groupBoxCesar.BackColor = System.Drawing.SystemColors.Control;
			this.groupBoxCesar.Controls.Add(this.radioButtonCesar);
			this.groupBoxCesar.Controls.Add(this.trackBarCesar1);
			this.groupBoxCesar.Controls.Add(this.textBoxCesar1);
			this.groupBoxCesar.Controls.Add(this.labelCesar1);
			this.groupBoxCesar.ForeColor = System.Drawing.Color.Teal;
			this.groupBoxCesar.Location = new System.Drawing.Point(9, 9);
			this.groupBoxCesar.Name = "groupBoxCesar";
			this.groupBoxCesar.Size = new System.Drawing.Size(450, 61);
			this.groupBoxCesar.TabIndex = 4;
			this.groupBoxCesar.TabStop = false;
			this.groupBoxCesar.Text = "Cesar";
			this.groupBoxCesar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RadioButtonCesarCheckedChanged);
			// 
			// radioButtonCesar
			// 
			this.radioButtonCesar.Checked = true;
			this.radioButtonCesar.Location = new System.Drawing.Point(13, 25);
			this.radioButtonCesar.Name = "radioButtonCesar";
			this.radioButtonCesar.Size = new System.Drawing.Size(13, 18);
			this.radioButtonCesar.TabIndex = 6;
			this.radioButtonCesar.TabStop = true;
			this.radioButtonCesar.UseVisualStyleBackColor = true;
			// 
			// trackBarCesar1
			// 
			this.trackBarCesar1.LargeChange = 25;
			this.trackBarCesar1.Location = new System.Drawing.Point(254, 15);
			this.trackBarCesar1.Maximum = 25;
			this.trackBarCesar1.Name = "trackBarCesar1";
			this.trackBarCesar1.Size = new System.Drawing.Size(190, 45);
			this.trackBarCesar1.TabIndex = 5;
			// 
			// textBoxCesar1
			// 
			this.textBoxCesar1.Location = new System.Drawing.Point(170, 22);
			this.textBoxCesar1.Name = "textBoxCesar1";
			this.textBoxCesar1.Size = new System.Drawing.Size(78, 23);
			this.textBoxCesar1.TabIndex = 4;
			// 
			// groupBoxVigenere
			// 
			this.groupBoxVigenere.Controls.Add(this.radioButtonVigenere);
			this.groupBoxVigenere.Controls.Add(this.textBoxVigenere1);
			this.groupBoxVigenere.Controls.Add(this.labelVigenere1);
			this.groupBoxVigenere.ForeColor = System.Drawing.Color.Teal;
			this.groupBoxVigenere.Location = new System.Drawing.Point(9, 76);
			this.groupBoxVigenere.Name = "groupBoxVigenere";
			this.groupBoxVigenere.Size = new System.Drawing.Size(450, 52);
			this.groupBoxVigenere.TabIndex = 5;
			this.groupBoxVigenere.TabStop = false;
			this.groupBoxVigenere.Text = "Vigenere";
			this.groupBoxVigenere.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RadioButtonVigenereCheckedChanged);
			// 
			// radioButtonVigenere
			// 
			this.radioButtonVigenere.BackColor = System.Drawing.Color.Transparent;
			this.radioButtonVigenere.Location = new System.Drawing.Point(13, 18);
			this.radioButtonVigenere.Name = "radioButtonVigenere";
			this.radioButtonVigenere.Size = new System.Drawing.Size(13, 18);
			this.radioButtonVigenere.TabIndex = 7;
			this.radioButtonVigenere.TabStop = true;
			this.radioButtonVigenere.UseVisualStyleBackColor = false;
			// 
			// textBoxVigenere1
			// 
			this.textBoxVigenere1.Enabled = false;
			this.textBoxVigenere1.Location = new System.Drawing.Point(170, 20);
			this.textBoxVigenere1.Name = "textBoxVigenere1";
			this.textBoxVigenere1.Size = new System.Drawing.Size(271, 23);
			this.textBoxVigenere1.TabIndex = 4;
			// 
			// labelVigenere1
			// 
			this.labelVigenere1.Enabled = false;
			this.labelVigenere1.ForeColor = System.Drawing.Color.Black;
			this.labelVigenere1.Location = new System.Drawing.Point(29, 23);
			this.labelVigenere1.Name = "labelVigenere1";
			this.labelVigenere1.Size = new System.Drawing.Size(135, 26);
			this.labelVigenere1.TabIndex = 3;
			this.labelVigenere1.Text = "Mot clef  :";
			// 
			// groupBoxRSA
			// 
			this.groupBoxRSA.BackColor = System.Drawing.Color.Transparent;
			this.groupBoxRSA.Controls.Add(this.radioButtonRSA);
			this.groupBoxRSA.Controls.Add(this.textBoxRSA1);
			this.groupBoxRSA.Controls.Add(this.labelRSA1);
			this.groupBoxRSA.ForeColor = System.Drawing.Color.Teal;
			this.groupBoxRSA.Location = new System.Drawing.Point(8, 134);
			this.groupBoxRSA.Name = "groupBoxRSA";
			this.groupBoxRSA.Size = new System.Drawing.Size(451, 52);
			this.groupBoxRSA.TabIndex = 6;
			this.groupBoxRSA.TabStop = false;
			this.groupBoxRSA.Text = "RSA";
			this.groupBoxRSA.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RadioButtonRSACheckedChanged);
			// 
			// radioButtonRSA
			// 
			this.radioButtonRSA.Location = new System.Drawing.Point(13, 18);
			this.radioButtonRSA.Name = "radioButtonRSA";
			this.radioButtonRSA.Size = new System.Drawing.Size(13, 18);
			this.radioButtonRSA.TabIndex = 8;
			this.radioButtonRSA.TabStop = true;
			this.radioButtonRSA.UseVisualStyleBackColor = true;
			// 
			// textBoxRSA1
			// 
			this.textBoxRSA1.Enabled = false;
			this.textBoxRSA1.Location = new System.Drawing.Point(171, 22);
			this.textBoxRSA1.Name = "textBoxRSA1";
			this.textBoxRSA1.Size = new System.Drawing.Size(271, 23);
			this.textBoxRSA1.TabIndex = 4;
			// 
			// labelRSA1
			// 
			this.labelRSA1.Enabled = false;
			this.labelRSA1.ForeColor = System.Drawing.Color.Black;
			this.labelRSA1.Location = new System.Drawing.Point(29, 23);
			this.labelRSA1.Name = "labelRSA1";
			this.labelRSA1.Size = new System.Drawing.Size(136, 22);
			this.labelRSA1.TabIndex = 3;
			this.labelRSA1.Text = "Clef :";
			// 
			// CryptoGUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(462, 237);
			this.Controls.Add(this.groupBoxRSA);
			this.Controls.Add(this.groupBoxVigenere);
			this.Controls.Add(this.groupBoxCesar);
			this.Controls.Add(this.buttonCrack);
			this.Controls.Add(this.buttonDecrypt);
			this.Controls.Add(this.buttonEncrypt);
			this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "CryptoGUI";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cryptographie";
			this.groupBoxCesar.ResumeLayout(false);
			this.groupBoxCesar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarCesar1)).EndInit();
			this.groupBoxVigenere.ResumeLayout(false);
			this.groupBoxVigenere.PerformLayout();
			this.groupBoxRSA.ResumeLayout(false);
			this.groupBoxRSA.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.RadioButton radioButtonRSA;
		private System.Windows.Forms.RadioButton radioButtonVigenere;
		private System.Windows.Forms.RadioButton radioButtonCesar;
		private System.Windows.Forms.Label labelRSA1;
		public System.Windows.Forms.TextBox textBoxRSA1;
		private System.Windows.Forms.GroupBox groupBoxRSA;
		private System.Windows.Forms.Label labelVigenere1;
		public System.Windows.Forms.TextBox textBoxVigenere1;
		private System.Windows.Forms.GroupBox groupBoxVigenere;
		public System.Windows.Forms.TextBox textBoxCesar1;
		private System.Windows.Forms.TrackBar trackBarCesar1;
		private System.Windows.Forms.GroupBox groupBoxCesar;
		private System.Windows.Forms.Label labelCesar1;
		private System.Windows.Forms.Button buttonCrack;
		private System.Windows.Forms.Button buttonDecrypt;
		private System.Windows.Forms.Button buttonEncrypt;
	}
}
