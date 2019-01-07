namespace Droid.Crypto
{
    using System;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Security.Cryptography;
    using System.Text;
    public static class Rsa
    {
        #region Attribute
        public static string privateKey;
        public static string publicKey;
        public static RSACryptoServiceProvider rsa;
        #endregion

        #region Methods public
        public static string ChangeKeysAndReturnNewPrivateKey(string _privatekey)
        {

            string testData = "TestData";
            string testSalt = "salt";
            // encrypt the test data using the exisiting public key...
            string encryptedTestData = EncryptData(testData, testSalt);
            try
            {
                // try to decrypt the test data using the _privatekey provided by user...
                string decryptTestData = DecryptData(encryptedTestData, _privatekey, testSalt);
                // if the data is successfully decrypted assign new keys...
                if (decryptTestData == testData)
                {
                    AssignNewKey();
                    // "AssignNewKey()" should set "privateKey" to the newly created private key...
                    return privateKey;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }
        public static void AssignParameter()
        {
            const int PROVIDER_RSA_FULL = 1;
            const string CONTAINER_NAME = "KeyContainer";
            CspParameters cspParams;
            cspParams = new CspParameters(PROVIDER_RSA_FULL);
            cspParams.KeyContainerName = CONTAINER_NAME;
            cspParams.Flags = CspProviderFlags.UseMachineKeyStore;
            cspParams.ProviderName = "Microsoft Strong Cryptographic Provider";
            rsa = new RSACryptoServiceProvider(cspParams);
        }
        public static void AssignNewKey()
        {
            AssignParameter();

            // TODO : plug it on current database with manager_database

            //using (SqlConnection myConn = new SqlConnection(Utilities.ConnectionString))
            //{
            //    SqlCommand myCmd = myConn.CreateCommand();

            //    string publicPrivateKeyXML = rsa.ToXmlString(true);
            //    privateKey = publicPrivateKeyXML; // sets the public variable privateKey to the new private key.

            //    string publicOnlyKeyXML = rsa.ToXmlString(false);
            //    publicKey = publicOnlyKeyXML; // sets the public variable publicKey to the new public key.

            //    myCmd.CommandText = "UPDATE Settings SET PublicKey = @PublicKey";
            //    myCmd.Parameters.AddWithValue("@PublicKey", publicOnlyKeyXML);
            //    myConn.Open();

            //    myComm.ExecuteScalar();
            //}
        }
        public static string EncryptData(string data2Encrypt, string salt)
        {
            AssignParameter();

            // TODO : plug it on current database with manager_database

            //using (SqlConnection myConn = new SqlConnection(Utilities.ConnectionString))
            //{
            //    SqlCommand myCmd = myConn.CreateCommand();

            //    myCmd.CommandText = "SELECT TOP 1 PublicKey FROM Settings";

            //    myConn.Open();

            //    using (SqlDataReader sdr = myCmd.ExecuteReader())
            //    {
            //        if (sdr.HasRows)
            //        {
            //            DataTable dt = new DataTable();
            //            dt.Load(sdr);
            //            rsa.FromXmlString(dt.Rows[0]["PublicKey"].ToString());
            //        }
            //    }
            //}

            //read plaintext, encrypt it to ciphertext
            byte[] plainbytes = System.Text.Encoding.UTF8.GetBytes(data2Encrypt + salt);
            byte[] cipherbytes = rsa.Encrypt(plainbytes, false);
            return Convert.ToBase64String(cipherbytes);
        }
        public static string DecryptData(string data2Decrypt, string privatekey, string salt)
            {
                AssignParameter();

                byte[] getpassword = Convert.FromBase64String(data2Decrypt);

                string publicPrivateKeyXML = privatekey;
                rsa.FromXmlString(publicPrivateKeyXML);

                //read ciphertext, decrypt it to plaintext
                byte[] plain = rsa.Decrypt(getpassword, false);
                string dataAndSalt = System.Text.Encoding.UTF8.GetString(plain);
                return dataAndSalt.Substring(0, dataAndSalt.Length - salt.Length);
            }
        #endregion
    }
}