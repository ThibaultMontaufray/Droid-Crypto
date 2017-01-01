/*
 * Created by SharpDevelop.
 * User: Amos
 * Date: 10/08/2011
 * Time: 09:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Droid_cryptographie
{
    using System;
    using System.Linq;
    using System.Text;

    public class Vigenere
    {
        #region Enum
        [Flags]
        public enum LegalCharacters : byte
        {
            Alphabetical = 0x0,
            Alphanumerical = 0x1,
            Symbols = 0x2
        }
        #endregion

        #region Attribute
        private const string Alphabetical = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Alphanumerical = "0123456789";
        private const string Symbols = "!\"#¤%&/()=?@£$€{[]}:^´`½§_,.";

        private CipherTable _completeTable;
        private LegalCharacters _chars;
        #endregion

        #region Properties
        public string KeyPhrase { get; set; }
        #endregion

        #region Constructor
        public Vigenere()
        {
            Init();
        }
        public Vigenere(LegalCharacters chars, string keyPhrase)
        {
            _chars = chars;
            KeyPhrase = keyPhrase.Replace(" ", "");

            Init();
        }
        #endregion

        #region Methods public
        public string EncryptData(string data)
        {
            var extKey = ExtendKeyPhrase(data.Length);
            var encrypted = new byte[data.Length];

            if (!_completeTable.VerifyString(data)) throw new ArgumentException("Plaintext data contains characters that does not exist in the cipher table");

            if (!_completeTable.VerifyString(KeyPhrase)) throw new ArgumentException("Key data contains characters that does not exist in the cipher table");

            byte[][] tbl = _completeTable.Table;
            for (var i = 0; i < data.Length; i++)
            {
                if (char.IsWhiteSpace(data[i]))
                {
                    encrypted[i] = (byte)' ';
                    continue;
                }

                int plainPos = 0;

                for (var j = 0; j < _completeTable.RawStringRow.Length; j++)
                    if (data[i] == _completeTable.RawStringRow[j])
                    {
                        plainPos = j;
                        break;
                    }

                foreach (var row in tbl.Where(row => row[0] == extKey[i]))
                {
                    encrypted[i] = row[plainPos];
                    break;
                }
            }

            return Encoding.Default.GetString(encrypted);
        }
        public string DecryptData(string encryptedData)
        {
            var extKey = ExtendKeyPhrase(encryptedData.Length);
            var decrypted = new byte[encryptedData.Length];
            var tbl = _completeTable.Table;

            for (var i = 0; i < encryptedData.Length; i++)
            {
                if (char.IsWhiteSpace(encryptedData[i]))
                {
                    decrypted[i] = (byte)' ';
                    continue;
                }

                for (var j = 0; j < tbl.Length; j++)
                {
                    if (tbl[j][0] != extKey[i]) continue;
                    for (var x = 0; x < tbl[j].Length; x++)
                        if (tbl[j][x] == encryptedData[i])
                            decrypted[i] = (byte)_completeTable.RawStringRow[x];
                }
            }

            return Encoding.Default.GetString(decrypted);
        }
        public override string ToString()
        {
            return _completeTable.ToString();
        }
        #endregion

        #region Methods private
        private void Init()
        {
            _completeTable = new CipherTable("");

            if ((_chars & LegalCharacters.Alphabetical) == LegalCharacters.Alphabetical) _completeTable += new CipherTable(Alphabetical);
            if ((_chars & LegalCharacters.Alphanumerical) == LegalCharacters.Alphanumerical) _completeTable += new CipherTable(Alphanumerical);
            if ((_chars & LegalCharacters.Symbols) == LegalCharacters.Symbols) _completeTable += new CipherTable(Symbols);
        }
        private string ExtendKeyPhrase(int total)
        {
            var extended = new StringBuilder(total);
            var i = KeyPhrase.Length;

            extended.Append(KeyPhrase);
            while ((i += KeyPhrase.Length) < total)
                extended.Append(KeyPhrase);

            for (var j = 0; j < total - (i - KeyPhrase.Length); j++)
                extended.Append(KeyPhrase[j]);

            return extended.ToString();
        }
        #endregion
    }
}