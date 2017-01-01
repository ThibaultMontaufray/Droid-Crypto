using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Droid_cryptographie
{
    public partial class Login : Form
    {
        #region Attribute
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public Login()
        {
            InitializeComponent();
            textBoxKeyFrequenceDetection1.KeyFrequence.CalculationDone += KeyFrequence_CalculationDone;
        }
        #endregion

        #region Event
        private void KeyFrequence_CalculationDone(string message = null)
        {
            this.Text = string.Format("Login : user [speed {0}] confirmed at {1} %", textBoxKeyFrequenceDetection1.KeyFrequence.KeySpeed.ToString("F0"), textBoxKeyFrequenceDetection1.KeyFrequence.Percent.ToString("F2"));
        }
        private void buttonPost_Click(object sender, EventArgs e)
        {
            textBoxKeyFrequenceDetection1.ValidateText();
        }
        private void checkBoxLearnMode_CheckedChanged(object sender, EventArgs e)
        {
            textBoxKeyFrequenceDetection1.Learning = checkBoxLearnMode.Checked;
        }
        #endregion
    }
}
