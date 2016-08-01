using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace BulkCodeGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPattern.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToLower();
            txtLength.Text = "8";
            txtMax.Text = "500";
            chkUpper.Checked = true;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            List<string> arr = new List<string>();

            

            string Pat = "";
            int Length = 0;
            int Max = 0;

            Pat = txtPattern.Text;

            if (chkUpper.Checked)
            {
                Pat = Pat.ToUpper();
            }

            int.TryParse(txtLength.Text, out Length);
            int.TryParse(txtMax.Text, out Max);
            int maxSize = Length;
            int minSize = Length;
            char[] chars = new char[62];
            string a;
            a = Pat;
            chars = a.ToCharArray();
            int size = maxSize;
            for (int i = 0; i < Max; i++)
            {
                byte[] data = new byte[1];
                RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
                crypto.GetNonZeroBytes(data);
                size = maxSize;
                data = new byte[size];
                crypto.GetNonZeroBytes(data);
                StringBuilder result = new StringBuilder(size);
                string re = "";
                foreach (byte b in data)
                {
                    result.Append(chars[b % (chars.Length - 0)]);
                }
                re = result.ToString();
                if (arr.Contains(re) == false)
                {

                    arr.Add(re);

                }
                else 
                {
                    i--;
                    continue;
                }
                
                
            }

            string strings = String.Join("\r\n", arr);
            Clipboard.SetText(strings);
            

        }
    }
}
