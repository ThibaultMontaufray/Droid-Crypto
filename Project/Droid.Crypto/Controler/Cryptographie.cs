/*
 * Created by SharpDevelop.
 * User: Amos
 * Date: 10/08/2011
 * Time: 09:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Droid.Crypto
{
	/// <summary>
	/// Description of Crypto.
	/// </summary>
	public class Cryptographie
	{
		#region Attributes
		public string input;
		public string output;
		public string key;
		#endregion
		
		#region Properties
		public virtual string Input
		{
			get { return input;}
			set { input = value;}
		}
		public virtual string Output
		{
			get { return output;}
			set { output = value;}
		}
		public virtual string Key
		{
			get { return key;}
			set { key = value;}
		}
		#endregion
		
		#region Constructors
		public virtual void Crypto()
		{
			
		}
		#endregion
		
		#region Methods
		public virtual string Encrypt()
		{
			return "";
		}
		public virtual string Decrypt()
		{
			return "";
		}
		public virtual string Crack()
		{
			return "";
		}
		#endregion
	}
}
