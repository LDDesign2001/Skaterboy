using System;
using System.Security.Cryptography;
using System.Text;

namespace Skaterboy
{
    class clHash
    {
        private string HashPw;
        public clHash(string pw)
        {
            pw = "日本語s@lt07lucsce" + pw + "p€p09hihihohohhahahahahah$1sL€uk日本語";
            HashPw = "hashNietGelukt";
            char[] alleLetters = pw.ToCharArray();
            foreach (var charke in alleLetters)
            {
                pw = pw + charke;
            }
            byte[] bytes = new UTF32Encoding().GetBytes(pw);
            using (SHA512 hashalgoritme = new SHA512Managed())
            {
                bytes = hashalgoritme.ComputeHash(bytes);
            }

            HashPw = Convert.ToBase64String(bytes).Substring(0, Convert.ToBase64String(bytes).Length - 2);

        }
        public string getHash()
        {
            return HashPw;
        }
    }
}
