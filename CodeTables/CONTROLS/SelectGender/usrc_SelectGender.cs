using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelectGender
{
    public partial class usrc_SelectGender : UserControl
    {
        private bool m_RadioButton1IsTrue = true;
        public bool RadioButton1IsTrue
        {
            get { return m_RadioButton1IsTrue; }
            set { m_RadioButton1IsTrue = value; }
        }

        private string m_RadioButton1_Text = "0";
        public string RadioButton1_Text
        {
            get { return m_RadioButton1_Text; }
            set { m_RadioButton1_Text = value;
                 this.radioButton1.Text = m_RadioButton1_Text;
                }
        }

        private string m_RadioButton2_Text = "1";
        public string RadioButton2_Text
        {
            get { return m_RadioButton2_Text; }
            set
            {
                m_RadioButton2_Text = value;
                this.radioButton2.Text = m_RadioButton2_Text;
            }
        }


        public bool Checked
        {
            get
            {
                if (m_RadioButton1IsTrue)
                    return this.radioButton1.Checked;
                else
                    return this.radioButton2.Checked;
            }
        set {
                if (m_RadioButton1IsTrue)
                {
                    radioButton1.Checked = value;
                }
                else
                { 
                    radioButton2.Checked = value;
                }
            }
        }

        public usrc_SelectGender(string unqique_index)
        {
            InitializeComponent();
            this.Name = "selgender_" + unqique_index;
        }
    }
}
