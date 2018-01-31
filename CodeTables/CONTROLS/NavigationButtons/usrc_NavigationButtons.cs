using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using LanguageControl;

namespace NavigationButtons
{
    public partial class usrc_NavigationButtons : UserControl
    {
        ToolTip toolTip1 = null;
        public delegate void delegate_button_pressed(Navigation.eEvent evt);
        public event delegate_button_pressed ButtonPressed;

        public event HUDCMS.usrc_Help.delegate_HelpClicked HelpClicked = null;

        public System.Windows.Forms.Timer Timer_Next = null;

        public Navigation.eButtons m_eButtons = Navigation.eButtons.OkCancel;

        public Navigation m_nav = null;

        public Navigation.eButtons Buttons
        {
            get { return m_eButtons; }
            set { m_eButtons = value;
                  switch (m_eButtons)
                {
                    case Navigation.eButtons.OkCancel:
                        btn2.Visible = false;
                        btn1.Visible = true;
                        btn3.Visible = true;
                        break;
                    case Navigation.eButtons.PrevNextExit:
                        btn2.Visible = false;
                        btn1.Visible = true;
                        btn3.Visible = true;
                        break;

                }
            }
        }

        private string m_ExitQuestion = "Exit Program?";
        public string ExitQuestion
        { 
            get { return m_ExitQuestion; }
            set { m_ExitQuestion = value; }
         }

        private string m_btn1_ToolTip_Text = "";
        public string btn1_ToolTip_Text
        {
            get { return m_btn1_ToolTip_Text; }
            set
            {
                m_btn1_ToolTip_Text = value;
                if (m_btn1_ToolTip_Text!=null)
                {
                    if (toolTip1!=null)
                    {
                        toolTip1.SetToolTip(btn1, m_btn1_ToolTip_Text);
                    }
                }
            }
        }

        private string m_btn2_ToolTip_Text = "";
        public string btn2_ToolTip_Text
        {
            get { return m_btn2_ToolTip_Text; }
            set
            {
                m_btn2_ToolTip_Text = value;
                if (m_btn2_ToolTip_Text != null)
                {
                    if (toolTip1 != null)
                    {
                        toolTip1.SetToolTip(btn2, m_btn2_ToolTip_Text);
                    }
                }
            }
        }

        public void HidePreviousButton()
        {
            btn1.Visible = false;
        }

        private string m_btn3_ToolTip_Text = "";
        public string btn3_ToolTip_Text
        {
            get { return m_btn3_ToolTip_Text; }
            set
            {
                m_btn3_ToolTip_Text = value;
                if (m_btn3_ToolTip_Text != null)
                {
                    if (toolTip1 != null)
                    {
                        toolTip1.SetToolTip(btn3, m_btn3_ToolTip_Text);
                    }
                }
            }
        }

        public Image Image_OK
        {
            get { return btn1.Image; }
            set { btn1.Image = value; }
        }

        public Image Image_Cancel
        {
            get { return btn3.Image; }
            set { btn3.Image = value; }
        }

        public string Text_OK
        {
            get { return btn1.Text; }
            set { btn1.Text = value; }
        }

        public string Text_Cancel
        {
            get { return btn3.Text; }
            set { btn3.Text = value; }
        }

        public Image Image_PREV
        {
            get { return btn1.Image; }
            set { btn1.Image = value; }
        }
        public Image Image_NEXT
        {
            get { return btn2.Image; }
            set { btn2.Image = value; }
        }
        public Image Image_EXIT
        {
            get { return btn3.Image; }
            set { btn3.Image = value; }
        }

        public string Text_PREV
        {
            get { return btn1.Text; }
            set { btn1.Text = value; }
        }
        public string Text_NEXT
        {
            get { return btn2.Text; }
            set { btn2.Text = value; }
        }
        public string Text_EXIT
        {
            get { return btn3.Text; }
            set { btn3.Text = value; }
        }

        public bool Visible_PREV
        {
            get { return btn1.Visible; }
            set { btn1.Visible = value; }
        }
        public bool Visible_NEXT
        {
            get { return btn2.Visible; }
            set { btn2.Visible = value; }
        }
        public bool Visible_EXIT
        {
            get { return btn3.Visible; }
            set { btn3.Visible = value; }
        }

        public bool Button_NEXT_Enabled
        {
            get {return btn2.Enabled; }
            set { btn2.Enabled = value; }
        }

        public usrc_NavigationButtons()
        {
            InitializeComponent();
            Image_PREV = Properties.Resources.Prev;
            Image_NEXT = Properties.Resources.Next;
            Text_PREV = "";
            Text_NEXT = "";

            toolTip1 = new ToolTip();
            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 2000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;
            btn1.ImageAlign = ContentAlignment.MiddleLeft;
            btn2.ImageAlign = ContentAlignment.MiddleRight;
        }

        public void Init(Navigation xnav)
        {
            if (xnav != null)
            {
                m_nav = xnav;
                if (m_nav != null)
                {
                    m_nav.DialogShown = false;
                }
                if (xnav.ExitProgramQuestionInLanguage != null)
                {
                    ExitQuestion = xnav.ExitProgramQuestionInLanguage;
                }
                this.m_eButtons = xnav.m_eButtons;
                if (xnav.m_Auto_NEXT != null)
                {
                    if (this.m_eButtons == Navigation.eButtons.PrevNextExit)
                    {
                        this.Timer_Next = new System.Windows.Forms.Timer(this.components);
                        this.Timer_Next.Interval = xnav.m_Auto_NEXT.NextButtonPressedInMiliSeconds;
                        this.Timer_Next.Enabled = true;
                        this.Timer_Next.Tick += Timer_Next_Tick;
                    }
                    else
                    {
                        MessageBox.Show("AUTO_NEXT works only with (this.m_eButtons == Navigation.eButtons.PrevNextExit");
                    }
                }
                btn1.Visible = xnav.btn1_Visible;
                btn2.Visible = xnav.btn2_Visible;
                btn3.Visible = xnav.btn3_Visible;
                btn1.Text = xnav.btn1_Text;
                btn1_ToolTip_Text = xnav.btn1_ToolTip_Text;
                btn2.Text = xnav.btn2_Text;
                btn2_ToolTip_Text = xnav.btn2_ToolTip_Text;
                btn3.Text = xnav.btn3_Text;
                btn3_ToolTip_Text = xnav.btn3_ToolTip_Text;

                btn1.Image = xnav.btn1_Image;
                btn2.Image = xnav.btn2_Image;
                btn3.Image = xnav.btn3_Image;
            }
            else
            {
                this.m_eButtons = Navigation.eButtons.OkCancel;
            }




            switch (this.m_eButtons)
            {
                case Navigation.eButtons.OkCancel:
                    btn2.Visible = false;
                    btn1.Visible = true;
                    btn3.Visible = true;
                    btn1.Image = null;
                    btn3.Image = null;
                    btn1.Text = lngRPM_strings.s_OK;
                    btn3.Text = lngRPM_strings.s_Cancel;
                    break;

                case Navigation.eButtons.PrevNextExit:
                    btn2.Visible = true;
                    break;
            }
        }

        private void Timer_Next_Tick(object sender, EventArgs e)
        {
            ButtonPressed(Navigation.eEvent.NEXT);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (ButtonPressed!=null)
            {
                switch (m_eButtons)
                {
                    case Navigation.eButtons.PrevNextExit:
                        ButtonPressed(Navigation.eEvent.PREV);
                        break;
                    case Navigation.eButtons.OkCancel:
                        ButtonPressed(Navigation.eEvent.OK);
                        break;
                }
                if (m_nav != null)
                {
                    m_nav.DialogShown = true;
                }
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (ButtonPressed != null)
            {
                switch (m_eButtons)
                {
                    case Navigation.eButtons.PrevNextExit:
                        ButtonPressed(Navigation.eEvent.NEXT);
                        break;
                }
                if (m_nav != null)
                {
                    m_nav.DialogShown = true;
                }
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (ButtonPressed != null)
            {
                switch (m_eButtons)
                {
                    case Navigation.eButtons.PrevNextExit:
                        if (MessageBox.Show(this, ExitQuestion, "?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ButtonPressed(Navigation.eEvent.EXIT);
                        }
                        break;
                    case Navigation.eButtons.OkCancel:
                        ButtonPressed(Navigation.eEvent.CANCEL);
                        break;
                }
                if (m_nav != null)
                {
                    m_nav.DialogShown = true;
                }
            }
        }

        private void usrc_Help1_HelpClicked()
        {
            if (HelpClicked!=null)
            {
                HelpClicked();
            }
        }
    }
}
