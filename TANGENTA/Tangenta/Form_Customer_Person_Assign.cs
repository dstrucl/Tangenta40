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
    public partial class Form_Customer_Person_Assign : Form
    {
        internal ID PersonData_ID = null;
        internal string FirstName = null;
        internal string LastName = null;
        internal string GsmNumber = null;
        internal string PhoneNumber = null;
        internal string StreetName = null;
        internal string HouseNumber = null;
        internal string ZIP = null;
        internal string City = null;
        internal string State = null;
        internal string Country= null;
        internal DateTime DateOfBirth = DateTime.MinValue;
        public ID Person_ID = null;
        public ID CustomerPerson_ID = null;

        public Form_Customer_Person_Assign()
        {
            // TODO: Complete member initialization
            InitializeComponent();
        }

        public Form_Customer_Person_Assign(ID xPersonData_ID)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.PersonData_ID = xPersonData_ID;
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
                            PersonData_$_per_$_cfn_$$FirstName,
                            PersonData_$_per_$_cln_$$LastName,
                            PersonData_$_cgsmnper_$$GsmNumber,
                            PersonData_$_cphnnper_$$PhoneNumber,
                            PersonData_$_cadrper_$_cstrnper_$$StreetName,
                            PersonData_$_cadrper_$_chounper_$$HouseNumber,
                            PersonData_$_cadrper_$_zipper_$$ZIP,
                            PersonData_$_cadrper_$_ccitper_$$City,
                            PersonData_$_cadrper_$_ccouper_$$State,
                            PersonData_$_cadrper_$_cstper_$$Country,
                            PersonData_$_per_$$DateOfBirth,
                            PersonData_$_per_$$ID
                            from PersonData_VIEW where ID = " + PersonData_ID.ToString();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt,sql, ref Err))
            {
                if (dt.Rows.Count>0)
                {
                    if (dt.Rows[0]["PersonData_$_per_$_cfn_$$FirstName"] is string)
                    {
                        FirstName = (string)dt.Rows[0]["PersonData_$_per_$_cfn_$$FirstName"];
                    }
                    if (dt.Rows[0]["PersonData_$_per_$_cln_$$LastName"] is string)
                    {
                        LastName = (string)dt.Rows[0]["PersonData_$_per_$_cln_$$LastName"];
                    }
                    if (dt.Rows[0]["PersonData_$_cgsmnper_$$GsmNumber"] is string)
                    {
                        GsmNumber = (string)dt.Rows[0]["PersonData_$_cgsmnper_$$GsmNumber"];
                    }
                    if (dt.Rows[0]["PersonData_$_cphnnper_$$PhoneNumber"] is string)
                    {
                        PhoneNumber = (string)dt.Rows[0]["PersonData_$_cphnnper_$$PhoneNumber"];
                    }
                    if (dt.Rows[0]["PersonData_$_cadrper_$_cstrnper_$$StreetName"] is string)
                    {
                        StreetName = (string)dt.Rows[0]["PersonData_$_cadrper_$_cstrnper_$$StreetName"];
                    }
                    if (dt.Rows[0]["PersonData_$_cadrper_$_chounper_$$HouseNumber"] is string)
                    {
                        HouseNumber = (string)dt.Rows[0]["PersonData_$_cadrper_$_chounper_$$HouseNumber"];
                    }
                    if (dt.Rows[0]["PersonData_$_cadrper_$_zipper_$$ZIP"] is string)
                    {
                        ZIP = (string)dt.Rows[0]["PersonData_$_cadrper_$_zipper_$$ZIP"];
                    }
                    if (dt.Rows[0]["PersonData_$_cadrper_$_ccitper_$$City"] is string)
                    {
                        City = (string)dt.Rows[0]["PersonData_$_cadrper_$_ccitper_$$City"];
                    }
                    if (dt.Rows[0]["PersonData_$_cadrper_$_ccouper_$$State"] is string)
                    {
                        State = (string)dt.Rows[0]["PersonData_$_cadrper_$_ccouper_$$State"];
                    }
                    if (dt.Rows[0]["PersonData_$_cadrper_$_cstper_$$Country"] is string)
                    {
                        Country= (string)dt.Rows[0]["PersonData_$_cadrper_$_cstper_$$Country"];
                    }
                    if (dt.Rows[0]["PersonData_$_per_$$DateOfBirth"] is DateTime)
                    {
                        DateOfBirth = (DateTime)dt.Rows[0]["PersonData_$_per_$$DateOfBirth"];
                    }

                    Person_ID = tf.set_ID(dt.Rows[0]["PersonData_$_per_$$ID"]);

                    lbl_Person.Text = "";
                    if (FirstName!=null)
                    {
                        lbl_Person.Text += FirstName;
                    }
                    if (LastName != null)
                    {
                        if (lbl_Person.Text.Length>0)
                        { 
                            lbl_Person.Text += " " +LastName;
                        }
                        else
                        {
                            lbl_Person.Text += LastName;
                        }
                    }

                    if (GsmNumber != null)
                    {
                        lbl_Person.Text += "\r\nGSM:" + GsmNumber;
                    }
                    if (PhoneNumber != null)
                    {
                        lbl_Person.Text += "\r\nTEL:" + PhoneNumber;
                    }
                    if (DateOfBirth > DateTime.MinValue)
                    {
                        lbl_Person.Text += "\r\n"+lng.s_DateOfBirth.s+":" + DateOfBirth.Day.ToString() + "." + DateOfBirth.Month.ToString() + "." + DateOfBirth.Year.ToString();
                    }

                    if (StreetName != null)
                    {
                        lbl_Person.Text += "\r\n" +lng.s_Address.s +":"+ StreetName;
                    }
                    if (HouseNumber != null)
                    {
                        lbl_Person.Text += " " + HouseNumber;
                    }
                    if (ZIP != null)
                    {
                        lbl_Person.Text += "\r\n    " + lng.s_ZIP.s + ":" + ZIP;
                    }
                    if (City != null)
                    {
                        lbl_Person.Text += "\r\n     " + lng.s_City.s + ":" + City;
                    }
                    if (State != null)
                    {
                        lbl_Person.Text += "\r\n     " + lng.s_State.s + ":" + State;
                    }
                    if (Country!= null)
                    {
                        lbl_Person.Text += "\r\n     " + lng.s_Country.s + ":" + Country;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Form_Customer_Assign:Form_Customer_Assign_Load:Sql=" + sql + "\r\nErr=" + Err);
                this.Close();
                DialogResult = DialogResult.Abort;
            }

        }

        public bool GetCustomerPerson(Transaction transaction)
        {
            DataTable dt = new DataTable();
            string sql = @"select ID from customer_person where Person_ID = "+Person_ID.ToString();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt,sql, ref Err))
            {
                if (dt.Rows.Count>0)
                {
                    CustomerPerson_ID = tf.set_ID(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into customer_person (Person_ID)values("+Person_ID.ToString()+")";

                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql,null,ref CustomerPerson_ID, ref Err,"customer_person"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:Form_Customer_Assign:GetCustomerPerson:Sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Form_Customer_Assign:GetCustomerPerson:Sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private void btn_Yes_Click(object sender, EventArgs e)
        {
            Transaction transaction_Form_Customer_Person_Assign_GetCustomerPerson = DBSync.DBSync.NewTransaction("Form_Customer_Person_Assign.GetCustomerPerson");
            if (GetCustomerPerson(transaction_Form_Customer_Person_Assign_GetCustomerPerson))
            {
                transaction_Form_Customer_Person_Assign_GetCustomerPerson.Commit();
                Close();
                DialogResult = DialogResult.Yes;
            }
            else
            {
                transaction_Form_Customer_Person_Assign_GetCustomerPerson.Rollback();
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
