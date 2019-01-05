using DBTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentEditor
{
    public class WArea
    {
        string m_Name = null;
        public string Name
        {
            get
            {
                return m_Name;
            }
        }

        string m_Description = null;
        public string Description
        {
            get
            {
                return m_Description;
            }
        }


        private Image  m_Image = null;
        public Image Image
        {
            get
            {
                return m_Image;
            }
        }

        public WArea(string xname, string description, byte_array_v image_bytes_v)
        {
            m_Description = description;
            m_Name = xname;
            if (image_bytes_v != null)
            {
                m_Image = DBTypes.func.byteArrayToImage(image_bytes_v.v);
            }
            else
            {
                m_Image = null;
            }
        }

    }
}
