using LanguageControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TangentaSampleDB
{
    public partial class Form_EditMyOrgSampleData : Form
    {
        ToolTip toolTip1 = null;
        private bool DataChanged = false;
        private bool AllDataChanged = false;
        private Icon oIcon = null;
        private NavigationButtons.Navigation nav = null;
        public Form_EditMyOrgSampleData(SampleDB smd, NavigationButtons.Navigation xnav,Icon xoIcon)
        {
            InitializeComponent();
            lng.s_Form_EditMyOrgSampleData.Text(this);
            oIcon = xoIcon;
            nav = xnav;
            usrc_NavigationButtons1.Init(nav);

            if (oIcon != null)
            {
                this.Icon = oIcon;
            }
            toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            smd.Init(this.m_usrc_SampleDataEdit);
        }

        private void m_usrc_SampleDataEdit_Load(object sender, EventArgs e)
        {
            m_usrc_SampleDataEdit.Init();
        }

        private void do_Cancel()
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void do_OK()
        {
            DataChanged = false;
            AllDataChanged = false;
            if (m_usrc_SampleDataEdit.Check(EnumControlCallback_Check))
            {
                if (DataChanged && AllDataChanged)
                {
                    m_usrc_SampleDataEdit.Fill(EnumControlCallback_Fill);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else if (!DataChanged && !AllDataChanged)
                {
                    m_usrc_SampleDataEdit.Fill(EnumControlCallback_Fill);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    if (XMessage.Box.Show(this, lng.s_YouHaveChangedSomeDataButNotAllSampleData_YouShouldChangeAllSampleDataToYourRealData, "?", MessageBoxButtons.OKCancel, Icon, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
                    {
                        m_usrc_SampleDataEdit.Fill(EnumControlCallback_Fill);
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        nav.eExitResult = NavigationButtons.Navigation.eEvent.NOTHING;
                    }
                }
            }
        }

        public bool EnumControlCallback_Check(DynEditControls.EditControl edt_control)
        {
            if (edt_control.DataNotChanged())
            {
                edt_control.MarkAsNotChanged();
            }
            else
            {
                edt_control.MarkAsChanged();
                DataChanged = true;
                AllDataChanged = false;
            }
            return true;
        }

        public void EnumControlCallback_Fill(DynEditControls.EditControl edt_control)
        {
            edt_control.Fill();
        }

        private void Form_EditSampleData_Load(object sender, EventArgs e)
        {
        }

        private void usrc_NavigationButtons1_Load(object sender, EventArgs e)
        {

        }

        private void usrc_NavigationButtons1_ButtonPressed(NavigationButtons.Navigation.eEvent evt)
        {
            nav.eExitResult = evt;
            switch (nav.m_eButtons)
            {
                case NavigationButtons.Navigation.eButtons.PrevNextExit:
                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.NEXT:
                            do_OK();
                            break;
                        case NavigationButtons.Navigation.eEvent.PREV:
                            do_Cancel();
                            break;
                        case NavigationButtons.Navigation.eEvent.EXIT:
                            do_Cancel();
                            break;
                    }
                    break;
                case NavigationButtons.Navigation.eButtons.OkCancel:
                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.OK:
                            do_OK();
                            break;
                        case NavigationButtons.Navigation.eEvent.CANCEL:
                            do_Cancel();
                            break;
                    }
                    break;
            }
        }
    }
}
