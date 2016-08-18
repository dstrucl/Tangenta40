
using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBConnectionControl40;
using CodeTables;
using LanguageControl;
using TangentaTableClass;
using DBTypes;
using Country_ISO_3166;
using System.Drawing;

namespace TangentaDataBaseDef
{
    public partial class MyDataBase_Tangenta
    {

        //        public DBTypes.SQL_Database_Tables_Definition mt_DB;

        public ISO_3166_Table m_ISO_3166_Table = new ISO_3166_Table();

        public TangentaTableClass.SQL_Database_Tables_Definition mt;

        public DBTableControl m_DBTables = null;

        public MyDataBase_Tangenta(Form pForm, string XmlRootName, string xmlIniFileFolder)
        {
            // TODO: Complete member initialization
            mt = new TangentaTableClass.SQL_Database_Tables_Definition();

            m_DBTables = new DBTableControl(pForm, XmlRootName, xmlIniFileFolder);

            //            Define_Image_SQL_Database_Tables();

            //            Define_Document_SQL_Database_Tables();

            Define_SQL_Database_Tables();

        }

        public DBConnection.eDBType DBType
        {

            get { return m_DBTables.m_con.DBType; }
            set { m_DBTables.m_con.DBType = value; }

        }


        public DBTableControl.enumDataBaseCheckResult CheckDatabase(Form pParentForm, ref string csError)
        {
            return m_DBTables.DataBaseCheck(ref csError);
        }

        public bool CheckConnection(Form pParentForm, Object DB_Param)
        {
            return m_DBTables.m_con.CheckConnection(DB_Param);
        }

        public bool CreateNewConnection(Form pParentForm, Object DB_Param, ref string BackupFolder, NavigationButtons.NavigationButtons xnav_buttons, ref bool bCanceled)
        {
            m_DBTables.m_con.BackupFolder = BackupFolder;
            if (m_DBTables.m_con.CreateNewDataBaseConnection(pParentForm, DB_Param, xnav_buttons, ref bCanceled))
            {
                BackupFolder = m_DBTables.m_con.BackupFolder;
                return true;
            }
            return false;
        }

        public void Backup(Form m_parent_form, object olocalDB_data_SQLite, ref string m_BackupFolder)
        {
            if (olocalDB_data_SQLite is LocalDB_data)
            {
                LocalDB_data localDB_data_SQLite = (LocalDB_data)olocalDB_data_SQLite;
                Form_Backup_SQLite frm_backup = new Form_Backup_SQLite(localDB_data_SQLite.DataBaseFilePath+ localDB_data_SQLite.DataBaseFileName, localDB_data_SQLite.DataBaseFileName, m_BackupFolder);
                if (frm_backup.ShowDialog() == DialogResult.OK)
                {
                    m_BackupFolder = frm_backup.BackupFolder;
                }
            }
        }

        public bool Backup(string full_backup_filename)
        {
            return m_DBTables.m_con.DataBase_Backup(full_backup_filename);
        }

        public bool Restore(string full_backup_filename)
        {
            return m_DBTables.m_con.DataBase_Restore(full_backup_filename);
        }


        public bool MakeConnection(Form pParentForm, Object DB_Param, NavigationButtons.NavigationButtons nav_buttons, ref bool bCanceled)
        {

             return m_DBTables.m_con.MakeDataBaseConnection(pParentForm,DB_Param, nav_buttons, ref bCanceled);
        }

        public void Init(DBConnection.eDBType eDBType)
        {
            this.m_DBTables.Init(eDBType);
        }

        public bool DropViews(ref string Err)
        {
            return this.m_DBTables.DropVIEWs(ref Err);
        }

        public bool Create_VIEWs()
        {
            return this.m_DBTables.Create_VIEWs();
        }

        //private void Define_Image_SQL_Database_Tables()
        //{
        //    SQLTable tbl_DBm_Image_Name = new SQLTable((Object)new DBm_Image_Name(), Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_DBm_Image_Name);
        //    tbl_DBm_Image_Name.AddColumn((Object)mt_DB.m_DBm_Image_Name.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new string[] { "ID", "ID" });
        //    tbl_DBm_Image_Name.AddColumn((Object)mt_DB.m_DBm_Image_Name.Image_Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new string[] { "Image Name", "Ime slike" });
        //    m_DBTables.items.Add(tbl_DBm_Image_Name);

        //    SQLTable tbl_DBm_Image_Author = new SQLTable((Object)new DBm_Image_Author(), Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_DBm_Image_Author);
        //    tbl_DBm_Image_Author.AddColumn((Object)mt_DB.m_DBm_Image_Author.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new string[] { "ID", "ID" });
        //    tbl_DBm_Image_Author.AddColumn((Object)mt_DB.m_DBm_Image_Author.Image_Author, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new string[] { "Image Author", "Avtor slike" });
        //    m_DBTables.items.Add(tbl_DBm_Image_Author);

        //    SQLTable tbl_DBm_Image_CaptureLocation = new SQLTable((Object)new DBm_Image_CaptureLocation(), Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_DBm_Image_CaptureLocation);
        //    tbl_DBm_Image_CaptureLocation.AddColumn((Object)mt_DB.m_DBm_Image_CaptureLocation.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new string[] { "ID", "ID" });
        //    tbl_DBm_Image_CaptureLocation.AddColumn((Object)mt_DB.m_DBm_Image_CaptureLocation.Image_CaptureLocation, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new string[] { "Capture Location", "Kraj Posnetka" });
        //    m_DBTables.items.Add(tbl_DBm_Image_CaptureLocation);

        //    SQLTable tbl_DBm_Image_FileName = new SQLTable((Object)new DBm_Image_FileName(), Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_DBm_Image_FileName);
        //    tbl_DBm_Image_FileName.AddColumn((Object)mt_DB.m_DBm_Image_FileName.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new string[] { "ID", "ID" });
        //    tbl_DBm_Image_FileName.AddColumn((Object)mt_DB.m_DBm_Image_FileName.Image_FileName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new string[] { "Image File Name", "Ime slikovne datoteke" });
        //    m_DBTables.items.Add(tbl_DBm_Image_FileName);

        //    SQLTable tbl_DBm_Image_Folder = new SQLTable((Object)new DBm_Image_Folder(), Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_DBm_Image_Path);
        //    tbl_DBm_Image_Folder.AddColumn((Object)mt_DB.m_DBm_Image_Folder.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new string[] { "ID", "ID" });
        //    tbl_DBm_Image_Folder.AddColumn((Object)mt_DB.m_DBm_Image_Folder.Image_Folder, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new string[] { "Image path", "Izvorna pot do slike" });
        //    m_DBTables.items.Add(tbl_DBm_Image_Folder);

        //    SQLTable tbl_DBm_Image_Ext = new SQLTable((Object)new DBm_Image_Ext(), Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_DBm_Image_Ext);
        //    tbl_DBm_Image_Ext.AddColumn((Object)mt_DB.m_DBm_Image_Ext.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new string[] { "ID", "ID" });
        //    tbl_DBm_Image_Ext.AddColumn((Object)mt_DB.m_DBm_Image_Ext.Image_Ext, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new string[] { "Image extension", "Tip slike (končnica)" });
        //    m_DBTables.items.Add(tbl_DBm_Image_Ext);

        //    SQLTable tbl_DBm_Image_Computer = new SQLTable((Object)new DBm_Image_Computer(), Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_DBm_Image_Computer);
        //    tbl_DBm_Image_Computer.AddColumn((Object)mt_DB.m_DBm_Image_Computer.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new string[] { "ID", "ID" });
        //    tbl_DBm_Image_Computer.AddColumn((Object)mt_DB.m_DBm_Image_Computer.Image_Computer, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new string[] { "Computer source of Image ", "Izvorni računalnik slike" });
        //    m_DBTables.items.Add(tbl_DBm_Image_Computer);

        //    SQLTable tbl_DBm_Image_ComputerUserName = new SQLTable((Object)new DBm_Image_ComputerUserName(), Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_DBm_Image_ComputerUser);
        //    tbl_DBm_Image_ComputerUserName.AddColumn((Object)mt_DB.m_DBm_Image_ComputerUserName.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new string[] { "ID", "ID" });
        //    tbl_DBm_Image_ComputerUserName.AddColumn((Object)mt_DB.m_DBm_Image_ComputerUserName.Image_ComputerUserName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new string[] { "Computer user source of Image ", "Izvorni računalniški uporabnik slike" });
        //    m_DBTables.items.Add(tbl_DBm_Image_ComputerUserName);

        //    SQLTable tbl_DBm_Image = new SQLTable((Object)new DBm_Image(), Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_DBm_Image);
        //    tbl_DBm_Image.AddColumn((Object)mt_DB.m_DBm_Image.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new string[] { "ID", "ID" });
        //    tbl_DBm_Image.AddColumn((Object)mt_DB.m_DBm_Image.m_DBm_Image_Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new string[] { "Image Name ID", "Ime slike ID" });
        //    tbl_DBm_Image.AddColumn((Object)mt_DB.m_DBm_Image.m_DBm_Image_Author, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new string[] { "Image Author ID", "Ime avtorja posnetka ID" });
        //    tbl_DBm_Image.AddColumn((Object)mt_DB.m_DBm_Image.m_DBm_Image_CaptureLocation, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new string[] { "Capture Location ID", "Kraj posnetka ID" });
        //    tbl_DBm_Image.AddColumn((Object)mt_DB.m_DBm_Image.m_DBm_Image_FileName, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new string[] { "Image File Name ID", "Ime datoteke ID" });
        //    tbl_DBm_Image.AddColumn((Object)mt_DB.m_DBm_Image.m_DBm_Image_Ext, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new string[] { "Image extension ID", "Tip posnetka ID (končnica)" });
        //    tbl_DBm_Image.AddColumn((Object)mt_DB.m_DBm_Image.m_DBm_Image_Folder, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new string[] { "Image path ID", "Izvorna pot posnetka ID" });
        //    tbl_DBm_Image.AddColumn((Object)mt_DB.m_DBm_Image.m_DBm_Image_Computer, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new string[] { "Computer source of Image ID", "Izvorni računalnik posnetka ID" });
        //    tbl_DBm_Image.AddColumn((Object)mt_DB.m_DBm_Image.m_DBm_Image_ComputerUserName, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new string[] { "Computer user source of image ID", "Izvorni računalniški uporabnik posnetka ID" });
        //    tbl_DBm_Image.AddColumn((Object)mt_DB.m_DBm_Image.Image_DateCreated, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.DateTimePicker_ReadOnly, new string[] { "Capture time", "Čas posnetka" });
        //    tbl_DBm_Image.AddColumn((Object)mt_DB.m_DBm_Image.Image_Size, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.TextBox_ReadOnly, new string[] { "Image size", "Velikost posnetka" });
        //    tbl_DBm_Image.AddColumn((Object)mt_DB.m_DBm_Image.Image_Width, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.TextBox_ReadOnly, new string[] { "Image Width", "Širina posnetka" });
        //    tbl_DBm_Image.AddColumn((Object)mt_DB.m_DBm_Image.Image_Height, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.TextBox_ReadOnly, new string[] { "Image Height", "Višina posnetka" });
        //    tbl_DBm_Image.AddColumn((Object)mt_DB.m_DBm_Image.Image_Hash, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.TextBox_ReadOnly, new string[] { "Image unique identity", "Unikatna identiteta posnetka" });
        //    tbl_DBm_Image.AddColumn((Object)mt_DB.m_DBm_Image.Image_Data, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new string[] { "Image", "Posnetek" });
        //    m_DBTables.items.Add(tbl_DBm_Image);
        //}

        //private void Define_Document_SQL_Database_Tables()
        //{
        //    SQLTable tbl_DBm_Document_Name = new SQLTable((Object)new DBm_Document_Name(), Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_DBm_Document_Name);
        //    tbl_DBm_Document_Name.AddColumn((Object)mt_DB.m_DBm_Document_Name.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new string[] { "ID", "ID" });
        //    tbl_DBm_Document_Name.AddColumn((Object)mt_DB.m_DBm_Document_Name.Document_Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new string[] { "Document Name", "Ime dokumenta" });
        //    m_DBTables.items.Add(tbl_DBm_Document_Name);

        //    SQLTable tbl_DBm_Document_Author = new SQLTable((Object)new DBm_Document_Author(), Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_DBm_Document_Author);
        //    tbl_DBm_Document_Author.AddColumn((Object)mt_DB.m_DBm_Document_Author.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new string[] { "ID", "ID" });
        //    tbl_DBm_Document_Author.AddColumn((Object)mt_DB.m_DBm_Document_Author.Document_Author, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new string[] { "Document Author", "Avtor dokumenta" });
        //    m_DBTables.items.Add(tbl_DBm_Document_Author);

        //    SQLTable tbl_DBm_Document_FileName = new SQLTable((Object)new DBm_Document_FileName(), Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_DBm_Document_FileName);
        //    tbl_DBm_Document_FileName.AddColumn((Object)mt_DB.m_DBm_Document_FileName.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new string[] { "ID", "ID" });
        //    tbl_DBm_Document_FileName.AddColumn((Object)mt_DB.m_DBm_Document_FileName.Document_FileName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new string[] { "Document File Name", "Ime datoteke" });
        //    m_DBTables.items.Add(tbl_DBm_Document_FileName);

        //    SQLTable tbl_DBm_Document_Folder = new SQLTable((Object)new DBm_Document_Folder(), Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_DBm_Document_Path);
        //    tbl_DBm_Document_Folder.AddColumn((Object)mt_DB.m_DBm_Document_Folder.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new string[] { "ID", "ID" });
        //    tbl_DBm_Document_Folder.AddColumn((Object)mt_DB.m_DBm_Document_Folder.Document_Folder, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new string[] { "Document path", "Izvorna pot do dokumenta" });
        //    m_DBTables.items.Add(tbl_DBm_Document_Folder);

        //    SQLTable tbl_DBm_Document_Ext = new SQLTable((Object)new DBm_Document_Ext(), Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_DBm_Document_Ext);
        //    tbl_DBm_Document_Ext.AddColumn((Object)mt_DB.m_DBm_Document_Ext.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new string[] { "ID", "ID" });
        //    tbl_DBm_Document_Ext.AddColumn((Object)mt_DB.m_DBm_Document_Ext.Document_Ext, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new string[] { "Document extension", "Tip dokumenta (končnica)" });
        //    m_DBTables.items.Add(tbl_DBm_Document_Ext);

        //    SQLTable tbl_DBm_Document_Computer = new SQLTable((Object)new DBm_Document_Computer(), Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_DBm_Document_Computer);
        //    tbl_DBm_Document_Computer.AddColumn((Object)mt_DB.m_DBm_Document_Computer.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new string[] { "ID", "ID" });
        //    tbl_DBm_Document_Computer.AddColumn((Object)mt_DB.m_DBm_Document_Computer.Document_Computer, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new string[] { "Computer source of Document ", "Izvorni računalnik dokumenta" });
        //    m_DBTables.items.Add(tbl_DBm_Document_Computer);

        //    SQLTable tbl_DBm_Document_ComputerUserName = new SQLTable((Object)new DBm_Document_ComputerUserName(), Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_DBm_Document_ComputerUser);
        //    tbl_DBm_Document_ComputerUserName.AddColumn((Object)mt_DB.m_DBm_Document_ComputerUserName.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new string[] { "ID", "ID" });
        //    tbl_DBm_Document_ComputerUserName.AddColumn((Object)mt_DB.m_DBm_Document_ComputerUserName.Document_ComputerUserName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new string[] { "Computer user source of Document ", "Izvorni računalniški uporabnik dokumenta" });
        //    m_DBTables.items.Add(tbl_DBm_Document_ComputerUserName);

        //    SQLTable tbl_DBm_Document = new SQLTable((Object)new DBm_Document(), Column.Flags.UNIQUE, lngTName.lngt_DBm_Document);
        //    tbl_DBm_Document.AddColumn((Object)mt_DB.m_DBm_Document.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new string[] { "ID", "ID" });
        //    tbl_DBm_Document.AddColumn((Object)mt_DB.m_DBm_Document.m_DBm_Document_Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new string[] { "Document Name ID", "Ime slike ID" });
        //    tbl_DBm_Document.AddColumn((Object)mt_DB.m_DBm_Document.m_DBm_Document_Author, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new string[] { "Document Author ID", "Ime avtorja slike ID" });
        //    tbl_DBm_Document.AddColumn((Object)mt_DB.m_DBm_Document.m_DBm_Document_FileName, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new string[] { "Document File Name ID", "Ime slikovne datoteke ID" });
        //    tbl_DBm_Document.AddColumn((Object)mt_DB.m_DBm_Document.m_DBm_Document_Ext, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new string[] { "Document extension ID", "Tip slike ID (končnica)" });
        //    tbl_DBm_Document.AddColumn((Object)mt_DB.m_DBm_Document.m_DBm_Document_Folder, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new string[] { "Document path ID", "Izvorna pot slike ID" });
        //    tbl_DBm_Document.AddColumn((Object)mt_DB.m_DBm_Document.m_DBm_Document_Computer, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new string[] { "Computer source of Document ID", "Izvorni računalnik slike ID" });
        //    tbl_DBm_Document.AddColumn((Object)mt_DB.m_DBm_Document.m_DBm_Document_ComputerUserName, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new string[] { "Computer user source of image ID", "Izvorni računalniški uporabnik slike ID" });
        //    tbl_DBm_Document.AddColumn((Object)mt_DB.m_DBm_Document.Document_Data, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new string[] { "Document data", "Vsebina dokumenta" });
        //    m_DBTables.items.Add(tbl_DBm_Document);
        //}

        public bool DataBase_Backup(string full_backup_filename)
        {
            return this.m_DBTables.DataBase_Backup(full_backup_filename);
        }

        public bool DataBase_Restore(string full_backup_filename)
        {
            return this.m_DBTables.DataBase_Restore(full_backup_filename);
        }

        public bool DataBase_Make_BackupTemp()
        {
            return this.m_DBTables.DataBase_Make_BackupTemp();
        }

        public bool DataBase_Delete_BackupTemp()
        {
            return this.m_DBTables.DataBase_Delete_BackupTemp();
        }

        public bool DataBase_Delete()
        {
            return this.m_DBTables.DataBase_Delete();
        }

        public bool DataBase_Create()
        {
            if (this.m_DBTables.DataBase_Create())
            { 
                return this.m_DBTables.CreateDatabaseTables(false);
            }
            else
            {
                return false;
            }
        }
    }
}
