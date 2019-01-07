using Droid.Crypto.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Droid.Crypto.UI.View
{
    public partial class HiddenPassword : Form
    {
        #region Attributes
        private Passwords _passwords;
        #endregion

        #region Properties
        public Passwords Passwords
        {
            get { return _passwords; }
            set { _passwords = value; }
        }
        #endregion

        #region Constructor
        public HiddenPassword()
        {
            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        #endregion

        #region Methods private
        private void Init()
        {
            _passwords = new Passwords();
            textBoxPasswords.Text = _passwords.Path;

            LoadPasswords();
        }
        private void LoadPasswords()
        {
            dataGridViewPasswords.Rows.Clear();
            _passwords.Profils.Clear();
            
            if (File.Exists(Path.Combine(_passwords.Path, _passwords.FileName)))
            {
                textBoxPasswords.BackColor = Color.White;
                LoadProfile();

                if (_passwords != null)
                {
                    foreach (PasswordProfil profile in _passwords.Profils)
                    {
                        dataGridViewPasswords.Rows.Add();
                        dataGridViewPasswords.Rows[dataGridViewPasswords.Rows.Count - 1].Tag = profile;
                        dataGridViewPasswords.Rows[dataGridViewPasswords.Rows.Count - 1].Cells[ColumnLogin.Index].Value = profile.Login;
                        dataGridViewPasswords.Rows[dataGridViewPasswords.Rows.Count - 1].Cells[ColumnPassword.Index].Tag = profile.Password;
                        dataGridViewPasswords.Rows[dataGridViewPasswords.Rows.Count - 1].Cells[ColumnPassword.Index].Value = "Copy";
                        dataGridViewPasswords.Rows[dataGridViewPasswords.Rows.Count - 1].Cells[ColumnDelete.Index].Value = Tools4Libraries.Resources.ResourceIconSet16Default.cross;
                    }
                }

                //string xmlFile = File.ReadAllText(Path.Combine(_passwords.Path, _passwords.FileName));
                //XmlDocument xmldoc = new XmlDocument();
                //xmldoc.LoadXml(xmlFile);
                //XmlNodeList nodeList = xmldoc.GetElementsByTagName("PasswordProfil");
                //string Short_Fall = string.Empty;
                //foreach (XmlNode node in nodeList)
                //{
                //    _passwords.Profils.Add(new PasswordProfil() { Login = node.SelectNodes("login").Item, Password = node.Attributes["password"].Value });
                //    dataGridViewPasswords.Rows.Add();
                //    dataGridViewPasswords.Rows[dataGridViewPasswords.Rows.Count - 1].Tag = node;
                //    dataGridViewPasswords.Rows[dataGridViewPasswords.Rows.Count - 1].Cells[ColumnLogin.Index].Value = node.Attributes["login"].Value;
                //    dataGridViewPasswords.Rows[dataGridViewPasswords.Rows.Count - 1].Cells[ColumnPassword.Index].Tag = node.Attributes["password"].Value;
                //    dataGridViewPasswords.Rows[dataGridViewPasswords.Rows.Count - 1].Cells[ColumnPassword.Index].Value = "Copy";
                //    dataGridViewPasswords.Rows[dataGridViewPasswords.Rows.Count - 1].Cells[ColumnDelete.Index].Value = Tools4Libraries.Resources.ResourceIconSet16Default.cross;
                //}
            }
            else
            {
                textBoxPasswords.BackColor = Color.LightYellow;
            }
        }
        private void SaveProfile()
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(_passwords.Path, _passwords.FileName)))
            {
                sw.Write(_passwords.Serialize());
            }
            
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(Passwords));
            //using (StringWriter writer = new StringWriter())
            //{
            //    using (XmlTextWriter xmlWriter = new XmlTextWriter(writer))
            //    {
            //        xmlWriter.Formatting = Formatting.Indented;
            //        xmlWriter.Indentation = 4;
            //        xmlSerializer.Serialize(xmlWriter, _passwords);
            //        using (StreamWriter sw = new StreamWriter(Path.Combine(_passwords.Path, _passwords.FileName))) { sw.Write(writer.ToString()); }
            //    }
            //}
        }
        private void LoadProfile()
        {
            using (StreamReader sr = new StreamReader(Path.Combine(_passwords.Path, _passwords.FileName)))
            {
                _passwords = Passwords.Deserialise(sr.ReadToEnd());
            }
        }
        #endregion

        #region Event
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBoxPasswords.Text = fbd.SelectedPath;
                _passwords.Path = fbd.SelectedPath;
                Properties.Settings.Default.PasswordPath = textBoxPasswords.Text;
                Properties.Settings.Default.Save();
                LoadPasswords();
            }
        }
        private void Add_Click(object sender, EventArgs e)
        {
            bool available = true;

            if (string.IsNullOrEmpty(textBoxLogin.Text)) { textBoxLogin.BackColor = Color.LightYellow; available = false; }
            else { textBoxLogin.BackColor = Color.White; }
            
            if (string.IsNullOrEmpty(textBoxPassword.Text)) { textBoxPassword.BackColor = Color.LightYellow; available = false; }
            else { textBoxPassword.BackColor = Color.White; }

            if (available)
            {
                PasswordProfil profile = new PasswordProfil()
                {
                    Login = textBoxLogin.Text,
                    Password = textBoxPassword.Text
                };
                _passwords.Profils.Add(profile);
                SaveProfile();
                LoadPasswords();
            }
        }
        private void dataGridViewPasswords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ColumnDelete.Index)
            {
                //XmlNode node = ((XmlNode)dataGridViewPasswords.Rows[e.ColumnIndex].Tag);
                //_passwords.Profils.Remove(_passwords.Profils.Where(p => p.Login == node.Attributes["login"].Value && p.Password == node.Attributes["password"].Value).FirstOrDefault());
                PasswordProfil profile = ((PasswordProfil)dataGridViewPasswords.Rows[e.RowIndex].Tag);
                _passwords.Profils.Remove(profile);
                SaveProfile();
                LoadPasswords();
            }
        }
        private void dataGridViewPasswords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ColumnPassword.Index)
            {
                Clipboard.SetText(dataGridViewPasswords.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag.ToString());

                // TODO : fix the position of the TT
                ToolTip tt = new ToolTip();
                tt.Show("Copied", this, MousePosition.X - 54, MousePosition.Y - 84, 1000);
                Console.WriteLine("Copied");
            }
        }
        #endregion
    }
}
