using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public class f_SupplierOrg_Data
    {

        private string_v organisationTYPE_v = null;
        public string OrganisationTYPE
        {
            get
            {
                if (organisationTYPE_v != null)
                {
                    return organisationTYPE_v.v;
                }
                else
                {
                    return null;
                }
            }
        }

        private string_v streetName_v = null;
        public string StreetName
        {
            get
            {
                if (streetName_v != null)
                {
                    return streetName_v.v;
                }
                else
                {
                    return null;
                }
            }
        }

        private string_v houseNumber_v = null;
        public string HouseNumber
        {
            get
            {
                if (houseNumber_v != null)
                {
                    return houseNumber_v.v;
                }
                else
                {
                    return null;
                }
            }
        }

        private string_v city_v = null;
        public string City
        {
            get
            {
                if (city_v != null)
                {
                    return city_v.v;
                }
                else
                {
                    return null;
                }
            }
        }


        private string_v m_ZIP_v = null;
        public string ZIP
        {
            get
            {
                if (m_ZIP_v != null)
                {
                    return m_ZIP_v.v;
                }
                else
                {
                    return null;
                }
            }
        }


        private string_v state_v = null;
        public string State
        {
            get
            {
                if (state_v != null)
                {
                    return state_v.v;
                }
                else
                {
                    return null;
                }
            }
        }

        private string_v country_v = null;
        public string Country
        {
            get
            {
                if (country_v != null)
                {
                    return country_v.v;
                }
                else
                {
                    return null;
                }
            }
        }


        private string_v country_ISO_3166_a2_v = null;
        public string Country_ISO_3166_a2
        {
            get
            {
                if (country_ISO_3166_a2_v != null)
                {
                    return country_ISO_3166_a2_v.v;
                }
                else
                {
                    return null;
                }
            }
        }

        private string_v country_ISO_3166_a3_v = null;
        public string Country_ISO_3166_a3
        {
            get
            {
                if (country_ISO_3166_a3_v != null)
                {
                    return country_ISO_3166_a3_v.v;
                }
                else
                {
                    return null;
                }
            }
        }

        private short_v country_ISO_3166_num_v = null;
        public short Country_ISO_3166_num
        {
            get
            {
                if (country_ISO_3166_num_v != null)
                {
                    return country_ISO_3166_num_v.v;
                }
                else
                {
                    return 0;
                }
            }
        }

        private string_v phoneNumber_v = null;
        public string PhoneNumber
        {
            get
            {
                if (phoneNumber_v != null)
                {
                    return phoneNumber_v.v;
                }
                else
                {
                    return null;
                }
            }
        }

        private string_v faxNumber_v = null;
        public string FaxNumber
        {
            get
            {
                if (faxNumber_v != null)
                {
                    return faxNumber_v.v;
                }
                else
                {
                    return null;
                }
            }
        }

        private string_v email_v = null;
        public string Email
        {
            get
            {
                if (email_v != null)
                {
                    return email_v.v;
                }
                else
                {
                    return null;
                }
            }
        }

        private string_v homepage_v = null;
        public string HomePage
        {
            get
            {
                if (homepage_v != null)
                {
                    return homepage_v.v;
                }
                else
                {
                    return null;
                }
            }
        }

        private byte_array_v logo_image_data_v = null;
        public Image Logo
        {
            get
            {
                if (logo_image_data_v != null)
                {
                    ImageConverter ic = new ImageConverter();
                    return (Image)ic.ConvertFrom(logo_image_data_v.v);
                }
                else
                {
                    return null;
                }
            }
        }

        private string_v logo_image_description_v = null;


        public string LogoImageDesrcription
        {
            get
            {
                if (logo_image_description_v != null)
                {
                    return logo_image_description_v.v;
                }
                else
                {
                    return null;
                }
            }
        }

        public void Set(DataRow dr, f_DocInvoice_ShopC_Item_Source.Col c)
        {
            organisationTYPE_v = tf.set_string(dr[c.Supplier_OrganisationTYPE]);
            streetName_v = tf.set_string(dr[c.SupplierOrg_StreetName]);
            houseNumber_v = tf.set_string(dr[c.SupplierOrg_HouseNumber]);
            city_v = tf.set_string(dr[c.SupplierOrg_City]);
            m_ZIP_v = tf.set_string(dr[c.SupplierOrg_ZIP]);
            state_v = tf.set_string(dr[c.SupplierOrg_State]);
            country_v = tf.set_string(dr[c.SupplierOrg_Country]);
            country_ISO_3166_a2_v = tf.set_string(dr[c.SupplierOrg_Country_ISO_3166_a2]);
            country_ISO_3166_a3_v = tf.set_string(dr[c.SupplierOrg_Country_ISO_3166_a3]);
            country_ISO_3166_num_v = tf.set_short(dr[c.SupplierOrg_Country_ISO_3166_num]);
            phoneNumber_v = tf.set_string(dr[c.SupplierOrg_PhoneNumber]);
            faxNumber_v = tf.set_string(dr[c.SupplierOrg_FaxNumber]);
            email_v = tf.set_string(dr[c.SupplierOrg_Email]);
            homepage_v = tf.set_string(dr[c.SupplierOrg_HomePage]);
            logo_image_data_v = tf.set_byte_array(dr[c.SupplierOrgLogo_Image_Data]);
            logo_image_description_v = tf.set_string(dr[c.SupplierOrgLogo_Image_Descrition]);
        }

        public f_SupplierOrg_Data(DataRow dr, f_DocInvoice_ShopC_Item_Source.Col c)
        {
            Set(dr,c);
        }

       
    }
}
