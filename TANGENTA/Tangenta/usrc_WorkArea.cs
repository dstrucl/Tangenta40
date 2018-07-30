using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBTypes;
using DBConnectionControl40;
using TangentaDB;

namespace Tangenta
{
    public partial class usrc_WorkArea : UserControl
    {
        public delegate void delegate_Selected(WArea warea);

        public event delegate_Selected Selected = null;

        internal usrc_WorkAreaAll m_usrc_WorkAreaAll = null;

        public WArea wArea = null;

        public usrc_WorkArea()
        {
            InitializeComponent();
            //lng.s_btn_GetAccess.Text(btn_GetAccess);
        }

        private void RePaint()
        {

        }

        internal void DoPaint(DataRow dr, string[] s_name_Group, object xobj)
        {
            RePaint();
        }


        internal void SetData(DataRow dr)
        {
            if (wArea!=null)
            {
                if (wArea.Image!=null)
                {
                    wArea.Image.Dispose();
                }
            }
            wArea = new WArea(tf._set_string(dr["WorkArea_$$Name"]), tf._set_string(dr["WorkArea_$$Description"]),tf.set_byte_array(dr["WorkArea_$_wai_$$Image_Data"]));
            btn_WorkArea.Text = wArea.Name;
            if (wArea.Image!=null)
            {
                this.pictureBox1.Image = wArea.Image;
            }
            else
            {
                this.pictureBox1.Image = null;
            }
        }


        private void btn_btn_WorkArea_Click(object sender, EventArgs e)
        {
            if (wArea != null)
            {
                if (Selected!=null)
                {
                    Selected(wArea);
                }
            }
        }
    }
}
