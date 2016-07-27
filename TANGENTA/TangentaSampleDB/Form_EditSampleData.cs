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
        public Form_EditSampleData(SampleDB smd, Image xImageCancel)
        {
            InitializeComponent();

            if (xImageCancel!=null)
            { 
                this.btn_Cancel.Image = xImageCancel;
                this.btn_Cancel.Text = "";
            }
            else
            {
                lngRPM.s_Cancel.Text(btn_Cancel);
            }

            smd.Init(this.m_usrc_SampleDataEdit);
        }

        private void m_usrc_SampleDataEdit_Load(object sender, EventArgs e)
        {
            m_usrc_SampleDataEdit.Init();
        }
    }
}
