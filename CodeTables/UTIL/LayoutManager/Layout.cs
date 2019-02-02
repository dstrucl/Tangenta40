using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayoutManager
{
    public class Layout
    {
        int screenwidth = 0;
        public int ScreenWidth
        {
            get
            {
                return screenwidth;
            }
            set
            {
                screenwidth = value;
            }
        }

        int screenheight = 0;
        public int ScreenHeight
        {
            get
            {
                return screenheight;
            }
            set
            {
                screenheight = value;
            }
        }

        public ControlLayout FormLayout = null;



        public Layout(int screen_width, int screen_height,Form form)
        {
            screenwidth = screen_width;
            screenheight = screen_height;
            //FormLayout = new ControlLayout(null,form);
        }
    }
}
