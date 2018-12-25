using CodeTables;
using DBConnectionControl40;
using DBTypes;
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
    public partial class Form_Select_Person_SINGLE_USER : Form
    {
        private ID m_Office_ID;
        DataTable dt_myOrganisation_Person = new DataTable();

        private NavigationButtons.Navigation nav = null;

        private ID m_my_Org_Person_ID = null;
        private string_v mFirstName_v = null;
        private string_v mLastName_v = null;

        public Form_Select_Person_SINGLE_USER(ID xOffice_ID, NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            usrc_NavigationButtons1.Init(nav);
            m_Office_ID = xOffice_ID;
            this.Icon = Properties.Resources.Person;
            lng.s_Form_Select_Person_SINGLE_USER_Title.Text(this);
            lng.s_Form_Select_Person_SINGLE_USER_Instruction.Text(lbl_Instruction);
            lng.s_Form_Select_Person_SINGLE_USER_FirstName.Text(lbl_FirstName);
            lng.s_Form_Select_Person_SINGLE_USER_LastName.Text(lbl_LastName);
        }

        private bool Init()
        {
            if (ID.Validate(m_Office_ID))
            {
                string sql = @" SELECT 
			    myOrganisation_Person.ID, 
			    myOrganisation_Person.Job AS myOrganisation_Person_$$Job,
			    myOrganisation_Person.Active AS myOrganisation_Person_$$Active,
			    myOrganisation_Person.Description AS myOrganisation_Person_$$Description,
			    myOrganisation_Person_$_per_$_cfn.FirstName AS myOrganisation_Person_$_per_$_cfn_$$FirstName,
			    myOrganisation_Person_$_per_$_cln.LastName AS myOrganisation_Person_$_per_$_cln_$$LastName,
			    myOrganisation_Person_$_per.Tax_ID AS myOrganisation_Person_$_per_$$Tax_ID,
			    myOrganisation_Person_$_per.Registration_ID AS myOrganisation_Person_$_per_$$Registration_ID,
			    myOrganisation_Person_$_office.Name AS myOrganisation_Person_$_office_$$Name,
			    myOrganisation_Person_$_office.ShortName AS myOrganisation_Person_$_office_$$ShortName
			    FROM myOrganisation_Person 
			    INNER JOIN Person myOrganisation_Person_$_per ON myOrganisation_Person.Person_ID = myOrganisation_Person_$_per.ID 
			    INNER JOIN cFirstName myOrganisation_Person_$_per_$_cfn ON myOrganisation_Person_$_per.cFirstName_ID = myOrganisation_Person_$_per_$_cfn.ID 
			    LEFT JOIN cLastName myOrganisation_Person_$_per_$_cln ON myOrganisation_Person_$_per.cLastName_ID = myOrganisation_Person_$_per_$_cln.ID 
			    INNER JOIN Office myOrganisation_Person_$_office ON myOrganisation_Person.Office_ID = myOrganisation_Person_$_office.ID where myOrganisation_Person.Office_ID = " + m_Office_ID.ToString();
                dt_myOrganisation_Person.Columns.Clear();
                string Err = null;
                dgvx_my_Org_Person.DataSource = null;
                if (DBSync.DBSync.ReadDataTable(ref dt_myOrganisation_Person,sql,ref Err))
                {
                    dgvx_my_Org_Person.DataSource = dt_myOrganisation_Person;
                    DBSync.DBSync.DB_for_Tangenta.t_myOrganisation_Person.SetVIEW_DataGridViewImageColumns_Headers(dgvx_my_Org_Person, DBSync.DBSync.DB_for_Tangenta.m_DBTables);
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:Tangenta:Form_Select_Person_SINGLE_USER:Init:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Tangenta:Form_Select_Person_SINGLE_USER:Init:m_Office_ID is not valid!");
                return false;
            }
        }

        private void Form_Select_Person_SINGLE_USER_Load(object sender, EventArgs e)
        {
            if (!Init())
            {
                this.Close();
                DialogResult = DialogResult.Abort;
            }
        }


        private void usrc_NavigationButtons1_ButtonPressed(NavigationButtons.Navigation.eEvent evt)
        {
            switch (nav.m_eButtons)
            {
                case NavigationButtons.Navigation.eButtons.OkCancel:
                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.OK:
                            nav.eExitResult = evt;
                            if (!do_OK())
                            {
                                nav.eExitResult = NavigationButtons.Navigation.eEvent.NOTHING;
                            }
                            break;
                        case NavigationButtons.Navigation.eEvent.CANCEL:
                            nav.eExitResult = evt;
                            do_Cancel();
                            break;
                    }
                    break;
                case NavigationButtons.Navigation.eButtons.PrevNextExit:
                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.NEXT:
                            nav.eExitResult = evt;
                            if (!do_OK())
                            {
                                nav.eExitResult = NavigationButtons.Navigation.eEvent.NOTHING;
                            }
                            break;
                        case NavigationButtons.Navigation.eEvent.PREV:
                            nav.eExitResult = evt;
                            do_Cancel();
                            break;
                        case NavigationButtons.Navigation.eEvent.EXIT:
                            nav.eExitResult = evt;
                            do_Cancel();
                            break;
                    }
                    break;

            }
        }

        private bool Find_myOrg_Person_SingleUser(ID xm_my_Org_Person_ID)
        {
            if (TangentaDB.myOrg.m_myOrg_Office != null)
            {
                if (TangentaDB.myOrg.m_myOrg_Office.Find_myOrg_Person_SingleUser(xm_my_Org_Person_ID))
                {

                    return true;
                }
            }
            return false;
        }


        private bool do_OK()
        {
            if (Find_myOrg_Person_SingleUser(m_my_Org_Person_ID))
            {
                ID myOrganisation_Person_SingleUser_ID = null;
                Transaction transaction_Form_Select_Person_SINGLE_USER_do_OK = new Transaction("Form_Select_Person_SINGLE_USER_do_OK", DBSync.DBSync.MyTransactionLog_delegates);
                if (TangentaDB.f_myOrganisation_Person_SingleUser.Get(m_Office_ID, m_my_Org_Person_ID, ref myOrganisation_Person_SingleUser_ID, transaction_Form_Select_Person_SINGLE_USER_do_OK))
                {
                    if (transaction_Form_Select_Person_SINGLE_USER_do_OK.Commit())
                    {
                        Close();
                        DialogResult = DialogResult.OK;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    transaction_Form_Select_Person_SINGLE_USER_do_OK.Rollback();
                    return false;
                }
            }
            else
            {
                XMessage.Box.Show(this, lng.s_my_organisation_person_for_single_user_operation_is_not_selected, lng.s_Warning.s, MessageBoxButtons.YesNo, Properties.Resources.Tangenta_Question, MessageBoxDefaultButton.Button1);
                return false;
            }
        }

        private void do_Cancel()
        {
            Close();
            DialogResult = DialogResult.OK;    
        }



        private void dgvx_my_Org_Person_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection dgvCellCollection = this.dgvx_my_Org_Person.SelectedCells;
            if (dgvCellCollection.Count >= 1)
            {
                m_my_Org_Person_ID = tf.set_ID(dgvCellCollection[0].OwningRow.Cells["ID"].Value);

                mFirstName_v = tf.set_string(dgvCellCollection[0].OwningRow.Cells["myOrganisation_Person_$_per_$_cfn_$$FirstName"].Value);
                mLastName_v = tf.set_string(dgvCellCollection[0].OwningRow.Cells["myOrganisation_Person_$_per_$_cln_$$LastName"].Value);
                Showmy_myOrg_Person();
            }
        }

        private void Showmy_myOrg_Person()
        {
            if (ID.Validate(m_my_Org_Person_ID))
            {
                if (mFirstName_v != null)
                {
                    this.txt_FirstName.Text = mFirstName_v.v;
                }
                else
                {
                    this.txt_FirstName.Text = "";
                }
                if (mLastName_v != null)
                {
                    this.txt_LastName.Text = mLastName_v.v;
                }
                else
                {
                    this.txt_LastName.Text = "";
                }
            }
        }
    }
}
