/*
 * Created by SharpDevelop.
 * User: Amos
 * Date: 10/08/2011
 * Time: 09:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace Droid_cryptographie
{
	/// <summary>
	/// Description of Cesar.
	/// </summary>
	public class Cesar : Cryptographie
	{
		#region Attributes
		private new string input;
		private new string output;
		private new string key;
		private char[] dicoLower = {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
		private char[] dicoUpper = {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
		#endregion
		
		#region Properties
		public override string Input
		{
			get { return input;}
			set { input = value;}
		}
		public override string Output
		{
			get { return output;}
			set { output = value;}
		}
		public override string Key
		{
			get { return key;}
			set { key = value;}
		}
		#endregion
		
		#region Constructors
		public Cesar()
		{
			key = "0";
		}
		#endregion
		
		#region Methods public
		public override string Encrypt()
		{
			char[] tabChar = Input.ToCharArray();
			Output = "";
			foreach (char c in tabChar) 
			{
				int index = DicoIndexLower(c);
				if (index == -1) 
				{
					index = DicoIndexUpper(c);
					if (index == -1) 
					{
						Output += c;
					}
					else
					{
						Output += dicoUpper[(index + int.Parse(key))%26];
					}
				}
				else Output += dicoLower[(index + int.Parse(key))%26];
			}
			return Output;
		}
		
		public override string Decrypt()
		{
			char[] tabChar = Input.ToCharArray();
			Output = "";
			foreach (char c in tabChar) 
			{
				int index = DicoIndexLower(c);
				if (index != -1) 
				{
					Output += dicoLower[(index - int.Parse(key))%26];
				}
				else
				{
					index = DicoIndexUpper(c);
					if (index == -1) 
					{
						Output += c;
					}
					else
					{
                        int val = (index - int.Parse(key)) % 26;
                        if (val < 0) val = val * -1;
						Output += dicoUpper[val];
					}
				}
			}
			return Output;
		}
		
		public override string Crack()
		{
			return "";
		}
		#endregion
		
		#region Methods private
		private int DicoIndexLower(char c)
		{
			for(int i=0 ; i<dicoLower.Length; i++) 
			{
				if (dicoLower[i].Equals(c))return i;
			}
			return -1;
		}
		
		private int DicoIndexUpper(char c)
		{
			for(int i=0 ; i<dicoUpper.Length; i++) 
			{
				if (dicoUpper[i].Equals(c))return i;
			}
			return -1;
		}
		#endregion
	}
}