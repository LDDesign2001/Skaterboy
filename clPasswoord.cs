using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skaterboy
{
    class clPasswoord
    {
        bool allesOK;
        public bool clPasswoordCheck(string pw, string match)
        {
            bool lengtePasswoord = pw.Length >= 8;
            bool bevatGetall = bevatGetal(pw);
            bool bevatHoofdletter = bevatCaps(pw);
            bool passwoordenZelfde = match == pw && pw == match;
            bool goedPasswoord = lengtePasswoord && bevatGetall && bevatHoofdletter && passwoordenZelfde;
            if (goedPasswoord) allesOK = true;
            else allesOK = false;
            return allesOK;
        }
        
        private bool bevatCaps(string text)
        {
            bool hoofdletter = false;
            char[] tekens = text.ToCharArray();
            for (int i = 0; i < tekens.Length; i++)
            {
                if (tekens[i] >= 65 && tekens[i] <= 90)
                {
                    hoofdletter = true;
                    break;
                }
            }
            return hoofdletter;
        }

        private bool bevatGetal(string pw)
        {
            bool cijfer = false;
            char[] tekens = pw.ToCharArray();
            for (int i = 0; i < tekens.Length; i++)
            {
                if (tekens[i] >= 48 && tekens[i] <= 57)
                {
                    cijfer = true;
                    break;
                }
            }
            return cijfer;
        }
        
    }
}
