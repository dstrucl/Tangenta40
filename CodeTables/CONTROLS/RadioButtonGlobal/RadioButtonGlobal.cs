using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Global;

namespace RadioButtonGlobal
{
    
    public partial class RadioButtonGlobal : UserControl
    {
        public delegate void delegateCheckChanged();
        public event delegateCheckChanged CheckChanged = null;

        private Color m_ParentBackColor = System.Drawing.SystemColors.Control;
        public Color ParentBackColor
        {
            get
            {
                return m_ParentBackColor;
            }
            set
            {
                m_ParentBackColor = value;
            }
        }

        private Color m_HighlightBackColor = System.Drawing.SystemColors.ActiveCaption;
        public Color HighlightBackColor
        {
            get
            {
                return m_HighlightBackColor;
            }
            set
            {
                m_HighlightBackColor = value;
            }
        }

        public bool Checked
        {
            get { return rdb.Checked; }
            set
            {
                rdb.Checked = value;
            }
        }

        private void Uncheck_usrc_SelectFileRadioEditButton_in_SubCtrls(Control BaseCtrl, RadioButtonGlobal rdbg)
        {
            foreach (Control ctrl in BaseCtrl.Controls)
            {
                if (ctrl is RadioButtonGlobal)
                {
                    if ((RadioButtonGlobal)ctrl != rdbg)
                    {
                        ((RadioButtonGlobal)ctrl).Checked = false;
                        ((RadioButtonGlobal)ctrl).Parent.BackColor = ParentBackColor;
                        if (((RadioButtonGlobal)ctrl).Parent.Parent!=null)
                        {
                            ((RadioButtonGlobal)ctrl).Parent.Parent.BackColor = ParentBackColor;
                        }
                    }
                }
                if (ctrl.Controls != null)
                {
                    Uncheck_usrc_SelectFileRadioEditButton_in_SubCtrls(ctrl, rdbg);
                }
            }
        }
        public RadioButtonGlobal()
        {
            InitializeComponent();
        }

        private void rdb_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb.Checked)
            {
                Form bBaseControl = f.GetParentForm(this);
                Uncheck_usrc_SelectFileRadioEditButton_in_SubCtrls(bBaseControl,this);
                this.Parent.BackColor = HighlightBackColor;
            }
            if (CheckChanged!=null)
            {
                CheckChanged();
            }
        }
    }
}
