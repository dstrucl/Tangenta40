using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUDCMS
{
    public static class BookmarkDic
    {
        private static List<BookmarkX> dic = new List<BookmarkX>();

        private static bool Find(string xControlUniqueName,ref string xID)
        {
            foreach(BookmarkX bk in dic)
            {
                if (bk.ControlUniqueName.Equals(xControlUniqueName))
                {
                    xID = bk.ID;
                    return true;
                }
            }
            return false;
        }
        public static string GetBookmark(string xControlUniqueName)
        {
            string xID = null;
            if (Find(xControlUniqueName, ref xID))
            {
                return xID;
            }
            else
            {
                int iCount = dic.Count;
                BookmarkX bk = new BookmarkX(xControlUniqueName, iCount);
                dic.Add(bk);
                return bk.ID;
            }
        }
    }
}
