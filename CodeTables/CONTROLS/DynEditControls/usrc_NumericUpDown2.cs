#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace DynEditControls
{
    public partial class usrc_NumericUpDown2 : UserControl
    {
        public enum eType { CURRENCY, PERCENT, INTEGER,DECIMAL };
        
        //public delegate void delegate_ValueChanged(object sender, EventArgs e);
        public event System.EventHandler ValueChanged = null;

        private eType m_eType = eType.INTEGER;
        private string m_Unit = "";
        private decimal m_MinValue = 0;
        private decimal m_MaxValue = 100;
        private decimal m_ValueMultiplier = 1;
        private decimal m_Increment = 1;
        private bool m_ReadOnly = false;
        private int m_DecimalPlaces = 2;
        public int DecimalPlaces
        {
            get { return m_DecimalPlaces; }

            set { m_DecimalPlaces = value;
            }
        }


        public eType Type
        {
            get { return m_eType; }

            set
            {
                m_eType = value;
            }

        }
        public string Unit
        {
            get { return m_Unit; }

            set { m_Unit = value; }
        }

        public decimal Increment
        {
            get { return m_Increment; }

            set { m_Increment = value; }
        }

        public decimal Value
        {
            get { return GetValue(); }

            set { SetValue(value); }
        }

        public decimal ValueMultiplier
        {
            get { return m_ValueMultiplier; }

            set { m_ValueMultiplier =value; }
        }

        public bool ReadOnly
        {
            get { return m_ReadOnly; }

            set { m_ReadOnly = value;
                  this.txt_Value.ReadOnly = m_ReadOnly;
                  this.btn_Minus.Enabled = !m_ReadOnly;
                  this.btn_Plus.Enabled = !m_ReadOnly;

                if (m_ReadOnly)
                {
                    txt_Value.Cursor = Cursors.No;
                    btn_Minus.Cursor = Cursors.No;
                    btn_Plus.Cursor = Cursors.No;
                }
                else
                {
                    txt_Value.Cursor = Cursors.Arrow;
                    btn_Minus.Cursor = Cursors.Arrow;
                    btn_Plus.Cursor = Cursors.Arrow;
                }
            }
        }

        private void SetValue(decimal val)
        {
            string Format = null;
            decimal v;
            string s_v = null;
            switch (m_eType)
            {
                case eType.CURRENCY:
                    Format = "C" + m_DecimalPlaces.ToString();
                    v = val * m_ValueMultiplier;
                    s_v = v.ToString(Format);
                    this.txt_Value.Text = s_v;
                    break;
                case  eType.PERCENT:
                    Format = "N" + m_DecimalPlaces.ToString();
                    v = val * m_ValueMultiplier;
                    s_v = v.ToString(Format);
                    this.txt_Value.Text = s_v + m_Unit;
                    break;

                case eType.INTEGER:
                    v = val * m_ValueMultiplier;
                    s_v = v.ToString();
                    this.txt_Value.Text = s_v;
                    break;

                case eType.DECIMAL:
                    Format = "N" + m_DecimalPlaces.ToString();
                    v = val * m_ValueMultiplier;
                    s_v = v.ToString(Format);
                    this.txt_Value.Text = s_v;
                    break;
            }
        }

        private decimal GetValue()
        {
            decimal v = 0;
            string s = this.txt_Value.Text;
            try
            {
                switch (m_eType)
                {
                    case eType.CURRENCY:
                        v = decimal.Parse(s, NumberStyles.Currency);
                        break;

                    case eType.DECIMAL:
                        v = decimal.Parse(s, NumberStyles.AllowDecimalPoint);
                        break;

                    case eType.PERCENT:
                        int i_UnitIndex = s.IndexOf(m_Unit);
                        string sValue = null;
                        if (i_UnitIndex > 0)
                        {
                            sValue = s.Substring(0, i_UnitIndex);
                            try
                            {
                                v = Convert.ToDecimal(sValue);
                            }
                            catch
                            {
                                v = 0;
                            }
                        }
                        else
                        {
                            v = 0;
                        }
                        break;
                    case eType.INTEGER:
                        v = Convert.ToDecimal(s);
                        break;

                }
            }
            catch
            {
                v = 0;
            }

            return v / m_ValueMultiplier;
        }

        public decimal Maximum
        {
            get { return m_MaxValue; }

            set { m_MaxValue = value; }
        }



        public decimal Minimum
        {
            get { return m_MinValue; }

            set { m_MinValue = value; }
        }

        public usrc_NumericUpDown2(bool xbReadOnly, string unique_index)
        {
            InitializeComponent();
            this.Name = "unmUpDn_" + unique_index;
            m_ReadOnly = xbReadOnly;
            if (!m_ReadOnly)
            { 
                this.txt_Value.TextChanged += new EventHandler(txt_Value_TextChanged);
                this.Cursor = Cursors.Arrow;
                txt_Value.Cursor = Cursors.IBeam;
            }
            else
            {
                this.Cursor = Cursors.No;
                txt_Value.Cursor = Cursors.No;
                btn_Minus.Visible = false;
                btn_Plus.Visible = false;
                txt_Value.ReadOnly = true;
                txt_Value.Cursor = Cursors.No;
                txt_Value.BorderStyle = System.Windows.Forms.BorderStyle.None;
                txt_Value.BackColor = Color.Gray; 
                txt_Value.ForeColor = Color.Black;
                this.BackColor =  Color.Gray;
            }
        }

        public void Init(bool xbReadOnly, string unique_index)
        {
            InitializeComponent();
            this.Name = "unmUpDn_" + unique_index;
            m_ReadOnly = xbReadOnly;
        }
        public usrc_NumericUpDown2()
        {
            InitializeComponent();
            this.Name = "unmUpDn_";
            m_ReadOnly = false;
            if (!m_ReadOnly)
            {
                this.txt_Value.TextChanged += new EventHandler(txt_Value_TextChanged);
                this.Cursor = Cursors.Arrow;
                txt_Value.Cursor = Cursors.IBeam;
            }
            else
            {
                this.Cursor = Cursors.No;
                txt_Value.Cursor = Cursors.No;
                btn_Minus.Visible = false;
                btn_Plus.Visible = false;
                txt_Value.ReadOnly = true;
                txt_Value.Cursor = Cursors.No;
                txt_Value.BorderStyle = System.Windows.Forms.BorderStyle.None;
                txt_Value.BackColor = Color.Gray;
                txt_Value.ForeColor = Color.Black;
                this.BackColor = Color.Gray;
            }
        }

        void txt_Value_TextChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
            {
                ValueChanged(this, e);
            }
        }

        private void btn_Plus_Click(object sender, EventArgs e)
        {
            if (!m_ReadOnly)
            {
                decimal v = GetValue();
                v += m_Increment;
                if (v > m_MaxValue)
                {
                    v = m_MaxValue;
                    SetValue(v);
                }
                else
                {
                    SetValue(v);
                }
            }
        }

        private void btn_Minus_Click(object sender, EventArgs e)
        {
            if (!m_ReadOnly)
            {
                decimal v = GetValue();
                v -= m_Increment;
                if (v < m_MinValue)
                {
                    v = m_MinValue;
                    SetValue(v);
                }
                else
                {
                    SetValue(v);
                }
            }
        }

        public void SetIncrement(int decimal_places)
        {
            m_Increment = Convert.ToDecimal(Math.Pow(10, -decimal_places));
        }

    }
}
