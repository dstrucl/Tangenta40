using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace usrc_Item_Group_Handler
{
    public partial class usrc_Item_InsidePageGroupHandler : UserControl
    {
        private int ilasttop = -1;
        public usrc_Item_InsidePageGroupHandler()
        {
            InitializeComponent();
        }

        public void Init(DataTable dtItm)
        {
            this.usrc_Item_InsideGroup_Handler1.Init(dtItm);
        }

        private void usrc_Item_InsideGroup_Handler1_SizeChanged(int top, int height)
        {
            if (ilasttop==-1)
            {
                ilasttop = top;
            }
            usrc_Item_InsidePageHandler1.Top = 0;    
        }
    }
}
