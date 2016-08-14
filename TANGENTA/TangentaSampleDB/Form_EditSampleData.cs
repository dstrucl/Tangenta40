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
    public partial class Form_EditSampleData : Form
    {
        private bool DataChanged = false;
        private bool AllDataChanged = false;
        private Icon oIcon = null;
        public Form_EditSampleData(SampleDB smd, Image xImageCancel,Icon xoIcon)
        {
            InitializeComponent();
            oIcon = xoIcon;

            if (xImageCancel!=null)
            { 
                this.btn_Cancel.Image = xImageCancel;
                this.btn_Cancel.Text = "";
            }
            else
            {
                lngRPM.s_Cancel.Text(btn_Cancel);
            }

            if (oIcon != null)
            {
                this.Icon = oIcon;
            }
            smd.Init(this.m_usrc_SampleDataEdit);
        }

        private void m_usrc_SampleDataEdit_Load(object sender, EventArgs e)
        {
            m_usrc_SampleDataEdit.Init();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DataChanged = false;
            AllDataChanged = true;
            if (m_usrc_SampleDataEdit.Check(EnumControlCallback_Check))
            {
                if (DataChanged && AllDataChanged)
                {
                    m_usrc_SampleDataEdit.Fill(EnumControlCallback_Fill);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    if (XMessage.Box.Show(this, lngRPM.s_YouHaveChangedSomeDataButNotAllSampleData_YouShouldChangeAllSampleDataToYourRealData, "?", MessageBoxButtons.OKCancel, Icon, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
                    {
                        m_usrc_SampleDataEdit.Fill(EnumControlCallback_Fill);
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }

        public bool EnumControlCallback_Check(DynEditControls.EditControl edt_control)
        {
            if (edt_control.DataChanged())
            {
                edt_control.MarkAsChanged();
                DataChanged = true;
            }
            else
            {
                AllDataChanged = false;
                edt_control.MarkAsNotChanged();
            }
            return true;
        }

        public void EnumControlCallback_Fill(DynEditControls.EditControl edt_control)
        {
            edt_control.Fill();
        }

}
}
