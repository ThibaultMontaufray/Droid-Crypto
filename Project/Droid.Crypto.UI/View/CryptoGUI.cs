using System;
using System.Drawing;
using System.Windows.Forms;

namespace Droid.Crypto.UI
{
	/// <summary>
	/// Description of IHM.
	/// </summary>
	public partial class CryptoGUI : Form
	{
		#region Attributes
		private string textValue;
		private int cryptoIndex;
		private bool keyState;
		#endregion
		
		#region Properties
		public string TextValue
		{
			get { return textValue;}
			set { textValue = value;}
		}
		#endregion
		
		#region Constructors
		public CryptoGUI(string txt)
		{
			textValue = txt;
			InitializeComponent();
			
			RadioButtonCesarCheckedChanged(null, null); // init on cesar crypto;
			trackBarCesar1.ValueChanged += new EventHandler(trackBarCesar1_ValueChanged);
			textBoxCesar1.TextChanged += new EventHandler(textBoxCesar1_TextChanged);
			buttonCrack.Enabled = false;
			keyState = false;
			
			this.ShowDialog();
		}
		#endregion
		
		#region Methods
		public new string Dispose()
		{
			this.Close();
			return textValue;
		}
		#endregion
		
		#region Event
		void ButtonEncryptClick(object sender, EventArgs e)
		{
			switch (cryptoIndex) {
				case 1 : // Cesar Encryption
					if(!keyState)
					{
						this.Text = "Cryptographie : Format de clef Cesar incorrect !";
						labelCesar1.ForeColor = Color.DarkRed;
						labelVigenere1.ForeColor = Color.Black;
						labelRSA1.ForeColor = Color.Black;
						break;
					}
					else
					{
						Cesar c = new Cesar();
						c.Key = textBoxCesar1.Text;
						c.Input = textValue;
						textValue = c.Encrypt();
						this.Hide();
						break;
					}
				case 2 : // Vigenere Encryption
					if(!keyState)
					{
						this.Text = "Cryptographie : Format de clef Vigenere incorrect !";
						labelCesar1.ForeColor = Color.Black;
						labelVigenere1.ForeColor = Color.DarkRed;
						labelRSA1.ForeColor = Color.Black;
						break;
					}
					else
					{
						Vigenere v = new Vigenere();
						v.KeyPhrase = "je suis une mouette";
						textValue = v.EncryptData(textValue);
						this.Hide();
						break;
					}
				case 3 : // RSA Encryption
					if(!keyState)
					{
						this.Text = "Cryptographie : Format de clef RSA incorrect !";
						labelCesar1.ForeColor = Color.Black;
						labelVigenere1.ForeColor = Color.Black;
						labelRSA1.ForeColor = Color.DarkRed;
						break;
					}
					else
					{
						this.Hide();
						break;
					}
				default:
					
					break;
			}
		}
		
		void ButtonDecryptClick(object sender, EventArgs e)
		{
			switch (cryptoIndex) {
				case 1 : // Cesar Decryption
					if(!keyState)
					{
						this.Text = "Cryptographie : Format de clef Cesar incorrect !";
						labelCesar1.ForeColor = Color.DarkRed;
						labelVigenere1.ForeColor = Color.Black;
						labelRSA1.ForeColor = Color.Black;
						break;
					}
					else
					{
						Cesar c = new Cesar();
						c.Key = textBoxCesar1.Text;
						c.Input = textValue;
						textValue = c.Decrypt();
						this.Hide();
						break;
					}
				case 2 : // Vigenere Decryption
					if(!keyState)
					{
						this.Text = "Cryptographie : Format de clef Vigenere incorrect !";
						labelCesar1.ForeColor = Color.Black;
						labelVigenere1.ForeColor = Color.DarkRed;
						labelRSA1.ForeColor = Color.Black;
						break;
					}
					else
					{
						Vigenere v = new Vigenere();
						v.KeyPhrase = "je suis une mouette";
						textValue = v.DecryptData(textValue);
						this.Hide();
						break;
					}
				case 3 : // RSA Decryption
					if(!keyState)
					{
						this.Text = "Cryptographie : Format de clef RSA incorrect !";
						labelCesar1.ForeColor = Color.Black;
						labelVigenere1.ForeColor = Color.Black;
						labelRSA1.ForeColor = Color.DarkRed;
						break;
					}
					else
					{
						this.Hide();
						break;
					}
				default:
					
					break;
			}
		}
		
		void ButtonCrackClick(object sender, EventArgs e)
		{
			switch (cryptoIndex) {
				case 1 : // Cesar Crack
					
					break;
				case 2 : // Vigenere Crack
					
					break;
				case 3 : // RSA Crack
					
					break;
				default:
					
					break;
			}
		}
		
		void RadioButtonCesarCheckedChanged(object sender, MouseEventArgs e)
		{
			cryptoIndex = 1;
			radioButtonCesar.Checked = true;
			radioButtonCesar.Enabled = true;
			labelCesar1.Enabled = true;
			textBoxCesar1.Enabled = true;
			trackBarCesar1.Enabled = true;
			radioButtonVigenere.Checked = false;
			radioButtonVigenere.Enabled = false;
			labelVigenere1.Enabled = false;
			textBoxVigenere1.Enabled = false;
			radioButtonRSA.Checked = false;
			radioButtonRSA.Enabled = false;
			labelRSA1.Enabled = false;
			textBoxRSA1.Enabled = false;
		}
		
		void RadioButtonVigenereCheckedChanged(object sender, MouseEventArgs e)
		{
			cryptoIndex = 2;
			radioButtonCesar.Checked = false;
			radioButtonCesar.Enabled = false;
			labelCesar1.Enabled = false;
			textBoxCesar1.Enabled = false;
			trackBarCesar1.Enabled = false;
			radioButtonVigenere.Checked = true;
			radioButtonVigenere.Enabled = true;
			labelVigenere1.Enabled = true;
			textBoxVigenere1.Enabled = true;
			radioButtonRSA.Checked = false;
			radioButtonRSA.Enabled = false;
			labelRSA1.Enabled = false;
			textBoxRSA1.Enabled = false;
		}
		
		void RadioButtonRSACheckedChanged(object sender, MouseEventArgs e)
		{
			cryptoIndex = 3;
			radioButtonCesar.Checked = false;
			radioButtonCesar.Enabled = false;
			labelCesar1.Enabled = false;
			textBoxCesar1.Enabled = false;
			trackBarCesar1.Enabled = false;
			radioButtonVigenere.Checked = false;
			radioButtonVigenere.Enabled = false;
			labelVigenere1.Enabled = false;
			textBoxVigenere1.Enabled = false;
			radioButtonRSA.Checked = true;
			radioButtonRSA.Enabled = true;
			labelRSA1.Enabled = true;
			textBoxRSA1.Enabled = true;
		}
		
		void trackBarCesar1_ValueChanged(object sender, EventArgs e)
		{
			textBoxCesar1.Text = trackBarCesar1.Value.ToString();
			keyState = true;
		}

		void textBoxCesar1_TextChanged(object sender, EventArgs e)
		{
			int tmp = 0;
			if (int.TryParse(textBoxCesar1.Text, out tmp))
			{
				if (tmp > 25 || tmp < 0)
				{
					textBoxCesar1.BackColor = Color.Orange;
					keyState = false;
				}
				else
				{
					textBoxCesar1.BackColor = Color.White;
					trackBarCesar1.Value = tmp;
					keyState = true;
				}
			}
			else				
			{
				textBoxCesar1.BackColor = Color.Orange;
				keyState = false;
			}
		}
		#endregion
	}
}
