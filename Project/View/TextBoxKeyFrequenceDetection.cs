using System;
using System.Windows.Forms;

namespace Droid_cryptographie
{
    public partial class TextBoxKeyFrequenceDetection : TextBox
    {
        #region Attribute
        private KeyFrequence _keyFrequence;
        #endregion

        #region Properties
        public bool Learning
        {
            get { return _keyFrequence.Learning; }
            set { _keyFrequence.Learning = value; }
        }
        public KeyFrequence KeyFrequence
        {
            get
            {
                return _keyFrequence;
            }

            set
            {
                _keyFrequence = value;
            }
        }
        #endregion

        #region Constructor
        public TextBoxKeyFrequenceDetection()
        {
            Init(true);
        }
        public TextBoxKeyFrequenceDetection(bool learning)
        {
            Init(learning);
        }
        #endregion

        #region Methods public
        public void ValidateText()
        {
            _keyFrequence.AddKey('\r');
        }
        #endregion

        #region Methods protected
        #endregion

        #region Methods private
        private void Init(bool learning)
        {
            _keyFrequence = new KeyFrequence(learning);
            KeyPress += TextBoxKeyFrequenceDetection_KeyPress;
        }
        #endregion

        #region Event
        private void TextBoxKeyFrequenceDetection_KeyPress(object sender, KeyPressEventArgs e)
        {
            _keyFrequence.AddKey(e.KeyChar);
            if (e.KeyChar == '\r' || e.KeyChar == '\n') this.Text = string.Empty;
        }
        private void buttonPost_Click(object sender, EventArgs e)
        {
            _keyFrequence.AddKey('\r');
        }
        private void _keyFrequence_UpdateMatch(string message)
        {
            this.AccessibleDescription = message;
        }
        #endregion
    }
}
