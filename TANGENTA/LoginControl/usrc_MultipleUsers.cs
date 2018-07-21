using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginControl
{
    public partial class usrc_MultipleUsers : UserControl
    {

        public string[] s_name_Group = null;

        public int m_NumberOfItemsPerPage = 10;
        public int NumberOfItemsPerPage
        {
            get { return m_NumberOfItemsPerPage; }
            set
            {
                m_NumberOfItemsPerPage = value;
                Init();
            }
        }

        public usrc_LoginOfMyOrgUser[] usrc_Item_aray = null;

        public usrc_MultipleUsers()
        {
            InitializeComponent();
        }

        internal void Init()
        {
            usrc_Item_aray = new usrc_LoginOfMyOrgUser[NumberOfItemsPerPage];

            int i = 0;
            int yPos = 0;
            while (pnl_Items.Controls.Count > 0)
            {
                Control ctrl = pnl_Items.Controls[0];
                this.pnl_Items.Controls.Remove(ctrl);
                ctrl.Dispose();
            }
            pnl_Items.AutoScrollOffset = new Point(0, 0);
            pnl_Items.AutoScrollPosition = new Point(0, 0);
            for (i = 0; i < m_NumberOfItemsPerPage; i++)
            {
                usrc_LoginOfMyOrgUser usrc_item = new usrc_LoginOfMyOrgUser();
                usrc_item.Top = yPos;
                usrc_item.Left = 5;
                usrc_item.Width = this.pnl_Items.Width - 10;
                usrc_item.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                yPos += usrc_item.Height + 1;
                //usrc_item.BackColor = Colors.ItemFromStock.BackColor;
                //usrc_item.ForeColor = Colors.ItemFromStock.ForeColor;
                usrc_Item_aray[i] = usrc_item;
                this.pnl_Items.Controls.Add(usrc_item);
            }
            this.pnl_Items.AutoScroll = true;
            this.pnl_Items.HorizontalScroll.Enabled = true;
            this.pnl_Items.VerticalScroll.Enabled = true;
            if (this.Visible)
            {
                LogFile.LogFile.WriteDEBUG("-> usrc_ItemList:Init(..) Visible=TRUE");
            }
            else
            {
                LogFile.LogFile.WriteDEBUG("-> usrc_ItemList:Init(..) Visible=FALSE");
            }
        }

        private void m_usrc_Item_PageHandler_ShowObject(int Item_id_index, object o_data, object o_usrc, bool bVisible)
        {
            if (this.Visible)
            {
                LogFile.LogFile.WriteDEBUG("-> usrc_ItemList:m_usrc_Item_PageHandler_ShowObject(..) Visible=TRUE");
                usrc_LoginOfMyOrgUser usrc_item = (usrc_LoginOfMyOrgUser)o_usrc;
                if (bVisible)
                {
                    //Item_Data iData = (Item_Data)o_data;
                    usrc_item.Visible = true;
                    usrc_item.Enabled = true;
                    usrc_item.DoPaint(null, s_name_Group, null);
                }
                else
                {
                    usrc_item.Visible = false;
                    usrc_item.Enabled = false;
                }
            }
            else
            {
                LogFile.LogFile.WriteDEBUG("-> usrc_ItemList:m_usrc_Item_PageHandler_ShowObject(..) Visible=FALSE");
            }
        }

    }
}
