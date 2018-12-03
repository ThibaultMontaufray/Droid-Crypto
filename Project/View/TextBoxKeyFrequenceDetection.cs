using System;
using System.Windows.Forms;

namespace Droid.Cryptographie
{
    public delegate void TextBoxKeyFrequenceDetectionEventHandler(object o);

    [Serializable]
    public partial class TextBoxKeyFrequenceDetection : TextBox
    {
        #region Attribute
        public event TextBoxKeyFrequenceDetectionEventHandler TextSend;

        private KeyFrequence _keyFrequence = null;
        private string _currentText = string.Empty;
        private bool _reinit;
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
        public override string Text
        {
            get { return _currentText; }
            set { base.Text = value; }
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
            _reinit = false;
            _currentText = string.Empty;
            _keyFrequence = new KeyFrequence(learning);
            KeyPress += TextBoxKeyFrequenceDetection_KeyPress;
        }
        #endregion

        #region Event
        private void TextBoxKeyFrequenceDetection_KeyPress(object sender, KeyPressEventArgs e)
        {
            _keyFrequence.AddKey(e.KeyChar);
            if (e.KeyChar == '\r' || e.KeyChar == '\n')
            {
                if (TextSend != null) TextSend(_currentText);
                this.Text = string.Empty;
                _reinit = true;
            }
            else if (e.KeyChar != '\b')
            {
                if (_reinit) { _currentText = string.Empty; _reinit = false; }
                _currentText += e.KeyChar;
            }
        }
        private void buttonPost_Click(object sender, EventArgs e)
        {
            _currentText = this.Text;
            _keyFrequence.AddKey('\r');
        }
        private void _keyFrequence_UpdateMatch(string message)
        {
            this.AccessibleDescription = message;
        }
        #endregion
    }
}
