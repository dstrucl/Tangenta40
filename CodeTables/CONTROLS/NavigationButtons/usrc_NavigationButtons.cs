using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavigationButtons
{
    public partial class usrc_NavigationButtons : UserControl
    {
        public delegate void delegate_button_pressed(NavigationButtons.eEvent evt);
        public event delegate_button_pressed ButtonPressed;

        public NavigationButtons.eButtons m_eButtons = NavigationButtons.eButtons.OkCancel;

        public NavigationButtons.eButtons Buttons
        {
            get { return m_eButtons; }
            set { m_eButtons = value;
                  switch (m_eButtons)
                {
                    case NavigationButtons.eButtons.OkCancel:
                        btn2.Visible = false;
                        btn1.Visible = true;
                        btn3.Visible = true;
                        break;
                    case NavigationButtons.eButtons.PrevNextExit:
                        btn2.Visible = false;
                        btn1.Visible = true;
                        btn3.Visible = true;
                        break;

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

        public usrc_NavigationButtons()
        {
            InitializeComponent();
        }

        public void Init(NavigationButtons nav_buttons)
        {
            this.m_eButtons = nav_buttons.m_eButtons;
            btn1.Visible = nav_buttons.btn1_Visible;
            btn2.Visible = nav_buttons.btn2_Visible;
            btn3.Visible = nav_buttons.btn3_Visible;

            btn1.Text = nav_buttons.btn1_Text;
            btn2.Text = nav_buttons.btn2_Text;
            btn3.Text = nav_buttons.btn3_Text;

            btn1.Image = nav_buttons.btn1_Image;
            btn2.Image = nav_buttons.btn2_Image;
            btn3.Image = nav_buttons.btn3_Image;

            switch (this.m_eButtons)
            {
                case NavigationButtons.eButtons.OkCancel:
                    btn2.Visible = false;
                    break;

                case NavigationButtons.eButtons.PrevNextExit:
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
                    case NavigationButtons.eButtons.PrevNextExit:
                        ButtonPressed(NavigationButtons.eEvent.PREV);
                        break;
                    case NavigationButtons.eButtons.OkCancel:
                        ButtonPressed(NavigationButtons.eEvent.OK);
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
                    case NavigationButtons.eButtons.PrevNextExit:
                        ButtonPressed(NavigationButtons.eEvent.NEXT);
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
                    case NavigationButtons.eButtons.PrevNextExit:
                        ButtonPressed(NavigationButtons.eEvent.EXIT);
                        break;
                    case NavigationButtons.eButtons.OkCancel:
                        ButtonPressed(NavigationButtons.eEvent.CANCEL);
                        break;
                }
            }
        }
    }
}
