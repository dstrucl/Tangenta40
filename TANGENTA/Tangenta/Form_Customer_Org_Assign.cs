#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using DBConnectionControl40;
using DBTypes;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tangenta
{
    public partial class Form_Customer_Org_Assign : Form
    {
        internal string Customer_Name = null;
        internal string Tax_ID = null;
        internal string Registration_ID = null;
        internal string PhoneNumber = null;
        internal string FaxNumber = null;
        internal string StreetName = null;
        internal string HouseNumber = null;
        internal string ZIP = null;
        internal string City = null;
        internal string State = null;
        internal string Country= null;
        public ID OrganisationData_ID = null;
        public ID CustomerOrganisationData_ID = null;

        public Form_Customer_Org_Assign()
        {
            // TODO: Complete member initialization
            InitializeComponent();
        }

        public Form_Customer_Org_Assign(ID xCustomer_OrganisationData_ID)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.CustomerOrganisationData_ID = xCustomer_OrganisationData_ID;
            this.lbl_Instruction_part1.Text = lng.s_DoYouWantCustomer.s;
            this.lbl_Instruction_part2.Text = lng.s_WriteOnYourAccount.s;
            this.btn_Yes.Text = lng.s_Yes.s;
            this.btn_No.Text = lng.s_No.s;
            this.Text = lng.s_Add_Customer_to_invoice.s;

        }

        private void Form_Customer_Assign_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string sql = @"select 
                            Customer_Org_$_orgd_$_org_$$Name,
                            Customer_Org_$_orgd_$_org_$$Tax_ID,
                            Customer_Org_$_orgd_$_org_$$Registration_ID,
                            Customer_Org_$_orgd_$_cphnnorg_$$PhoneNumber,
                            Customer_Org_$_orgd_$_cfaxnorg_$$FaxNumber,
                            Customer_Org_$_orgd_$_cadrorg_$_cstrnorg_$$StreetName,
                            Customer_Org_$_orgd_$_cadrorg_$_chounorg_$$HouseNumber,
                            Customer_Org_$_orgd_$_cadrorg_$_cziporg_$$ZIP,
                            Customer_Org_$_orgd_$_cadrorg_$_ccitorg_$$City,
                            Customer_Org_$_orgd_$_cadrorg_$_cstorg_$$State,
                            Customer_Org_$_orgd_$_cadrorg_$_ccouorg_$$Country,
                            Customer_Org_$_orgd_$$ID,
                            ID
                            from Customer_Org_VIEW where ID = " + CustomerOrganisationData_ID.ToString();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt,sql, ref Err))
            {
                if (dt.Rows.Count>0)
                {
                    this.Customer_Name = DBTypes.tf._set_string(dt.Rows[0]["Customer_Org_$_orgd_$_org_$$Name"]);
                    this.Tax_ID = DBTypes.tf._set_string(dt.Rows[0]["Customer_Org_$_orgd_$_org_$$Tax_ID"]);
                    this.Registration_ID = DBTypes.tf._set_string(dt.Rows[0]["Customer_Org_$_orgd_$_org_$$Registration_ID"]);
                    this.PhoneNumber = DBTypes.tf._set_string(dt.Rows[0]["Customer_Org_$_orgd_$_cphnnorg_$$PhoneNumber"]);
                    this.FaxNumber = DBTypes.tf._set_string(dt.Rows[0]["Customer_Org_$_orgd_$_cfaxnorg_$$FaxNumber"]);
                    this.StreetName = DBTypes.tf._set_string(dt.Rows[0]["Customer_Org_$_orgd_$_cadrorg_$_cstrnorg_$$StreetName"]);
                    this.HouseNumber = DBTypes.tf._set_string(dt.Rows[0]["Customer_Org_$_orgd_$_cadrorg_$_chounorg_$$HouseNumber"]);
                    this.ZIP = DBTypes.tf._set_string(dt.Rows[0]["Customer_Org_$_orgd_$_cadrorg_$_cziporg_$$ZIP"]);
                    this.City = DBTypes.tf._set_string(dt.Rows[0]["Customer_Org_$_orgd_$_cadrorg_$_ccitorg_$$City"]);
                    this.State = DBTypes.tf._set_string(dt.Rows[0]["Customer_Org_$_orgd_$_cadrorg_$_cstorg_$$State"]);
                    this.Country= DBTypes.tf._set_string(dt.Rows[0]["Customer_Org_$_orgd_$_cadrorg_$_ccouorg_$$Country"]);

                    OrganisationData_ID = tf.set_ID(dt.Rows[0]["Customer_Org_$_orgd_$$ID"]);

                    lbl_Org.Text = "";
                    if (this.Customer_Name != null)
                    {
                        lbl_Org.Text += this.Customer_Name;
                    }

                    if (StreetName != null)
                    {
                        lbl_Org.Text += "\r\n" +lng.s_Address.s +":"+ StreetName;
                    }
                    if (HouseNumber != null)
                    {
                        lbl_Org.Text += " " + HouseNumber;
                    }
                    if (ZIP != null)
                    {
                        lbl_Org.Text += "\r\n    " + lng.s_ZIP.s + ":" + ZIP;
                    }
                    if (City != null)
                    {
                        lbl_Org.Text += "\r\n     " + lng.s_City.s + ":" + City;
                    }
                    if (State != null)
                    {
                        lbl_Org.Text += "\r\n     " + lng.s_State.s + ":" + State;
                    }
                    if (Country!= null)
                    {
                        lbl_Org.Text += "\r\n     " + lng.s_Country.s + ":" + Country;
                    }
                    if (FaxNumber != null)
                    {
                        lbl_Org.Text += "\r\nFax:" + FaxNumber;
                    }
                    if (PhoneNumber != null)
                    {
                        lbl_Org.Text += "\r\nTEL:" + PhoneNumber;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Form_Customer_Org_Assign:Form_Customer_Assign_Load:Sql=" + sql + "\r\nErr=" + Err);
                this.Close();
                DialogResult = DialogResult.Abort;
            }

        }

        public bool GetCustomerOrganisation()
        {
            DataTable dt = new DataTable();
            string sql = @"select ID from customer_org where OrganisationData_ID = "+ OrganisationData_ID.ToString();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt,sql, ref Err))
            {
                if (dt.Rows.Count>0)
                {
                    OrganisationData_ID = tf.set_ID(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into customer_org (OrganisationData_ID)values(" + OrganisationData_ID.ToString()+")";

                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql,null,ref CustomerOrganisationData_ID,  ref Err,"customer_org"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:Form_Customer_Org_Assign:GetCustomerPerson:Sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Form_Customer_Org_Assign:GetCustomerPerson:Sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private void btn_Yes_Click(object sender, EventArgs e)
        {
            if (GetCustomerOrganisation())
            {
                Close();
                DialogResult = DialogResult.Yes;
            }
            else
            {
                Close();
                DialogResult = DialogResult.Abort;
            }
        }

        private void btn_No_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.No;
        }

    }
}
