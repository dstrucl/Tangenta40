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
    public class f_SupplierPerson_Data
    {
        private string_v firstName_v = null;
        public string FirstName
        {
            get
            {
                if (firstName_v != null)
                {
                    return firstName_v.v;
                }
                else
                {
                    return null;
                }
            }
        }

        private string_v lastName_v = null;
        public string LastName
        {
            get
            {
                if (lastName_v != null)
                {
                    return lastName_v.v;
                }
                else
                {
                    return null;
                }
            }
        }

        private bool_v gender_v = null;
        public bool Gender
        {
            get
            {
                if (gender_v != null)
                {
                    return gender_v.v;
                }
                else
                {
                    return false;
                }
            }
        }

        private DateTime_v dateOfBirth_v = null;
        public DateTime DateOfBirth
        {
            get
            {
                if (dateOfBirth_v != null)
                {
                    return dateOfBirth_v.v;
                }
                else
                {
                    return DateTime.MinValue;
                }
            }
        }

        private string_v tax_id_v = null;
        public string Tax_ID
        {
            get
            {
                if (tax_id_v != null)
                {
                    return tax_id_v.v;
                }
                else
                {
                    return null;
                }
            }
        }

        private string_v registration_id_v = null;
        public string Registration_ID
        {
            get
            {
                if (registration_id_v != null)
                {
                    return registration_id_v.v;
                }
                else
                {
                    return null;
                }
            }
        }

        private string_v cardNumber_v = null;
        public string CardNumber
        {
            get
            {
                if (cardNumber_v != null)
                {
                    return cardNumber_v.v;
                }
                else
                {
                    return null;
                }
            }
        }

        private int_v pin_v = null;
        public int PIN
        {
            get
            {
                if (pin_v != null)
                {
                    return pin_v.v;
                }
                else
                {
                    return -1;
                }
            }
        }

        private string_v description_v = null;
        public string Description
        {
            get
            {
                if (description_v != null)
                {
                    return description_v.v;
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



        private string_v person_image_hash_v = null;
        public string Person_Image_Hash
        {
            get
            {
                if (person_image_hash_v != null)
                {
                    return person_image_hash_v.v;
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

        private string_v gsmNumber_v = null;
        public string GsmNumber
        {
            get
            {
                if (gsmNumber_v != null)
                {
                    return gsmNumber_v.v;
                }
                else
                {
                    return null;
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

        private byte_array_v person_image_data_v = null;
        public Image PersonImage
        {
            get
            {
                if (person_image_data_v != null)
                {
                    ImageConverter ic = new ImageConverter();
                    return (Image)ic.ConvertFrom(person_image_data_v.v);
                }
                else
                {
                    return null;
                }
            }
        }


        public void Set(DataRow dr, f_DocInvoice_ShopC_Item_Source.Col c)
        {
            firstName_v = tf.set_string(dr[c.SupplierPer_FirstName]);

            lastName_v = tf.set_string(dr[c.SupplierPer_LastName]);

            gender_v = tf.set_bool(dr[c.SupplierPer_Gender]);

            dateOfBirth_v = tf.set_DateTime(dr[c.SupplierPer_DateOfBirth]);

            tax_id_v = tf.set_string(dr[c.SupplierPer_Tax_ID]);

            registration_id_v = tf.set_string(dr[c.SupplierPer_Registration_ID]);

            cardNumber_v = tf.set_string(dr[c.SupplierPer_CardNumber]);

            pin_v = tf.set_int(dr[c.SupplierPer_PIN]);

            description_v = tf.set_string(dr[c.SupplierPer_Description]);

            streetName_v = tf.set_string(dr[c.SupplierPer_StreetName]);

            houseNumber_v = tf.set_string(dr[c.SupplierPer_HouseNumber]);

            city_v = tf.set_string(dr[c.SupplierPer_City]);

            m_ZIP_v = tf.set_string(dr[c.SupplierPer_ZIP]);


            state_v = tf.set_string(dr[c.SupplierPer_State]);

            country_v = tf.set_string(dr[c.SupplierPer_Country]);


            country_ISO_3166_a2_v = tf.set_string(dr[c.SupplierPer_Country_ISO_3166_a2]);

            country_ISO_3166_a3_v = tf.set_string(dr[c.SupplierPer_Country_ISO_3166_a3]);

            country_ISO_3166_num_v = tf.set_short(dr[c.SupplierPer_Country_ISO_3166_num]);

            gsmNumber_v = tf.set_string(dr[c.SupplierPer_GsmNumber]);

            phoneNumber_v = tf.set_string(dr[c.SupplierPer_PhoneNumber]);

            email_v = tf.set_string(dr[c.SupplierPer_Email]);

            person_image_data_v = tf.set_byte_array(dr[c.SupplierPer_Image_Data]);

            person_image_hash_v = tf.set_string(dr[c.SupplierPer_Image_Hash]);
        }

        public f_SupplierPerson_Data(DataRow dr, f_DocInvoice_ShopC_Item_Source.Col c)
        {
            Set(dr,c);
        }

    }
}
