#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeTables;
using TangentaTableClass;
using LanguageControl;
using DBTypes;
using DBConnectionControl40;

namespace Tangenta
{
    public partial class usrc_Customer : UserControl
    {
        public delegate void delegate_Customer_Person_Changed(ID Customer_Person_ID);
        public event delegate_Customer_Person_Changed aa_Customer_Person_Changed = null;

        public delegate void delegate_Customer_Org_Changed(ID Customer_Org_ID);
        public event delegate_Customer_Org_Changed aa_Customer_Org_Changed = null;

        public delegate bool delegate_Customer_Removed();
        public event delegate_Customer_Removed aa_Customer_Removed = null;

        public ID Customer_OrganisationData_ID = null;
        public ID Customer_Person_ID = null;
        public NavigationButtons.Navigation nav = null;
        private List<CustomerItem> CustomerItemType_List = null;
        public usrc_Customer()
        {
            InitializeComponent();
            lbl_Buyer.Text = lng.s_Buyer.s + ":";
            lbl_CardNumber.Text = lng.s_CardNumber.s + ":";
            lbl_TypeOfBuyerCard.Text = lng.s_Type.s + ":";
            this.btn_BuyerSelect.Image = CodeTables.Globals.Image_SelectRow;
            CustomerItemType_List = new List<CustomerItem>();
            CustomerItemType_List.Add(new CustomerItem(CustomerItem.eCustomerType.PERSON));
            CustomerItemType_List.Add(new CustomerItem(CustomerItem.eCustomerType.ORGANISATION));
            cmb_BuyerType.DataSource = CustomerItemType_List;
            cmb_BuyerType.DisplayMember = "type_name";
            cmb_BuyerType.ValueMember = "type";
            this.btn_BuyerSelect.Visible = false;
            this.txt_Buyer.Visible = false;
        }

        public new string Text
        {
            get {return this.txt_Buyer.Text;}
            set
            {
                string s = value;
                if (s!=null)
                {
                    this.txt_Buyer.Text = s;
                }
                else
                {
                    this.txt_Buyer.Text = "";
                }
            }
            }

        internal bool Edit_Customer_Person()
        {
            SQLTable tbl_Customer_Person = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(PersonData)));
            Form_Customer_Person_Edit Customer_Person_dlg = new Form_Customer_Person_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                            tbl_Customer_Person,
                                                            "PersonData_$_per_$_cln_$$LastName desc",nav);

            if (Customer_Person_dlg.ShowDialog()==DialogResult.Yes)
            {
                Customer_Person_ID = tf.set_ID(Customer_Person_dlg.CustomerPerson_ID);
                if (aa_Customer_Person_Changed != null)
                {
                    Program.Cursor_Wait();
                    aa_Customer_Person_Changed(Customer_Person_ID);
                    Program.Cursor_Arrow();
                }
            }
            return true;
        }

        internal bool Edit_Customer_Organisation()
        {
            SQLTable tbl_Customer_Org = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Customer_Org)));
            Form_Customer_Org_Edit Customer_Org_dlg = new Form_Customer_Org_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                            tbl_Customer_Org,
                                                            "Customer_Org_$_orgd_$_org_$$Name desc",nav);
            if (Customer_Org_dlg.ShowDialog()==DialogResult.Yes)
            {
                Customer_OrganisationData_ID = tf.set_ID(Customer_Org_dlg.Customer_OrganisationData_ID);
                if (aa_Customer_Org_Changed != null)
                {
                    Program.Cursor_Wait();
                    aa_Customer_Org_Changed(Customer_OrganisationData_ID);
                    Program.Cursor_Arrow();
                }
            }

            return true;
        }

        private void btn_Buyer_Click(object sender, EventArgs e)
        {
            if (cmb_BuyerType.SelectedValue != null)
            {
                if ((CustomerItem.eCustomerType)cmb_BuyerType.SelectedValue == CustomerItem.eCustomerType.PERSON)
                {
                    Edit_Customer_Person();
                }
                else
                {
                    Edit_Customer_Organisation();
                }
            }
        }

        private void Select_Customer_Person()
        {
            SQLTable tbl_Customer_Person = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Customer_Person)));
            tbl_Customer_Person.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
            string sql = @"SELECT
            Customer_Person.ID,
            Customer_Person_$_per.ID AS Customer_Person_$_per_$$ID,
            Customer_Person_$_per.Gender AS Customer_Person_$_per_$$Gender,
            Customer_Person_$_per_$_cfn.ID AS Customer_Person_$_per_$_cfn_$$ID,
            Customer_Person_$_per_$_cfn.FirstName AS Customer_Person_$_per_$_cfn_$$FirstName,
            Customer_Person_$_per_$_cln.ID AS Customer_Person_$_per_$_cln_$$ID,
            Customer_Person_$_per_$_cln.LastName AS Customer_Person_$_per_$_cln_$$LastName,
            Customer_Person_$_per.DateOfBirth AS Customer_Person_$_per_$$DateOfBirth,
            Customer_Person_$_per.Tax_ID AS Customer_Person_$_per_$$Tax_ID,
            Customer_Person_$_per.Registration_ID AS Customer_Person_$_per_$$Registration_ID,
            cgsm_per.GsmNumber,
            ctel_per.PhoneNumber,
            email_per.Email,
            cstrn_per.StreetName,
            chnr_per.HouseNumber,
            city_per.City,
            zip_per.ZIP,
            state_per.Country,
            country_per.State,
            per_data.CardNumber,
            per_data.Description,
            img_per.Image_Data
            FROM Customer_Person
            INNER JOIN Person Customer_Person_$_per ON Customer_Person.Person_ID = Customer_Person_$_per.ID
            INNER JOIN cFirstName Customer_Person_$_per_$_cfn ON Customer_Person_$_per.cFirstName_ID = Customer_Person_$_per_$_cfn.ID
            LEFT JOIN cLastName Customer_Person_$_per_$_cln ON Customer_Person_$_per.cLastName_ID = Customer_Person_$_per_$_cln.ID
            LEFT JOIN PersonData per_data ON per_data.Person_ID = Customer_Person_$_per.ID
            LEFT JOIN cGsmNumber_Person cgsm_per ON per_data.cGsmNumber_Person_ID = cgsm_per.ID
            LEFT JOIN  cPhoneNumber_Person  ctel_per ON per_data.cPhoneNumber_Person_ID = ctel_per.ID
            LEFT JOIN  cEmail_Person  email_per ON per_data.cEmail_Person_ID = email_per.ID
            LEFT JOIN  cAddress_Person  cadr_per ON per_data.cAddress_Person_ID = cadr_per.ID
            LEFT JOIN  cStreetName_Person  cstrn_per ON cadr_per.cStreetName_Person_ID = cstrn_per.ID
            LEFT JOIN  cHouseNumber_Person  chnr_per ON cadr_per.cHouseNumber_Person_ID = chnr_per.ID
            LEFT JOIN  cCity_Person  city_per ON cadr_per.cCity_Person_ID = city_per.ID
            LEFT JOIN  cZIP_Person  zip_per ON cadr_per.cZIP_Person_ID = zip_per.ID
            LEFT JOIN  cCountry_Person state_per ON cadr_per.cCountry_Person_ID = state_per.ID
            LEFT JOIN  cState_Person  country_per ON cadr_per.cState_Person_ID = country_per.ID
            LEFT JOIN  PersonImage img_per ON per_data.PersonImage_ID = img_per.ID
            ";
            string[] sColumnsToView = new string[] { "Customer_Person_$_per_$_cfn_$$FirstName",
                                                     "Customer_Person_$_per_$_cln_$$LastName",
                                                     "Customer_Person_$_per_$$DateOfBirth",
                                                     "GsmNumber",
                                                    "Image_Data",
                                                    "PhoneNumber",
                                                    "Email",
                                                    "StreetName",
                                                    "HouseNumber",
                                                    "City",
                                                    "ZIP",
                                                    "Country",
                                                    "State",
                                                    "CardNumber",
                                                    "Description",
                                                    };


            CodeTables.SelectID_Table_Assistant_Form selectID_Table_Assistant_Form = new SelectID_Table_Assistant_Form(sql, tbl_Customer_Person, DBSync.DBSync.DB_for_Tangenta.m_DBTables, sColumnsToView);
            if (selectID_Table_Assistant_Form.ShowDialog()==DialogResult.OK)
            {
                Customer_Person_ID = tf.set_ID(selectID_Table_Assistant_Form.ID);
                if (aa_Customer_Person_Changed!=null)
                {
                    aa_Customer_Person_Changed(Customer_Person_ID);
                }
            }
        }

        private void Select_Customer_Org()
        {
            SQLTable tbl_Customer_Org = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Customer_Org)));
            tbl_Customer_Org.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
            string[] sColumnsToView = new string[] { "Customer_Org_$_orgd_$_org_$$Name",
                                                     "Customer_Org_$_orgd_$_org_$$Tax_ID",
                                                     "Customer_Org_$_orgd_$_cadrorg_$_cstrnorg_$$StreetName",
                                                     "Customer_Org_$_orgd_$_cadrorg_$_chounorg_$$HouseNumber",
                                                    "Customer_Org_$_orgd_$_cadrorg_$_ccitorg_$$City",
                                                    "Customer_Org_$_orgd_$_cadrorg_$_cziporg_$$ZIP",
                                                    "Customer_Org_$_orgd_$_cadrorg_$_ccouorg_$$Country",
                                                    "Customer_Org_$_orgd_$_cphnnorg_$$PhoneNumber",
                                                    "Customer_Org_$_orgd_$_cfaxnorg_$$FaxNumber",
                                                    "Customer_Org_$_orgd_$_cemailorg_$$Email",
                                                    "Customer_Org_$_orgd_$_chomepgorg_$$HomePage",
                                                    "Customer_Org_$_orgd_$_org_$$Registration_ID",
                                                    "Customer_Org_$_orgd_$_cfaxnorg_$$FaxNumber"
                                                    };

            CodeTables.SelectID_Table_Assistant_Form selectID_Table_Assistant_Form = new SelectID_Table_Assistant_Form(tbl_Customer_Org, DBSync.DBSync.DB_for_Tangenta.m_DBTables, sColumnsToView);
            if (selectID_Table_Assistant_Form.ShowDialog() == DialogResult.OK)
            {
                Customer_OrganisationData_ID.Set(selectID_Table_Assistant_Form.ID);
                if (aa_Customer_Org_Changed != null)
                {
                    aa_Customer_Org_Changed(Customer_OrganisationData_ID);
                }
            }
        }

        private void btn_BuyerSelect_Click(object sender, EventArgs e)
        {
            if (cmb_BuyerType.SelectedValue != null)
            {
                if ((CustomerItem.eCustomerType)cmb_BuyerType.SelectedValue == CustomerItem.eCustomerType.PERSON)
                {
                    Select_Customer_Person();
                }
                else
                {
                    Select_Customer_Org();
                }
            }
        }

        public class CustomerItem
        { 
            public enum eCustomerType { PERSON, ORGANISATION };
            private eCustomerType m_eCustomerType;
            
            public CustomerItem(eCustomerType xeCustomerType)
            {
                m_eCustomerType = xeCustomerType;
            }
            public eCustomerType type
            {
                get { return m_eCustomerType; }
                set { m_eCustomerType = value; }
            }

            public string type_name
            {
                get {
                        if (m_eCustomerType == eCustomerType.PERSON)
                        {
                            return lng.s_Person.s;
                        }
                        else
                        {
                            return lng.s_Organisation.s;
                        }
                    }
            }

        }

        internal void Show_Customer(TangentaDB.CurrentInvoice x_CurrentInvoice)
        {
            txt_Buyer.Text = "";

            if (x_CurrentInvoice.Atom_Customer_Person_ID != null)
            {
                Show_Customer_Person(x_CurrentInvoice);
                btn_Buyer.Enabled = true;
                btn_BuyerSelect.Visible = true;
                txt_Buyer.Visible = true;
            }
            else if (x_CurrentInvoice.Atom_Customer_Org_ID != null)
            {
                Show_Customer_Org(x_CurrentInvoice);
                btn_Buyer.Enabled = true;
                btn_BuyerSelect.Visible = true;
                txt_Buyer.Visible = true;
            }
            else
            {
                cmb_BuyerType.SelectedItem = null;
                btn_Buyer.Enabled = false;
                btn_BuyerSelect.Visible = false;
                txt_Buyer.Visible = false;
            }
        }

        public void Show_Customer_Person(TangentaDB.CurrentInvoice x_CurrentInvoice)
        {
            if (x_CurrentInvoice.Atom_Customer_Person_ID != null)
            {
                ID Atom_Customer_Person_ID = x_CurrentInvoice.Atom_Customer_Person_ID;
                string sql = @"select
                                        Atom_Customer_Person_$_aper_$_acfn_$$FirstName,
                                        Atom_Customer_Person_$_aper_$_acln_$$LastName,
                                        Atom_Customer_Person_$_aper_$_agsmnper_$$GsmNumber,
                                        Atom_Customer_Person_$_aper_$_aphnnper_$$PhoneNumber,
                				        Atom_Customer_Person_$_aper_$$DateOfBirth,
                                        Atom_Customer_Person_$_aper_$$Tax_ID,
                                        Atom_Customer_Person_$_aper_$$Registration_ID,
                                        Atom_Customer_Person_$_aper_$_acadrper_$_astrnper_$$StreetName,
                                        Atom_Customer_Person_$_aper_$_acadrper_$_ahounper_$$HouseNumber,
                				        Atom_Customer_Person_$_aper_$_acadrper_$_azipper_$$ZIP,
				                        Atom_Customer_Person_$_aper_$_acadrper_$_acitper_$$City,
				                        Atom_Customer_Person_$_aper_$_acadrper_$_astper_$$Country,
				                        Atom_Customer_Person_$_aper_$_acadrper_$_acouper_$$State
                                        from  Atom_Customer_Person_VIEW 
                                        where ID = " + Atom_Customer_Person_ID.ToString();
                DataTable dt = new DataTable();
                string Err = null;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                {
                    if (dt.Rows.Count == 1)
                    {
                        object oFirstName = dt.Rows[0]["Atom_Customer_Person_$_aper_$_acfn_$$FirstName"];
                        object oLastName = dt.Rows[0]["Atom_Customer_Person_$_aper_$_acln_$$LastName"];
                        object oGsmNumber = dt.Rows[0]["Atom_Customer_Person_$_aper_$_agsmnper_$$GsmNumber"];
                        object oPhoneNumber = dt.Rows[0]["Atom_Customer_Person_$_aper_$_aphnnper_$$PhoneNumber"];
                        object oTaxID = dt.Rows[0]["Atom_Customer_Person_$_aper_$$Tax_ID"];
                        object oRegistrationID = dt.Rows[0]["Atom_Customer_Person_$_aper_$$Registration_ID"];
                        object oStreetName = dt.Rows[0]["Atom_Customer_Person_$_aper_$_acadrper_$_astrnper_$$StreetName"];
                        object oHouseNumber = dt.Rows[0]["Atom_Customer_Person_$_aper_$_acadrper_$_ahounper_$$HouseNumber"];
                        object oZIP = dt.Rows[0]["Atom_Customer_Person_$_aper_$_acadrper_$_azipper_$$ZIP"];
                        object oCity = dt.Rows[0]["Atom_Customer_Person_$_aper_$_acadrper_$_acitper_$$City"];
                        object oCountry= dt.Rows[0]["Atom_Customer_Person_$_aper_$_acadrper_$_astper_$$Country"];
                        object oState = dt.Rows[0]["Atom_Customer_Person_$_aper_$_acadrper_$_acouper_$$State"];
                        object oBirthDay = dt.Rows[0]["Atom_Customer_Person_$_aper_$$DateOfBirth"];
                        string slbl = "";
                        if (oFirstName is string)
                        {
                            slbl += (string)oFirstName;
                        }
                        if (oLastName is string)
                        {
                            slbl += " " + (string)oLastName;
                        }
                        if (oGsmNumber is string)
                        {
                            slbl += ",gsm:" + (string)oGsmNumber;
                        }
                        if (oPhoneNumber is string)
                        {
                            slbl += ",tel:" + (string)oPhoneNumber;
                        }

                        if (oTaxID is int)
                        {
                            slbl += ",DŠ:" + ((int)oTaxID).ToString();
                        }
                        if (oRegistrationID is string)
                        {
                            slbl += ",EMŠO:" + (string)oRegistrationID;
                        }
                        if (oStreetName is string)
                        {
                            slbl += "," + (string)oStreetName;
                        }
                        if (oHouseNumber is string)
                        {
                            slbl += "," + (string)oHouseNumber;
                        }
                        if (oZIP is string)
                        {
                            slbl += "," + (string)oZIP;
                        }

                        if (oCity is string)
                        {
                            slbl += " " + (string)oCity;
                        }
                        if (oCountry is string)
                        {
                            slbl += "," + (string)oCountry;
                        }
                        if (oState is string)
                        {
                            slbl += "," + (string)oState;
                        }
                        txt_Buyer.Text = slbl;
                        txt_Buyer.Visible = true;
                        btn_BuyerSelect.Visible = true;
                        btn_Buyer.Enabled = true;
                        cmb_BuyerType.SelectedItem = cmb_BuyerType.Items[0];
                    }
                    else if (dt.Rows.Count > 1)
                    {
                        LogFile.Error.Show("ERROR:usrc_Invoice:Show_Customer_Person:dt.Rows.Count > 1");
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Invoice:Show_Customer_Person:Err=" + Err);
                }
            }
        }

        public void Show_Customer_Org(TangentaDB.CurrentInvoice x_CurrentInvoice)
        {
            if (ID.Validate(x_CurrentInvoice.Atom_Customer_Org_ID))
            {
                ID Atom_Customer_Org_ID = x_CurrentInvoice.Atom_Customer_Org_ID;
                string sql = @"SELECT 
                                Atom_Customer_Org.ID,
                                Atom_Customer_Org_$_aorg.Name,
                				Atom_OrganisationData_$_orgt.OrganisationTYPE,
                                Atom_Customer_Org_$_aorg.Tax_ID,
                                Atom_Customer_Org_$_aorg.Registration_ID,
                                Atom_OrganisationData_$_acadrorg_$_astrnorg.StreetName,
				                Atom_OrganisationData_$_acadrorg_$_ahounorg.HouseNumber,
				                Atom_OrganisationData_$_acadrorg_$_acitorg.City,
				                Atom_OrganisationData_$_acadrorg_$_aziporg.ZIP,
				                Atom_OrganisationData_$_acadrorg_$_astorg.Country,
				                Atom_OrganisationData_$_acadrorg_$_acouorg.State,
				                Atom_OrganisationData_$_cphnnorg.PhoneNumber,
				                Atom_OrganisationData_$_cemailorg.Email,
				                Atom_OrganisationData_$_chomepgorg.HomePage,
				                Atom_OrganisationData_$_aorgd.BankName,
				                Atom_OrganisationData_$_aorgd.TRR
                                FROM Atom_Customer_Org
                                INNER JOIN Atom_Organisation Atom_Customer_Org_$_aorg ON Atom_Customer_Org.Atom_Organisation_ID = Atom_Customer_Org_$_aorg.ID
                                LEFT JOIN Atom_OrganisationData Atom_OrganisationData_$_aorgd ON Atom_OrganisationData_$_aorgd.Atom_Organisation_ID = Atom_Customer_Org_$_aorg.ID
                                LEFT JOIN Atom_cAddress_Org Atom_OrganisationData_$_acadrorg ON Atom_OrganisationData_$_aorgd.Atom_cAddress_Org_ID = Atom_OrganisationData_$_acadrorg.ID
                                LEFT JOIN Atom_cStreetName_Org Atom_OrganisationData_$_acadrorg_$_astrnorg ON Atom_OrganisationData_$_acadrorg.Atom_cStreetName_Org_ID = Atom_OrganisationData_$_acadrorg_$_astrnorg.ID
                                LEFT JOIN Atom_cHouseNumber_Org Atom_OrganisationData_$_acadrorg_$_ahounorg ON Atom_OrganisationData_$_acadrorg.Atom_cHouseNumber_Org_ID = Atom_OrganisationData_$_acadrorg_$_ahounorg.ID
                                LEFT JOIN Atom_cCity_Org Atom_OrganisationData_$_acadrorg_$_acitorg ON Atom_OrganisationData_$_acadrorg.Atom_cCity_Org_ID = Atom_OrganisationData_$_acadrorg_$_acitorg.ID
                                LEFT JOIN Atom_cZIP_Org Atom_OrganisationData_$_acadrorg_$_aziporg ON Atom_OrganisationData_$_acadrorg.Atom_cZIP_Org_ID = Atom_OrganisationData_$_acadrorg_$_aziporg.ID
                                LEFT JOIN Atom_cCountry_Org Atom_OrganisationData_$_acadrorg_$_astorg ON Atom_OrganisationData_$_acadrorg.Atom_cCountry_Org_ID = Atom_OrganisationData_$_acadrorg_$_astorg.ID
                                LEFT JOIN Atom_cState_Org Atom_OrganisationData_$_acadrorg_$_acouorg ON Atom_OrganisationData_$_acadrorg.Atom_cState_Org_ID = Atom_OrganisationData_$_acadrorg_$_acouorg.ID
                                LEFT JOIN cPhoneNumber_Org Atom_OrganisationData_$_cphnnorg ON Atom_OrganisationData_$_aorgd.cPhoneNumber_Org_ID = Atom_OrganisationData_$_cphnnorg.ID
                                LEFT JOIN cFaxNumber_Org Atom_OrganisationData_$_cfaxnorg ON Atom_OrganisationData_$_aorgd.cFaxNumber_Org_ID = Atom_OrganisationData_$_cfaxnorg.ID
                                LEFT JOIN cEmail_Org Atom_OrganisationData_$_cemailorg ON Atom_OrganisationData_$_aorgd.cEmail_Org_ID = Atom_OrganisationData_$_cemailorg.ID
                                LEFT JOIN cHomePage_Org Atom_OrganisationData_$_chomepgorg ON Atom_OrganisationData_$_aorgd.cHomePage_Org_ID = Atom_OrganisationData_$_chomepgorg.ID
                                LEFT JOIN cOrgTYPE Atom_OrganisationData_$_orgt ON Atom_OrganisationData_$_aorgd.cOrgTYPE_ID = Atom_OrganisationData_$_orgt.ID
                                LEFT JOIN Atom_Logo Atom_OrganisationData_$_alogo ON Atom_OrganisationData_$_aorgd.Atom_Logo_ID = Atom_OrganisationData_$_alogo.ID
                                WHERE Atom_Customer_Org.ID = " + Atom_Customer_Org_ID.ToString();
                DataTable dt = new DataTable();
                string Err = null;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                {
                    if (dt.Rows.Count == 1)
                    {
                        string_v Name_v = tf.set_string(dt.Rows[0]["Name"]);
                        string_v OrganisationTYPE_v = tf.set_string(dt.Rows[0]["OrganisationTYPE"]);
                        string_v Tax_ID_v = tf.set_string(dt.Rows[0]["Tax_ID"]);
                        string_v Registration_ID_v = tf.set_string(dt.Rows[0]["Registration_ID"]);
                        string_v StreetName_v = tf.set_string(dt.Rows[0]["StreetName"]);
                        string_v HouseNumber_v = tf.set_string(dt.Rows[0]["HouseNumber"]);
                        string_v City_v = tf.set_string(dt.Rows[0]["City"]);
                        string_v ZIP_v = tf.set_string(dt.Rows[0]["ZIP"]);
                        string_v Country_v = tf.set_string(dt.Rows[0]["Country"]);
                        string_v State_v = tf.set_string(dt.Rows[0]["State"]);
                        string_v PhoneNumber_v = tf.set_string(dt.Rows[0]["PhoneNumber"]);
                        string_v Email_v = tf.set_string(dt.Rows[0]["Email"]);
                        string_v HomePage_v = tf.set_string(dt.Rows[0]["HomePage"]);
                        string_v BankName_v = tf.set_string(dt.Rows[0]["BankName"]);
                        string_v TRR_v = tf.set_string(dt.Rows[0]["TRR"]);
                        string slbl = "";
                        if (Name_v != null)
                        {
                            slbl += Name_v.vs;
                        }

                        if (Tax_ID_v != null)
                        {
                            slbl += "," + lng.s_Tax_ID.s + ":" + Tax_ID_v.vs;
                        }

                        if (StreetName_v != null)
                        {
                            slbl += "," + lng.s_Address.s + ":" + StreetName_v.vs;
                        }
                        if (HouseNumber_v != null)
                        {
                            slbl += " " + HouseNumber_v.vs;
                        }
                        if (ZIP_v != null)
                        {
                            slbl += "," + ZIP_v.vs;
                        }
                        if (City_v != null)
                        {
                            slbl += " " + City_v.vs;
                        }
                        if (State_v != null)
                        {
                            slbl += "," + State_v.vs;
                        }
                        if (Country_v != null)
                        {
                            slbl += "," + Country_v.vs;
                        }
                        txt_Buyer.Text = slbl;
                        txt_Buyer.Visible = true;
                        btn_BuyerSelect.Visible = true;
                        btn_Buyer.Enabled = true;
                        cmb_BuyerType.SelectedItem = cmb_BuyerType.Items[1];
                    }
                    else if (dt.Rows.Count > 1)
                    {
                        LogFile.Error.Show("ERROR:usrc_Invoice:Show_Customer_Org:dt.Rows.Count > 1");
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Invoice:Show_Customer_Org:Err=" + Err);
                }
            }
        }



        private void lbl_Buyer_Click(object sender, EventArgs e)
        {

        }

        private void cmb_BuyerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_BuyerType.SelectedValue!=null)
            {
                btn_Buyer.Enabled = true;
                btn_BuyerSelect.Enabled = true;
                btn_BuyerSelect.Visible = true;
                txt_Buyer.Visible = true;
            }
            else
            {
                btn_Buyer.Enabled = false;
                btn_BuyerSelect.Enabled = false;
                btn_BuyerSelect.Visible = false;
                txt_Buyer.Visible = false;
            }
        }

        private void cmb_BuyerType_TextChanged(object sender, EventArgs e)
        {
            if (cmb_BuyerType.Text.Length==0)
            {
                if (aa_Customer_Removed!=null)
                {
                    if (aa_Customer_Removed())
                    {
                        btn_Buyer.Enabled = false;
                        btn_BuyerSelect.Enabled = false;
                        btn_BuyerSelect.Visible = false;
                        txt_Buyer.Visible = false;
                        txt_Buyer.Text = "";
                    }
                }
            }
        }
    }
    
}
