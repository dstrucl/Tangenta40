using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StaticLib;
using DBTypes;

namespace SQLTableControl
{
    public static class UniqueNames
    {

        private static bool AlreadyExistInUniqueConstraintNameList(List<string> UniqueNameList, string x)
        {
            foreach (string s in UniqueNameList)
            {
                if (s.Equals(x))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool AlreadyExistInUniqueConstraintNameList(ImageStore imgstore, string x)
        {
            foreach (ImageItem e3pi in imgstore.items)
            {
                if (e3pi.name.Equals(x))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsDigit(char c)
        {
            if ((c == '0') ||
                (c == '1') ||
                (c == '2') ||
                (c == '3') ||
                (c == '4') ||
                (c == '5') ||
                (c == '6') ||
                (c == '7') ||
                (c == '8') ||
                (c == '9'))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool GetStringLastNumber(string s, ref string sWithoutNumber, ref int Index)
        {

            int iLen = s.Length;
            int i;
            string sNum = "";
            if (iLen > 0)
            {
                i = iLen - 1;
                while (i >= 0)
                {
                    if (IsDigit(s[i]))
                    {
                        sNum = s[i] + sNum;
                        i--;
                    }
                    else
                    {
                        break;
                    }
                }
                if (sNum.Length == 0)
                {
                    sWithoutNumber = s;
                    return false;
                }
                else
                {
                    if (i > 0)
                    {
                        sWithoutNumber = s.Substring(0, i + 1);
                    }
                    else
                    {
                        sWithoutNumber = "";
                    }
                    int iNum = Convert.ToInt32(sNum);
                    Index = iNum;
                    return true;
                }

            }
            else
            {
                Index = 0;
                return false;
            }
        }

        public static string GetName(List<string> UniqueNameList,string p)
        {
            string x = p;
            while (AlreadyExistInUniqueConstraintNameList(UniqueNameList,x))
            {
                string sWithoutNumber = "";
                int iNum=0;
                GetStringLastNumber(x, ref sWithoutNumber, ref iNum);
                iNum++;
                x = sWithoutNumber + iNum;
            }
            return x;
        }

        public static string GetName(ImageStore imgstore, string p)
        {
            string x = p;
            while (AlreadyExistInUniqueConstraintNameList(imgstore, x))
            {
                string sWithoutNumber = "";
                int iNum = 0;
                GetStringLastNumber(x, ref sWithoutNumber, ref iNum);
                iNum++;
                x = sWithoutNumber + iNum;
            }
            return x;
        }



        internal static string GetName(List<ViewXml> ViewXmllist, string p)
        {
            string x = p;
            ViewXml xViewXmlToFind = null;
            while (AlreadyExistInUniqueConstraintNameList(ViewXmllist, x, ref xViewXmlToFind))
            {
                string sWithoutNumber = "";
                int iNum = 0;
                GetStringLastNumber(x, ref sWithoutNumber, ref iNum);
                iNum++;
                x = sWithoutNumber + iNum;
            }
            return x;
        }

        public static bool AlreadyExistInUniqueConstraintNameList(List<ViewXml> ViewXmllist, string x, ref ViewXml found_ViewXml)
        {
            foreach (ViewXml  xViewXml in ViewXmllist)
            {
                if (xViewXml.Name.Equals(x))
                {
                    found_ViewXml = xViewXml;
                    return true;
                }
            }
            return false;
        }
    }
}
