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
using LanguageControl;
using DBTypes;
using UniqueControlNames;

namespace CodeTables
{
    public partial class usrc_InputControl_Label : UserControl
    {
        public delegate void delegate_null_selected(bool b);
        public event delegate_null_selected null_selected = null;

        Label lbl = null;
        usrc_RadioButton rdb_null = null;
        usrc_RadioButton rdb_lbl = null;
        PictureBox pic_Unique = null;
        public Column m_col = null;
        public Color Color_NewData = Color.Blue;
        public Color Color_NoNewData = Color.Black;

        public bool_v Initial_NoData = null;

        private bool readOnly = false;
        public bool ReadOnly
        {
            get { return readOnly; }  
            set  { readOnly = value; 
                       if (rdb_null!=null)
                       {
                           rdb_null.ReadOnly = readOnly;
                       }
                    if (rdb_lbl!=null)
                    {
                        rdb_lbl.ReadOnly = readOnly;
                    }

                }  
        }


        public bool bNoData_Changed(ref bool_v New_NoData)
        {
            if (Initial_NoData != null)
            {
                if (rdb_null != null)
                {
                    bool bChecked = rdb_null.Checked;
                    if (bChecked != Initial_NoData.v)
                    {
                        if (New_NoData == null)
                        {
                            New_NoData = new bool_v();
                            New_NoData.v = bChecked;
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        public usrc_InputControl_Label()
        {
            InitializeComponent();
            this.BackColor = Color.Transparent;
        }


        public void SetCheck()
        {
            if (m_col.nulltype == Column.nullTYPE.NULL)
            {
                if (m_col.obj != null)
                {
                    try
                    {
                        ValSet vs = (ValSet)m_col.obj;
                        if (vs.defined)
                        {
                            rdb_lbl.Checked = true;
                        }
                        else
                        {
                            rdb_null.Checked = true;
                        }
                    }
                    catch
                    {
                        // Table
                        rdb_null.Checked = true;
                    }
                }
                else
                {
                    rdb_null.Checked = true;
                }
            }
        }

        public void Init_SetCheck()
        {
            if (m_col.nulltype == Column.nullTYPE.NULL)
            {
                if (m_col.obj != null)
                {
                    try
                    {
                        ValSet vs = (ValSet)m_col.obj;
                        if (vs.defined)
                        {
                            rdb_lbl.Checked = true;
                        }
                        else
                        {
                            rdb_null.Checked = true;
                            if (null_selected != null)
                            {
                                null_selected(true);
                            }
                        }
                    }
                    catch
                    {
                        // Table
                        rdb_null.Checked = true;
                        if (null_selected != null)
                        {
                            null_selected(true);
                        }
                    }
                }
                else
                {
                    rdb_null.Checked = true;
                }

                Initial_NoData = new bool_v();
                Initial_NoData.v = rdb_null.Checked;

            }
        }

        public void NoData(bool b)
        {
            if (b)
            {
                if (rdb_null != null)
                {
                    rdb_null.Checked = true;
                    rdb_lbl.Checked = false;
                }
            }
            else
            {
                if (rdb_null != null)
                {
                    rdb_null.Checked = false;
                    rdb_lbl.Checked = true;
                }
            }
        }

        public bool Null_Selected
        {
            get
            {
                if (rdb_null != null)
                {
                    if (rdb_null.Checked)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public void InitNoData(bool b)
        {

            if (Initial_NoData == null)
            {
                Initial_NoData = new bool_v();
            }
            Initial_NoData.v = b;
            if (b)
            {
                if (rdb_null != null)
                {
                    rdb_null.Checked = true;
                    rdb_lbl.Checked = false;
                }
            }
            else
            {
                if (rdb_null != null)
                {
                    rdb_null.Checked = false;
                    rdb_lbl.Checked = true;
                }
            }
        }

        private void EventHandler_Set()
        {
            rdb_null.CheckedChanged += new EventHandler(rdb_null_CheckedChanged);
            rdb_lbl.CheckedChanged += new EventHandler(rdb_lbl_CheckedChanged);
        }

        private void EventHandler_Remove()
        {
            rdb_null.CheckedChanged -= rdb_null_CheckedChanged;
            rdb_lbl.CheckedChanged -= rdb_lbl_CheckedChanged;
        }


        public void Init(Column xcol, UniqueControlName xuctrln,int inpCtrlList_Count, bool xReadOnly )
        {
            readOnly = xReadOnly;
            m_col = xcol;
            this.Visible = true;
            this.BackColor = Color.Transparent;
            int x = 2;
            int y = 2;
            if ((m_col.flags & Column.Flags.UNIQUE) > 0)
            {
                pic_Unique = new PictureBox();
                pic_Unique.Name = "picUnique";
                pic_Unique.Image = Properties.Resources.Unique;
                pic_Unique.Left = x;
                pic_Unique.Top = y;
                pic_Unique.Width = Properties.Resources.Unique.Width;
                pic_Unique.Height = Properties.Resources.Unique.Height;
                pic_Unique.Visible = true;
                x += pic_Unique.Width + 2;
                this.Controls.Add(pic_Unique);

                System.Windows.Forms.ToolTip ToolTip_uinique = new System.Windows.Forms.ToolTip();
                ToolTip_uinique.SetToolTip(this.pic_Unique, lng.s_ValueMustBeUnique.s);
                
            }
            if (m_col.nulltype == Column.nullTYPE.NULL)
            {
                rdb_null = new usrc_RadioButton(xuctrln);
                rdb_null.ReadOnly = readOnly;
                rdb_null.Left = x;
                rdb_null.AutoSize = true;
                rdb_null.Top = y;
                rdb_null.Height = this.Height - 4;
                rdb_null.Text = lng.s_null.s;
                rdb_null.BackColor = Color.Transparent;
                rdb_null.Visible = true;
                rdb_null.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                rdb_null.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
                System.Windows.Forms.ToolTip ToolTip_null_means_no_data = new System.Windows.Forms.ToolTip();
                ToolTip_null_means_no_data.SetToolTip(this.rdb_null, lng.s_null_means_nod_data.s);

                this.Controls.Add(rdb_null);

                rdb_lbl = new usrc_RadioButton(xuctrln);
                rdb_lbl.ReadOnly = readOnly;
                if (inpCtrlList_Count > 0)
                {
                    m_col.Name_in_language.Text((inpCtrlList_Count + 1).ToString() + ":",rdb_lbl);
                }
                else
                {
                    m_col.Name_in_language.Text(rdb_lbl);
                }

                rdb_lbl.AutoSize = true;

                rdb_lbl.Top = rdb_null.Top;
                rdb_lbl.Height = rdb_null.Height;

                rdb_lbl.Left = rdb_null.Left + rdb_null.Width + 2;
                rdb_lbl.Visible = true;
                //rdb_lbl.BackColor = Color.Transparent;
                rdb_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                rdb_null.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
                this.Controls.Add(rdb_lbl);
                this.Width = rdb_lbl.Left + rdb_lbl.Width + 2;
                Init_SetCheck();
                EventHandler_Set();
            }
            else
            {
                lbl = new Label();
                lbl.Name = "xlbl_" + xuctrln.Get_Label_UniqueIndex();
                this.Controls.Add(lbl);
                if (inpCtrlList_Count > 0)
                {
                    m_col.Name_in_language.Text((inpCtrlList_Count + 1).ToString()+":", lbl);
                }
                else
                {
                    m_col.Name_in_language.Text(lbl);
                }

                lbl.Left = x;
                lbl.Top = y;
                lbl.Height = this.Height - 4;
                lbl.Visible = true;
                lbl.BackColor = Color.Transparent;
                lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                lbl.AutoSize = true;
                this.Width = lbl.Left + lbl.Width + 2;
            }

        }

        void rdb_lbl_CheckedChanged(object sender, EventArgs e)
        {
            bool_v NewData = null;
            if (rdb_lbl.Checked)
            {
                if (bNoData_Changed(ref NewData))
                {
                    rdb_lbl.ForeColor = Color_NewData;
                }
                else
                {
                    rdb_lbl.ForeColor = Color_NoNewData;
                }

                if (null_selected != null)
                {
                    null_selected(false);
                }
            }
            else
            {
                rdb_lbl.ForeColor = Color_NoNewData;
            }
        }

        void rdb_null_CheckedChanged(object sender, EventArgs e)
        {
            bool_v NewData = null;
            if (rdb_null.Checked)
            {
                if (bNoData_Changed(ref NewData))
                {
                    rdb_null.ForeColor = Color_NewData;
                }
                else
                {
                    rdb_null.ForeColor = Color_NoNewData;
                }

                if (null_selected != null)
                {
                    null_selected(true);
                }
            }
            else
            {
                rdb_null.ForeColor = Color_NoNewData;
            }
        }



    }
}
