using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiscalVerificationOfInvoices_SLO
{
    public partial class FormWait : Form
    {

        private usrc_FVI_SLO m_usrc_FVI_SLO;
        private Thread_FVI_Message m_msg;

        /****** For DEBUG & TEST PURPOSES ***/
        usrc_DEBUG_MessagePreview m_DEBUG_MessagePreview = null;
        int iForm_Default_Height = -1;
        int iForm_Default_Width = -1;
        FormBorderStyle default_FormBorderStyle = FormBorderStyle.None;
        /****** End For DEBUG & TEST PURPOSES ***/

        public FormWait(usrc_FVI_SLO Parent, Thread_FVI_Message msg )
        {
            InitializeComponent();

           

            m_usrc_FVI_SLO = Parent;
            m_msg = msg;

            /****** For DEBUG & TEST PURPOSES ***/
            if (m_usrc_FVI_SLO.DEBUG)
            {
                default_FormBorderStyle = this.FormBorderStyle;
                iForm_Default_Height = this.Height;
                iForm_Default_Width = this.Width;
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
                m_DEBUG_MessagePreview.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                m_DEBUG_MessagePreview.PostMessage += M_DEBUG_MessagePreview_PostMessage;

            }
            
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
            m_usrc_FVI_SLO.RetFromWaitForm = m_usrc_FVI_SLO.thread_fvi.message_box.Post(m_msg);
        }

        private void TmrStart_Tick(object sender, EventArgs e)
        {
            TmrStart.Enabled = false;

            Refresh();

            PostMessage();
        }
    }
}
