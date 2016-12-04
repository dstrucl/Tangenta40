#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

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
        internal string Name = null;
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
        public long OrganisationData_ID = -1;
        public long CustomerOrganisationData_ID = -1;

        public Form_Customer_Org_Assign()
        {
            // TODO: Complete member initialization
            InitializeComponent();
        }

        public Form_Customer_Org_Assign(long xOorganisationData_ID)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.OrganisationData_ID = xOorganisationData_ID;
            this.lbl_Instruction_part1.Text = lngRPM.s_DoYouWantCustomer.s;
            this.lbl_Instruction_part2.Text = lngRPM.s_WriteOnYourAccount.s;
            this.btn_Yes.Text = lngRPM.s_Yes.s;
            this.btn_No.Text = lngRPM.s_No.s;
            this.Text = lngRPM.s_Add_Customer_to_invoice.s;

        }

        private void Form_Customer_Assign_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string sql = @"select 
                            OrganisationData_$_org_$$Name,
                            OrganisationData_$_org_$$Tax_ID,
                            OrganisationData_$_org_$$Registration_ID,
                            OrganisationData_$_cphnnorg_$$PhoneNumber,
                            OrganisationData_$_cfaxnorg_$$FaxNumber,
                            OrganisationData_$_cadrorg_$_cstrnorg_$$StreetName,
                            OrganisationData_$_cadrorg_$_chounorg_$$HouseNumber,
                            OrganisationData_$_cadrorg_$_cziporg_$$ZIP,
                            OrganisationData_$_cadrorg_$_ccitorg_$$City,
                            OrganisationData_$_cadrorg_$_cstorg_$$State,
                            OrganisationData_$_cadrorg_$_ccouorg_$$Country,
                            OrganisationData.ID
                            from OrganisationData_VIEW where ID = " + OrganisationData_ID.ToString();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt,sql, ref Err))
            {
                if (dt.Rows.Count>0)
                {
                    this.Name = DBTypes.tf._set_string(dt.Rows[0]["OrganisationData_$_org_$$Name"]);
                    this.Tax_ID = DBTypes.tf._set_string(dt.Rows[0]["OrganisationData_$_org_$$Tax_ID"]);
                    this.Registration_ID = DBTypes.tf._set_string(dt.Rows[0]["OrganisationData_$_org_$$Registration_ID"]);
                    this.PhoneNumber = DBTypes.tf._set_string(dt.Rows[0]["OrganisationData_$_cphnnorg_$$PhoneNumber"]);
                    this.FaxNumber = DBTypes.tf._set_string(dt.Rows[0]["OrganisationData_$_cfaxnorg_$$FaxNumber"]);
                    this.StreetName = DBTypes.tf._set_string(dt.Rows[0]["OrganisationData_$_cadrorg_$_cstrnorg_$$StreetName"]);
                    this.HouseNumber = DBTypes.tf._set_string(dt.Rows[0]["OrganisationData_$_cadrorg_$_chounorg_$$HouseNumber"]);
                    this.ZIP = DBTypes.tf._set_string(dt.Rows[0]["OrganisationData_$_cadrorg_$_cziporg_$$ZIP"]);
                    this.City = DBTypes.tf._set_string(dt.Rows[0]["OrganisationData_$_cadrorg_$_ccitorg_$$City"]);
                    this.State = DBTypes.tf._set_string(dt.Rows[0]["OrganisationData_$_cadrorg_$_cstorg_$$State"]);
                    this.Country= DBTypes.tf._set_string(dt.Rows[0]["OrganisationData_$_cadrorg_$_ccouorg_$$Country"]);

                    OrganisationData_ID = (long)dt.Rows[0]["ID"];

                    lbl_Org.Text = "";
                    if (this.Name != null)
                    {
                        lbl_Org.Text += this.Name;
                    }

                    if (StreetName != null)
                    {
                        lbl_Org.Text += "\r\n" +lngRPM.s_Address.s +":"+ StreetName;
                    }
                    if (HouseNumber != null)
                    {
                        lbl_Org.Text += " " + HouseNumber;
                    }
                    if (ZIP != null)
                    {
                        lbl_Org.Text += "\r\n    " + lngRPM.s_ZIP.s + ":" + ZIP;
                    }
                    if (City != null)
                    {
                        lbl_Org.Text += "\r\n     " + lngRPM.s_City.s + ":" + City;
                    }
                    if (State != null)
                    {
                        lbl_Org.Text += "\r\n     " + lngRPM.s_State.s + ":" + State;
                    }
                    if (Country!= null)
                    {
                        lbl_Org.Text += "\r\n     " + lngRPM.s_Country.s + ":" + Country;
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
                    OrganisationData_ID = (long) dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = @"insert into customer_org (OrganisationData_ID)values(" + OrganisationData_ID.ToString()+")";

                    object oRet = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql,null,ref CustomerOrganisationData_ID, ref oRet, ref Err,"customer_org"))
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
