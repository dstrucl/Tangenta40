using BlagajnaTableClass;
using DBTypes;
using LanguageControl;
using SQLTableControl;
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
    public partial class Form_Print_A4 : Form
    {
        public bool bCompressedDocumentTemplate = false;
        public long Default_ID = -1;
        public string Default_Tamplate = null;
        public byte[] Doc = null;

        private usrc_Print usrc_Print;
        private usrc_Payment.ePaymentType paymentType;
        private string sPaymentMethod;
        private string sAmountReceived;
        private string sToReturn;
        private DateTime_v issue_time;


        public Form_Print_A4(usrc_Print usrc_Print, usrc_Payment.ePaymentType paymentType, string sPaymentMethod, string sAmountReceived, string sToReturn, DateTime_v issue_time)
        {
            InitializeComponent();

            this.usrc_Print = usrc_Print;
            this.paymentType = paymentType;
            this.sPaymentMethod = sPaymentMethod;
            this.sAmountReceived = sAmountReceived;
            this.sToReturn = sToReturn;
            this.issue_time = issue_time;

            lngRPM.s_Template.Text(lbl_Template, ":");
        }


        private void btn_EditTemplates_Click(object sender, EventArgs e)
        {
            SQLTable tbl_doc = new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(doc)));
            Form_Templates edt_doc_dlg = new Form_Templates(DBSync.DBSync.DB_for_Blagajna.m_DBTables,
                                                            tbl_doc,
                                                            "doc_$$Name");
            if (edt_doc_dlg.ShowDialog() == DialogResult.OK)
            {
                long id = edt_doc_dlg.ID_v.v;
                string doc_name = null;
                if (GetTemplate(id,ref doc_name, ref Doc, ref bCompressedDocumentTemplate))
                {
                    txt_Template.Text = doc_name;
                    SetDefault(id);
                }
               
            }

        }

        private bool SetDefault(long id)
        {
            string Err = null;
            string sql = "update doc set bDefault = 0";
            object objres = null;
            if (DBSync.DBSync.DB_for_Blagajna.m_DBTables.m_con.ExecuteNonQuerySQL(sql, null, ref objres, ref Err))
            {
                sql = "update doc set bDefault = 1 where id = " + id.ToString();
                objres = null;
                if (DBSync.DBSync.DB_for_Blagajna.m_DBTables.m_con.ExecuteNonQuerySQL(sql, null, ref objres, ref Err))
                {
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:Form_Print_A4:SetDefault:sql=" + sql + "\r\nErr" + Err);
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Form_Print_A4:SetDefault:sql=" + sql + "\r\nErr" + Err);
            }
            return false;
        }


        private bool GetTemplate(long id, ref string doc_Name,ref byte[] xDocument, ref bool bCommpressed)
        {
            bool Commpressed = false;
            string Err = null;
            string sql = "select doc_$$Name,doc_$$xDocument,doc_$$Compressed from doc_VIEW where ID = " + id.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.DB_for_Blagajna.m_DBTables.m_con.ReadDataTable(ref dt,sql,ref Err))
            {
                if (dt.Rows.Count>0)
                {
                    object o_doc_name = dt.Rows[0]["doc_$$Name"];
                    if (o_doc_name is string)
                    {
                        doc_Name =(string)o_doc_name;
                    }
                    object o_Compressed = dt.Rows[0]["doc_$$Compressed"];
                    if (o_Compressed is bool)
                    {
                        Commpressed = (bool)o_Compressed;
                        bCommpressed = Commpressed;
                    }

                    object o_doc = dt.Rows[0]["doc_$$xDocument"];
                    if (o_doc is byte[])
                    {
                        if (Commpressed)
                        {
                            xDocument = fs.Decompress((byte[])((byte[])o_doc).Clone());
                        }
                        else
                        {
                            xDocument = (byte[])((byte[])o_doc).Clone();
                        }

        //private usrc_Print usrc_Print;
        //private usrc_Payment.ePaymentType paymentType;
        //private string sPaymentMethod;
        //private string sAmountReceived;
        //private string sToReturn;
        //private DateTime_v issue_time;
                        m_usrc_Invoice_Preview.Init(xDocument, usrc_Print, paymentType, sPaymentMethod, sAmountReceived, sToReturn, issue_time);
                        return true;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Form_Print_A4:GetTemplateName:sql=" + sql + "\r\nErr" + Err);
            }
            doc_Name = "";
            return false;
        }

        private void btn_Select_Template_Click(object sender, EventArgs e)
        {

        }

        private bool GetDefaultTemplate(ref long id,ref string doc_Name, ref byte[] xDocument, ref bool bCommpressed)
        {
            string Err = null;
            bool Commpressed = false;
            string sql = "select id,doc_$$Name,doc_$$xDocument,doc_$$Compressed from doc_VIEW where doc_$$bDefault = 1";
            DataTable dt = new DataTable();
            if (DBSync.DBSync.DB_for_Blagajna.m_DBTables.m_con.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    object o_doc_name = dt.Rows[0]["doc_$$Name"];
                    if (o_doc_name is string)
                    {
                        doc_Name = (string)o_doc_name;
                    }
                    object o_id = dt.Rows[0]["id"];
                    if (o_id is long)
                    {
                        id = (long)o_id;
                    }
                    object o_Compressed = dt.Rows[0]["doc_$$Compressed"];
                    if (o_Compressed is bool)
                    {
                        Commpressed = (bool)o_Compressed;
                        bCommpressed = Commpressed;
                    }
                    object o_doc = dt.Rows[0]["doc_$$xDocument"];
                    if (o_doc is byte[])
                    {
                        if (Commpressed)
                        {
                            xDocument = fs.Decompress((byte[])((byte[])o_doc).Clone());
                        }
                        else
                        {
                            xDocument = (byte[])((byte[])o_doc).Clone();
                        }
                        m_usrc_Invoice_Preview.Init(xDocument, usrc_Print, paymentType, sPaymentMethod, sAmountReceived, sToReturn, issue_time);
                        return true;
                    }
                    return true;

                }
            }
            else
            {
              LogFile.Error.Show("ERROR:Form_Print_A4:GetTemplateName:sql=" + sql + "\r\nErr" + Err);
            }
            doc_Name = "";
            return false;
        }

        private void Form_Print_A4_Load(object sender, EventArgs e)
        {
            if (GetDefaultTemplate(ref Default_ID,ref Default_Tamplate,ref Doc, ref bCompressedDocumentTemplate))
            {
                txt_Template.Text = Default_Tamplate;
            }
        }
    }
}
