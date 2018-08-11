using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginControl
{
    public partial class IdleControl : Component
    {
        internal usrc_Idle m_usrc_Idle = null;

        internal usrc_IdleSettings m_usrc_IdleSettings = null;

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

    }
}
