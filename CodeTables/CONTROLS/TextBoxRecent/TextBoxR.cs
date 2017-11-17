using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LanguageControl;

namespace TextBoxRecent
{
    public class TextBoxR: TextBox
    {
        ToolStripMenuItem menuitem = null;
        TextList txt_list = new TextList();

        public TextBoxR():base()
        {
            menuitem = new ToolStripMenuItem();
            menuitem.Text = lng.s_RecentText.s;
            menuitem.Click += Menuitem_Click;
            ContextMenuStrip myContextMenuStrip = base.ContextMenuStrip;
            if (myContextMenuStrip == null)
            {
                base.ContextMenuStrip = new ContextMenuStrip();
                //myContextMenuStrip.Items.Add()
            }
            base.ContextMenuStrip.Items.Add(menuitem);
        }

        private void Menuitem_Click(object sender, EventArgs e)
        {
            int xpos = System.Windows.Forms.Cursor.Position.X;
            int ypos = System.Windows.Forms.Cursor.Position.Y;
            Form_SelectRecentText frseltext = new Form_SelectRecentText(txt_list,xpos,ypos);
            frseltext.ShowDialog();
            if (frseltext.SelectedString!=null)
            {
                this.Text = frseltext.SelectedString;
            }
        }

        public new void Clear()
        {
            string sNewText = base.Text;
            if (sNewText != null)
            {
                if (sNewText.Length>0)
                {
                    string stext = txt_list.items.Find(s => s.Equals(sNewText));
                    if (stext == null)
                    {
                        txt_list.items.Add(sNewText);
                    }
                }
            }
            base.Text = "";
            base.Clear();
        }
    }
}
