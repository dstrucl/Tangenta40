using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQLTableControl
{
    public partial class usrc_InputControl_DateTimePicker : UserControl
    {
        public delegate void delegate_ValueChanged(object sender, EventArgs e);
        public delegate void delegate_GotFocus(object sender, EventArgs e);
        public event delegate_ValueChanged ValueChanged;
        public event delegate_GotFocus GotFocus;
        private bool readOnly;
        private TextBox txt_DateTimeReadOnly = null;

        private DateTime m_Value = DateTime.MinValue;

        private void Create_txt_DateTimeReadOnly()
        {
            if (txt_DateTimeReadOnly==null)
            { 
                txt_DateTimeReadOnly = new TextBox();
                txt_DateTimeReadOnly.Visible = true;
                txt_DateTimeReadOnly.Left = dateTimePicker.Left;
                txt_DateTimeReadOnly.Top = dateTimePicker.Top;
                txt_DateTimeReadOnly.Width = dateTimePicker.Width;
                txt_DateTimeReadOnly.Cursor = Cursors.No;
                txt_DateTimeReadOnly.ReadOnly = true;
                this.Controls.Add(txt_DateTimeReadOnly);
            }
            else
            {
                txt_DateTimeReadOnly.Visible = true;
            }
        }
        public usrc_InputControl_DateTimePicker(bool xReadOnly)
        {
            InitializeComponent();
            m_Value = dateTimePicker.MinDate;
            readOnly = xReadOnly;
            if (!readOnly)
            {

                dateTimePicker.Visible = true;
                dateTimePicker.ValueChanged += new EventHandler(dateTimePicker_ValueChanged);
                dateTimePicker.GotFocus +=new EventHandler(dateTimePicker_GotFocus);
                dateTimePicker.Cursor = Cursors.Arrow;
                this.Cursor = Cursors.Arrow;
            }
            else
            {
                Create_txt_DateTimeReadOnly();
                dateTimePicker.Visible = false;
                dateTimePicker.Cursor = Cursors.No;
                this.Cursor = Cursors.No;

            }
        }

        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                if (!readOnly)
                {
                    if (txt_DateTimeReadOnly!=null)
                    { 
                        txt_DateTimeReadOnly.Visible = false;
                    }
                    
                    dateTimePicker.ValueChanged += new EventHandler(dateTimePicker_ValueChanged);
                    dateTimePicker.GotFocus += new EventHandler(dateTimePicker_GotFocus);
                    dateTimePicker.Cursor = Cursors.Arrow;
                    this.Cursor = Cursors.Arrow;
                    dateTimePicker.Visible = true;
                }
                else
                {
                    Create_txt_DateTimeReadOnly();
                    dateTimePicker.Visible = false;
                    dateTimePicker.ValueChanged -= new EventHandler(dateTimePicker_ValueChanged);
                    dateTimePicker.GotFocus -= new EventHandler(dateTimePicker_GotFocus);
                    dateTimePicker.Cursor = Cursors.No;
                    this.Cursor = Cursors.No;
                }
            }
        }
        void  dateTimePicker_GotFocus(object sender, EventArgs e)
        {
            if (GotFocus != null)
            {
                GotFocus(this, e);
            }
        }

        void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
            {
                ValueChanged(this, e);
            }
        }
        public DateTime MinDate
        {
            get { return dateTimePicker.MinDate; }
        }
        public DateTime Value
        {
            get { if (readOnly)
                  {
                      return m_Value;
                  }
                 else
                 {
                     m_Value=dateTimePicker.Value;
                     return m_Value;
                 }
                 }
            set {  m_Value = value; 
                    if (readOnly)
                    {
                        if (txt_DateTimeReadOnly!=null)
                        {
                            txt_DateTimeReadOnly.Text = m_Value.ToString();
                        }
                    }
                    else
                    {
                        dateTimePicker.Value = m_Value;
                    }
                }
        }
    }
}
