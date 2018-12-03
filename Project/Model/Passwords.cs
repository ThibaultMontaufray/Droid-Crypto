using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Droid.Cryptographie.Model
{
    [Serializable]
    public class Passwords
    {
        #region Attributes
        private string _passwordsPath;
        private List<PasswordProfil> _passwordProfil;

        public readonly string FileName = "PasswordProfil.xml";
        #endregion

        #region Properties
        public string Path
        {
            get { return _passwordsPath; }
            set { _passwordsPath = value; }
        }
        public List<PasswordProfil> Profils
        {
            get { return _passwordProfil; }
            set { _passwordProfil = value; }
        }
        #endregion

        #region Constructor
        public Passwords()
        {
            Init();
        }
        public Passwords(string passwordsPath, List<PasswordProfil> passwordProfil, string fileName, string path, List<PasswordProfil> profils)
        {
            _passwordsPath = passwordsPath;
            _passwordProfil = passwordProfil;
            FileName = fileName;
            Path = path;
            Profils = profils;
        }
        #endregion

        #region Methods public
        public string Serialize()
        {
            var serializer = new XmlSerializer(this.GetType());
            var sb = new StringBuilder();

            using (TextWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, this);
            }

            return sb.ToString();
        }
        public static Passwords Deserialise(string objectData)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(Passwords));
                Passwords result;

                using (TextReader reader = new StringReader(objectData))
                {
                    result = serializer.Deserialize(reader) as Passwords;
                }

                return result;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                Passwords pwds = new Passwords();
                return pwds;
            }
        }
        #endregion

        #region Methods private
        private void Init()
        {
            _passwordProfil = new List<PasswordProfil>();
            _passwordsPath = Properties.Settings.Default.PasswordPath;
        }
        #endregion
    }
}
