using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Crypto
{
    public delegate void KeyFrequenceEventHandler(string message=null);

    [Serializable]
    public class KeyFrequence
    {
        #region Struct
        public struct KeyProfil
        {
            public string Key;
            public int Offset;
            public double Value;
            public int OffsetDiff;
            public double UsualDiff;
        }
        #endregion

        #region Attribute
        public event KeyFrequenceEventHandler CalculationDone;

        private DateTime _lastDate;
        private List<KeyProfil> _profil;
        private char _lastChar;
        private double _percent;
        private int _offset;
        private bool _learning;
        #endregion

        #region Properties
        public double Percent
        {
            get
            {
                return _percent;
            }

            set
            {
                _percent = value;
            }
        }
        public List<KeyProfil> Profil
        {
            get
            {
                return _profil;
            }

            set
            {
                _profil = value;
            }
        }
        public bool Learning
        {
            get
            {
                return _learning;
            }

            set
            {
                _learning = value;
            }
        }
        public double KeySpeed
        {
            get
            {
                double speed = 0;
                foreach (KeyProfil item in _profil)
                {
                    speed += item.Value;
                }
                return speed / _profil.Count;
            }
        }
        #endregion

        #region Constructor
        public KeyFrequence(bool learning = true)
        {
            _learning = learning;
            _profil = new List<KeyProfil>();
            _percent = 0;
            ResetProp();
        }
        #endregion

        #region Methods public
        public void AddKey(char key)
        {
            if (key.Equals('\r') || key.Equals('\n') || key.Equals('\b'))
            {
                ResetProp();
            }
            else
            {
                GetFrequence(key);
            }
        }
        #endregion

        #region Methods protected
        protected void OnCalculationDone()
        {
            if (CalculationDone != null) { CalculationDone(null); }
        }
        #endregion

        #region Methods private
        private void GetFrequence(char key)
        {
            DateTime dateNow = DateTime.Now;
            if (_lastDate != DateTime.MinValue && key != char.MinValue)
            {
                KeyProfil kp = GetProfil(string.Format("{0}_{1}", _lastChar, key), (dateNow - _lastDate).Milliseconds);
                double diff = Diff(kp);
                kp.UsualDiff = ((kp.UsualDiff * kp.OffsetDiff) + diff) / (kp.OffsetDiff + 1);
                kp.OffsetDiff++;

                if (_learning)
                {
                    UpdateProfil(kp);
                }
                else
                {
                    double tmpPercent;
                    if (diff < kp.UsualDiff)
                    {
                        tmpPercent = ((100 * diff) / kp.UsualDiff);
                    }
                    else
                    {
                        tmpPercent = ((100 * kp.UsualDiff) / diff);
                    }
                    _percent = (tmpPercent + (_percent * _offset)) / (_offset + 1);
                    _offset++;
                }
            }
            _lastDate = dateNow;
            _lastChar = key;
        }
        private void ResetProp()
        {
            _offset = 0;
            _lastDate = DateTime.MinValue;
            _lastChar = char.MinValue;
            if (_percent == double.NaN || double.IsNaN(_percent)) _percent = 0;
            OnCalculationDone();
        }
        private KeyProfil GetProfil(string key, double value)
        {
            if (_profil.Count(p => p.Key == key) > 0)
            {
                KeyProfil kp = _profil.Where(p => p.Key == key).ToList()[0];
                kp.Value = ((kp.Value * kp.Offset) + value) / (kp.OffsetDiff + 1);
                kp.Offset++;
                return kp;
            }
            else
            {
                return new KeyProfil() { Key = key, Offset = 1, Value = value };
            }
        }
        private void UpdateProfil(KeyProfil kp)
        {
            if (!kp.Key.Equals("unknown"))
            {
                if (_profil.Contains(kp)) { _profil.Remove(_profil.Where(p => p.Key.Equals(kp.Key)).ToList()[0]); }
                _profil.Add(kp);
            }
        }
        private double Diff(KeyProfil kp)
        {
            if (_profil.Count(p => p.Key.Equals(kp.Key)) > 0)
            {
                return Math.Abs(kp.Value - _profil.Where(p => p.Key.Equals(kp.Key)).ToList()[0].Value);
            }
            else
            {
                return 0;
            }
        }
        #endregion
    }
}
