using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LanguageControl;

namespace NavigationButtons
{
    public partial class usrc_NavigationButtons : UserControl
    {
        ToolTip toolTip1 = null;

        public delegate void delegate_button_pressed(Navigation.eEvent evt);
        public event delegate_button_pressed ButtonPressed;

        
        public Navigation.eButtons m_eButtons = Navigation.eButtons.OkCancel;

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

        public void Init(Navigation nav)
        {
            if (nav != null)
            {
                if (nav.ExitProgramQuestionInLanguage != null)
                {
                    ExitQuestion = nav.ExitProgramQuestionInLanguage;
                }
            }
            this.m_eButtons = nav.m_eButtons;
            btn1.Visible = nav.btn1_Visible;
            btn2.Visible = nav.btn2_Visible;
            btn3.Visible = nav.btn3_Visible;

            btn1.Text = nav.btn1_Text;
            btn1_ToolTip_Text = nav.btn1_ToolTip_Text;
            btn2.Text = nav.btn2_Text;
            btn2_ToolTip_Text = nav.btn2_ToolTip_Text;
            btn3.Text = nav.btn3_Text;
            btn3_ToolTip_Text = nav.btn3_ToolTip_Text;

            btn1.Image = nav.btn1_Image;
            btn2.Image = nav.btn2_Image;
            btn3.Image = nav.btn3_Image;


            switch (this.m_eButtons)
            {
                case Navigation.eButtons.OkCancel:
                    btn2.Visible = false;
                    btn1.Visible = true;
                    btn3.Visible = true;
                    btn1.Image = null;
                    btn3.Image = null;
                    lngRPM.s_OK.Text(btn1);
                    lngRPM.s_Cancel.Text(btn3);
                    break;

                case Navigation.eButtons.PrevNextExit:
                    btn2.Visible = true;
                    break;
            }
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
            }
        }
    }
}
