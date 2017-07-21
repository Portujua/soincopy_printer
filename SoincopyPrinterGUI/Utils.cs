using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoincopyPrinterGUI
{
    class Utils
    {
        public static bool DigitsOnly(string s)
        {
            int len = s.Length;
            for (int i = 0; i < len; ++i)
            {
                char c = s[i];
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
    }
}
