using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageControl;
using System.Windows.Forms;
using SelectGender;
using DBTypes;
using System.Drawing;
using System.IO;
using UniqueControlNames;

namespace DynEditControls
{
    public class EditControl
    {
        public ltext m_lt_help = null;
        public Label lbl = null;

        public Control edit_control = null;
        private string Image_Hash = null;

        private DynGroupBox m_grp_box = null;

        private object m_refobj = null;
        private string m_Name = null;
        public int Height = -1;
        public int Width = -1;
        public int Top = -1;
        public int Left = -1;
        public int ypos = -1;
        public int xpos = -1;
        public EditControl pNext = null;
        public EditControl pPrev = null;

        private Color m_ColorChanged = Color.DarkRed;
        public Color ColorChanged
        {
            get { return m_ColorChanged; }
            set { m_ColorChanged = value; }
        }

        private Color m_ColorNotChanged = Color.DarkBlue;
        public Color ColorNotChanged
        {
            get { return m_ColorNotChanged; }
            set { m_ColorNotChanged = value; }
        }

        private int m_MinEditBoxWidth = 200;
        public int MinEditBoxWidth
        {
            get { return m_MinEditBoxWidth; }
            set { m_MinEditBoxWidth = value; }
        }

        private int m_LeftMargin = 10;
        public int LeftMargin
        {
            get { return m_LeftMargin; }
            set { m_LeftMargin = value; }
        }

        private int m_RightMargin = 10;
        public int RightMargin
        {
            get { return m_RightMargin; }
            set { m_RightMargin = value; }
        }

        private int m_TopMargin = 50;
        public int TopMargin
        {
            get { return m_TopMargin; }
            set { m_TopMargin = value; }
        }

        private int m_VerticalDistance = 5;
        public int VerticalDistance
        {
            get { return m_VerticalDistance; }
            set { m_VerticalDistance = value; }
        }

        private int m_HorisontalDistance = 3;
        public int HorisontalDistance
        {
            get { return m_HorisontalDistance; }
            set { m_HorisontalDistance = value; }
        }

        private int m_txtVerticalOffsetToLabel = 0;
        public int TxtVerticalOffsetToLabel
        {
            get { return m_txtVerticalOffsetToLabel; }
            set { m_txtVerticalOffsetToLabel = value; }
        }

        private int m_lblVerticalOffset = 4;
        public int lblVerticalOffset
        {
            get { return m_lblVerticalOffset; }
            set { m_lblVerticalOffset = value; }
        }

        private int m_HorisontallOffsetToLabel = 4;
        public int HorisontallOffsetToLabel
        {
            get { return m_HorisontallOffsetToLabel; }
            set { m_HorisontallOffsetToLabel = value; }
        }

        private bool m_ReadOnly = false;

        public bool ReadOnly {
            get { return m_ReadOnly; }
            set { m_ReadOnly = value;
                    if (edit_control is TextBox)
                    {
                        ((TextBox)edit_control).ReadOnly = m_ReadOnly;
                    }
                    if (edit_control is Password.usrc_PasswordDefinition)
                    {
                        ((Password.usrc_PasswordDefinition)edit_control).ReadOnly = m_ReadOnly;
                    }
                    else if (edit_control is usrc_NumericUpDown)
                    {
                        ((usrc_NumericUpDown)edit_control).ReadOnly = m_ReadOnly;
                    }
                    if (m_ReadOnly)
                    {
                        edit_control.Cursor = Cursors.No;
                    }
                    else
                    {
                        edit_control.Cursor = Cursors.Arrow;
                    }
                }
            }

        public EditControl(DynGroupBox xgrp_box, UniqueControlName xuctrln, object refobj, string xName, ltext lt_label, ltext lt_val, ltext lt_help)
        {
            m_grp_box = xgrp_box;
            m_lt_help = lt_help;
            this.MinEditBoxWidth = m_grp_box.MinEditBoxWidth;
            this.LeftMargin = m_grp_box.LeftMargin;
            this.RightMargin = m_grp_box.RightMargin;
            this.TopMargin = m_grp_box.TopMargin;
            this.VerticalDistance = m_grp_box.VerticalDistance;
            this.HorisontalDistance = m_grp_box.HorisontalDistance;
            this.lblVerticalOffset = m_grp_box.lblVerticalOffset;
            this.TxtVerticalOffsetToLabel = m_grp_box.VerticalOffsetToLabel;
            this.HorisontallOffsetToLabel = m_grp_box.HorisontallOffsetToLabel;
            this.ColorChanged = m_grp_box.ColorChanged;
            this.ColorNotChanged = m_grp_box.ColorNotChanged;

            m_refobj = refobj;
            m_Name = xName;
            lbl = new Label();
            if (m_refobj is dstring_v)
            {
                if (xName.Equals("MyOrg_Person_Password"))
                {
                    edit_control = new Password.usrc_PasswordDefinition();
                    edit_control.Name = "upwd_" + xuctrln.Get_usrc_PasswordDefinition_UniqueIndex();
                    ((Password.usrc_PasswordDefinition)edit_control).PasswordLocked = false;
                    bool bltValDefined = false;
                    if (lt_val != null)
                    {
                        if (lt_val.s != null)
                        {
                            bltValDefined = true;
                        }
                    }
                    if (bltValDefined)
                    {
                        ((Password.usrc_PasswordDefinition)edit_control).Text = lt_val.s;
                        ((dstring_v)m_refobj).v = lt_val.s;
                    }
                    else
                    {
                        edit_control.Text = ((dstring_v)m_refobj).vs;
                    }
                    ((dstring_v)m_refobj).defined = true;
                }
                else
                {
                    edit_control = new TextBox();
                    edit_control.Name = "txt_" + xuctrln.Get_TextBox_UniqueIndex();
                    bool bltValDefined = false;
                    if (lt_val != null)
                    {
                        if (lt_val.s != null)
                        {
                            bltValDefined = true;
                        }
                    }
                    if (bltValDefined)
                    {
                        edit_control.Text = lt_val.s;
                        ((dstring_v)m_refobj).v = lt_val.s;
                    }
                    else
                    {
                        edit_control.Text = ((dstring_v)m_refobj).vs;
                    }
                    ((dstring_v)m_refobj).defined = true;
                }
            }
            else if (m_refobj is dbool_v)
            {
                if (xName.Equals("MyOrg_Person_Gender"))
                {
                    edit_control = new usrc_SelectGender(xuctrln.Get_usrc_SelectGender_UniqueIndex());
                    ((usrc_SelectGender)edit_control).RadioButton1IsTrue = true;
                    ((usrc_SelectGender)edit_control).RadioButton1_Text = lng.s_Male.s;
                    ((usrc_SelectGender)edit_control).RadioButton2_Text = lng.s_Female.s;
                    if (((dbool_v)m_refobj).defined)
                    {
                        ((usrc_SelectGender)edit_control).Checked = ((dbool_v)m_refobj).v;
                    }
                }
                else
                {
                    edit_control = new CheckBox();
                    edit_control.Name = xuctrln.Get_usrc_CheckBox_UniqueIndex();
                    ((CheckBox)edit_control).Text = "";
                    if (((dbool_v)m_refobj).defined)
                    {
                        ((CheckBox)edit_control).Checked = ((dbool_v)m_refobj).v;
                    }
                }
            }
            else if (m_refobj is dDateTime_v)
            {
                edit_control = new DateTimePicker();
                edit_control.Name = "datetimepicker_" + xuctrln.Get_DateTimePicker_UniqueIndex();
                edit_control.Text = "";
                ((DateTimePicker)edit_control).Value = DateTime.Now;
                ((dDateTime_v)m_refobj).v = ((DateTimePicker)edit_control).Value;
            }
            else if (m_refobj is dshort_v)
            {
                edit_control = new usrc_NumericUpDown(false, xuctrln.Get_usrc_NumericUpDown_UniqueIndex());
                ((usrc_NumericUpDown)edit_control).Minimum = 0;
                ((usrc_NumericUpDown)edit_control).Maximum = 100000;
                ((usrc_NumericUpDown)edit_control).Value = Convert.ToDecimal(((dshort_v)m_refobj).v);
                ((dshort_v)m_refobj).v = Convert.ToInt16(((usrc_NumericUpDown)edit_control).Value);
            }
            else if (m_refobj is dbyte_array_v)
            {
                edit_control = new usrc_GetImage();
                edit_control.Name = "ugetimg_" + xuctrln.Get_usrc_GetImage_UniqueIndex();
                if (m_refobj!=null)
                {
                    if (((dbyte_array_v)m_refobj).v != null)
                    {
                        ImageConverter ic = new ImageConverter();
                        ((usrc_GetImage)edit_control).Image = (Image)ic.ConvertFrom(((dbyte_array_v)m_refobj).v);
                        Image_Hash = ((usrc_GetImage)edit_control).Image_Hash;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:EditControl:unsuported type: m_refobj type =" + m_refobj.GetType().ToString());
                return;
            }

            lbl.Name = "lbl_" + m_grp_box.Name + "_" + m_Name;
            lbl.Font = m_grp_box.Font;
            edit_control.Name = "txt_" + m_grp_box.Name + "_" + m_Name;
            edit_control.Font = m_grp_box.Font;
            lbl.AutoSize = false;
            lbl.Text = lt_label.s + ":";
            SizeF size_lbl = lbl.CreateGraphics().MeasureString(lbl.Text, lbl.Font);
            SizeF size_txt = lbl.CreateGraphics().MeasureString(edit_control.Text, edit_control.Font);
            lbl.Width = (int)Math.Ceiling(size_lbl.Width)+20;
            lbl.Height = (int)Math.Ceiling(size_lbl.Height);
            lbl.TextAlign = ContentAlignment.MiddleRight;
            if ((m_refobj is dstring_v))
            {
                edit_control.Width = MinEditBoxWidth;
                if (edit_control is TextBox)
                {
                    int txt_calculated_width = (int)Math.Ceiling(size_txt.Width) + 4;
                    if (edit_control.Width < txt_calculated_width)
                    {
                        edit_control.Width = txt_calculated_width;
                    }
                }
                else if (edit_control is Password.usrc_PasswordDefinition)
                {
                    edit_control.Width = 128;
                }
            }

            this.Width = lbl.Width + m_HorisontallOffsetToLabel + edit_control.Width;
            if (m_grp_box.EditControlsList == null)
            {
                m_grp_box.EditControlsList = new List<EditControl>();
            }
            m_grp_box.EditControlsList.Add(this);
            int EditControlsList_Count = m_grp_box.EditControlsList.Count;
            if (EditControlsList_Count == 1)
            {
                this.pPrev = null;
                this.pNext = null;
            }
            else if (EditControlsList_Count > 1)
            {
                this.pPrev = m_grp_box.EditControlsList[EditControlsList_Count - 2];
                m_grp_box.EditControlsList[EditControlsList_Count - 2].pNext = this;
                this.pNext = null;
            }
            m_grp_box.Controls.Add(lbl);
            m_grp_box.Controls.Add(edit_control);
            if (m_grp_box.tooltip != null)
            {
                m_grp_box.tooltip.SetToolTip(edit_control, lt_help.s);
                m_grp_box.tooltip.SetToolTip(lbl, lt_help.s);
            }
        }

        public void DoReposition(ref int MaxHeightInRow)
        {

            ypos = m_TopMargin;
            xpos = m_LeftMargin;
            if (pPrev != null)
            {
                if (pPrev.xpos + pPrev.Width + m_HorisontalDistance + this.edit_control.Width + m_RightMargin + 200 < m_grp_box.Width)
                {
                    xpos = pPrev.xpos + pPrev.Width + m_HorisontalDistance;
                    if (MaxHeightInRow<this.edit_control.Height)
                    {
                        MaxHeightInRow = this.edit_control.Height;
                    }
                    ypos = pPrev.ypos;
                }
                else
                {
                    ypos = pPrev.ypos + MaxHeightInRow + m_VerticalDistance;
                    MaxHeightInRow = this.edit_control.Height;
                    xpos = m_LeftMargin;
                }
            }
            else
            {
                MaxHeightInRow = this.edit_control.Height;
            }

            lbl.Top = ypos + m_lblVerticalOffset;
            this.Top = lbl.Top;
            lbl.Left = xpos;
            this.Left = lbl.Left;
            edit_control.Top = ypos;
            edit_control.Left = lbl.Left + lbl.Width + m_HorisontalDistance;
            this.Width = edit_control.Left + edit_control.Width - this.Left;
            this.Height = edit_control.Bottom - edit_control.Top;
        }

        public void Fill()
        {
            if (m_refobj is dstring_v)
            {
                if (edit_control is TextBox)
                {
                    ((dstring_v)m_refobj).v = ((TextBox)edit_control).Text;
                }
                else if (edit_control is Password.usrc_PasswordDefinition)
                {
                    ((dstring_v)m_refobj).v = ((Password.usrc_PasswordDefinition)edit_control).Text;
                }
            }
            else if (m_refobj is dbool_v)
            {
                if (edit_control is usrc_SelectGender)
                {
                    ((dbool_v)m_refobj).v = ((usrc_SelectGender)edit_control).Checked;
                }
                else if (edit_control is CheckBox)
                {
                    ((dbool_v)m_refobj).v = ((CheckBox)edit_control).Checked;
                }
                else
                {
                    LogFile.Error.Show("ERROR:EditControl:unsuported edit_control: edit_control type =" + edit_control.GetType().ToString());
                    return;
                }
            }
            else if (m_refobj is dDateTime_v)
            {

                edit_control = new DateTimePicker();
                edit_control.Text = "";
                ((dDateTime_v)m_refobj).v = ((DateTimePicker)edit_control).Value;
            }
            else if (m_refobj is dshort_v)
            {
                ((dshort_v)m_refobj).v = Convert.ToInt16(((usrc_NumericUpDown)edit_control).Value);
            }
            else if (m_refobj is dbyte_array_v)
            {
                ((dbyte_array_v)m_refobj).v = imageToByteArray(((usrc_GetImage)edit_control).Image, ((usrc_GetImage)edit_control).imgFormat);
            }
            else
            {
                LogFile.Error.Show("ERROR:EditControl:unsuported type: m_refobj type =" + m_refobj.GetType().ToString());
                return;
            }
        }
        public byte[] imageToByteArray(Image imageIn, System.Drawing.Imaging.ImageFormat imgformat)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, imgformat);
            //SaveImageInFormat(imageIn, ms);
            return ms.ToArray();
        }

        public bool DataNotChanged()
        {
            if (m_refobj is dstring_v)
            {
                if (((dstring_v)m_refobj).v != null)
                {
                    if (edit_control is TextBox)
                    {
                        return ((dstring_v)m_refobj).v.Equals(((TextBox)edit_control).Text);
                    }
                    else if (edit_control is Password.usrc_PasswordDefinition)
                    {
                        if (((Password.usrc_PasswordDefinition)edit_control).PasswordLocked)
                        {
                            return Password.Password.LockPassword((((dstring_v)m_refobj).v)).Equals(((Password.usrc_PasswordDefinition)edit_control).Text);
                        }
                        else
                        {
                            return ((dstring_v)m_refobj).v.Equals(((Password.usrc_PasswordDefinition)edit_control).Text);
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:DynEditControls:EditControl.cs:DataNotChanged type of edit_control " + edit_control.GetType().ToString() + " not suported.");
                        return false;
                    }
                }
                else
                {
                    string s = null;
                    if (edit_control is TextBox)
                    {
                        s = ((TextBox)edit_control).Text;
                        s.Replace(" ", "");
                    }
                    else if (edit_control is Password.usrc_PasswordDefinition)
                    {
                        s = ((Password.usrc_PasswordDefinition)edit_control).Text;
                    }
                    if (s.Length == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            else if (m_refobj is dbool_v)
            {
                if (edit_control is usrc_SelectGender)
                {
                    return (((dbool_v)m_refobj).v == ((usrc_SelectGender)edit_control).Checked);
                }
                else if (edit_control is CheckBox)
                {
                    return (((dbool_v)m_refobj).v == ((CheckBox)edit_control).Checked);
                }
                else
                {
                    LogFile.Error.Show("ERROR:EditControl:unsuported edit_control: edit_control type =" + edit_control.GetType().ToString());
                    return false;
                }
            }
            else if (m_refobj is dDateTime_v)
            {

                return (((dDateTime_v)m_refobj).v == ((DateTimePicker)edit_control).Value);
            }
            else if (m_refobj is dshort_v)
            {
                return ((dshort_v)m_refobj).v == Convert.ToInt16(((usrc_NumericUpDown)edit_control).Value);
            }
            else if (m_refobj is dbyte_array_v)
            {
                if (Image_Hash == null)
                {
                    if (((usrc_GetImage)edit_control).Image_Hash == null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (((usrc_GetImage)edit_control).Image_Hash != null)
                    {
                        return (((usrc_GetImage)edit_control).Image_Hash.Equals(Image_Hash));
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:EditControl:unsuported type: m_refobj type =" + m_refobj.GetType().ToString());
                return false;
            }
        }
        public void MarkAsChanged()
        {
            this.lbl.ForeColor = this.ColorChanged;
        }

        public void MarkAsNotChanged()
        {
            this.lbl.ForeColor = this.ColorNotChanged;
        }
    }
}
