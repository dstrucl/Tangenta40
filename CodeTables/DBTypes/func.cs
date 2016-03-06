#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace DBTypes
{
    public static class func
    {

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }


        public static string GenderAsString(bool gender)
        {
            if (gender)
            {
                return LanguageControl.lngRPM.s_Man.s;
            }
            else
            {
                return LanguageControl.lngRPM.s_Woman.s;
            }
        }

        public static string int_to_string(int i, int len)
        {
            string s;
            s = i.ToString();
            while (s.Length < len)
            {
                s = '0' + s;
            }
            return s;
        }

        public static string Get_DATE_dd_mm_yyyy(DateTime xdate)
        {
            return int_to_string(xdate.Day, 2) + "." + int_to_string(xdate.Month, 2) + "." + int_to_string(xdate.Year,4);
        }

    }
}
