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
using DBTypes;
using System.IO;
using StaticLib;
using DBConnectionControl40;
using DynEditControls;
using UniqueControlNames;

namespace CodeTables
{
    public partial class usrc_InputControl : UserControl
    {
        public delegate void delegate_ObjectChanged(SQLTable m_ParentTbl,usrc_InputControl InputControl);
        public event delegate_ObjectChanged ObjectChanged;

        public SQLTable m_ParentTbl = null;
        public List<usrc_InputControl> m_inpCtrlList = null;
        private bool bReadOnly = false;

        private bool m_Defined = false;

        internal bool Defined
        {
            get { return m_Defined; }
            set
            {
                bool b = value;
                if (b)
                {
                    m_Defined = true;
                }
                else
                {
                    m_Defined = false;
                }
            }
        }



        List<Control> m_active_ctrl_List = new List<Control>();

        public bool bManualyChanged = false;

        public string sImportExportVector;
        public Column m_col;

        internal string m_PathImportPicture;
        internal string m_PathImportDocument;

        private Color ColorDefined = Color.White;

        private object m_ObjectInitialValue = null;
        private object ObjectInitialValue
        {
            get { return m_ObjectInitialValue; }
            set
            {
                object oValue = value;
                m_ObjectInitialValue = value;
                if (m_ObjectInitialValue!=null)
                { 
                    try
                    { 
                        if (this.m_col.nulltype == Column.nullTYPE.NULL)
                        {
                            if (oValue is System.DBNull)
                            {
                                return;
                            }
                        }
                        switch (m_eDBType)
                        {
                            case Globals.eDBType.DB_smallInt:
                                if ((oValue is int) || (oValue is uint) || (oValue is long) || (oValue is ulong) || (oValue is ushort) || (oValue is short))
                                {
                                    m_ObjectInitialValue = Convert.ToInt16(oValue);
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:usrc_InputControl:ObjectInitialValue:m_eDBType == Globals.eDBType.DB_smallInt,typeof(value)==" + oValue.GetType().ToString());
                                }
                                break;
                            case Globals.eDBType.DB_Int32:
                                if ((oValue is int) || (oValue is uint) || (oValue is long) || (oValue is ulong) || (oValue is short) || (oValue is ushort))
                                {
                                    m_ObjectInitialValue = Convert.ToInt32(oValue);
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:usrc_InputControl:ObjectInitialValue:m_eDBType == Globals.eDBType.DB_Int32,typeof(value)==" + oValue.GetType().ToString());
                                }
                                break;
                            case Globals.eDBType.DB_Int64:
                                if ((oValue is int) || (oValue is uint) || (oValue is long) || (oValue is ulong) || (oValue is short) || (oValue is ushort))
                                {
                                    m_ObjectInitialValue = Convert.ToInt64(oValue);
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:usrc_InputControl:ObjectInitialValue:m_eDBType == Globals.eDBType.DB_Int64,typeof(value)==" + oValue.GetType().ToString());
                                }
                                break;
                        }
                    } 
                    catch (Exception ex)
                    {
                        LogFile.Error.Show("ERROR:usrc_InputControl:ObjectInitialValue:m_eDBType == Globals.eDBType.DB_Int64,typeof(value)==" + oValue.GetType().ToString()+"\r\nException = " + ex.Message);
                    }
                }

            }
        }

        public bool Changed
        {
            get { return pic_Changed.Changed; }
            set { pic_Changed.Changed = value; }
        }


        //public Object Value;

        private int PictureBoxWidth = 200;
        private int PictureBoxHeight = 200;

        private const int MAX_PICTURE_WIDTH = 400;
        private const int MAX_PICTURE_HEIGHT = 400;

        private int txtBox_Width = 360;
        private int usrc_InputControl_Height = 21;
        private int BtnFileSelectWidth = 32;
        private int btnFolderSelect_Height = 22;
        private int DataBoxWidth = 320;
        private int DataBoxHeight = 320;
        private int DocumentBoxWidth = 160;
        private int DocumentBoxHeight = 32;
        private int chkBoxWidth = 20;
        private int rdbButtonWidth = 100;
        private int RichTextBoxWidth = 360;
        private int RichTextBoxHeight = 300;


        private int dist = 2;
        private bool bIsNumber;

        private TextBox txtBox;
        private Password.usrc_PasswordDefinition txtPassword;
        private RichTextBox RichtxtBox;

        private usrc_InputControl_DataBox DataBox;
        private Picture_Box Picture_Box;
        private InputControl_DocumentBox Document_Box;


        private usrc_NumericUpDown nmUpDown;
        private usrc_NumericUpDown PercentUpDown;
        private usrc_NumericUpDown MoneyUpDown;


        private usrc_InputControl_DateTimePicker DateTimeInput;
        private usrc_RadioButton rdbButton1;
        private usrc_RadioButton rdbButton2;
        private usrc_CheckBox chkBox;


        private Button btnFolderSelect;


        private Globals.eDBType m_eDBType;

        public usrc_InputControl(UniqueControlName xuctrln)
        {
            InitializeComponent();
            this.BackColor = Color.Transparent;
            this.Name = "inp_ctrl" + xuctrln.Get_usrc_InputControl_UniqueIndex();
        }


                public string PathImportPicture
        {
            get { return m_PathImportPicture; }

            set { m_PathImportPicture = value; }

        }

        public string PathImportDocument
        {
            get { return m_PathImportDocument; }

            set { m_PathImportDocument = value; }

        }

        public bool Null_Selected
        {
            get {
                    if (this.usrc_lbl !=null)
                    {
                        return this.usrc_lbl.Null_Selected;
                    }
                    else
                    {
                        return false;
                    }
                }
        }

        internal void SetChanged(object sender)
        {

            if (this.m_col.ownerTable.iFillTableData == 0)
            {
                Control ctrl = (Control)sender;
                ctrl.BackColor = Color.White;
                Defined = true;
                if (Picture_Box != null)
                {
                    if (this.m_col.ownerTable.Image_Hash_Changed())
                    {
                        bManualyChanged = true;
                        pic_Changed.Changed = true;
                        if (ObjectChanged != null)
                        {
                            ObjectChanged(this.m_ParentTbl, this);
                        }
                    }
                    else
                    {
                        bManualyChanged = false;
                        pic_Changed.Changed = false;
                        if (ObjectChanged != null)
                        {
                            ObjectChanged(this.m_ParentTbl, this);
                        }
                    }
                }
                else if (Document_Box != null)
                {
                    if (this.m_col.ownerTable.xDocument_Hash_Changed())
                    {
                        bManualyChanged = true;
                        pic_Changed.Changed = true;
                        if (ObjectChanged != null)
                        {
                            ObjectChanged(this.m_ParentTbl, this);
                        }
                    }
                    else
                    {
                        bManualyChanged = false;
                        pic_Changed.Changed = false;
                        if (ObjectChanged != null)
                        {
                            ObjectChanged(this.m_ParentTbl, this);
                        }
                    }
                }
                else
                {
                    if (DifferentToObjectInitialValue())
                    {
                        bManualyChanged = true;
                        pic_Changed.Changed = true;
                        if (ObjectChanged != null)
                        {
                            ObjectChanged(this.m_ParentTbl, this);
                        }
                    }
                    else
                    {
                        bManualyChanged = false;
                        pic_Changed.Changed = false;
                        if (ObjectChanged != null)
                        {
                            ObjectChanged(this.m_ParentTbl, this);
                        }
                    }
                }
            }
        }


        private bool DifferentToObjectInitialValue_not_null()
        {
            if (ObjectInitialValue == null)
            {
                return true;
            }
            else
            {
                switch (m_eDBType)
                {

                    case Globals.eDBType.DB_bit:
                        switch (m_col.Style)
                        {
                            case Column.eStyle.none:
                            case Column.eStyle.CheckBox:
                            case Column.eStyle.CheckBox_default_true:
                            case Column.eStyle.ReadOnly_CheckBox_default_true:
                                if (ObjectInitialValue.GetType() == typeof(bool))
                                {
                                    bool b = (bool)ObjectInitialValue;
                                    if (chkBox.Checked != b)
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
                                    LogFile.Error.Show("ERROR:DifferentToObjectInitialValue:ObjectInitialValue.GetType() != typeof(bool)!");
                                    return false;
                                }
                                //break;
                                //30000 - 0013505055
                            case Column.eStyle.RadioButtons:
                                if (ObjectInitialValue.GetType() == typeof(bool))
                                {
                                    bool b = (bool)ObjectInitialValue;
                                    if (rdbButton1.Checked != b)
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
                                    LogFile.Error.Show("ERROR:DifferentToObjectInitialValue:case Column.eStyle.RadioButtons:ObjectInitialValue.GetType() != typeof(bool)!");
                                    return false;
                                }
                               // break;
                            default:
                                break;
                        }
                        break;

                    case Globals.eDBType.DB_smallInt:
                    case Globals.eDBType.DB_Int32:
                    case Globals.eDBType.DB_Int64:
                        switch (m_eDBType)
                        {
                            case Globals.eDBType.DB_smallInt:
                                if (ObjectInitialValue.GetType() == typeof(short))
                                {
                                    short ishort = (short)ObjectInitialValue;
                                    short iedited_short = Convert.ToInt16(nmUpDown.Value);
                                    if (iedited_short != ishort)
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
                                    LogFile.Error.Show("ERROR:DifferentToObjectInitialValue:Globals.eDBType.DB_smallInt:ObjectInitialValue.GetType() != typeof(short)!");
                                    return false;
                                }
                                //break;

                            case Globals.eDBType.DB_Int32:
                                if (ObjectInitialValue.GetType() == typeof(int))
                                {
                                    int i = (int)ObjectInitialValue;
                                    int iedited = Convert.ToInt32(nmUpDown.Value);
                                    if (iedited != i)
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
                                    LogFile.Error.Show("ERROR:DifferentToObjectInitialValue:Globals.eDBType.DB_Int32:ObjectInitialValue.GetType() != typeof(int)!");
                                    return false;
                                }
                                //break;

                            case Globals.eDBType.DB_Int64:
                                if (ObjectInitialValue.GetType() == typeof(long))
                                {
                                    long l = (long)ObjectInitialValue;
                                    long ledited = Convert.ToInt64(nmUpDown.Value);
                                    if (ledited != l)
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
                                    LogFile.Error.Show("ERROR:DifferentToObjectInitialValue:Globals.eDBType.DB_Int64:ObjectInitialValue.GetType() != typeof(int)!");
                                    return false;
                                }
                                //break;
                        }
                        break;

                    case Globals.eDBType.DB_Money:
                        if (ObjectInitialValue.GetType() == typeof(decimal))
                        {
                            decimal d = (decimal)ObjectInitialValue;
                            decimal dedited = MoneyUpDown.Value;
                            if (dedited != d)
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
                            LogFile.Error.Show("ERROR:DifferentToObjectInitialValue:Globals.eDBType.DB_Money:ObjectInitialValue.GetType() != typeof(decimal)!");
                            return false;
                        }
                        //break;

                    case Globals.eDBType.DB_decimal:
                        if (ObjectInitialValue.GetType() == typeof(decimal))
                        {
                            decimal d = (decimal)ObjectInitialValue;
                            decimal dedited = nmUpDown.Value;
                            if (dedited != d)
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
                            LogFile.Error.Show("ERROR:DifferentToObjectInitialValue:Globals.eDBType.DB_decimal:ObjectInitialValue.GetType() != typeof(decimal)!");
                            return false;
                        }
                        //break;


                    case Globals.eDBType.DB_Percent:
                        if (ObjectInitialValue.GetType() == typeof(decimal))
                        {
                            decimal d = (decimal)ObjectInitialValue;
                            decimal dedited = PercentUpDown.Value;
                            if (dedited != d)
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
                            LogFile.Error.Show("ERROR:DifferentToObjectInitialValue:Globals.eDBType.DB_Percent:ObjectInitialValue.GetType() != typeof(decimal)!");
                            return false;
                        }
                        //break;

                    case Globals.eDBType.DB_varbinary_max:
                        return false;
                        //break;

                    case Globals.eDBType.DB_Image:
                        return false;
                       // break;

                    case Globals.eDBType.DB_Document:
                        return false;
                       // break;

                    case Globals.eDBType.DB_varchar_264:
                    case Globals.eDBType.DB_varchar_250:
                    case Globals.eDBType.DB_varchar_64:
                    case Globals.eDBType.DB_varchar_50:
                    case Globals.eDBType.DB_varchar_45:
                    case Globals.eDBType.DB_varchar_32:
                    case Globals.eDBType.DB_varchar_25:
                    case Globals.eDBType.DB_varchar_10:
                    case Globals.eDBType.DB_varchar_5:
                        if (ObjectInitialValue.GetType() == typeof(string))
                        {
                            string s = (string)ObjectInitialValue;
                            string sedited = null;
                            if (m_col.Style == Column.eStyle.Password)
                            {
                                sedited = txtPassword.Text;
                            }
                            else
                            {
                                sedited = txtBox.Text;
                            }
                            if (!sedited.Equals(s))
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
                            LogFile.Error.Show("ERROR:DifferentToObjectInitialValue:Globals.eDBType.DB_varchar_XX:ObjectInitialValue.GetType() != typeof(string)!");
                            return false;
                        }
                        //break;

                    case Globals.eDBType.DB_varchar_2000:
                    case Globals.eDBType.DB_varchar_max:
                        if (ObjectInitialValue.GetType() == typeof(string))
                        {
                            string s = (string)ObjectInitialValue;
                            string sedited = RichtxtBox.Text;
                            if (!sedited.Equals(s))
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
                            LogFile.Error.Show("ERROR:DifferentToObjectInitialValue:Globals.eDBType.DB_varchar_2000 or DB_varchar_max:ObjectInitialValue.GetType() != typeof(string)!");
                            return false;
                        }
                        //break;
                    case Globals.eDBType.DB_DateTime:
                        if (ObjectInitialValue.GetType() == typeof(DateTime))
                        {
                            DateTime date_time = (DateTime)ObjectInitialValue;
                            DateTime date_time_edited = this.DateTimeInput.Value;
                            if (!date_time_edited.Equals(date_time))
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
                            LogFile.Error.Show("ERROR:DifferentToObjectInitialValue:Globals.eDBType.DB_DateTime or DB_DateTime:ObjectInitialValue.GetType() != typeof(DateTime)!");
                            return false;
                        }
                        //break;

                    case Globals.eDBType.DB_UNKNOWN:
                        LogFile.Error.Show("ERROR in public InputControl(..) Can not find Globals.Get_eDBType(m_col.obj) from object:" + m_col.obj.GetType().ToString());
                        return false;
                        //break;

                }
                return false;
            }
        }

        private bool DifferentToObjectInitialValue()
        {
            if (usrc_lbl.Initial_NoData != null)
            {
                if (usrc_lbl.Initial_NoData.v != usrc_lbl.Null_Selected)
                {
                    return true;
                }
                else
                {
                    if (!usrc_lbl.Initial_NoData.v)
                    {
                        return DifferentToObjectInitialValue_not_null();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return DifferentToObjectInitialValue_not_null();
            }
        }

        public void nmUpDown_ValueChanged(object sender, EventArgs e)
        {
            InputControl_ValueChanged(sender);
        }

        public void txtBox_TextChanged(object sender, EventArgs e)
        {
            InputControl_ValueChanged(sender);
        }

        public void DateTimeInput_ValueChanged(object sender, EventArgs e)
        {
            InputControl_ValueChanged(sender);
        }

        public void chkBox_CheckedChanged(object sender, EventArgs e)
        {
            InputControl_ValueChanged(sender);
        }

        public void InputControl_GotFocus(object sender, EventArgs e)
        {
            try
            {
                Control ctrl = (Control)sender;
                ctrl.BackColor = Color.White;
            }
            catch
            {
            }
        }

        private void OnButtonClick_FolderSelect(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Button))
            {
                Button btnSelect = (Button)sender;
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    TextBox txtBox = (TextBox)btnSelect.Tag;
                    txtBox.Text = fbd.SelectedPath;
                    InputControl_ValueChanged(sender);
                }
            }

        }
        private void OnButtonClick_DocumentSelect(object sender, EventArgs e)
        {

            if (sender.GetType() == typeof(Button))
            {
                Button btnSelect = (Button)sender;
                DialogResult dRes;
                OpenFileDialog opnFileDlg = new OpenFileDialog();
                opnFileDlg.Filter = "Document files (*.doc)|*.doc|(*.pdf)|*.pdf|(*.odt)|*.odt|(*.docx)|*.docx|(*.xls)|*.xls|All files (*.*)|*.* ";
                opnFileDlg.FilterIndex = 2;
                opnFileDlg.FileName = "*.*"; //PathImport + "\\" + btnSelectFile.m_InputTextBox.Text;
                opnFileDlg.InitialDirectory = PathImportDocument;
                opnFileDlg.RestoreDirectory = true;
                dRes = opnFileDlg.ShowDialog();
                if (dRes == DialogResult.OK)
                {
                    PathImportDocument = Path.GetDirectoryName(opnFileDlg.FileName);
                    Properties.Settings.Default.SelectDocumentPath = PathImportDocument;
                    Properties.Settings.Default.Save();

                    //Document = File.ReadAllBytes(opnFileDlg.FileName);
                    InputControl_ValueChanged(sender);
                }
            }
        }

        public void EventHandler_Set(bool b)
        {
            if (bReadOnly)
            {
                return;
            }
            m_eDBType = Globals.Get_eDBType(m_col.obj);
            switch (m_eDBType)
            {

                case Globals.eDBType.DB_bit:
                    switch (m_col.Style)
                    {
                        case Column.eStyle.none:
                        case Column.eStyle.CheckBox:
                        case Column.eStyle.CheckBox_default_true:
                            if (b)
                            {
                                chkBox.CheckedChanged += new EventHandler(chkBox_CheckedChanged);
                                chkBox.GotFocus += new EventHandler(InputControl_GotFocus);
                            }
                            else
                            {
                                chkBox.CheckedChanged -= chkBox_CheckedChanged;
                                chkBox.GotFocus -= InputControl_GotFocus;
                            }
                            break;

                        case Column.eStyle.RadioButtons:
                            if (b)
                            {
                                rdbButton1.CheckedChanged += new EventHandler(chkBox_CheckedChanged);
                                rdbButton2.CheckedChanged += new EventHandler(chkBox_CheckedChanged);
                                rdbButton1.GotFocus += new EventHandler(InputControl_GotFocus);
                                rdbButton2.GotFocus += new EventHandler(InputControl_GotFocus);
                            }
                            else
                            {
                                rdbButton1.CheckedChanged -= chkBox_CheckedChanged;
                                rdbButton2.CheckedChanged -= chkBox_CheckedChanged;
                                rdbButton1.GotFocus -= InputControl_GotFocus;
                                rdbButton2.GotFocus -= InputControl_GotFocus;
                            }
                            break;

                        default:
                            break;
                    }
                    break;

                case Globals.eDBType.DB_smallInt:
                case Globals.eDBType.DB_Int32:
                case Globals.eDBType.DB_Int64:
                    if (b)
                    {
                        nmUpDown.ValueChanged += new usrc_NumericUpDown.delegate_ValueChanged(nmUpDown_ValueChanged);
                        nmUpDown.GotFocus += new EventHandler(InputControl_GotFocus);
                    }
                    else
                    {
                        nmUpDown.ValueChanged -= nmUpDown_ValueChanged;
                        nmUpDown.GotFocus -= InputControl_GotFocus;
                    }
                    break;

                case Globals.eDBType.DB_Money:
                    if (b)
                    {
                        MoneyUpDown.ValueChanged += new usrc_NumericUpDown.delegate_ValueChanged(MoneyUpDown_ValueChanged);
                        MoneyUpDown.GotFocus += new EventHandler(nmUpDown_ValueChanged);
                    }
                    else
                    {
                        MoneyUpDown.ValueChanged -= MoneyUpDown_ValueChanged;
                        MoneyUpDown.GotFocus -= nmUpDown_ValueChanged;
                    }
                    break;

                case Globals.eDBType.DB_decimal:
                    if (b)
                    {
                        nmUpDown.ValueChanged += new usrc_NumericUpDown.delegate_ValueChanged(nmUpDown_ValueChanged);
                        nmUpDown.GotFocus += new EventHandler(InputControl_GotFocus);
                    }
                    else
                    {
                        nmUpDown.ValueChanged -= nmUpDown_ValueChanged;
                        nmUpDown.GotFocus -= InputControl_GotFocus;
                    }

                    break;

                case Globals.eDBType.DB_Percent:
                    if (b)
                    {
                        PercentUpDown.ValueChanged += new usrc_NumericUpDown.delegate_ValueChanged(PercentUpDown_ValueChanged);
                        PercentUpDown.GotFocus += new EventHandler(InputControl_GotFocus);
                    }
                    else
                    {
                        PercentUpDown.ValueChanged -= PercentUpDown_ValueChanged;
                        PercentUpDown.GotFocus -= InputControl_GotFocus;
                    }
                    break;

                case Globals.eDBType.DB_DateTime:
                    if (b)
                    {
                        DateTimeInput.ValueChanged += new usrc_InputControl_DateTimePicker.delegate_ValueChanged(DateTimeInput_ValueChanged);
                        DateTimeInput.GotFocus += new usrc_InputControl_DateTimePicker.delegate_GotFocus(InputControl_GotFocus);
                    }
                    else
                    {
                        DateTimeInput.ValueChanged -= DateTimeInput_ValueChanged;
                        DateTimeInput.GotFocus -= InputControl_GotFocus;
                    }

                    break;

                case Globals.eDBType.DB_varbinary_max:
                    if (b)
                    {
                        DataBox.GotFocus += new EventHandler(InputControl_GotFocus);
                    }
                    else
                    {
                        DataBox.GotFocus -= InputControl_GotFocus;
                    }

                    break;

                case Globals.eDBType.DB_Image:
                    if (b)
                    {
                        Picture_Box.GotFocus += new EventHandler(InputControl_GotFocus);
                    }
                    else
                    {
                        Picture_Box.GotFocus -= InputControl_GotFocus;
                    }
                    break;

                case Globals.eDBType.DB_Document:
                    Document_Box.GotFocus += new EventHandler(InputControl_GotFocus);
                    break;

                case Globals.eDBType.DB_varchar_264:
                case Globals.eDBType.DB_varchar_250:
                case Globals.eDBType.DB_varchar_64:
                case Globals.eDBType.DB_varchar_50:
                case Globals.eDBType.DB_varchar_45:
                case Globals.eDBType.DB_varchar_32:
                case Globals.eDBType.DB_varchar_25:
                case Globals.eDBType.DB_varchar_10:
                case Globals.eDBType.DB_varchar_5:
                    if (b)
                    {
                        if (m_col.Style == Column.eStyle.Password)
                        {
                            txtPassword.PasswordTextChanged += TxtPassword_TextChanged; 
                            txtPassword.GotFocus += new EventHandler(InputControl_GotFocus);
                        }
                        else
                        {
                            txtBox.TextChanged += new EventHandler(txtBox_TextChanged);
                            txtBox.GotFocus += new EventHandler(InputControl_GotFocus);
                            if (btnFolderSelect != null)
                            {
                                btnFolderSelect.Click += new EventHandler(OnButtonClick_FolderSelect);
                            }
                        }
                    }
                    else
                    {
                        if (m_col.Style == Column.eStyle.Password)
                        {
                            txtPassword.PasswordTextChanged -= TxtPassword_TextChanged;
                            txtPassword.GotFocus -= InputControl_GotFocus;
                        }
                        else
                        {
                            txtBox.TextChanged -= txtBox_TextChanged;
                            txtBox.GotFocus -= InputControl_GotFocus;
                            if (btnFolderSelect != null)
                            {
                                btnFolderSelect.Click -= OnButtonClick_FolderSelect;
                            }
                        }
                    }
                    break;

                case Globals.eDBType.DB_varchar_2000:
                case Globals.eDBType.DB_varchar_max:
                    if (b)
                    {
                        if (m_col.Style == Column.eStyle.Password)
                        {
                            txtPassword.PasswordTextChanged += TxtPassword_TextChanged;
                            txtPassword.GotFocus += new EventHandler(InputControl_GotFocus);
                        }
                        else
                        {
                            RichtxtBox.TextChanged += new EventHandler(txtBox_TextChanged);
                            RichtxtBox.GotFocus += new EventHandler(InputControl_GotFocus);
                        }
                    }
                    else
                    {
                        if (m_col.Style == Column.eStyle.Password)
                        {
                            txtPassword.PasswordTextChanged -= TxtPassword_TextChanged;
                            txtPassword.GotFocus -= InputControl_GotFocus;
                        }
                        else
                        {

                            RichtxtBox.TextChanged -= txtBox_TextChanged;
                            RichtxtBox.GotFocus -= InputControl_GotFocus;
                        }
                    }

                    break;

                case Globals.eDBType.DB_UNKNOWN:
                    LogFile.Error.Show("ERROR in public InputControl(..) Can not find Globals.Get_eDBType(m_col.obj) from object:" + m_col.obj.GetType().ToString());
                    break;

            }
        }


        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            InputControl_ValueChanged(sender);
        }

        public void CreateInputControls(SQLTable pParentTbl, UniqueControlName xuctrln, Type myType)
        {
            m_eDBType = Globals.Get_eDBType(m_col.obj);
            usrc_lbl.ReadOnly = bReadOnly;
            switch (m_eDBType)
            {

                case Globals.eDBType.DB_bit:
                    switch (m_col.Style)
                    {
                        case Column.eStyle.none:
                        case Column.eStyle.CheckBox:
                        case Column.eStyle.CheckBox_default_true:
                        case Column.eStyle.ReadOnly_CheckBox_default_true:
                            chkBox = new usrc_CheckBox(xuctrln);
                            chkBox.ReadOnly = bReadOnly;
                            chkBox.Left = usrc_lbl.Left + usrc_lbl.Width + dist;
                            chkBox.Top = usrc_lbl.Top;
                            this.Controls.Add(chkBox);
                            chkBox.Text = "";
                            chkBox.AutoSize = false;
                            chkBox.Width = chkBoxWidth;
                            chkBox.Height = usrc_InputControl_Height;
                            chkBox.Visible = true;
                            chkBox.BackColor = Color.Transparent;
                            m_active_ctrl_List.Add(chkBox);
                            if ((m_col.Style == Column.eStyle.CheckBox_default_true)
                               ||
                               (m_col.Style == Column.eStyle.ReadOnly_CheckBox_default_true))
                            {
                                chkBox.Checked = true;
                                m_Defined = true;
                                if (m_col.Style == Column.eStyle.ReadOnly_CheckBox_default_true)
                                {
                                    chkBox.ReadOnly = true;
                                }
                            }
                            break;

                        case Column.eStyle.RadioButtons:
                            rdbButton1 = new usrc_RadioButton(xuctrln);
                            rdbButton1.ReadOnly = bReadOnly;
                            rdbButton2 = new usrc_RadioButton(xuctrln);
                            rdbButton2.ReadOnly = bReadOnly;

                            rdbButton1.Left = usrc_lbl.Left + usrc_lbl.Width + dist;
                            rdbButton1.Top = usrc_lbl.Top;
                            rdbButton2.Left = rdbButton1.Left + rdbButton1.Width + dist;
                            rdbButton2.Top = usrc_lbl.Top;

                            this.Controls.Add(rdbButton1);
                            this.Controls.Add(rdbButton2);

                            usrc_lbl.Text = SetRadioButtonText(rdbButton1, rdbButton2);

                            rdbButton1.AutoSize = false;
                            rdbButton1.Width = rdbButtonWidth;
                            rdbButton1.Height = usrc_InputControl_Height;
                            rdbButton1.Visible = true;
                            rdbButton1.BackColor = Color.Transparent;

                            rdbButton2.AutoSize = false;
                            rdbButton2.Width = rdbButtonWidth;
                            rdbButton2.Height = usrc_InputControl_Height;
                            rdbButton2.Visible = true;
                            rdbButton2.BackColor = Color.Transparent;
                            m_active_ctrl_List.Add(rdbButton1);
                            m_active_ctrl_List.Add(rdbButton2);
                            break;

                        default:
                            break;
                    }
                    break;

                case Globals.eDBType.DB_smallInt:
                case Globals.eDBType.DB_Int32:
                case Globals.eDBType.DB_Int64:
                    nmUpDown = new usrc_NumericUpDown(bReadOnly, xuctrln.Get_usrc_NumericUpDown_UniqueIndex());
                    nmUpDown.ReadOnly = bReadOnly;
                    nmUpDown.Left = usrc_lbl.Left + usrc_lbl.Width + dist;
                    nmUpDown.Top = usrc_lbl.Top;

                    if (bReadOnly||(m_col.Style == Column.eStyle.TextBox_ReadOnly))
                    {
                        nmUpDown.ReadOnly = true;
                        nmUpDown.BackColor = Color.LightGray;
                    }
                    this.Controls.Add(nmUpDown);
                    nmUpDown.Type = usrc_NumericUpDown.eType.INTEGER;
                    nmUpDown.ValueMultiplier = 1;
                    nmUpDown.Visible = true;
                    nmUpDown.Tag = this;
                    nmUpDown.Maximum = int.MaxValue;
                    nmUpDown.Minimum = 0;
                    nmUpDown.Value = nmUpDown.Minimum;
                    switch (m_eDBType)
                    {
                        case Globals.eDBType.DB_smallInt:
                            ObjectInitialValue = Convert.ToInt16(nmUpDown.Value);
                            break;
                        case Globals.eDBType.DB_Int32:
                            ObjectInitialValue = Convert.ToInt32(nmUpDown.Value);
                            break;
                        case Globals.eDBType.DB_Int64:
                            ObjectInitialValue = Convert.ToInt64(nmUpDown.Value);
                            break;
                    }
                    nmUpDown.Increment = 1;
                    this.Width = usrc_lbl.Width + dist + nmUpDown.Width;
                    this.Height = nmUpDown.Height;
                    m_active_ctrl_List.Add(nmUpDown);
                    break;

                case Globals.eDBType.DB_Money:
                    MoneyUpDown = new usrc_NumericUpDown(bReadOnly, xuctrln.Get_usrc_NumericUpDown_UniqueIndex());
                    MoneyUpDown.ValueMultiplier = 1;
                    MoneyUpDown.Type = usrc_NumericUpDown.eType.CURRENCY;
                    MoneyUpDown.Left = usrc_lbl.Left + usrc_lbl.Width + dist;
                    MoneyUpDown.Top = usrc_lbl.Top;

                    if (bReadOnly || (m_col.Style == Column.eStyle.TextBox_ReadOnly))
                    {
                        MoneyUpDown.ReadOnly = true;
                        MoneyUpDown.BackColor = Color.LightGray;
                    }
                    MoneyUpDown.DecimalPlaces = 3;
                    this.Controls.Add(MoneyUpDown);
                    MoneyUpDown.Visible = true;
                    MoneyUpDown.Tag = this;
                    MoneyUpDown.Maximum = 1000000000;
                    MoneyUpDown.Minimum = 0;
                    MoneyUpDown.Value = MoneyUpDown.Minimum;
                    ObjectInitialValue = MoneyUpDown.Value;
                    MoneyUpDown.Increment = 0.01M;
                    this.Width = usrc_lbl.Width + dist + MoneyUpDown.Width;
                    this.Height = MoneyUpDown.Height;
                    m_active_ctrl_List.Add(MoneyUpDown);
                    break;

                case Globals.eDBType.DB_decimal:
                    nmUpDown = new usrc_NumericUpDown(bReadOnly, xuctrln.Get_usrc_NumericUpDown_UniqueIndex());
                    nmUpDown.Left = usrc_lbl.Left + usrc_lbl.Width + dist;
                    nmUpDown.Top = usrc_lbl.Top;

                    if (bReadOnly || (m_col.Style == Column.eStyle.TextBox_ReadOnly))
                    {
                        nmUpDown.ReadOnly = true;
                        nmUpDown.BackColor = Color.LightGray;
                    }
                    nmUpDown.Type = usrc_NumericUpDown.eType.INTEGER;
                    nmUpDown.ValueMultiplier = 1;
                    nmUpDown.DecimalPlaces = 2;
                    this.Controls.Add(nmUpDown);
                    nmUpDown.Visible = true;
                    nmUpDown.Tag = this;
                    nmUpDown.Maximum = 1000000;
                    nmUpDown.Minimum = 0;
                    nmUpDown.Value = nmUpDown.Minimum;
                    ObjectInitialValue = nmUpDown.Value;
                    nmUpDown.Increment = 0.01M;
                    this.Width = usrc_lbl.Width + dist + nmUpDown.Width;
                    this.Height = nmUpDown.Height;
                    m_active_ctrl_List.Add(nmUpDown);
                    break;

                case Globals.eDBType.DB_Percent:
                    PercentUpDown = new usrc_NumericUpDown(bReadOnly, xuctrln.Get_usrc_NumericUpDown_UniqueIndex());
                    PercentUpDown.ValueMultiplier = 100;
                    PercentUpDown.Unit = " %";
                    PercentUpDown.Type = usrc_NumericUpDown.eType.PERCENT;
                    PercentUpDown.Left = usrc_lbl.Left + usrc_lbl.Width + dist;
                    PercentUpDown.Top = usrc_lbl.Top;

                    if (bReadOnly || (m_col.Style == Column.eStyle.TextBox_ReadOnly))
                    {
                        PercentUpDown.ReadOnly = true;
                        PercentUpDown.BackColor = Color.LightGray;
                    }
                    PercentUpDown.DecimalPlaces = 1;
                    this.Controls.Add(PercentUpDown);
                    PercentUpDown.Visible = true;
                    PercentUpDown.Tag = this;
                    PercentUpDown.Maximum = 1;
                    PercentUpDown.Minimum = 0;
                    PercentUpDown.Value = PercentUpDown.Minimum;
                    ObjectInitialValue = PercentUpDown.Value;
                    PercentUpDown.Increment = 0.005M;
                    this.Width = usrc_lbl.Width + dist + PercentUpDown.Width;
                    this.Height = PercentUpDown.Height;
                    m_active_ctrl_List.Add(PercentUpDown);
                    break;

                case Globals.eDBType.DB_DateTime:
                    DateTimeInput = new usrc_InputControl_DateTimePicker(xuctrln,bReadOnly);
                    DateTimeInput.Left = usrc_lbl.Left + usrc_lbl.Width + dist;
                    DateTimeInput.Top = usrc_lbl.Top;
                    this.Controls.Add(DateTimeInput);
                    DateTimeInput.Visible = true;
                    switch (m_col.Style)
                    {
                        case Column.eStyle.DateTimePicker_ReadOnly:
                            DateTimeInput.Enabled = false;
                            break;
                        case Column.eStyle.DateTimePicker_MinDate:
                            DateTimeInput.Value = DateTimeInput.MinDate;
                            ObjectInitialValue = DateTimeInput.Value;
                            break;
                        case Column.eStyle.DateTimePicker_Now:
                            DateTime DateToday = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);
                            DateTimeInput.Value = DateToday;
                            ObjectInitialValue = DateTimeInput.Value;
                            Defined = true;
                            break;
                        default:
                            ObjectInitialValue = DateTimeInput.Value;
                            break;
                    }


                    DateTimeInput.Tag = this;
                    this.Width = usrc_lbl.Width + dist + DateTimeInput.Width;
                    this.Height = DateTimeInput.Height;
                    m_active_ctrl_List.Add(DateTimeInput);
                    break;

                case Globals.eDBType.DB_varbinary_max:
                    DataBox = new usrc_InputControl_DataBox(xuctrln);
                    DataBox.Left = usrc_lbl.Left + usrc_lbl.Width + dist;
                    DataBox.Top = usrc_lbl.Top;
                    this.Controls.Add(DataBox);
                    DataBox.Width = DataBoxWidth;
                    DataBox.Height = DataBoxHeight;
                    DataBox.Visible = true;
                    DataBox.Data = null;
                    DataBox.Tag = this;
                    this.Width = usrc_lbl.Width + dist + DataBoxWidth;
                    this.Height = DataBoxHeight;
                    m_active_ctrl_List.Add(DataBox);
                    break;

                case Globals.eDBType.DB_Image:
                    Picture_Box = new Picture_Box(this, xuctrln, pParentTbl, PictureBoxWidth, PictureBoxHeight,bReadOnly);
                    Picture_Box.Left = usrc_lbl.Left + usrc_lbl.Width + dist;
                    Picture_Box.Top = usrc_lbl.Top;
                    if (Picture_Box.btnFolderSelect!=null)
                    { 
                        Picture_Box.btnFolderSelect.Left = usrc_lbl.Left + usrc_lbl.Width - 32;
                        Picture_Box.btnFolderSelect.Top = usrc_lbl.Top + usrc_lbl.Height + 5;
                    }
                    //Picture_Box.Width = PictureBoxWidth;
                    //Picture_Box.Height = 400;
                    this.Controls.Add(Picture_Box);
                    Picture_Box.Visible = true;
                    Picture_Box.Picture.Image = Properties.Resources.DefPictureImage;
                    Picture_Box.Tag = this;

                    if (Picture_Box.btnFolderSelect != null)
                    {
                        this.Width = usrc_lbl.Width + dist + Picture_Box.Width + dist + Picture_Box.btnFolderSelect.Width;
                    }
                    else
                    {
                        this.Width = usrc_lbl.Width + dist + Picture_Box.Width + dist;
                    }
                    this.Height = Picture_Box.Top + Picture_Box.Height + 2;

                    m_active_ctrl_List.Add(Picture_Box);
                    break;

                case Globals.eDBType.DB_Document:
                    Document_Box = new InputControl_DocumentBox(this, xuctrln);
                    Document_Box.Left = usrc_lbl.Left + usrc_lbl.Width + dist;
                    Document_Box.Top = usrc_lbl.Top;
                    if (btnFolderSelect!=null)
                    { 
                    btnFolderSelect.Left = Document_Box.Left + Document_Box.Width + dist;
                    btnFolderSelect.Top = usrc_lbl.Top;
                    }
                    this.Controls.Add(Document_Box);
                    Document_Box.Width = DocumentBoxWidth;
                    Document_Box.Height = DocumentBoxHeight;
                    Document_Box.Visible = true;
                    //Document_Box.Picture.Image = Properties.Resources.DefPictureImage;
                    Document_Box.Tag = this;
                    //Document_Box.FileInfo_Box.btnFileSelect.Click += new EventHandler(this.OnButtonClick_DocumentSelect);
                    this.Width = Document_Box.Width + dist + PictureBoxWidth;
                    this.Height = Document_Box.Height;
                    m_active_ctrl_List.Add(Document_Box);
                    break;

                case Globals.eDBType.DB_varchar_264:
                case Globals.eDBType.DB_varchar_250:
                case Globals.eDBType.DB_varchar_64:
                case Globals.eDBType.DB_varchar_50:
                case Globals.eDBType.DB_varchar_45:
                case Globals.eDBType.DB_varchar_32:
                case Globals.eDBType.DB_varchar_25:
                case Globals.eDBType.DB_varchar_10:
                case Globals.eDBType.DB_varchar_5:
                    if (m_col.Style == Column.eStyle.Password)
                    {
                        txtPassword = new Password.usrc_PasswordDefinition();
                        txtPassword.Name = "upwd_" + xuctrln.Get_usrc_PasswordDefinition_UniqueIndex();
                        txtPassword.PasswordLocked = true;
                        txtPassword.Width = txtBox_Width;
                        txtPassword.Left = usrc_lbl.Left + usrc_lbl.Width + dist;
                        txtPassword.Top = usrc_lbl.Top;
                        this.Controls.Add(txtPassword);
                        txtPassword.Visible = true;
                        txtPassword.Tag = this;
                        m_active_ctrl_List.Add(txtPassword);
                        int iMaxLength = Func.GetMaxStringLength(myType);
                        if (iMaxLength > 0)
                        {
                            txtPassword.MaxLength = iMaxLength;
                        }
                        this.Width = usrc_lbl.Width + dist + txtPassword.Width;
                        this.Height = txtPassword.Height;
                        m_col.Style = Column.eStyle.Password;
                    }
                    else
                    { 
                        txtBox = new TextBox();
                        txtBox.Name = "txt_" + xuctrln.Get_TextBox_UniqueIndex();
                        txtBox.Width = txtBox_Width;
                        if (bReadOnly || (m_col.Style == Column.eStyle.TextBox_ReadOnly))
                        {
                            txtBox.ReadOnly = true;
                            txtBox.BackColor = Color.LightGray;
                            txtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
                            txtBox.Cursor = Cursors.No;
                        }
                        else
                        {
                            txtBox.Cursor = Cursors.IBeam;
                        }
                        txtBox.Left = usrc_lbl.Left + usrc_lbl.Width + dist;
                        txtBox.Top = usrc_lbl.Top;
                        this.Controls.Add(txtBox);
                        txtBox.Visible = true;
                        txtBox.Tag = this;
                        m_active_ctrl_List.Add(txtBox);
                        int iMaxLength = Func.GetMaxStringLength(myType);
                        if (iMaxLength > 0)
                        {
                            txtBox.MaxLength = iMaxLength;
                        }
                        if (m_col.Style == Column.eStyle.FileSelection)
                        {
                            if (!bReadOnly)
                            {
                                btnFolderSelect = new Button();
                                btnFolderSelect.Name = "btnfoldersel" + xuctrln.Get_Button_UniqueIndex();
                                btnFolderSelect.Left = txtBox.Left + txtBox.Width + dist;
                                btnFolderSelect.Top = usrc_lbl.Top;
                                this.Controls.Add(btnFolderSelect);
                                btnFolderSelect.Width = BtnFileSelectWidth;
                                btnFolderSelect.Height = btnFolderSelect_Height;
                                btnFolderSelect.Image = Properties.Resources.SmallFolderIcon.ToBitmap();
                                btnFolderSelect.Text = "";
                                btnFolderSelect.Visible = true;
                                btnFolderSelect.Tag = txtBox;
                                this.Width = usrc_lbl.Width + dist + txtBox.Width + dist + btnFolderSelect.Width;
                                this.Height = txtBox.Height;
                            }

                        }
                        else
                        {
                            this.Width = usrc_lbl.Width + dist + txtBox.Width;
                            this.Height = txtBox.Height;
                            m_col.Style = Column.eStyle.TextBox;
                        }
                    }
                    break;

                case Globals.eDBType.DB_varchar_2000:
                case Globals.eDBType.DB_varchar_max:
                    m_col.Style = Column.eStyle.RichTextBox;
                    RichtxtBox = new RichTextBox();
                    RichtxtBox.Name = "rtxt_" + xuctrln.Get_RichTextBox_UniqueIndex();
                    RichtxtBox.Left = usrc_lbl.Left + usrc_lbl.Width + dist;
                    RichtxtBox.Top = usrc_lbl.Top;
                    if (bReadOnly || (m_col.Style == Column.eStyle.TextBox_ReadOnly))
                    {
                        RichtxtBox.ReadOnly = true;
                        RichtxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        RichtxtBox.Cursor = Cursors.No;
                    }
                    else
                    {
                        RichtxtBox.Cursor = Cursors.IBeam;
                    }
                    this.Controls.Add(RichtxtBox);
                    RichtxtBox.Width = RichTextBoxWidth;
                    RichtxtBox.Height = RichTextBoxHeight;
                    RichtxtBox.Visible = true;
                    RichtxtBox.Multiline = true;
                    RichtxtBox.Tag = this;
                    m_active_ctrl_List.Add(RichtxtBox);
                    this.Width = RichtxtBox.Left + RichtxtBox.Width + 2;
                    this.Height = RichtxtBox.Height;
                    break;

                case Globals.eDBType.DB_UNKNOWN:
                    LogFile.Error.Show("ERROR in public InputControl(..) Can not find Globals.Get_eDBType(m_col.obj) from object:" + m_col.obj.GetType().ToString());
                    break;

            }
        }

        public void SetDefault()
        {
            ObjectInitialValue = null;
            m_eDBType = Globals.Get_eDBType(m_col.obj);
            switch (m_eDBType)
            {

                case Globals.eDBType.DB_bit:
                    switch (m_col.Style)
                    {
                        case Column.eStyle.none:
                        case Column.eStyle.CheckBox:
                        case Column.eStyle.CheckBox_default_true:
                        case Column.eStyle.ReadOnly_CheckBox_default_true:
                            if ((m_col.Style == Column.eStyle.CheckBox_default_true) || (m_col.Style == Column.eStyle.ReadOnly_CheckBox_default_true))
                            {
                                chkBox.Checked = true;
                                ObjectInitialValue = true;
                            }
                            else
                            {
                                chkBox.Checked = false;
                                ObjectInitialValue = false;
                            }
                            break;

                        case Column.eStyle.RadioButtons:
                            rdbButton1.Checked = true;
                            ObjectInitialValue = true;
                            break;

                        default:
                            break;
                    }
                    break;

                case Globals.eDBType.DB_smallInt:
                case Globals.eDBType.DB_Int32:
                case Globals.eDBType.DB_Int64:
                    nmUpDown.Value = nmUpDown.Minimum;
                    switch (m_eDBType)
                    {
                        case Globals.eDBType.DB_smallInt:
                            ObjectInitialValue = Convert.ToInt16(nmUpDown.Value);
                            break;
                        case Globals.eDBType.DB_Int32:
                            ObjectInitialValue = Convert.ToInt32(nmUpDown.Value);
                            break;
                        case Globals.eDBType.DB_Int64:
                            ObjectInitialValue = Convert.ToInt64(nmUpDown.Value);
                            break;
                    }
                    break;

                case Globals.eDBType.DB_Money:
                    MoneyUpDown.Value = MoneyUpDown.Minimum;
                    ObjectInitialValue = MoneyUpDown.Value;
                    break;

                case Globals.eDBType.DB_decimal:
                    nmUpDown.Value = nmUpDown.Minimum;
                    ObjectInitialValue = nmUpDown.Value;
                    break;

                case Globals.eDBType.DB_Percent:
                    PercentUpDown.Value = PercentUpDown.Minimum;
                    ObjectInitialValue = PercentUpDown.Value;
                    break;

                case Globals.eDBType.DB_DateTime:
                    switch (m_col.Style)
                    {
                        case Column.eStyle.DateTimePicker_ReadOnly:
                            DateTimeInput.Enabled = false;
                            break;
                        case Column.eStyle.DateTimePicker_MinDate:
                            DateTimeInput.Value = DateTimeInput.MinDate;
                            ObjectInitialValue = DateTimeInput.Value;
                            break;
                        case Column.eStyle.DateTimePicker_Now:
                            DateTime DateToday = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                            DateTimeInput.Value = DateToday;
                            ObjectInitialValue = DateTimeInput.Value;
                            Defined = true;
                            break;
                        default:
                            ObjectInitialValue = DateTimeInput.Value;
                            break;
                    }
                    break;

                case Globals.eDBType.DB_varbinary_max:
                    break;

                case Globals.eDBType.DB_Image:
                    break;

                case Globals.eDBType.DB_Document:
                    break;

                case Globals.eDBType.DB_varchar_264:
                case Globals.eDBType.DB_varchar_250:
                case Globals.eDBType.DB_varchar_64:
                case Globals.eDBType.DB_varchar_50:
                case Globals.eDBType.DB_varchar_45:
                case Globals.eDBType.DB_varchar_32:
                case Globals.eDBType.DB_varchar_25:
                case Globals.eDBType.DB_varchar_10:
                case Globals.eDBType.DB_varchar_5:
                    if (m_col.Style == Column.eStyle.Password)
                    {
                        txtPassword.Text = "";
                    }
                    else
                    {
                        txtBox.Text = "";
                    }
                    break;

                case Globals.eDBType.DB_varchar_2000:
                case Globals.eDBType.DB_varchar_max:
                    RichtxtBox.Text = "";
                    break;

                case Globals.eDBType.DB_UNKNOWN:
                    LogFile.Error.Show("ERROR in public InputControl(..) Can not find Globals.Get_eDBType(m_col.obj) from object:" + m_col.obj.GetType().ToString());
                    break;

            }

        }



        public void Init(SQLTable pParentTbl, UniqueControlName xuctrln, Column col, List<usrc_InputControl> inpCtrlList, string sImportExportVec, bool bNumber, bool xbReadOnly)
        {
            bReadOnly = xbReadOnly;
            if (bReadOnly)
            {
                this.Cursor = Cursors.No;
            }
            else
            {
                this.Cursor = Cursors.Arrow;
            }
            m_active_ctrl_List.Clear();
            m_ParentTbl = pParentTbl;
            m_inpCtrlList = inpCtrlList;
            this.m_PathImportPicture = Properties.Settings.Default.SelectPicturePath;
            if (m_PathImportPicture == null)
            {
                m_PathImportPicture = Path.GetDirectoryName(Application.CommonAppDataPath);
            }
            else if (m_PathImportPicture.Length == 0)
            {
                m_PathImportPicture = Path.GetDirectoryName(Application.CommonAppDataPath);
            }

            this.m_PathImportDocument = Properties.Settings.Default.SelectDocumentPath;
            if (m_PathImportDocument == null)
            {
                m_PathImportDocument = Path.GetDirectoryName(Application.CommonAppDataPath);
            }
            else if (m_PathImportDocument.Length == 0)
            {
                m_PathImportDocument = Path.GetDirectoryName(Application.CommonAppDataPath);
            }

            bIsNumber = bNumber;
            sImportExportVector = sImportExportVec;
            Type myType = col.obj.GetType().BaseType;
            m_col = col;
            //Value = Activator.CreateInstance(myType);
            usrc_lbl.Init(m_col, xuctrln, m_inpCtrlList.Count, bReadOnly);
            CreateInputControls(pParentTbl, xuctrln, myType);
            SetDefault();
            EventHandler_Set(true);
            if (!bReadOnly)
            { 
                usrc_lbl.null_selected += new CodeTables.usrc_InputControl_Label.delegate_null_selected(this.usrc_lbl_null_selected);
            }
            pParentTbl.myGroupBox.grpBox.Controls.Add(this);
            inpCtrlList.Add(this);
            if (usrc_lbl.Null_Selected)
            {
                hide_when_null(true);
            }
            this.Changed = false;
        }
        public void InputControl_ValueChanged(object sender)
        {
            if (this.m_col.ownerTable.iFillTableData == 0)
            {
                this.usrc_lbl.NoData(false);
                SetChanged(sender);
            }
        }

        void PercentUpDown_ValueChanged(object sender, EventArgs e)
        {
            InputControl_ValueChanged(sender);
        }

        void MoneyUpDown_ValueChanged(object sender, EventArgs e)
        {
            InputControl_ValueChanged(sender);
        }


        private string SetRadioButtonText(RadioButton rdbButton1, RadioButton rdbButton2)
        {
            char[] chParamRdbSplit = new char[3] { ':', '|', '/' };
            string slabel;
            String s = m_col.Name_in_language.s;
            String[] sToken = s.Split(chParamRdbSplit);
            if (sToken.Length == 3)
            {
                slabel = sToken[0];
                rdbButton1.Text = sToken[1];
                rdbButton2.Text = sToken[2];
            }
            else if (sToken.Length == 2)
            {
                slabel = sToken[0];
                rdbButton1.Text = sToken[1];
                rdbButton2.Text = "";
            }
            else if (sToken.Length == 1)
            {
                slabel = sToken[0];
            }
            else
            {
                slabel = m_col.Name_in_language.s;
            }
            return slabel;
        }

        public new void  Show()
        {
            //this.Height = usrc_InputControl_Height;
            
            this.Visible = true;
            this.usrc_lbl.Visible = true;
            //this.usrc_lbl.Left = 2;
            //this.usrc_lbl.Top = 2;
            switch (m_eDBType)
            {

                case Globals.eDBType.DB_bit:
                    switch (m_col.Style)
                    {
                        case Column.eStyle.none:
                        case Column.eStyle.CheckBox:
                        case Column.eStyle.CheckBox_default_true:
                        case Column.eStyle.ReadOnly_CheckBox_default_true:
                            chkBox.Visible = true;
                            this.Width = this.usrc_lbl.Left + usrc_lbl.Width + dist + chkBox.Width;
                            this.Height = usrc_lbl.Height;

                            break;
                        case Column.eStyle.RadioButtons:
                            this.Width = this.usrc_lbl.Left + usrc_lbl.Width + dist + rdbButton1.Width + dist + rdbButton2.Width + dist;
                            this.Height = usrc_lbl.Height; 
                            break;

                        default:
                            break;
                    }
                    break;

                case Globals.eDBType.DB_smallInt:
                case Globals.eDBType.DB_Int32:
                case Globals.eDBType.DB_Int64:
                case Globals.eDBType.DB_decimal:
                    this.Width = this.usrc_lbl.Left + usrc_lbl.Width + dist + nmUpDown.Width + 2;
                    this.Height = nmUpDown.Height + 2; 
                    break;

                case Globals.eDBType.DB_Money:
                    this.Width = this.usrc_lbl.Left + usrc_lbl.Width + dist + MoneyUpDown.Width + 2;
                    this.Height = MoneyUpDown.Height+2; 
                    break;


                case Globals.eDBType.DB_Percent:
                    this.Width = this.usrc_lbl.Left + usrc_lbl.Width + dist + PercentUpDown.Width + 2;
                    this.Height = PercentUpDown.Height+2;
                    break;


                case Globals.eDBType.DB_DateTime:
                    this.Width = this.usrc_lbl.Left + usrc_lbl.Width + dist + DateTimeInput.Width;
                    this.Height = DateTimeInput.Height;
                    break;

                case Globals.eDBType.DB_varbinary_max:
                    this.Width = this.usrc_lbl.Left + usrc_lbl.Width + dist + DataBoxWidth;
                    this.Height = DataBoxHeight + 5;
                    break;

                case Globals.eDBType.DB_Image:
                    this.Width = this.usrc_lbl.Left + usrc_lbl.Width + dist + Picture_Box.Width;
                    this.Height = Picture_Box.Height + 5;
                    break;

                case Globals.eDBType.DB_Document:
                    this.Width = this.usrc_lbl.Left + usrc_lbl.Width + dist + Document_Box.Width;
                    this.Height = Document_Box.Height;
                    break;


                case Globals.eDBType.DB_varchar_64:
                case Globals.eDBType.DB_varchar_50:
                case Globals.eDBType.DB_varchar_45:
                case Globals.eDBType.DB_varchar_32:
                case Globals.eDBType.DB_varchar_25:
                case Globals.eDBType.DB_varchar_10:
                case Globals.eDBType.DB_varchar_5:
                    if (m_col.Style == Column.eStyle.Password)
                    {
                        this.Width = usrc_lbl.Width + dist + txtPassword.Width;
                        this.Height = txtPassword.Height;
                    }
                    else
                    {
                        this.Width = usrc_lbl.Width + dist + txtBox.Width;
                        this.Height = usrc_lbl.Height;
                    }
                    break;

                case Globals.eDBType.DB_varchar_264:
                case Globals.eDBType.DB_varchar_250:
                    if (m_col.Style == Column.eStyle.Password)
                    {
                        this.Width = this.usrc_lbl.Left + usrc_lbl.Width + dist + txtPassword.Width;
                        this.Height = txtPassword.Height;
                    }
                    else
                    {
                        this.Width = this.usrc_lbl.Left + usrc_lbl.Width + dist + txtBox.Width;
                        this.Height = usrc_lbl.Height;
                    }
                    break;

                case Globals.eDBType.DB_varchar_2000:
                case Globals.eDBType.DB_varchar_max:
                    if (m_col.Style == Column.eStyle.Password)
                    {
                        this.Width = this.usrc_lbl.Left + usrc_lbl.Width + dist + txtPassword.Width + 3;
                        if (this.usrc_lbl.Null_Selected)
                        {
                            this.Height = usrc_lbl.Height;
                        }
                        else
                        {
                            this.Height = txtPassword.Height + 6;
                        }
                    }
                    else
                    {
                        this.Width = this.usrc_lbl.Left + usrc_lbl.Width + dist + RichtxtBox.Width + 3;
                        if (this.usrc_lbl.Null_Selected)
                        {
                            this.Height = usrc_lbl.Height;
                        }
                        else
                        {
                            this.Height = RichtxtBox.Height + 6;
                        }
                    }
                    break;

                case Globals.eDBType.DB_UNKNOWN:
                    LogFile.Error.Show("ERROR in public InputControl(..) Can not find Globals.Get_eDBType(m_col.obj) from object:" + m_col.obj.GetType().ToString());
                    break;

            }

        }

        internal new void Hide()
        {
            usrc_lbl.Visible = false;
            this.Visible = false;
        }

        internal void GetRandomData(SQLTable tbl, SQLTable.delegate_GetInputControlRandomData ControlRandomData, bool bMen)
        {
            ControlRandomData(this, m_col, bMen);
        }

        public bool SetValue(Column column)
        {
            Object Obj = column.obj;
            Type basetype = Obj.GetType().BaseType;
            if (basetype == typeof(DB_Int32))
            {
                DB_Int32 xDB_int = (DB_Int32)Obj;
                nmUpDown.Value = xDB_int.val;
                return true;
            }
            else if (basetype == typeof(DB_Int64))
            {
                DB_Int64 xDB_long = (DB_Int64)Obj;
                nmUpDown.Value = Convert.ToDecimal(xDB_long.val);
                return true;
            }
            else if (basetype == typeof(DB_Money))
            {
                DB_Money xDB_Money = (DB_Money)Obj;
                MoneyUpDown.Value = xDB_Money.val;
                return true;
            }
            else if (basetype == typeof(DB_decimal))
            {
                DB_decimal xDB_decimal = (DB_decimal)Obj;
                nmUpDown.Value = xDB_decimal.val;
                return true;
            }
            else if (basetype == typeof(DB_Percent))
            {
                DB_Percent xDB_Percent = (DB_Percent)Obj;
                PercentUpDown.Value = xDB_Percent.val;
                return true;
            }
            else if (basetype == typeof(DB_smallInt))
            {
                DB_smallInt xDB_smallInt = (DB_smallInt)Obj;
                nmUpDown.Value = xDB_smallInt.val;
                return true;
            }
            else if (basetype == typeof(DB_bit))
            {
                DB_bit xDB_bit = (DB_bit)Obj;
                switch (m_col.Style)
                {
                    case Column.eStyle.none:
                    case Column.eStyle.CheckBox:
                    case Column.eStyle.CheckBox_default_true:
                    case Column.eStyle.ReadOnly_CheckBox_default_true:
                        if (xDB_bit.val)
                        {
                            chkBox.Checked = true;
                        }
                        else
                        {
                            chkBox.Checked = false;
                        }
                        break;


                    case Column.eStyle.RadioButtons:
                        if (xDB_bit.val)
                        {
                            rdbButton1.Checked = true;
                            rdbButton2.Checked = false;
                        }
                        else
                        {
                            rdbButton1.Checked = false;
                            rdbButton2.Checked = true;
                        }
                        break;
                }
                return true;
            }
            else if (basetype == typeof(DB_DateTime))
            {
                DB_DateTime xDB_DateTime = (DB_DateTime)Obj;
                if (xDB_DateTime.val == DateTime.MinValue)
                {
                   this.DateTimeInput.Value = this.DateTimeInput.MinDate;
                }
                else
                {
                    this.DateTimeInput.Value = xDB_DateTime.val;
                }

                return true;
            }
            else if (basetype == typeof(DB_varbinary_max))
            {
                DB_varbinary_max xDB_varbinary_max = (DB_varbinary_max)Obj;
                DataBox.Data = xDB_varbinary_max.val;
                return true;
            }
            else if (basetype == typeof(DB_Image))
            {
                DB_Image xDB_Image = (DB_Image)Obj;
                ImageConverter ic = new ImageConverter();
                Image img = (Image)ic.ConvertFrom(xDB_Image.val);
                Picture_Box.DBm_Image.Image_Data.Image = img;
                return true;
            }
            else if (basetype == typeof(DB_Document))
            {
                DB_Document xDB_Document = (DB_Document)Obj;
                Document_Box.Data = Globals.Decompress(xDB_Document.val);
                return true;
            }
            else if (basetype == typeof(DB_varchar_264))
            {
                DB_varchar_264 xDB_varchar_264 = (DB_varchar_264)Obj;
                SetTextValue(xDB_varchar_264.val);
                return true;
            }
            else if (basetype == typeof(DB_varchar_250))
            {
                DB_varchar_250 xDB_varchar_250 = (DB_varchar_250)Obj;
                SetTextValue(xDB_varchar_250.val);
                return true;
            }
            else if (basetype == typeof(DB_varchar_64))
            {
                DB_varchar_64 xDB_varchar_64 = (DB_varchar_64)Obj;
                SetTextValue(xDB_varchar_64.val);
                return true;
            }
            else if (basetype == typeof(DB_varchar_50))
            {
                DB_varchar_50 xDB_varchar_50 = (DB_varchar_50)Obj;
                SetTextValue(xDB_varchar_50.val);
                return true;
            }
            else if (basetype == typeof(DB_varchar_45))
            {
                DB_varchar_45 xDB_varchar_45 = (DB_varchar_45)Obj;
                SetTextValue(xDB_varchar_45.val);
                return true;
            }
            else if (basetype == typeof(DB_varchar_32))
            {
                DB_varchar_32 xDB_varchar_32 = (DB_varchar_32)Obj;
                SetTextValue(xDB_varchar_32.val);
                return true;
            }
            else if (basetype == typeof(DB_varchar_25))
            {
                DB_varchar_25 xDB_varchar_25 = (DB_varchar_25)Obj;
                SetTextValue(xDB_varchar_25.val);
                return true;
            }
            else if (basetype == typeof(DB_varchar_10))
            {
                DB_varchar_10 xDB_varchar_10 = (DB_varchar_10)Obj;
                SetTextValue(xDB_varchar_10.val);
                return true;
            }
            else if (basetype == typeof(DB_varchar_5))
            {
                DB_varchar_5 xDB_varchar_5 = (DB_varchar_5)Obj;
                SetTextValue(xDB_varchar_5.val);
                return true;
            }
            else if (basetype == typeof(DB_varchar_2000))
            {
                DB_varchar_2000 xDB_varchar_2000 = (DB_varchar_2000)Obj;
                this.RichtxtBox.Text = xDB_varchar_2000.val;
                return true;
            }
            else if (basetype == typeof(DB_varchar_max))
            {
                DB_varchar_max xDB_varchar_max = (DB_varchar_max)Obj;
                this.RichtxtBox.Text = xDB_varchar_max.val;
                return true;
            }
            else if (basetype == typeof(DB_Image))
            {
                DB_Image xDB_Image = (DB_Image)Obj;
                ImageConverter ic = new ImageConverter();
                Image img = (Image)ic.ConvertFrom(xDB_Image.val);
                Picture_Box.DBm_Image.Image_Data.Image = img;
                return true;
            }
            else if (basetype == typeof(DB_Document))
            {
                DB_Document xDB_Documentt = (DB_Document)Obj;
                //ImageConverter ic = new ImageConverter();
                //Image img = (Image)ic.ConvertFrom(xDBm_Image.val);
                //Picture.Image = img;
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR: Object of type:" + Obj.GetType().ToString() + "Is not one of DBTypes !");
                return false;
            }
        }

        private void SetTextValue(string val)
        {
            if (m_col.Style == Column.eStyle.Password)
            {
                txtPassword.Text = val;
            }
            else
            {
                txtBox.Text = val;
            }
        }

        public bool Init_SetValue(Object Value)
        {
            bool bRes = false;
            if (Value.GetType() == typeof(System.DBNull))
            {
                ValSet vs = (ValSet)m_col.obj;
                vs.defined = false;
            }
            ObjectInitialValue = Value;
            usrc_lbl.Init_SetCheck();
            bRes=SetVal(Value);
            if (usrc_lbl.Null_Selected)
            {
                this.hide_when_null(true);
            }
            else
            {
                this.hide_when_null(false);
            }

            if (bRes)
            {
                this.pic_Changed.Changed = false;
                return true;
            }
            else
            {
                ObjectInitialValue = null;
                return false;
            }
        }
        public bool SetValue(Object Value)
        {
            bool bRes = false;
            usrc_lbl.SetCheck();
            bRes = SetVal(Value);
            if (usrc_lbl.Null_Selected)
            {
                this.hide_when_null(true);
            }
            else
            {
                this.hide_when_null(false);
            }
            return bRes;
        }
        private bool SetVal(Object Value)
        {
            Defined = true;
            if (Value.GetType() == typeof(int))
            {
                nmUpDown.Value = Convert.ToDecimal(Value);
                nmUpDown.BackColor = ColorDefined;
                
                return true;
            }
            else if (Value.GetType() == typeof(Int16))
            {
                nmUpDown.Value = Convert.ToDecimal(Value);
                nmUpDown.BackColor = ColorDefined;
                return true;
            }
            else if (Value.GetType() == typeof(long))
            {
                nmUpDown.Value = Convert.ToDecimal(Value);
                nmUpDown.BackColor = ColorDefined;
                return true;
            }
            else if (Value.GetType() == typeof(decimal))
            {
                if (nmUpDown != null)
                {
                    nmUpDown.Value = (decimal)Value;
                    nmUpDown.BackColor = ColorDefined;
                }
                else if (MoneyUpDown != null)
                {
                    MoneyUpDown.Value = (decimal)Value;
                    MoneyUpDown.BackColor = ColorDefined;
                }
                else if (PercentUpDown != null)
                {
                    PercentUpDown.Value = (decimal)Value;
                    PercentUpDown.BackColor = ColorDefined;
                }
                return true;
            }
            else if (Value.GetType() == typeof(double))
            {
                if (nmUpDown != null)
                {
                    nmUpDown.Value = Convert.ToDecimal(Value);
                    nmUpDown.BackColor = ColorDefined;
                }
                else if (MoneyUpDown != null)
                {
                    MoneyUpDown.Value = Convert.ToDecimal(Value);
                    MoneyUpDown.BackColor = ColorDefined;
                }
                else if (PercentUpDown != null)
                {
                    PercentUpDown.Value = Convert.ToDecimal(Value);
                    PercentUpDown.BackColor = ColorDefined;
                }
                return true;
            }
            else if (Value.GetType() == typeof(float))
            {
                if (nmUpDown != null)
                {
                    nmUpDown.Value = Convert.ToDecimal(Value);
                    nmUpDown.BackColor = ColorDefined;
                }
                else if (MoneyUpDown != null)
                {
                    MoneyUpDown.Value = Convert.ToDecimal(Value);
                    MoneyUpDown.BackColor = ColorDefined;
                }
                else if (PercentUpDown != null)
                {
                    PercentUpDown.Value = Convert.ToDecimal(Value);
                    PercentUpDown.BackColor = ColorDefined;
                }
                return true;
            }
            else if (Value.GetType() == typeof(bool))
            {
                switch (m_col.Style)
                {
                    case Column.eStyle.none:
                    case Column.eStyle.CheckBox:
                    case Column.eStyle.CheckBox_default_true:
                    case Column.eStyle.ReadOnly_CheckBox_default_true:
                        if ((bool)Value)
                        {
                            chkBox.Checked = true;
                        }
                        else
                        {
                            chkBox.Checked = false;
                        }
                        chkBox.BackColor = ColorDefined;
                        break;

                   

                    case Column.eStyle.RadioButtons:
                        if ((bool)Value)
                        {
                            rdbButton1.Checked = true;
                            rdbButton2.Checked = false;
                        }
                        else
                        {
                            rdbButton1.Checked = false;
                            rdbButton2.Checked = true;
                        }
                        rdbButton1.BackColor = ColorDefined;
                        rdbButton2.BackColor = ColorDefined;

                        break;
                }
                return true;
            }
            else if (Value.GetType() == typeof(DateTime))
            {
                this.DateTimeInput.Value = (DateTime)Value;
                this.DateTimeInput.BackColor = ColorDefined;
                return true;
            }
            else if (Value.GetType() == typeof(byte[]))
            {
                if (this.Picture_Box != null)
                {
                    ImageConverter ic = new ImageConverter();
                    try
                    {
                        Image img = (Image)ic.ConvertFrom(Value);
                        Picture_Box.DBm_Image.Image_Data.Image = img;
                        Picture_Box.Picture.Image = img;
                    }
                    catch (Exception ex)
                    {
                        LogFile.LogFile.Write(LogFile.LogFile.LOG_LEVEL_RUN_RELEASE, "Error ImageConverter :" + ex.Message);
                    }
                    Picture_Box.BackColor = ColorDefined;
                    return true;
                }
                else if (this.DataBox != null)
                {
                    DataBox.Data = (byte[])Value;
                    DataBox.BackColor = ColorDefined;
                    return true;
                }
                else if (this.Document_Box != null)
                {
                    Document_Box.Data = Globals.Decompress((byte[])Value);
                    Document_Box.BackColor = ColorDefined;
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrcInputControl:SetVal:Value.GetType() == typeof(byte[]:No InputControl Found!");
                    Defined = false;
                    return false;
                }
            }
            else if (Value.GetType() == typeof(string))
            {
                switch (m_col.Style)
                {
                    case Column.eStyle.FileSelection:
                    case Column.eStyle.TextBox:
                    case Column.eStyle.TextBox_ReadOnly:
                        txtBox.Text = (string)Value;
                        txtBox.BackColor = ColorDefined;
                        break;


                    case Column.eStyle.RichTextBox:
                        RichtxtBox.Text = (string)Value;
                        RichtxtBox.BackColor = ColorDefined;
                        break;
                    case Column.eStyle.Password:
                        txtPassword.Text = (string)Value;
                        break;
                    default:
                        LogFile.Error.Show("ERROR wrong Column.eStyle :" + m_col.Style.ToString() + " for Value type string");
                        break;


                }
                return true;
            }
            else if (Value.GetType() == typeof(DB_varchar_264))
            {
                DB_varchar_264 xDB_varchar_264 = (DB_varchar_264)Value;
                SetTextValueDefined(xDB_varchar_264.val);
                return true;
            }
            else if (Value.GetType() == typeof(DB_varchar_250))
            {
                DB_varchar_250 xDB_varchar_250 = (DB_varchar_250)Value;
                SetTextValueDefined(xDB_varchar_250.val);
                return true;
            }
            else if (Value.GetType() == typeof(DB_varchar_64))
            {
                DB_varchar_64 xDB_varchar_64 = (DB_varchar_64)Value;
                SetTextValueDefined(xDB_varchar_64.val);
                return true;
            }
            else if (Value.GetType() == typeof(DB_varchar_50))
            {
                DB_varchar_50 xDB_varchar_50 = (DB_varchar_50)Value;
                SetTextValueDefined(xDB_varchar_50.val);
                return true;
            }
            else if (Value.GetType() == typeof(DB_varchar_45))
            {
                DB_varchar_45 xDB_varchar_45 = (DB_varchar_45)Value;
                SetTextValueDefined(xDB_varchar_45.val);
                return true;
            }
            else if (Value.GetType() == typeof(DB_varchar_32))
            {
                DB_varchar_32 xDB_varchar_32 = (DB_varchar_32)Value;
                SetTextValueDefined(xDB_varchar_32.val);
                return true;
            }
            else if (Value.GetType() == typeof(DB_varchar_25))
            {
                DB_varchar_25 xDB_varchar_25 = (DB_varchar_25)Value;
                SetTextValueDefined(xDB_varchar_25.val);
                return true;
            }
            else if (Value.GetType() == typeof(DB_varchar_10))
            {
                DB_varchar_10 xDB_varchar_10 = (DB_varchar_10)Value;
                SetTextValueDefined(xDB_varchar_10.val);
                return true;
            }
            else if (Value.GetType() == typeof(DB_varchar_5))
            {
                DB_varchar_5 xDB_varchar_5 = (DB_varchar_5)Value;
                SetTextValueDefined(xDB_varchar_5.val);
                return true;
            }
            else if (Value.GetType() == typeof(DB_varchar_2000))
            {
                DB_varchar_2000 xDB_varchar_2000 = (DB_varchar_2000)Value;
                SetTextValueDefined(xDB_varchar_2000.val);
                return true;
            }
            else if (Value.GetType() == typeof(DB_varchar_max))
            {
                DB_varchar_max xDB_varchar_max = (DB_varchar_max)Value;
                SetTextValueDefined(xDB_varchar_max.val);
                return true;
            }
            else if (Value.GetType() == typeof(System.DBNull))
            {
                switch (m_col.Style)
                {
                    case Column.eStyle.FileSelection:
                    case Column.eStyle.TextBox:
                    case Column.eStyle.TextBox_ReadOnly:
                        txtBox.Text = "";
                        txtBox.BackColor = ColorDefined;
                        break;


                    case Column.eStyle.RichTextBox:
                        RichtxtBox.Text = "";
                        RichtxtBox.BackColor = ColorDefined;
                        break;

                    case Column.eStyle.DateTimeNow:
                        txtBox.Text = "";
                        txtBox.BackColor = ColorDefined;
                        break;

                    case Column.eStyle.PictureBox:
                        Picture_Box.DBm_Image.Image_Data.Image = Properties.Resources.DefPictureImage;
                        Picture_Box.Picture.Image = Properties.Resources.DefPictureImage;
                        Picture_Box.BackColor = ColorDefined;
                        break;

                    default:
                        if (Picture_Box != null)
                        {
                            Picture_Box.DBm_Image.Image_Data.Image = Properties.Resources.DefPictureImage;
                            Picture_Box.Picture.Image = Properties.Resources.DefPictureImage;
                        }
                        if (txtBox != null)
                        {
                            txtBox.Text = "";
                        }
                        if (RichtxtBox != null)
                        {
                            RichtxtBox.Text = "";
                        }
                        break;


                }
                return true;

            }
            else
            {
                LogFile.Error.Show("ERROR: Object of type:" + Value.GetType().ToString() + "Is not one of DBTypes !");
                Defined = false;
                return false;
            }
        }

        private void SetTextValueDefined(string val)
        {
            if (m_col.Style == Column.eStyle.Password)
            {
                txtPassword.Text = val;
                txtPassword.BackColor = ColorDefined;
            }
            else
            {
                txtBox.Text = val;
                txtBox.BackColor = ColorDefined;
            }
        }

        public bool SetColumnObject(ref object objret, ref SQL_Parameter.eSQL_Parameter eSQL_Parameter_TYPE)
        {
            Object Obj = this.m_col.obj;
            Type basetype = Obj.GetType().BaseType;
            if (basetype == typeof(DB_Int32))
            {
                DB_Int32 xDB_int = (DB_Int32)Obj;
                xDB_int.val = Convert.ToInt32(nmUpDown.Value);
                objret = xDB_int.val;
                eSQL_Parameter_TYPE = SQL_Parameter.eSQL_Parameter.Int;
            }
            else if (basetype == typeof(DB_Int64))
            {
                DB_Int64 xDB_long = (DB_Int64)Obj;
                xDB_long.val = Convert.ToInt64(nmUpDown.Value);
                objret = xDB_long.val;
                eSQL_Parameter_TYPE = SQL_Parameter.eSQL_Parameter.Bigint;
            }
            else if (basetype == typeof(DB_Money))
            {
                DB_Money xDB_Money = (DB_Money)Obj;
                xDB_Money.val = MoneyUpDown.Value;
                objret = xDB_Money.val;
                eSQL_Parameter_TYPE = SQL_Parameter.eSQL_Parameter.Decimal;
            }
            else if (basetype == typeof(DB_decimal))
            {
                DB_decimal xDB_decimal = (DB_decimal)Obj;
                xDB_decimal.val = nmUpDown.Value;
                objret = xDB_decimal.val;
                eSQL_Parameter_TYPE = SQL_Parameter.eSQL_Parameter.Decimal;
            }
            else if (basetype == typeof(DB_Percent))
            {
                DB_Percent xDB_Percent = (DB_Percent)Obj;
                xDB_Percent.val = PercentUpDown.Value;
                objret = xDB_Percent.val;
                eSQL_Parameter_TYPE = SQL_Parameter.eSQL_Parameter.Decimal;
            }
            else if (basetype == typeof(DB_smallInt))
            {
                DB_smallInt xDB_smallInt = (DB_smallInt)Obj;
                xDB_smallInt.val = Convert.ToInt16(nmUpDown.Value);
                objret = xDB_smallInt.val;
                eSQL_Parameter_TYPE = SQL_Parameter.eSQL_Parameter.Smallint;
            }
            else if (basetype == typeof(DB_bit))
            {
                DB_bit xDB_bit = (DB_bit)Obj;
                switch (m_col.Style)
                {
                    case Column.eStyle.RadioButtons:
                        if (rdbButton1 != null)
                        {
                            if (rdbButton1.Checked)
                            {
                                xDB_bit.val = true;
                            }
                            else
                            {
                                xDB_bit.val = false;
                            }
                            objret = xDB_bit.val;
                            eSQL_Parameter_TYPE = SQL_Parameter.eSQL_Parameter.Bit;
                        }
                        break;

                    case Column.eStyle.none:
                    case Column.eStyle.CheckBox:
                    case Column.eStyle.CheckBox_default_true:
                    case Column.eStyle.ReadOnly_CheckBox_default_true:
                        if (this.chkBox != null)
                        {
                            if (this.chkBox.Checked)
                            {
                                xDB_bit.val = true;
                            }
                            else
                            {
                                xDB_bit.val = false;
                            }
                            objret = xDB_bit.val;
                            eSQL_Parameter_TYPE = SQL_Parameter.eSQL_Parameter.Bit;
                        }
                        break;
                }
            }
            else if (basetype == typeof(DB_DateTime))
            {
                DB_DateTime xDB_DateTime = (DB_DateTime)Obj;
                xDB_DateTime.val = DateTimeInput.Value;
                objret = xDB_DateTime.val;
                eSQL_Parameter_TYPE = SQL_Parameter.eSQL_Parameter.Datetime;
            }
            else if (basetype == typeof(DB_varbinary_max))
            {
                // Create Temporary File from PictureBox
                // and return it's path
                DB_varbinary_max xDB_varbinary_max = (DB_varbinary_max)Obj;
                if (DataBox != null)
                {
                    //Func.ImageStore = (Image) Picture.Image.Clone();
                    xDB_varbinary_max.val = (Byte[])DataBox.Data.Clone();
                    objret = xDB_varbinary_max.val;
                    eSQL_Parameter_TYPE = SQL_Parameter.eSQL_Parameter.Varbinary;
                }
            }
            else if (basetype == typeof(DB_Image))
            {
                // Create Temporary File from PictureBox
                // and return it's path
                DB_Image xDB_Image = (DB_Image)Obj;
                if (Picture_Box != null)
                {
                    //Func.ImageStore = (Image) Picture.Image.Clone();
                    if (Picture_Box.DBm_Image.Image_Data.Image != null)
                    {
                        xDB_Image.val = DBTypes.DBtypesFunc.imageToByteArray((Image)Picture_Box.DBm_Image.Image_Data.Image.Clone(), Picture_Box.imgFormat);
                        objret = xDB_Image.val;
                        eSQL_Parameter_TYPE = SQL_Parameter.eSQL_Parameter.Varbinary;
                    }
                }
            }
            else if (basetype == typeof(DB_Document))
            {
                // Create Temporary File from PictureBox
                // and return it's path
                DB_Document xDB_Document = (DB_Document) Obj;
                if (Document_Box != null)
                {
                    //Func.ImageStore = (Image) Picture.Image.Clone();
                    xDB_Document.val = Globals.Compress((byte[])Document_Box.Data.Clone());
                    objret =xDB_Document.val;
                    eSQL_Parameter_TYPE = SQL_Parameter.eSQL_Parameter.Varbinary;
                }
            }
            else if (basetype == typeof(DB_varchar_264))
            {
                DB_varchar_264 xDB_varchar_x = (DB_varchar_264)Obj;
                xDB_varchar_x.val = GetText();
                objret = xDB_varchar_x.val;
                eSQL_Parameter_TYPE = SQL_Parameter.eSQL_Parameter.Varchar;

            }
            else if (basetype == typeof(DB_varchar_250))
            {
                DB_varchar_250 xDB_varchar_x = (DB_varchar_250)Obj;
                xDB_varchar_x.val = GetText(); 
                objret = xDB_varchar_x.val;
                eSQL_Parameter_TYPE = SQL_Parameter.eSQL_Parameter.Varchar;
            }
            else if (basetype == typeof(DB_varchar_64))
            {
                DB_varchar_64 xDB_varchar_x = (DB_varchar_64)Obj;
                xDB_varchar_x.val = GetText(); 
                objret = xDB_varchar_x.val;
                eSQL_Parameter_TYPE = SQL_Parameter.eSQL_Parameter.Varchar;
            }
            else if (basetype == typeof(DB_varchar_50))
            {
                DB_varchar_50 xDB_varchar_x = (DB_varchar_50)Obj;
                xDB_varchar_x.val = GetText();
                objret = xDB_varchar_x.val;
                eSQL_Parameter_TYPE = SQL_Parameter.eSQL_Parameter.Varchar;
            }
            else if (basetype == typeof(DB_varchar_45))
            {
                DB_varchar_45 xDB_varchar_x = (DB_varchar_45)Obj;
                xDB_varchar_x.val = GetText();
                objret = xDB_varchar_x.val;
                eSQL_Parameter_TYPE = SQL_Parameter.eSQL_Parameter.Varchar;
            }
            else if (basetype == typeof(DB_varchar_32))
            {
                DB_varchar_32 xDB_varchar_x = (DB_varchar_32)Obj;
                xDB_varchar_x.val = GetText();
                objret = xDB_varchar_x.val;
                eSQL_Parameter_TYPE = SQL_Parameter.eSQL_Parameter.Varchar;
            }
            else if (basetype == typeof(DB_varchar_25))
            {
                DB_varchar_25 xDB_varchar_x = (DB_varchar_25)Obj;
                xDB_varchar_x.val = GetText();
                objret = xDB_varchar_x.val;
                eSQL_Parameter_TYPE = SQL_Parameter.eSQL_Parameter.Varchar;
            }
            else if (basetype == typeof(DB_varchar_10))
            {
                DB_varchar_10 xDB_varchar_x = (DB_varchar_10)Obj;
                xDB_varchar_x.val = GetText();
                objret = xDB_varchar_x.val;
                eSQL_Parameter_TYPE = SQL_Parameter.eSQL_Parameter.Varchar;
            }
            else if (basetype == typeof(DB_varchar_5))
            {
                DB_varchar_5 xDB_varchar_x = (DB_varchar_5)Obj;
                xDB_varchar_x.val = GetText();
                objret = xDB_varchar_x.val;
                eSQL_Parameter_TYPE = SQL_Parameter.eSQL_Parameter.Varchar;
            }
            else if (basetype == typeof(DB_varchar_2000))
            {
                DB_varchar_2000 xDB_varchar_x = (DB_varchar_2000)Obj;
                if (m_col.Style == Column.eStyle.Password)
                {
                    xDB_varchar_x.val = txtPassword.Text;
                }
                else
                {
                    xDB_varchar_x.val = RichtxtBox.Text;
                }
                objret = xDB_varchar_x.val;
                eSQL_Parameter_TYPE = SQL_Parameter.eSQL_Parameter.Varchar;
            }
            else if (basetype == typeof(DB_varchar_max))
            {
                DB_varchar_max xDB_varchar_x = (DB_varchar_max)Obj;
                if (m_col.Style == Column.eStyle.Password)
                {
                    xDB_varchar_x.val = txtPassword.Text;
                }
                else
                {
                    xDB_varchar_x.val = RichtxtBox.Text;
                }
                objret = xDB_varchar_x.val;
                eSQL_Parameter_TYPE = SQL_Parameter.eSQL_Parameter.Varchar;
            }
            else
            {
                LogFile.Error.Show("ERROR:SetColumnObject:Object of type:" + Obj.GetType().ToString() + "Is not one of DBTypes !");
                return false;
            }
            return true;
        }

        private string GetText()
        {
            if (m_col.Style == Column.eStyle.Password)
            {
                return txtPassword.Text;
            }
            else
            {
                return txtBox.Text;
            }
        }

        private void GetStringData(ref List<string> Lines)
        {
            Object Obj = this.m_col.obj;
            Type basetype = Obj.GetType().BaseType;
            if (basetype == typeof(DB_Int32))
            {
                DB_Int32 xDB_int = (DB_Int32)Obj;
                Lines.Add(this.sImportExportVector + nmUpDown.Value.ToString());
            }
            else if (basetype == typeof(DB_Int64))
            {
                DB_Int64 xDB_long = (DB_Int64)Obj;
                Lines.Add(this.sImportExportVector + nmUpDown.Value.ToString());
            }
            else if (basetype == typeof(DB_Money))
            {
                DB_Money xDB_Money = (DB_Money)Obj;
                Lines.Add(this.sImportExportVector + DecimalSeparator(MoneyUpDown.Value.ToString()));
            }
            else if (basetype == typeof(DB_decimal))
            {
                DB_decimal xDB_decimal = (DB_decimal)Obj;
                Lines.Add(this.sImportExportVector + DecimalSeparator(nmUpDown.Value.ToString()));
            }
            else if (basetype == typeof(DB_Percent))
            {
                DB_Percent xDB_decimal = (DB_Percent)Obj;
                Lines.Add(this.sImportExportVector + DecimalSeparator(PercentUpDown.Value.ToString()));
            }
            else if (basetype == typeof(DB_smallInt))
            {
                DB_smallInt xDB_smallInt = (DB_smallInt)Obj;
                nmUpDown.Value = xDB_smallInt.val;
                Lines.Add(this.sImportExportVector + nmUpDown.Value.ToString());
            }
            else if (basetype == typeof(DB_bit))
            {
                DB_bit xDB_bit = (DB_bit)Obj;
                switch (m_col.Style)
                {
                    case Column.eStyle.RadioButtons:
                        if (rdbButton1 != null)
                        {
                            if (rdbButton1.Checked)
                            {
                                Lines.Add(this.sImportExportVector + "1");
                            }
                            else
                            {
                                Lines.Add(this.sImportExportVector + "0");
                            }
                        }
                        else
                        {
                            Lines.Add(this.sImportExportVector + "0");
                        }
                        break;

                    case Column.eStyle.none:
                    case Column.eStyle.CheckBox:
                    case Column.eStyle.CheckBox_default_true:
                    case Column.eStyle.ReadOnly_CheckBox_default_true:
                        if (this.chkBox != null)
                        {
                            if (this.chkBox.Checked)
                            {
                                Lines.Add(this.sImportExportVector + "1");
                            }
                            else
                            {
                                Lines.Add(this.sImportExportVector + "0");
                            }
                        }
                        else
                        {
                            Lines.Add(this.sImportExportVector + "0");
                        }
                        break;
                }
            }
            else if (basetype == typeof(DB_DateTime))
            {
                DB_DateTime xDB_DateTime = (DB_DateTime)Obj;
                Lines.Add(this.sImportExportVector + Convert.ToString(DateTimeInput.Value));
            }
            else if (basetype == typeof(DB_varbinary_max))
            {
                // Create Temporary File from PictureBox
                // and return it's path
                if (DataBox != null)
                {
                    //Func.ImageStore = (Image) Picture.Image.Clone();
                    Lines.Add(this.sImportExportVector + DBTypes.DBtypesFunc.DataStore.Insert((Byte[])DataBox.Data.Clone()));
                }
                else
                {
                    //if (Func.ImageStore != null)
                    //{
                    //    Func.ImageStore.Dispose();
                    //}
                    //Func.ImageStore = null;
                    Lines.Add(this.sImportExportVector + "null");
                }
            }
            else if (basetype == typeof(DB_Image))
            {
                // Create Temporary File from PictureBox
                // and return it's path
                if (Picture_Box != null)
                {
                    //Func.ImageStore = (Image) Picture.Image.Clone();
                    if (Picture_Box.DBm_Image.Image_Data.Image != null)
                    {
                        Lines.Add(this.sImportExportVector + DBTypes.DBtypesFunc.ImageStore.Insert((Image)Picture_Box.DBm_Image.Image_Data.Image.Clone()));
                    }
                    else
                    {
                        Lines.Add(this.sImportExportVector + "DBm_Image_is_DB_null");
                    }
                }
                else
                {
                    //if (Func.ImageStore != null)
                    //{
                    //    Func.ImageStore.Dispose();
                    //}
                    //Func.ImageStore = null;
                    Lines.Add(this.sImportExportVector + "DBm_Image_is_DB_null");
                }
            }
            else if (basetype == typeof(DB_Document))
            {
                // Create Temporary File from PictureBox
                // and return it's path
                if (Document_Box != null)
                {
                    //Func.ImageStore = (Image) Picture.Image.Clone();
                    Lines.Add(this.sImportExportVector + DBTypes.DBtypesFunc.DocumentStore.Insert((Byte[])Document_Box.Data.Clone()));
                }
                else
                {
                    //if (Func.ImageStore != null)
                    //{
                    //    Func.ImageStore.Dispose();
                    //}
                    //Func.ImageStore = null;
                    Lines.Add(this.sImportExportVector + "null");
                }
            }
            else if ((basetype == typeof(DB_varchar_264)) ||
                     (basetype == typeof(DB_varchar_250)) ||
                     (basetype == typeof(DB_varchar_64)) ||
                     (basetype == typeof(DB_varchar_50)) ||
                     (basetype == typeof(DB_varchar_45)) ||
                     (basetype == typeof(DB_varchar_32)) ||
                     (basetype == typeof(DB_varchar_25)) ||
                     (basetype == typeof(DB_varchar_10)) ||
                     (basetype == typeof(DB_varchar_5)))
 
            {
                Lines.Add(this.sImportExportVector + ASet.KEYWORD_LINES + "=1");
                Lines.Add(txtBox.Text);
            }
            else if ((basetype == typeof(DB_varchar_2000)) ||
                     (basetype == typeof(DB_varchar_max)))
            {

                string[] sLines = RichtxtBox.Text.Split('\n');
                Lines.Add(this.sImportExportVector + ASet.KEYWORD_LINES + "=" + sLines.Count().ToString());
                foreach (string s in sLines)
                {
                    Lines.Add(s);
                }
            }
            else
            {
                LogFile.Error.Show("ERROR: Object of type:" + Obj.GetType().ToString() + "Is not one of DBTypes !");
                Lines.Add(this.sImportExportVector + "null");
            }
        }

        private string DecimalSeparator(string s)
        {
            return s.Replace(',', '.');
        }

        internal void GetStringDataDataLine(ref List<string> Line)
        {
            GetStringData(ref  Line);
        }

        internal void UpdateValue()
        {

            Object Obj = this.m_col.obj;
            Type basetype = Obj.GetType().BaseType;
            if (basetype == typeof(DB_Int32))
            {
                DB_Int32 xDB_int = (DB_Int32)Obj;
                xDB_int.val = Convert.ToInt32(nmUpDown.Value);
            }
            else if (basetype == typeof(DB_Int64))
            {
                DB_Int64 xDB_long = (DB_Int64)Obj;
                xDB_long.val = Convert.ToInt64(nmUpDown.Value);
            }
            else if (basetype == typeof(DB_Money))
            {
                DB_Money xDB_Money = (DB_Money)Obj;
                xDB_Money.val = MoneyUpDown.Value;
            }
            else if (basetype == typeof(DB_decimal))
            {
                DB_decimal xDB_decimal2 = (DB_decimal)Obj;
                xDB_decimal2.val = nmUpDown.Value;
            }
            else if (basetype == typeof(DB_Percent))
            {
                DB_Percent xDB_Percent = (DB_Percent)Obj;
                xDB_Percent.val = PercentUpDown.Value;
            }
            else if (basetype == typeof(DB_smallInt))
            {
                DB_smallInt xDB_smallInt = (DB_smallInt)Obj;
                xDB_smallInt.val = Convert.ToInt16(nmUpDown.Value);
            }
            else if (basetype == typeof(DB_bit))
            {
                DB_bit xDB_bit = (DB_bit)Obj;
                switch (m_col.Style)
                {
                    case Column.eStyle.RadioButtons:
                        if (rdbButton1 != null)
                        {
                            if (rdbButton1.Checked)
                            {
                                xDB_bit.val = true;
                            }
                            else
                            {
                                xDB_bit.val = false;
                            }
                        }
                        else
                        {
                            xDB_bit.val = false;
                        }
                        break;

                    case Column.eStyle.none:
                    case Column.eStyle.CheckBox:
                    case Column.eStyle.CheckBox_default_true:
                    case Column.eStyle.ReadOnly_CheckBox_default_true:
                        if (this.chkBox != null)
                        {
                            if (this.chkBox.Checked)
                            {
                                xDB_bit.val = true;
                            }
                            else
                            {
                                xDB_bit.val = false;
                            }
                        }
                        else
                        {
                            xDB_bit.val = false;
                        }
                        break;
                }
            }
            else if (basetype == typeof(DB_DateTime))
            {
                DB_DateTime xDB_DateTime = (DB_DateTime)Obj;
                xDB_DateTime.val = DateTimeInput.Value;
            }
            else if (basetype == typeof(DB_varbinary_max))
            {
                // Create Temporary File from PictureBox
                // and return it's path
                DB_varbinary_max xDB_varbinary_max = (DB_varbinary_max)Obj;
                xDB_varbinary_max.val = (Byte[])DataBox.Data.Clone();
            }
            else if (basetype == typeof(DB_Image))
            {
                // Create Temporary File from PictureBox
                // and return it's path
                DB_Image xDB_Image = (DB_Image)Obj;
                xDB_Image.val = DBTypes.DBtypesFunc.imageToByteArray((Image)Picture_Box.DBm_Image.Image_Data.Image.Clone());
            }
            else if (basetype == typeof(DB_Document))
            {
                // Create Temporary File from PictureBox
                // and return it's path
                DB_Document xDB_Document = (DB_Document)Obj;
                xDB_Document.val = (Byte[])Document_Box.Data.Clone();
            }
            else if (
                     (basetype == typeof(DB_varchar_264)) ||
                     (basetype == typeof(DB_varchar_250)) ||
                     (basetype == typeof(DB_varchar_64)) ||
                     (basetype == typeof(DB_varchar_50)) ||
                     (basetype == typeof(DB_varchar_45)) ||
                     (basetype == typeof(DB_varchar_32))||
                     (basetype == typeof(DB_varchar_25))||
                     (basetype == typeof(DB_varchar_10))||
                     (basetype == typeof(DB_varchar_5))
                    ) 
            {
                if (basetype == typeof(DB_varchar_264))
                {
                    DB_varchar_264 xDB_varchar_264 = (DB_varchar_264)Obj;
                    xDB_varchar_264.val = txtBox.Text;

                }
                if (basetype == typeof(DB_varchar_250))
                {
                    DB_varchar_250 xDB_varchar_250 = (DB_varchar_250)Obj;
                    xDB_varchar_250.val = txtBox.Text;

                }
                else if (basetype == typeof(DB_varchar_64))
                {
                    DB_varchar_64 xDB_varchar_64 = (DB_varchar_64)Obj;
                    xDB_varchar_64.val = txtBox.Text;

                }
                else if (basetype == typeof(DB_varchar_50))
                {
                    DB_varchar_50 xDB_varchar_50 = (DB_varchar_50)Obj;
                    xDB_varchar_50.val = txtBox.Text;

                }
                else if (basetype == typeof(DB_varchar_45))
                {
                    DB_varchar_45 xDB_varchar_45 = (DB_varchar_45)Obj;
                    xDB_varchar_45.val = txtBox.Text;

                }
                else if (basetype == typeof(DB_varchar_32))
                {
                    DB_varchar_32 xDB_varchar_32 = (DB_varchar_32)Obj;
                    xDB_varchar_32.val = txtBox.Text;

                }
                else if (basetype == typeof(DB_varchar_25))
                {
                    DB_varchar_25 xDB_varchar_25 = (DB_varchar_25)Obj;
                    xDB_varchar_25.val = txtBox.Text;

                }
                else if (basetype == typeof(DB_varchar_10))
                {
                    DB_varchar_10 xDB_varchar_10 = (DB_varchar_10)Obj;
                    xDB_varchar_10.val = txtBox.Text;

                }
                else if (basetype == typeof(DB_varchar_5))
                {
                    DB_varchar_5 xDB_varchar_5 = (DB_varchar_5)Obj;
                    xDB_varchar_5.val = txtBox.Text;

                }
            }
            else if ((basetype == typeof(DB_varchar_2000)) ||
                     (basetype == typeof(DB_varchar_max)))
            {
                if (basetype == typeof(DB_varchar_2000))
                {
                    DB_varchar_2000 xDB_varchar_2000 = (DB_varchar_2000)Obj;
                    xDB_varchar_2000.val = RichtxtBox.Rtf;
                }
                else if (basetype == typeof(DB_varchar_max))
                {
                    DB_varchar_max xDB_varchar_max = (DB_varchar_max)Obj;
                    xDB_varchar_max.val = RichtxtBox.Rtf;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR: Object of type:" + Obj.GetType().ToString() + "Is not one of DBTypes !");
            }
        }

        internal bool IsNotDefined()
        {
            if (m_col.Style == Column.eStyle.Password)
            {
                return !txtPassword.Defined();
            }
            else
            {
                return !Defined;
            }
        }

        internal void MarkAsUndefined()
        {
            foreach (Control ctrl in m_active_ctrl_List)
            {
               ctrl.BackColor = Color.Red;
            }
        }

        internal void hide_when_null(bool b)
        {
            if (b)
            {
                foreach (Control ctrl in m_active_ctrl_List)
                {
                    ctrl.Visible = false;
                    if (ctrl is RichTextBox)
                    {
                        this.Height = 32;
                        //                        this.BackColor = Color.Blue;
                        SQLTable ptbl = m_ParentTbl;
                        while (ptbl.pParentTable != null)
                        {
                            ptbl = ptbl.pParentTable;
                        }
                        MySize size = new MySize();
                        ptbl.RepositionInputControls(ptbl.myGroupBox, ref size, 0);
                        ptbl.myGroupBox.Refresh();
                    }
                    else if (ctrl is Password.usrc_PasswordDefinition)
                    {
                        this.Height = 64;
                        //                        this.BackColor = Color.Blue;
                        SQLTable ptbl = m_ParentTbl;
                        while (ptbl.pParentTable != null)
                        {
                            ptbl = ptbl.pParentTable;
                        }
                        MySize size = new MySize();
                        ptbl.RepositionInputControls(ptbl.myGroupBox, ref size, 0);
                        ptbl.myGroupBox.Refresh();
                    }
                }
            }
            else
            {
                foreach (Control ctrl in m_active_ctrl_List)
                {
                    ctrl.Visible = true;
                    if (ctrl is RichTextBox)
                    {
                        this.Height = ctrl.Height;
                        //                        this.BackColor = Color.Blue;
                        SQLTable ptbl = m_ParentTbl;
                        while (ptbl.pParentTable != null)
                        {
                            ptbl = ptbl.pParentTable;
                        }
                        MySize size = new MySize();
                        ptbl.RepositionInputControls(ptbl.myGroupBox, ref size, 0);
                    }
                    else if (ctrl is Password.usrc_PasswordDefinition)
                    {
                        this.Height = 64;
                        //                        this.BackColor = Color.Blue;
                        SQLTable ptbl = m_ParentTbl;
                        while (ptbl.pParentTable != null)
                        {
                            ptbl = ptbl.pParentTable;
                        }
                        MySize size = new MySize();
                        ptbl.RepositionInputControls(ptbl.myGroupBox, ref size, 0);
                        ptbl.myGroupBox.Refresh();
                    }
                }
            }
        }

        private void usrc_lbl_null_selected(bool b)
        {
            hide_when_null(b);
            SetChanged(usrc_lbl);
        }


        internal void Set_Image_Hash(string hash)
        {
            if (txtBox != null)
            {
                txtBox.Text = hash;
                txtBox.ReadOnly = true;
                this.bManualyChanged = false;
                Defined = true;
            }
            else
            {
                LogFile.Error.Show("ERROR:Set_Image_Gash:txtBox==null!");
            }
        }

        internal void Set_xDocument_Hash(string hash)
        {
            if (txtBox != null)
            {
                txtBox.Text = hash;
                txtBox.ReadOnly = true;
                this.bManualyChanged = false;
                Defined = true;
            }
            else
            {
                LogFile.Error.Show("ERROR:Set_xDocument_Hash:txtBox==null!");
            }
        }


        internal void InitToDefault()
        {
            EventHandler_Set(false);
            SetDefault();
            EventHandler_Set(true);
        }

        public void SetNumericUpDown(int decimal_places)
        {
            foreach (Control ctrl in m_active_ctrl_List)
            {
                if (ctrl is usrc_NumericUpDown)
                {
                    ((usrc_NumericUpDown)ctrl).SetIncrement(decimal_places);
                }
            }
        }
    }
}
