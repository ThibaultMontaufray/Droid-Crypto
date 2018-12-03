using Droid.Cryptographie;
using NUnit.Framework;
using System;

namespace UnitTestProject
{
    [TestFixture]
    public class UnitTest
    {
        [Test]
        public void TestUTRuns()
        {
            Assert.IsTrue(true);
        }
        [Test]
        public void Test_cesar()
        {
            string message = "je suis une mouette";

            Cesar c = new Cesar();
            c.Input = message;
            c.Encrypt();

            Assert.IsTrue(message.Equals(c.Decrypt()));
        }
        [Test]
        public void Test_vigenere()
        {
            string message = "je suis une mouette";

            Vigenere v = new Vigenere();
            v.KeyPhrase = "cuillere";
            string en = v.EncryptData(message);

            Assert.IsTrue(message.Equals(v.DecryptData(en)));
        }
        [Test]
        public void Test_keygen()
        {
            KeyGen k = new KeyGen();
            var v = k.Generate(10);

            Assert.IsTrue(v.Length == 10);
        }
        [Test]
        public void Test_cryptographie()
        {
            string message = "je suis une mouette";

            Cryptographie c = new Cryptographie();
            c.Key = "cuillere";
            c.Input = message;
            string en = c.Encrypt();

            Assert.IsTrue(message.Equals(c.Decrypt()));
        }
        [Test]
        public void Test_rsa()
        {
            try
            {
                Rsa.AssignNewKey();
                Rsa.ChangeKeysAndReturnNewPrivateKey("je suis une mouette");
                Rsa.DecryptData("je suis une mouette", "1234567890", "salt");
                Rsa.EncryptData("je suis une mouette", "salt");

                Assert.IsTrue(true);
            }
            catch (Exception exp)
            {
                Assert.Fail(exp.Message);
            }
        }
    }
}
