#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.Serialization;
using System.Windows.Forms;
using LanguageControl;
using LogFile;
using System.IO;
using System.Drawing;

namespace CodeTables
{
    public class wRect
    {
        public const string const_Minimized = "Minimized";
        public const string const_Maximized = "Maximized";
        public const string const_Normal = "Normal";
        public const string const_FormWindowState= "FormWindowState";
        public const string const_Top = "Top";
        public const string const_Left = "Left";
        public const string const_Width = "Width";
        public const string const_Height = "Height";

        public FormWindowState formWindowState= FormWindowState.Normal;
        public int Left = 0;
        public int Top = 0;
        public int Width = 400;
        public int Height = 300;

        public wRect(int xLeft,int xTop,int xWidth,int xHeight)
        {
            Left =  xLeft;
            Top =   xTop;
            Width = xWidth;
            Height = xHeight;
        }

        internal string GetWindowCountryString(FormWindowState formWindowState)
        {
            switch (formWindowState)
            {
                case FormWindowState.Normal:
                    return const_Normal;
                case FormWindowState.Maximized:
                    return const_Maximized;
                case FormWindowState.Minimized:
                    return const_Minimized;
            }
            return const_Normal;
        }

        internal FormWindowState SetFormWindowState(string p)
        {
            if (p.Equals(const_Normal))
            {
                return FormWindowState.Normal;
            }
            else if (p.Equals(const_Maximized))
            {
                return FormWindowState.Maximized;
            }
            else if (p.Equals(const_Minimized))
            {
                return FormWindowState.Minimized;
            }
            else
            {
                return FormWindowState.Normal;
            }
        }

        internal void SetFormPlacement(Form pForm)
        {
            pForm.WindowState= this.formWindowState;
            pForm.Left = this.Left;
            pForm.Top = this.Top;
            pForm.Width = this.Width;
            pForm.Height = this.Height;
        }
    }

    public class ColumnXml
    {
        public Column m_col;
        public const string const_Name = "Name";
        public const string const_bUseSqlFilter = "bUseSqlFilter";
        public const string const_true = "true";
        public const string const_false = "false";
        public string Name;
        public string SqlFilter;
        public bool bUseSqlFilter;

        public ColumnXml()
        {
        }

        public ColumnXml(ColumnXml sourceColumnXml)
        {
            m_col = sourceColumnXml.m_col;
            Name = sourceColumnXml.Name;
            SqlFilter = sourceColumnXml.SqlFilter;
            bUseSqlFilter = sourceColumnXml.bUseSqlFilter;

        }

        internal void Parse(XmlNode node, ref bool bRes)
        {
            XmlAttributeCollection attrcollection = node.Attributes;
            foreach (XmlAttribute attr in attrcollection)
            {
                if (attr.Name.Equals(const_Name))
                {
                    Name = attr.Value;
                }
                else if (attr.Name.Equals(const_bUseSqlFilter))
                {
                    if (attr.Value.Equals(const_true))
                    {
                        bUseSqlFilter = true;
                    }
                    else
                    {
                        bUseSqlFilter = false;
                    }


                }
            }
            SqlFilter = node.InnerText;
        }

        internal void SetAttributes(XmlDocument xmlDoc,XmlElement element_ColumXml)
        {
            XmlAttribute attrName = xmlDoc.CreateAttribute(const_Name);
            attrName.Value = Name;
            element_ColumXml.Attributes.Append(attrName);

            XmlAttribute attr_bUseSqlFilter = xmlDoc.CreateAttribute(const_bUseSqlFilter);
            if (bUseSqlFilter)
            {
                attr_bUseSqlFilter.Value = const_true;
            }
            else
            {
                attr_bUseSqlFilter.Value = const_false;
            }
            element_ColumXml.Attributes.Append(attr_bUseSqlFilter);


            element_ColumXml.InnerText = SqlFilter;
        }
    }

    public class ViewXml
    {
        public string SQLView;
        public const string const_Column = "Column";
        public const string const_Name = "Name";
        public string Name;
        public List<ColumnXml> m_ColumnXml = new List<ColumnXml>();

        public ViewXml()
        {
        }

        public ViewXml(ViewXml sourceViewXml)
        {
            SQLView = sourceViewXml.SQLView;
            Name = sourceViewXml.Name;
            foreach (ColumnXml colxml in sourceViewXml.m_ColumnXml)
            {
                ColumnXml ncol = new ColumnXml(colxml);
                m_ColumnXml.Add(ncol);
            }
        }

        public bool FillColumnXmlList(Control.ControlCollection m_ControlCollection)
        {
            m_ColumnXml.Clear();

            foreach (Control ctrl in m_ControlCollection)
            {
                if (ctrl.GetType() == typeof(DefineView_InputControl))
                {
                    DefineView_InputControl dvinpctrl = (DefineView_InputControl)ctrl;
                    ColumnXml xColumnXml = new ColumnXml();

                    xColumnXml.Name = dvinpctrl.FullName;
                    xColumnXml.m_col = dvinpctrl.m_col;

                    if (dvinpctrl.m_chkUseFiler != null)
                    {
                        dvinpctrl.bUseSqlFilter = dvinpctrl.m_chkUseFiler.Checked;
                    }
                    else
                    {
                        dvinpctrl.bUseSqlFilter = false;
                    }

                    xColumnXml.bUseSqlFilter = dvinpctrl.bUseSqlFilter;

                    if (dvinpctrl.m_txtSQLFilter != null)
                    {
                        xColumnXml.SqlFilter = dvinpctrl.m_txtSQLFilter.Text;
                    }

                    
                    m_ColumnXml.Add(xColumnXml);
                }
                else
                {
                    Error.Show("ERROR in saveToolStripMenuItem_Click! Wrong Type:" + ctrl.GetType().ToString());
                    return false;
                }
            }
            return true;
        }
        internal void Parse(XmlNode node, ref bool bRes)
        {
            XmlAttributeCollection attrcollection  = node.Attributes;


            foreach (XmlAttribute attr in attrcollection)
            {
                if (attr.Name.Equals(const_Name))
                {
                    Name = attr.Value;
                }
            }
            foreach(XmlNode node1 in node.ChildNodes)
            {
                if (node1.Name.Equals(const_Column))
                {
                    ColumnXml xColumnXml = new ColumnXml();
                    xColumnXml.Parse(node1, ref bRes);
                    m_ColumnXml.Add(xColumnXml);
                }
            }

            SQLView = node.InnerText;

        }

        internal void SetAtributes(XmlDocument xmlDoc,XmlElement element_xView)
        {
            XmlAttribute attrName = xmlDoc.CreateAttribute(const_Name);
            attrName.Value = Name;
            element_xView.Attributes.Append(attrName);

        }

        internal void WriteXml(XmlDocument xmlDoc, XmlElement element_xView)
        {
            element_xView.InnerText = SQLView;
            foreach (ColumnXml colxml in this.m_ColumnXml)
            {
                XmlElement element_ColumXml = xmlDoc.CreateElement(const_Column);
                colxml.SetAttributes(xmlDoc,element_ColumXml);
                element_xView.AppendChild(element_ColumXml);
            }
        }

        internal ColumnXml GetColumnXml(string fullname)
        {
            foreach (ColumnXml xColumnXml in m_ColumnXml)
            {
                if (xColumnXml.Name.Equals(fullname))
                {
                    return xColumnXml;
                }
            }
            return null;
        }
    }


    public class EditTableFormXml
    {
        public wRect wrect = new wRect(DefWindowPos.EditTable_Form_Left, DefWindowPos.EditTable_Form_Top, DefWindowPos.EditTable_Form_Width, DefWindowPos.EditTable_Form_Height);

        internal void Parse(XmlNode node, ref bool bRes)
        {
            XmlAttributeCollection attrcollection = node.Attributes;
            StaticXml.Get_wRect(ref wrect, attrcollection);
        }

        internal void SetAttributes(XmlDocument xmlDoc,XmlElement element_EditTableFormXml)
        {
            StaticXml.Set_wRect(wrect, xmlDoc, element_EditTableFormXml);
        }
    }

    public class CreateViewFormXml
    {
        public const string const_DefaultView = "DefaultView";
        public wRect wrect = new wRect(DefWindowPos.CreateView_Form_Left, DefWindowPos.CreateView_Form_Top, DefWindowPos.CreateView_Form_Width, DefWindowPos.CreateView_Form_Height);
        public ViewXml m_DefaultViewXml=null;
        public string sDefaultView=null;


        internal void Parse(XmlNode node, ref bool bRes)
        {
            XmlAttributeCollection attrcollection = node.Attributes;
            StaticXml.Get_wRect(ref wrect, attrcollection);
            foreach (XmlAttribute attr in attrcollection)
            {
                if (attr.Name.Equals(const_DefaultView))
                {
                    sDefaultView = attr.Value;
                    break;
                }
            }
        }

        internal void SetAttributes(XmlDocument xmlDoc,XmlElement element_CreateViewFormXml)
        {
            StaticXml.Set_wRect(wrect, xmlDoc, element_CreateViewFormXml);
            if (m_DefaultViewXml != null)
            {

                XmlAttribute attrDefaultView = xmlDoc.CreateAttribute(const_DefaultView);
                attrDefaultView.Value = m_DefaultViewXml.Name;
                element_CreateViewFormXml.Attributes.Append(attrDefaultView);
            }
        }
    }


    public class DataTableFormXml
    {

        public wRect wrect = new wRect(DefWindowPos.DataTable_Form_Left, DefWindowPos.DataTable_Form_Top, DefWindowPos.DataTable_Form_Width, DefWindowPos.DataTable_Form_Height);

        public const string const_Visible = "Visible";

        internal void Parse(XmlNode node, ref bool bRes)
        {
            XmlAttributeCollection attrcollection = node.Attributes;

            StaticXml.Get_wRect(ref wrect, attrcollection);

        }


        internal void SetAttributes(XmlDocument xmlDoc,XmlElement element_DataTableFormXml)
        {
            StaticXml.Set_wRect(wrect, xmlDoc, element_DataTableFormXml);

        }

        //internal void WriteXml(XmlDocument xmlDoc, XmlElement element_DataTableFormXml)
        //{
        //}
    }

    public class TableViewFormXml
    {

        public ViewXml m_DefaultViewXml;
        public string sDefaultView;

        public wRect wrect = new wRect(DefWindowPos.TableView_Form_Left, DefWindowPos.TableView_Form_Top, DefWindowPos.TableView_Form_Width, DefWindowPos.TableView_Form_Height);
        public const string const_DefaultView = "DefaultView";

        internal void Parse(XmlNode node, ref bool bRes)
        {
            XmlAttributeCollection attrcollection = node.Attributes;

            StaticXml.Get_wRect(ref wrect, attrcollection);

            foreach (XmlAttribute attr in attrcollection)
            {
                if (attr.Name.Equals(const_DefaultView))
                {
                    sDefaultView = attr.Value;
                    break;
                }
            }
        }



        internal void SetAttributes(XmlDocument xmlDoc, XmlElement element)
        {
            StaticXml.Set_wRect(wrect, xmlDoc, element);
            if (m_DefaultViewXml!=null)
            {

                XmlAttribute attrDefaultView = xmlDoc.CreateAttribute(const_DefaultView);
                attrDefaultView.Value = m_DefaultViewXml.Name;
                element.Attributes.Append(attrDefaultView);
            }
        }

        //internal void WriteXml(XmlDocument xmlDoc, XmlElement element_DataTableFormXml)
        //{
        //}+		Static members		

    }
    public class TableDockingFormXml
    {
        public wRect wrect = new wRect(DefWindowPos.TableDockingForm_Left, DefWindowPos.TableDockingForm_Top, DefWindowPos.TableDockingForm_Width, DefWindowPos.TableDockingForm_Height);

        public string const_Table = "Table";

        public List<ViewXml> m_ViewXml = new List<ViewXml>();


        public const string const_CreateViewForm = "CreateViewForm";
        public const string const_EditTableForm =  "EditTableForm";
        public const string const_DataTableForm =  "DataTableForm";
        public const string const_TableViewForm =  "TableViewForm";
        public const string const_View = "View";



        public string TableName;
        public CreateViewFormXml m_CreateViewFormXml = null;
        public EditTableFormXml m_EditTableFormXml= null;
        public DataTableFormXml m_DataTableFormXml=null;
        public TableViewFormXml[] m_TableViewFormXml = new TableViewFormXml[guid.MaxTableViews]{null,null,null,null};

        public TableDockingFormXml()
        {
        }

        public TableDockingFormXml(string tablename)
        {
            TableName = tablename;
        }


        internal void Parse(XmlNode node, ref bool bRes)
        {

            XmlAttributeCollection attrcollection  = node.Attributes;

            StaticXml.Get_wRect(ref wrect, attrcollection);

            foreach (XmlAttribute attr in attrcollection)
            {
                if (attr.Name.Equals(const_Table))
                {
                    TableName = attr.Value;
                }
            }
            string sDefaultView="";
            int indexOfTableViewForm = 0;
            foreach (XmlNode node1 in node.ChildNodes)
            {
                if (node1.Name.Equals(const_CreateViewForm))
                {
                    m_CreateViewFormXml = new CreateViewFormXml();
                    m_CreateViewFormXml.Parse(node1,ref bRes);
                }
                else if (node1.Name.Equals(const_EditTableForm))
                {
                    m_EditTableFormXml = new EditTableFormXml();
                    m_EditTableFormXml.Parse(node1,ref bRes);
                }
                else if (node1.Name.Equals(const_DataTableForm))
                {
                    m_DataTableFormXml = new DataTableFormXml();
                    m_DataTableFormXml.Parse(node1,ref bRes);
                }
                else if (OneOfTableViewForms(node1.Name,ref indexOfTableViewForm))
                {
                    if (indexOfTableViewForm < guid.MaxTableViews)
                    {
                        m_TableViewFormXml[indexOfTableViewForm] = new TableViewFormXml();
                        m_TableViewFormXml[indexOfTableViewForm].Parse(node1, ref bRes);
                    }
                    else
                    {
                        MessageBox.Show("Error To many TableViewForms ! Max =" + const_TableViewForm.ToString()); 
                    }
                }
                else if (node1.Name.Equals(const_View))
                {
                    ViewXml xViewXml = new ViewXml();
                    xViewXml.Parse(node1, ref bRes);
                    m_ViewXml.Add(xViewXml);

                    if (m_CreateViewFormXml != null)
                    {
                        if (m_CreateViewFormXml.sDefaultView != null)
                        {
                            if (m_CreateViewFormXml.sDefaultView.Equals(xViewXml.Name))
                            {
                                m_CreateViewFormXml.m_DefaultViewXml = xViewXml;

                            }
                        }
                    }
                    int i;
                    for (i = 0; i < guid.MaxTableViews; i++)
                    {
                        if (m_TableViewFormXml[i] != null)
                        {
                            if (m_TableViewFormXml[i].sDefaultView != null)
                            {
                                if (m_TableViewFormXml[i].sDefaultView.Equals(xViewXml.Name))
                                {
                                    m_TableViewFormXml[i].m_DefaultViewXml = xViewXml;
                                }
                            }
                        }
                    }

                    if (sDefaultView.Equals(xViewXml.Name))
                    {
//                        this.m_DefaultViewXml = xViewXml;
                    }
                }
                else
                {
                    MessageBox.Show(lng.s_Error.s +":"+ lng.s_File.s+ "=" + StaticXml.m_XMLFile + ":" +lng.s_XmlIlegalNode.s+" \"" +  node1.Name +"\"." + lng.s_Expected.s +" :\"" + const_CreateViewForm +"," + const_EditTableForm+ lng.s_Or.s + const_DataTableForm +"\" " ,lng.s_Error.s,MessageBoxButtons.OK,MessageBoxIcon.Error);
                    bRes = false;
                }
            }
        }

        private bool OneOfTableViewForms(string nodeName, ref int indexOfTableViewForm)
        {
            string sWithoutNumber="";
            int Index=0;
            if (UniqueNames.GetStringLastNumber(nodeName, ref sWithoutNumber, ref Index))
            {
                if (sWithoutNumber.Equals(const_TableViewForm))
                {
                    indexOfTableViewForm = Index;
                    return true;
                }
            }
            return false;
        }


        internal void WriteXml(XmlDocument xmlDoc, XmlElement root)
        {
            if (m_CreateViewFormXml != null)
            {
                XmlElement element_CreateViewFormXml = xmlDoc.CreateElement(const_CreateViewForm);
                m_CreateViewFormXml.SetAttributes(xmlDoc, element_CreateViewFormXml);
                root.AppendChild(element_CreateViewFormXml);
            }
            if (this.m_EditTableFormXml != null)
            {
                XmlElement element_EditTableFormXml = xmlDoc.CreateElement(const_EditTableForm);
                m_EditTableFormXml.SetAttributes(xmlDoc, element_EditTableFormXml);
                root.AppendChild(element_EditTableFormXml);
            }
            if (this.m_DataTableFormXml != null)
            {
                XmlElement element_DataTableFormXml = xmlDoc.CreateElement(const_DataTableForm);
                m_DataTableFormXml.SetAttributes(xmlDoc, element_DataTableFormXml);
                //m_DataTableFormXml.WriteXml(xmlDoc, element_DataTableFormXml);
                root.AppendChild(element_DataTableFormXml);
            }
            int indexOfTableViewForm;
            for (indexOfTableViewForm=0;indexOfTableViewForm<guid.MaxTableViews;indexOfTableViewForm++)
            {
                if (m_TableViewFormXml[indexOfTableViewForm]!=null)
                {
                    XmlElement element_TableViewFormXml = xmlDoc.CreateElement(const_TableViewForm + indexOfTableViewForm.ToString());
                    m_TableViewFormXml[indexOfTableViewForm].SetAttributes(xmlDoc, element_TableViewFormXml);
                    //m_TableViewFormXml[indexOfTableViewForm].WriteXml(xmlDoc, element_TableViewFormXml);
                    root.AppendChild(element_TableViewFormXml);
                }
            }
            foreach (ViewXml xView in m_ViewXml)
            {
                XmlElement element_xView = xmlDoc.CreateElement(const_View);
                xView.SetAtributes(xmlDoc, element_xView);
                xView.WriteXml(xmlDoc, element_xView);
                root.AppendChild(element_xView);
            }
        }

        internal void Create_pCreateViewFormXml()
        {
            m_CreateViewFormXml = new CreateViewFormXml();
        }
    }


    public class xml
    {


        public List<TableDockingFormXml> m_xmldata = new List<TableDockingFormXml>();

        public string const_Root = "";
        public wRect wrect;

        private const string const_TableDockingForm = "TableDockingForm";


        public xml(string Folder, string RootName,Form MainForm)
        {
            wrect = new wRect(DefWindowPos.MainForm_Left, DefWindowPos.MainForm_Top, DefWindowPos.MainForm_Width, DefWindowPos.MainForm_Height);
            const_Root = RootName;
            int l = Folder.Length;
            if (l > 0)
            {
                if (Folder[l - 1] == '\\')
                {
                    StaticXml.m_XMLFile = Folder + const_Root + ".xml";
                }
                else
                {
                    StaticXml.m_XMLFile = Folder + "\\" + const_Root + ".xml";
                }
            }
            else
            {
                StaticXml.m_XMLFile = null;
                MessageBox.Show(lng.s_XMLFolderIsNotDefined.s, lng.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private  bool ReadXmlFile(XmlDocument xmlDoc)
        {
            try
            {
                xmlDoc.Load(StaticXml.m_XMLFile);
                return true;
            }
            catch (Exception ex)
            {
                LogFile.LogFile.Write(0,ex.Message);
                return false;
            }
        }

        public bool Load(ref string csError)
        {
            bool bRes = true;
            XmlDocument xmlDoc = new XmlDocument();
            if (File.Exists(StaticXml.m_XMLFile))
            {
                if (ReadXmlFile(xmlDoc))
                {
                    XmlNode root = xmlDoc.DocumentElement;
                    {
                        if (root.Name.Equals(const_Root))
                        {

                            XmlAttributeCollection attrcollection = root.Attributes;
                            StaticXml.Get_wRect(ref wrect, attrcollection);

                            if (root.ChildNodes.Count > 0)
                            {
                                foreach (XmlNode node in root.ChildNodes)
                                {
                                    if (node.Name.Equals(const_TableDockingForm))
                                    {
                                        TableDockingFormXml xTableDockingFormXml = new TableDockingFormXml();
                                        xTableDockingFormXml.Parse(node, ref bRes);
                                        m_xmldata.Add(xTableDockingFormXml);
                                    }
                                    else
                                    {
                                        csError = lng.s_Error.s + ":" + lng.s_File.s + "=" + StaticXml.m_XMLFile + ":" + lng.s_XmlIlegalNode.s + " \"" + node.Name + "\"." + lng.s_Expected.s + "=\"" + const_TableDockingForm + "\"";
                                        bRes = false;
                                    }
                                }
                            }
                            else
                            {
                                csError = lng.s_Error.s + ":" + lng.s_File.s + "=" + StaticXml.m_XMLFile + ":" + lng.s_XmlNodeNotFound.s + " \"" + const_TableDockingForm + "\"";
                                bRes = false;
                            }
                        }
                        else
                        {
                            csError = lng.s_Error.s + ":" + lng.s_File.s + "=" + StaticXml.m_XMLFile + ":" + lng.s_XmlRootNotFound.s + lng.s_Expected.s + "\"" + const_Root + "\"";
                            bRes = false;
                        }
                    }
                }
                else
                {
                    csError = lng.s_Error.s + ":" + lng.s_File.s + "=" + StaticXml.m_XMLFile + ":" + lng.s_XmlFileNotLoadedInXmlDocument.s;
                    bRes = false;
                }
            }
            else
            {
                csError = lng.s_Warning.s + ":" + lng.s_File.s + "=" + StaticXml.m_XMLFile + ":" + lng.s_DoesNotExist.s;
                bRes = false;
            }
            return bRes;
        }


        internal bool Save()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                //XmlDeclaration dec = xmlDoc.CreateXmlDeclaration("1.0", null, null);
                //xmlDoc.AppendChild(dec);// Create the root element
                XmlElement root = xmlDoc.CreateElement(const_Root);
                xmlDoc.AppendChild(root);

                StaticXml.Set_wRect(wrect, xmlDoc, root);

                foreach (TableDockingFormXml xTableDockingFormXml in m_xmldata)
                {
                    XmlElement element_xTableDockingFormXml = xmlDoc.CreateElement(const_TableDockingForm);
                    XmlAttribute attr = xmlDoc.CreateAttribute(xTableDockingFormXml.const_Table);
                    attr.Value = xTableDockingFormXml.TableName;
                    element_xTableDockingFormXml.Attributes.Append(attr);
                    StaticXml.Set_wRect(xTableDockingFormXml.wrect, xmlDoc, element_xTableDockingFormXml);

                    xTableDockingFormXml.WriteXml(xmlDoc,element_xTableDockingFormXml);
                    root.AppendChild(element_xTableDockingFormXml);
                }
                xmlDoc.Save(StaticXml.m_XMLFile);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(lng.s_Error_Saving_XMLFile.s + " Exception = " + ex.Message);
                return false;
            }
        }

        internal TableDockingFormXml GetTableDockingFormXml(string TableName)
        {
            foreach (TableDockingFormXml xTableDockingFormXml in m_xmldata)
            {
                if (TableName.Equals(xTableDockingFormXml.TableName))
                {
                    return xTableDockingFormXml;
                }
            }
            return null;
        }


        internal ColumnXml GetCreateViewDefaultViewColumnXml(string tablename, string fullname)
        {
            ViewXml xDefaultViewXml = this.GetCreateViewFormDefaultView(tablename);
            if (xDefaultViewXml != null)
            {
                foreach (ColumnXml xColumnXml in xDefaultViewXml.m_ColumnXml)
                {
                    if (xColumnXml.Name.Equals(fullname))
                    {
                        return xColumnXml;
                    }
                }
            }
            return null;
        }

        internal ViewXml CreateView(string tablename)
        {
            TableDockingFormXml xTableDockingFormXml = GetTableDockingFormXml(tablename);
            if (xTableDockingFormXml == null)
            {
                xTableDockingFormXml = new TableDockingFormXml(tablename);
            }
            ViewXml xViewXml= new ViewXml();
            xTableDockingFormXml.m_ViewXml.Add(xViewXml);
            return xViewXml;
        }

        internal bool SetCreateViewFormDefaultView(string tablename, ViewXml xViewXml)
        {
            TableDockingFormXml xTableDockingFormXml = GetTableDockingFormXml(tablename);
            if (xTableDockingFormXml != null)
            {
                if (xTableDockingFormXml.m_CreateViewFormXml != null)
                {
                    xTableDockingFormXml.m_CreateViewFormXml.m_DefaultViewXml = xViewXml;
                    return true;
                }
                else
                {
                    MessageBox.Show("ERROR:SetDefaultView,(TableDockingFormXml.m_CreateViewFormXml == null)");
                }
            }
            else
            {
                MessageBox.Show("ERROR:SetDefaultView,(xTableDockingFormXml == null)");
            }
            return false;
        }


        internal ViewXml GetCreateViewFormDefaultView(string tablename)
        {
            TableDockingFormXml xTableDockingFormXml = GetTableDockingFormXml(tablename);
            if (xTableDockingFormXml != null)
            {
                if (xTableDockingFormXml.m_CreateViewFormXml != null)
                {
                    return xTableDockingFormXml.m_CreateViewFormXml.m_DefaultViewXml;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        internal TableDockingFormXml Create_pTableDockingFormXml(string TableName)
        {
            TableDockingFormXml xTableDockingFormXml = new TableDockingFormXml(TableName);
            return xTableDockingFormXml;
        }

        internal void Set_wRect(wRect wRect, Form myForm)
        {
            wRect.formWindowState= myForm.WindowState;
            if (myForm.WindowState== FormWindowState.Normal)
            {
                wRect.Left = myForm.Left;
                wRect.Top = myForm.Top;
                wRect.Width = myForm.Width;
                wRect.Height = myForm.Height;
            }
        }
    }

    public static class StaticXml
    {

        private const string const_true = "true";
        private const string const_false = "false";

        public static string m_XMLFile;
        public static string m_XMLFolder;

        public static string SetBool(bool b)
        {
            if (b)
            {
                return const_true;
            }
            else
            {
                return const_false;
            }
        }

        public static bool GetBool(string p)
        {
            if (p.Equals(const_true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal static void Get_wRect(ref wRect wrect, XmlAttributeCollection attrcollection)
        {
            foreach (XmlAttribute attr in attrcollection)
            {
                if (attr.Name.Equals(wRect.const_FormWindowState))
                {
                    wrect.formWindowState= wrect.SetFormWindowState(attr.Value);
                }
                else if (attr.Name.Equals(wRect.const_Left))
                {
                    wrect.Left = Convert.ToInt32(attr.Value);
                }
                else if (attr.Name.Equals(wRect.const_Top))
                {
                    wrect.Top = Convert.ToInt32(attr.Value);
                }
                else if (attr.Name.Equals(wRect.const_Width))
                {
                    wrect.Width = Convert.ToInt32(attr.Value);
                }
                else if (attr.Name.Equals(wRect.const_Height))
                {
                    wrect.Height = Convert.ToInt32(attr.Value);
                }
            }
        }

        internal static void Set_wRect(wRect wrect, XmlDocument xmlDoc, XmlElement element)
        {

            XmlAttribute attrFormWindowState= xmlDoc.CreateAttribute(wRect.const_FormWindowState);
            attrFormWindowState.Value = wrect.GetWindowCountryString(wrect.formWindowState);
            element.Attributes.Append(attrFormWindowState);

            XmlAttribute attrLeft = xmlDoc.CreateAttribute(wRect.const_Left);
            attrLeft.Value = wrect.Left.ToString();
            element.Attributes.Append(attrLeft);

            XmlAttribute attrTop = xmlDoc.CreateAttribute(wRect.const_Top);
            attrTop.Value = wrect.Left.ToString();
            element.Attributes.Append(attrTop);


            XmlAttribute attrWidth = xmlDoc.CreateAttribute(wRect.const_Width);
            attrWidth.Value = wrect.Width.ToString();
            element.Attributes.Append(attrWidth);

            XmlAttribute attrHeight = xmlDoc.CreateAttribute(wRect.const_Height); ;
            attrHeight.Value = wrect.Height.ToString();
            element.Attributes.Append(attrHeight);
        }
    }
}
