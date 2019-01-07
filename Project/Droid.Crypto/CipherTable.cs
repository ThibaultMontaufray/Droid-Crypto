using System;
using System.Linq;
using System.Text;

namespace Droid.Crypto
{
    public class CipherTable
    {
        #region Attribute
        #endregion

        #region Properties
        public string RawStringRow { get; private set; }
        public byte[][] Table { get { return Create(); } }
        #endregion

        #region Operator
        public static CipherTable operator +(CipherTable tbl1, CipherTable tbl2)
        {
            var fullString = new StringBuilder(tbl1.RawStringRow.Length + tbl2.RawStringRow.Length);
            fullString.Append(tbl1.RawStringRow);
            fullString.Append(tbl2.RawStringRow);

            return new CipherTable(fullString.ToString());
        }
        #endregion

        #region Constructor
        public CipherTable(string rawStringRow)
        {
            RawStringRow = rawStringRow;
        }
        #endregion

        #region Methods public
        public override string ToString()
        {
            var tbl = Create();
            var finalStr = new StringBuilder();

            finalStr.Append("plain\t");

            foreach (char c in RawStringRow)
                finalStr.Append(c + " ");

            finalStr.AppendLine();

            var curLen = finalStr.Length;
            for (var i = 0; i < curLen; i++)
                finalStr.Append("_");

            finalStr.AppendLine();

            for (var i = 0; i < tbl.Length; i++)
            {
                finalStr.Append(i + "\t");
                for (var j = 0; j < tbl[i].Length; j++)
                    finalStr.Append((char)(tbl[i][j]) + " ");
                finalStr.AppendLine();
            }

            return finalStr.ToString();
        }
        public bool VerifyString(string data)
        {
            return data.All(c => RawStringRow.Contains(c) || char.IsWhiteSpace(c));
        }
        #endregion

        #region Methods private
        private byte[][] Create()
        {
            var tbl = new byte[RawStringRow.Length][];
            var row = Encoding.Default.GetBytes(RawStringRow);

            for (var i = 0; i < RawStringRow.Length; i++)
            {
                var pushedRow = new byte[row.Length];
                Buffer.BlockCopy(row, 0, pushedRow, 0, row.Length);

                if (i == 0)
                {
                    CaesarShiftOne(ref pushedRow);
                    tbl[i] = pushedRow;
                    continue;
                }

                for (var j = 0; j < i + 1; j++)
                {
                    CaesarShiftOne(ref pushedRow);
                    tbl[i] = pushedRow;
                }
            }

            return tbl;
        }
        private static void CaesarShiftOne(ref byte[] orig)
        {
            var @new = new byte[orig.Length];
            Buffer.BlockCopy(orig, 0, @new, 0, orig.Length);

            var first = @new[0];

            for (var i = 0; i < @new.Length - 1; i++)
                orig[i] = @new[i + 1];

            orig[orig.Length - 1] = first;
        }
        #endregion
    }
}
