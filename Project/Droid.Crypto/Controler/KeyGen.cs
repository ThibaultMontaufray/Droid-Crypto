namespace Droid.Crypto
{
    public class KeyGen
    {
        #region Attribute
        private char[] dicoAlphaLower = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private char[] dicoAlphaUpper = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private char[] dicoNumber = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private char[] dicoSpecChar = { ',', '?', ';', '.', ':', '/', '!', '§', '*', 'µ', 'ù', '%', '$', '£', '¤', '&', 'é', '"', '\'', '(', '-', 'è', '_', 'ç', 'à', ')', '=', '°', '+', '~', '#', '{', '[', '|', '`', '\\', '^', '@', ']', '}', '²', '<', '>' };
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public KeyGen()
        {

        }
        #endregion

        #region Methods public
        public string Generate(int keyLength)
        {
            string key = string.Empty;
            return key;
        }
        #endregion

        #region Methods private
        #endregion
    }
}
