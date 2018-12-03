using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Globalization;
using System.ComponentModel;
using System.Collections.Specialized;

namespace Droid.Cryptographie
{
    [Serializable]
    public sealed class PasswordProfil
    {
        private string _login;
        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

    }




    //[Serializable]
    //public sealed class PasswordProfil : ConfigurationSection
    //{
    //    [ConfigurationProperty("login")] //, DefaultValue = "Contoso",IsRequired = true,IsKey = true)]
    //    public string Login
    //    {
    //        get
    //        {
    //            return (string)this["login"];
    //        }
    //        set
    //        {
    //            this["login"] = value;
    //        }
    //    }
    //    [ConfigurationProperty("password")]
    //    public string Password
    //    {
    //        get
    //        {
    //            return (string)this["password"];
    //        }
    //        set
    //        {
    //            this["password"] = value;
    //        }
    //    }
    //}
}
