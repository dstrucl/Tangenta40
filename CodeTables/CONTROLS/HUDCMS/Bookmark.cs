using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUDCMS
{
    public class BookmarkX
    {
        private int idx = -1;
        public int Index
        {
            get
            {
                return idx;
            }
            set
            {
                idx = value;
            }
        }

        public string ID
        {
            get
            {
                return "#b"+ idx.ToString();
            }
        }

        private string controluniquename = null;
        public string ControlUniqueName
        {
            get
            {
                return controluniquename;
            }
            set
            {
                controluniquename = value;
            }
        }

        public BookmarkX(string xControlUniqueName,int xIndex)
        {
            controluniquename = xControlUniqueName;
            idx = xIndex;
        }
    }
}
