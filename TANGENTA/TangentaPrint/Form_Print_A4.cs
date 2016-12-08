#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using TangentaTableClass;
using DBTypes;
using TangentaDB;
using LanguageControl;
using CodeTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TangentaPrint
{
    public partial class Form_Print_A4 : Form
    {
        public bool bCompressedDocumentTemplate = false;
        public long Default_ID = -1;
        public string Default_Tamplate = null;
        public byte[] Doc = null;

        private usrc_Invoice_Preview m_usrc_Invoice_Preview = null;
        private GlobalData.ePaymentType paymentType;
        private string sPaymentMethod;
        private string sAmountReceived;
        private string sToReturn;
        private DateTime_v issue_time;
        private usrc_PrinterSettings usrc_Printer;
        private InvoiceData m_InvoiceData;
        private NavigationButtons.Navigation nav = null;

        public Form_Print_A4(InvoiceData xInvoiceData, GlobalData.ePaymentType paymentType, string sPaymentMethod, string sAmountReceived, string sToReturn, DateTime_v issue_time, NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;

            this.m_InvoiceData = xInvoiceData;
            this.paymentType = paymentType;
            this.sPaymentMethod = sPaymentMethod;
            this.sAmountReceived = sAmountReceived;
            this.sToReturn = sToReturn;
            this.issue_time = issue_time;

            lngRPM.s_Template.Text(lbl_Template, ":");
        }

        public void Init()
        {
            if (GetDefaultTemplate(ref Default_ID, ref Default_Tamplate, ref Doc, ref bCompressedDocumentTemplate))
            {
                txt_Template.Text = Default_Tamplate;
            }
        }


        // 
        // m_usrc_Invoice_Preview
        // 
        public void Create_usrc_Invoice_Preview()
        {
            if (m_usrc_Invoice_Preview!=null)
            {
                this.m_usrc_Invoice_Preview.OK -= new usrc_Invoice_Preview.delegate_OK(this.m_usrc_Invoice_Preview_OK);
                this.Controls.Remove(m_usrc_Invoice_Preview);
                m_usrc_Invoice_Preview.Dispose();
                m_usrc_Invoice_Preview = null;
            }
            m_usrc_Invoice_Preview = new usrc_Invoice_Preview();
            this.m_usrc_Invoice_Preview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_usrc_Invoice_Preview.AutoScroll = true;
            this.m_usrc_Invoice_Preview.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_usrc_Invoice_Preview.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.m_usrc_Invoice_Preview.html_doc_text = "Document Template not set";
            this.m_usrc_Invoice_Preview.Location = new System.Drawing.Point(1, 42);
            this.m_usrc_Invoice_Preview.Name = "m_usrc_Invoice_Preview";
            this.m_usrc_Invoice_Preview.Size = new System.Drawing.Size(923, 560);
            this.m_usrc_Invoice_Preview.TabIndex = 0;
            this.m_usrc_Invoice_Preview.OK += new usrc_Invoice_Preview.delegate_OK(this.m_usrc_Invoice_Preview_OK);
            this.Controls.Add(m_usrc_Invoice_Preview);

        }
        private void btn_EditTemplates_Click(object sender, EventArgs e)
        {
            SQLTable tbl_doc = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(doc)));
            Form_Templates edt_doc_dlg = new Form_Templates(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                            tbl_doc,
                                                            "doc_$$Name",nav);
            if (edt_doc_dlg.ShowDialog() == DialogResult.OK)
            {
                long id = edt_doc_dlg.ID_v.v;
                string doc_name = null;
                SetDefault(id);
                if (GetTemplate(id,ref doc_name, ref Doc, ref bCompressedDocumentTemplate))
                {
                    txt_Template.Text = doc_name;
                }
            }
        }

        private bool SetDefault(long id)
        {
            string Err = null;
            string sql = "update doc set bDefault = 0";
            object objres = null;
            if (DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con.ExecuteNonQuerySQL(sql, null, ref objres, ref Err))
            {
                sql = "update doc set bDefault = 1 where id = " + id.ToString();
                objres = null;
                if (DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con.ExecuteNonQuerySQL(sql, null, ref objres, ref Err))
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
            if (DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con.ReadDataTable(ref dt,sql,ref Err))
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
                        Create_usrc_Invoice_Preview();
                        m_usrc_Invoice_Preview.Init(xDocument, m_InvoiceData, paymentType, sPaymentMethod, sAmountReceived, sToReturn, issue_time);
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
            if (DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con.ReadDataTable(ref dt, sql, ref Err))
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
                        Create_usrc_Invoice_Preview();
                        m_usrc_Invoice_Preview.Init(xDocument, m_InvoiceData, paymentType, sPaymentMethod, sAmountReceived, sToReturn, issue_time);
                        return true;
                    }
                    return true;

                }
                else
                {
                    XMessage.Box.Show(this, lngRPM.s_YouHaveNoDocumentTemplateToPrintOnA4, "!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    Create_usrc_Invoice_Preview();
                    m_usrc_Invoice_Preview.Init(m_InvoiceData);
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
            Init();
        }

        private void m_usrc_Invoice_Preview_OK()
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }
    }
}
