#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogFile
{
    public class Crypt
    {
        int[] encrypt_num = new int[32];

        public Crypt(int[] xencrypt_num)
        {
            int i;
            int iCount = xencrypt_num.Count();
            for (i=0;i<iCount;i++)
            {
                encrypt_num[i] = xencrypt_num[i];
            }
        }



        public string DecryptString(string PasswToDecrypt)
        {
            String decryptedstring;
            int i;
            i = 0;
            decryptedstring = "";
            foreach (Char ch in PasswToDecrypt)
            {

                decryptedstring += Convert.ToChar(Convert.ToInt16(ch) + encrypt_num[i]);
                i++; ;
            }
            return decryptedstring;
        }

        public string EncryptString(string PasswToEncrypt)
        {
            String encryptedstring;
            int i;
            i = 0;
            encryptedstring = "";
            foreach (Char ch in PasswToEncrypt)
            {

                encryptedstring += Convert.ToChar(Convert.ToInt16(ch) - encrypt_num[i]);
                i++; ;
            }
            return encryptedstring;
        }

    }
}
