using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBTypes
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

        private static bool AlreadyExistInUniqueConstraintNameList(DataStore datastore, string x)
        {
            foreach (DataItem dataitem in datastore.items)
            {
                if (dataitem.name.Equals(x))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool AlreadyExistInUniqueConstraintNameList(DocumentStore document_store, string x)
        {
            foreach (DocumentItem doc_item in document_store.items)
            {
                if (doc_item.name.Equals(x))
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

        private static int GetStringLastNumber(string s, ref string sWithoutNumber)
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
                    return 0;
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
                    return iNum;
                }

            }
            else
            {
                return 0;
            }
        }

        public static string GetName(List<string> UniqueNameList, string p)
        {
            string x = p;
            while (AlreadyExistInUniqueConstraintNameList(UniqueNameList, x))
            {
                string sWithoutNumber = "";
                int iNum = GetStringLastNumber(x, ref sWithoutNumber);
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
                int iNum = GetStringLastNumber(x, ref sWithoutNumber);
                iNum++;
                x = sWithoutNumber + iNum;
            }
            return x;
        }

        public static string GetName(DataStore datastore, string p)
        {
            string x = p;
            while (AlreadyExistInUniqueConstraintNameList(datastore, x))
            {
                string sWithoutNumber = "";
                int iNum = GetStringLastNumber(x, ref sWithoutNumber);
                iNum++;
                x = sWithoutNumber + iNum;
            }
            return x;
        }

        public static string GetName(DocumentStore document_store, string p)
        {
            string x = p;
            while (AlreadyExistInUniqueConstraintNameList(document_store, x))
            {
                string sWithoutNumber = "";
                int iNum = GetStringLastNumber(x, ref sWithoutNumber);
                iNum++;
                x = sWithoutNumber + iNum;
            }
            return x;
        }


        //private static bool AlreadyExistInUniqueConstraintNameList(List<string> UniqueNameList, string x)
        //{
        //    foreach (string s in UniqueNameList)
        //    {
        //        if (s.Equals(x))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //private static bool AlreadyExistInUniqueConstraintNameList(ImageStore imgstore, string x)
        //{
        //    foreach (ImageItem e3pi in imgstore.items)
        //    {
        //        if (e3pi.Name.Equals(x))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //private static bool IsDigit(char c)
        //{
        //    if ((c == '0') ||
        //        (c == '1') ||
        //        (c == '2') ||
        //        (c == '3') ||
        //        (c == '4') ||
        //        (c == '5') ||
        //        (c == '6') ||
        //        (c == '7') ||
        //        (c == '8') ||
        //        (c == '9'))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}

        //private static int GetStringLastNumber(string s, ref string sWithoutNumber)
        //{

        //    int iLen = s.Length;
        //    int i;
        //    string sNum = "";
        //    if (iLen > 0)
        //    {
        //        i = iLen - 1;
        //        while (i >= 0)
        //        {
        //            if (IsDigit(s[i]))
        //            {
        //                sNum = s[i] + sNum;
        //                i--;
        //            }
        //            else
        //            {
        //                break;
        //            }
        //        }
        //        if (sNum.Length == 0)
        //        {
        //            sWithoutNumber = s;
        //            return 0;
        //        }
        //        else
        //        {
        //            if (i > 0)
        //            {
        //                sWithoutNumber = s.Substring(0, i + 1);
        //            }
        //            else
        //            {
        //                sWithoutNumber = "";
        //            }
        //            int iNum = Convert.ToInt32(sNum);
        //            return iNum;
        //        }

        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        //public static string GetName(List<string> UniqueNameList,string p)
        //{
        //    string x = p;
        //    while (AlreadyExistInUniqueConstraintNameList(UniqueNameList,x))
        //    {
        //        string sWithoutNumber = "";
        //        int iNum = GetStringLastNumber(x, ref sWithoutNumber);
        //        iNum++;
        //        x = sWithoutNumber + iNum;
        //    }
        //    return x;
        //}

        //public static string GetName(ImageStore imgstore, string p)
        //{
        //    string x = p;
        //    while (AlreadyExistInUniqueConstraintNameList(imgstore, x))
        //    {
        //        string sWithoutNumber = "";
        //        int iNum = GetStringLastNumber(x, ref sWithoutNumber);
        //        iNum++;
        //        x = sWithoutNumber + iNum;
        //    }
        //    return x;
        //}


    }
}
