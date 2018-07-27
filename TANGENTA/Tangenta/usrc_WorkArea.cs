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
        internal usrc_WorkAreaAll m_usrc_WorkAreaAll = null;



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
            
            btn_WorkArea.Text = tf._set_string(dr["WorkArea_$$Name"]);
            byte_array_v imagebytes_v = tf.set_byte_array(dr["WorkArea_$_wai_$$Image_Data"]);
            if (imagebytes_v != null)
            {
                this.pictureBox1.Image = DBTypes.func.byteArrayToImage(imagebytes_v.v);
            }
        }


        private void btn_btn_WorkArea_Click(object sender, EventArgs e)
        {
            
        }
    }
}
