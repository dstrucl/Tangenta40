using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginControl
{
    public partial class IdleControl : Component
    {
        public enum eShow { URL1,URL2};
        internal usrc_Idle m_usrc_Idle = null;

        internal usrc_MultipleUsers m_usrc_MultipleUsers = null;

        private Form parentform = null;


        public delegate void delegate_IdleControlActivated();
        public event delegate_IdleControlActivated IdleControlActivated = null;

        public delegate void delegate_TimerCountDown(int countdown);
        public event delegate_TimerCountDown TimerCountDown = null;

        private Image m_ImageUrl1 = null;

        public Image ImageUrl1
        {
            get
            {
                return m_ImageUrl1;
            }
            set
            {
                m_ImageUrl1 = value;
            }
        }

        private Image m_ImageUrl2 = null;

        public Image ImageUrl2
        {
            get
            {
                return m_ImageUrl2;
            }
            set
            {
                m_ImageUrl2 = value;
            }
        }

        private bool m_Active = false;
        public bool Active {
            get
            {
                return m_Active;
            }
            
            set
            {
                m_Active = value;
            }        
        }

        private int timeoutCounter = 0;

        private int m_TimeInSecondsToActivate = 20;
        public int TimeInSecondsToActivate
        {
            get
            {
                return m_TimeInSecondsToActivate;
            }
            set
            {
                m_TimeInSecondsToActivate = value;
            }
        }

        private bool m_UseExitButton = true;
        public bool UseExitButton 
                {
                get
                    {
                        return m_UseExitButton;
                    }
                set
                    {
                        m_UseExitButton = value;
                    }
                }

        private bool m_ShowURL2 = false;

        public bool ShowURL2 {
            get {
                return m_ShowURL2;
                }
            set
            {
                m_ShowURL2 = value;
            }
        }

        private string m_URL1 = null;

        public string URL1
        {
            get
            {
                return m_URL1;
            }
            set
            {
                m_URL1 = value; 
            }
        }

        private string m_URL2 = null;

        public string URL2
        {
            get
            {
                return m_URL2;
            }
            set
            {
                m_URL2 = value;
            }
        }



        public IdleControl()
        {
            InitializeComponent();
        }

        public IdleControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


        private void timer_counter_Tick(object sender, EventArgs e)
        {
            if (timeoutCounter>0)
            {
                if (m_usrc_MultipleUsers!=null)
                {
                    m_usrc_MultipleUsers.IdleControlTimerCountDown(timeoutCounter);
                }
                if (TimerCountDown!=null)
                {
                    TimerCountDown(timeoutCounter);
                }
                timeoutCounter--;
            }
            else
            {
                Show(eShow.URL1);
                if (IdleControlActivated!=null)
                {
                    IdleControlActivated();
                }
                TimerCounter_Stop();
            }
        }

        public void Show(eShow xShow)
        {

            if (parentform == null)
            {
                if (m_usrc_MultipleUsers != null)
                {
                    parentform = Global.f.GetParentForm(m_usrc_MultipleUsers);
                    if (parentform != null)
                    {
                        if (m_usrc_Idle == null)
                        {
                            m_usrc_Idle = new usrc_Idle();
                            m_usrc_Idle.m_IdleCtrl = this;
                            m_usrc_Idle.m_usrc_MultipleUsers = this.m_usrc_MultipleUsers;
                            m_usrc_Idle.Dock = DockStyle.Fill;
                            m_usrc_Idle.Visible = false;
                            m_usrc_Idle.BackColor = m_usrc_MultipleUsers.BackColor;
                            parentform.Controls.Add(m_usrc_Idle);
                        }
                    }
                }
            }

            if (m_usrc_Idle != null)
            {
                m_usrc_MultipleUsers.Visible = false;
                m_usrc_Idle.Visible = true;
                m_usrc_Idle.Show(xShow);
            }
            
        }

        internal void TimerCounter_Start()
        {

            timeoutCounter = TimeInSecondsToActivate;
            timer_counter.Enabled = true;
        }

        internal void TimerCounter_Stop()
        {
            timeoutCounter = -1;
            timer_counter.Enabled = false;
        }
    }
}
