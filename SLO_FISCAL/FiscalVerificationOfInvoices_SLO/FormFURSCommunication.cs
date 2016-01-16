using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MNet.SLOTaxService.Messages;

namespace FiscalVerificationOfInvoices_SLO
{
    public partial class FormFURSCommunication : Form
    {

        public Result_MessageBox_Post RetFromWaitForm = Result_MessageBox_Post.TIMEOUT;


        private usrc_FVI_SLO m_usrc_FVI_SLO;
        private Thread_FVI_Message m_msg;

        usrc_Error_Response m_usrc_Error_Response = null;

        /****** For DEBUG & TEST PURPOSES ***/
        usrc_DEBUG_MessagePreview m_DEBUG_MessagePreview = null;
        int iForm_Default_Height = -1;
        int iForm_Default_Width = -1;
        FormBorderStyle default_FormBorderStyle = FormBorderStyle.None;
        /****** End For DEBUG & TEST PURPOSES ***/

        public FormFURSCommunication(usrc_FVI_SLO Parent, Thread_FVI_Message msg)
        {
            InitializeComponent();



            m_usrc_FVI_SLO = Parent;
            m_msg = msg;

            iForm_Default_Height = this.Height;
            iForm_Default_Width = this.Width;

            /****** For DEBUG & TEST PURPOSES ***/
            if (m_usrc_FVI_SLO.DEBUG)
            {
                default_FormBorderStyle = this.FormBorderStyle;
                Show_usrc_DEBUG_MessagePreview();
            }
            /****** End For DEBUG & TEST PURPOSES ***/


            //  this.Location = m_parent.ParentForm.Location;
            //   Point p = new Point(m_parent.ParentForm.Width / 2 - this.Width / 2, m_parent.ParentForm.Height / 2 - this.Height / 2);
            //    this.Location = p;

        }


        /****** For DEBUG & TEST PURPOSES ***/
        private void Show_usrc_DEBUG_MessagePreview()
        {
            if (m_DEBUG_MessagePreview != null)
            {
                this.Controls.Remove(m_DEBUG_MessagePreview);
                m_DEBUG_MessagePreview.Dispose();
                m_DEBUG_MessagePreview = null;
            }

            if (m_DEBUG_MessagePreview == null)
            {
                m_DEBUG_MessagePreview = new usrc_DEBUG_MessagePreview(m_msg);
                this.Controls.Add(m_DEBUG_MessagePreview);
                this.Height = iForm_Default_Height + m_DEBUG_MessagePreview.Height + 10;
                if (this.Width < m_DEBUG_MessagePreview.Width + 10)
                {
                    this.Width = m_DEBUG_MessagePreview.Width + 10;
                }
                m_DEBUG_MessagePreview.Top = iForm_Default_Height;
                m_DEBUG_MessagePreview.Left = 5;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                m_DEBUG_MessagePreview.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                m_DEBUG_MessagePreview.PostMessage += M_DEBUG_MessagePreview_PostMessage;
                m_DEBUG_MessagePreview.End += M_DEBUG_MessagePreview_End;

            }

        }

        private void M_DEBUG_MessagePreview_End()
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void M_DEBUG_MessagePreview_PostMessage()
        {
            PostMessage();
        }

        /****** End For DEBUG & TEST PURPOSES ***/




        private void FormWait_Load(object sender, EventArgs e)
        {
            if (m_usrc_FVI_SLO.DEBUG)
            {
                /* PostMessage(); will be done whe you click on button [PostMessage --> Thread_FVI_Message] 
                   which isa button  in  M_DEBUG_MessagePreview usercontrol (file:usrc_DEBUG_MessagePreview.cs)
                   When you click this button it triggers M_DEBUG_MessagePreview_PostMessage event on this form!
                */
            }
            else
            {
                /* PostMessage(); will be done in TmrStart_Tick */
                TmrStart.Enabled = true;
            }
        }

        private void FormWait_Shown(object sender, EventArgs e)
        {

        }

        private void PostMessage()
        {
            RetFromWaitForm = m_usrc_FVI_SLO.thread_fvi.message_box.Post(m_msg);
        }

        private void TmrStart_Tick(object sender, EventArgs e)
        {
            TmrStart.Enabled = false;

            Refresh();

            PostMessage();
        }


        internal bool FVI_Response_Single_Invoice(long message_ID, string xML_Data, bool success, MessageType messageType, string errorMessage, string protectedID, string uniqueInvoiceID, Image image_QRCode)
        {
            if (success)
            {

            }
            else
            {
                this.m_usrc_Error_Response = new usrc_Error_Response(messageType, errorMessage);
                this.Controls.Add(m_usrc_Error_Response);

                if (m_DEBUG_MessagePreview!= null)
                {
                    m_usrc_Error_Response.Top = m_DEBUG_MessagePreview.Top;
                    m_DEBUG_MessagePreview.Top = m_usrc_Error_Response.Top + m_usrc_Error_Response.Height + 10;
                    this.Height = m_DEBUG_MessagePreview.Top + m_DEBUG_MessagePreview.Height + 10;
                }
                else
                {
                    m_usrc_Error_Response.Top = this.Height;
                    this.Height = m_usrc_Error_Response.Top + m_usrc_Error_Response.Height + 10;
                }
                if (this.Width < m_usrc_Error_Response.Width + 10)
                {
                    this.Width = m_usrc_Error_Response.Width + 10;
                }

                m_usrc_Error_Response.Left = 5;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                m_usrc_Error_Response.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            }
            return true;
        }
    }
}
