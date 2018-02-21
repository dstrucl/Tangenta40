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
using System.Windows.Forms;
using DBTypes;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using UniqueControlNames;

namespace CodeTables
{
    public class Picture_Box : GroupBox
    {
        public System.Drawing.Imaging.ImageFormat imgFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
        public const int const_PictureWidth = 320;
        public const int const_PictureHeight = 320;
        public const int const_TopDistance = 5;
        public const int const_LeftDistance = 5;
        public const int const_LabelWidth = 64;
        public const int const_LabelHeight = 16;
        public const int const_TextBoxWidth = 120;
        public const int const_TextBoxHeight = 16;
        public const int const_btnFileSelect_Width = 32;
        public const int const_btnFileSelect_Height = 24;
        public bool bReadOnly = false;
        public int BtnFileSelectWidth = 32;
        public int InputBoxHeight = 21;

        //public FileInfo_Box FileInfo_Box;
        public DBm_Image DBm_Image;
        public Button btnFolderSelect = null;
        public PictureBox Picture;
        private usrc_InputControl inpCtrl;
        private SQLTable DBm_Image_Table;
        public Picture_Box(usrc_InputControl xinpCtrl, UniqueControlName xuctrln, SQLTable pParentTbl, int PictureBoxWidth, int PictureBoxHeight, bool xbReadOnly)
        {
            this.Name = "picbox_" + xuctrln.Get_PictureBox_UniqueIndex();
            inpCtrl = xinpCtrl;
            DBm_Image_Table = pParentTbl;
            bReadOnly = xbReadOnly;
            if (!bReadOnly)
            {
                btnFolderSelect = new Button();
                xinpCtrl.Controls.Add(btnFolderSelect);
                btnFolderSelect.Width = BtnFileSelectWidth;
                btnFolderSelect.Height = InputBoxHeight;
                btnFolderSelect.Image = Properties.Resources.SmallFolderIcon.ToBitmap();
                btnFolderSelect.Text = "";
                btnFolderSelect.Visible = true;
                btnFolderSelect.Tag = this;
            }

            DBm_Image = new DBm_Image();
            //FileInfo_Box = new FileInfo_Box(inpCtrl,this);
            Picture = new PictureBox();
            Picture.Parent = this;
            Picture.Top = 10;
            Picture.Left = 5;
            Picture.Width = PictureBoxWidth - 10;
            Picture.Height =PictureBoxHeight - 15;
            //this.Height += Picture.Height;
            Picture.SizeMode = PictureBoxSizeMode.Zoom;
            this.Height = PictureBoxHeight;
            if (!bReadOnly)
            {
                this.Cursor = Cursors.Arrow;
                btnFolderSelect.Cursor = Cursors.Arrow;
                Picture.Cursor = Cursors.Arrow;
                btnFolderSelect.Tag = Picture;
                btnFolderSelect.Click += new EventHandler(OnButtonClick_PictureSelect);
            }
            else
            {
                this.Cursor = Cursors.No;
                Picture.Cursor = Cursors.No;
            }
        }

        private void OnButtonClick_PictureSelect(object sender, EventArgs e)
        {

            if (sender.GetType() == typeof(Button))
            {
                Button btnSelect = (Button)sender;
                DialogResult dRes;
                OpenFileDialog opnFileDlg = new OpenFileDialog();
                opnFileDlg.Filter = "Picture files (*.jpg)|*.jpg|All files (*.*)|*.* ";
                opnFileDlg.FilterIndex = 2;
                opnFileDlg.FileName = "*.*"; //PathImport + "\\" + btnSelectFile.m_InputTextBox.Text;
                opnFileDlg.InitialDirectory = inpCtrl.PathImportPicture;
                opnFileDlg.RestoreDirectory = true;
                dRes = opnFileDlg.ShowDialog();
                if (dRes == DialogResult.OK)
                {
                    inpCtrl.PathImportPicture = Path.GetDirectoryName(opnFileDlg.FileName);
                    Properties.Settings.Default.SelectPicturePath = inpCtrl.PathImportPicture;
                    Properties.Settings.Default.Save();

                    PictureBox Picture = (PictureBox)btnSelect.Tag;

                    Image OrgImage = new Bitmap(opnFileDlg.FileName);
                    //if ((OrgImage.Width <= MAX_PICTURE_WIDTH) && (OrgImage.Height <= MAX_PICTURE_HEIGHT))
                    //{
                    //    Picture.Image = OrgImage;
                    //}
                    //else
                    //{

                    //}

                    ResizeImage_Form resdlg = new ResizeImage_Form(OrgImage);
                    if (resdlg.ShowDialog() == DialogResult.OK)
                    {
                        Picture.Image = (Image)resdlg.m_NewImage.Clone();
                        this.DBm_Image.Image_Data.Image = Picture.Image;
                        imgFormat = Picture.Image.RawFormat;
                        inpCtrl.Defined = true;
                    }
                    else
                    {
                        Picture.Image = OrgImage;
                    }

                    DBm_Image_Get_and_FillData(this.DBm_Image.Image_Data.Image, opnFileDlg.FileName);

                    Picture.SizeMode = PictureBoxSizeMode.Zoom;
                    inpCtrl.SetChanged(this);
                }
            }
        }

        public void DBm_Image_Get_and_FillData(Image img, string filename)
        {
            string hash = DBtypesFunc.GetHash_SHA1(DBtypesFunc.imageToByteArray(img));
            
            foreach (Column col in inpCtrl.m_ParentTbl.Column)
            {
                if (col.Name.Equals("Image_Hash"))
                {
                    col.InputControl.Set_Image_Hash(hash);
                    break;
                }
            }
            DBm_Image.Image_Data.Image = img;
            string Image_FileName = Path.GetFileNameWithoutExtension(filename);
            string Image_Ext = Path.GetExtension(filename);
            string Image_Folder = Path.GetDirectoryName(filename);
            string ComputerName = SystemInformation.ComputerName;
            string ComputerUserName = SystemInformation.UserDomainName + "\\" + SystemInformation.UserName;
            // Create new FileInfo object and get the Length.
            FileInfo f = new FileInfo(filename);
            DateTime CaptureTime = File.GetCreationTime(filename);
            long Image_Size = f.Length;
            int img_width = img.PhysicalDimension.ToSize().Width;
            int img_height = img.PhysicalDimension.ToSize().Height;

            DBm_Image_FillData(img_width,
                               img_height,
                               hash,
                               Picture.Image.RawFormat,
                               Image_Size,
                               Image_FileName,
                               Image_Ext,
                               Image_Folder,
                               ComputerName,
                               ComputerUserName,
                               CaptureTime
                               );

        }
        private void DBm_Image_FillData(int img_width, int img_height, string hash, ImageFormat imageFormat, long Image_Size, string Image_FileName, string Image_Ext, string Image_Folder, string ComputerName, string ComputerUserName, DateTime CaptureTime)
        {
            usrc_InputControl input_ctrl_Image_Width = DBm_Image_Table.GetInputControl(DBm_Image.Image_Width.GetType());
            if (input_ctrl_Image_Width != null)
            {
                input_ctrl_Image_Width.SetValue(img_width);
                input_ctrl_Image_Width.InputControl_ValueChanged(this);
            }

            usrc_InputControl input_ctrl_Image_Height = DBm_Image_Table.GetInputControl(DBm_Image.Image_Height.GetType());
            if (input_ctrl_Image_Width != null)
            {
                input_ctrl_Image_Width.SetValue(img_height);
                input_ctrl_Image_Width.InputControl_ValueChanged(this);
            }

            usrc_InputControl input_ctrl_Image_Hash = DBm_Image_Table.GetInputControl(DBm_Image.Image_Hash.GetType());
            if (input_ctrl_Image_Hash != null)
            {
                input_ctrl_Image_Hash.SetValue(hash);
                input_ctrl_Image_Hash.InputControl_ValueChanged(this);
            }

            usrc_InputControl input_ctrl_Image_Size = DBm_Image_Table.GetInputControl(DBm_Image.Image_Size.GetType());
            if (input_ctrl_Image_Size != null)
            {
                input_ctrl_Image_Size.SetValue(Image_Size);
                input_ctrl_Image_Size.InputControl_ValueChanged(this);
            }
            usrc_InputControl input_ctrl_Image_FileName = DBm_Image_Table.GetInputControl(DBm_Image.m_DBm_Image_FileName.Image_FileName.GetType());
            if (input_ctrl_Image_FileName != null)
            {
                input_ctrl_Image_FileName.SetValue(Image_FileName);
                input_ctrl_Image_FileName.InputControl_ValueChanged(this);
            }

            usrc_InputControl input_ctrl_Image_Ext = DBm_Image_Table.GetInputControl(DBm_Image.m_DBm_Image_Ext.Image_Ext.GetType());
            if (input_ctrl_Image_Ext != null)
            {
                input_ctrl_Image_Ext.SetValue(Image_Ext);
                input_ctrl_Image_Ext.InputControl_ValueChanged(this);
            }


            usrc_InputControl input_ctrl_Image_Folder = DBm_Image_Table.GetInputControl(DBm_Image.m_DBm_Image_Folder.Image_Folder.GetType());
            if (input_ctrl_Image_Folder != null)
            {
                input_ctrl_Image_Folder.SetValue(Image_Folder);
                input_ctrl_Image_Folder.InputControl_ValueChanged(this);
            }

            usrc_InputControl input_ctrl_Image_ComputerName = DBm_Image_Table.GetInputControl(DBm_Image.m_DBm_Image_Computer.Image_Computer.GetType());
            if (input_ctrl_Image_ComputerName != null)
            {
                input_ctrl_Image_ComputerName.SetValue(ComputerName);
                input_ctrl_Image_ComputerName.InputControl_ValueChanged(this);
            }

            usrc_InputControl input_ctrl_Image_ComputerUserName = DBm_Image_Table.GetInputControl(DBm_Image.m_DBm_Image_ComputerUserName.Image_ComputerUserName.GetType());
            if (input_ctrl_Image_ComputerUserName != null)
            {
                input_ctrl_Image_ComputerUserName.SetValue(ComputerUserName);
                input_ctrl_Image_ComputerUserName.InputControl_ValueChanged(this);
            }

            usrc_InputControl input_ctrl_Image_CaptureTime = DBm_Image_Table.GetInputControl(DBm_Image.Image_DateCreated.GetType());
            if (input_ctrl_Image_CaptureTime != null)
            {
                input_ctrl_Image_CaptureTime.SetValue(CaptureTime);
                input_ctrl_Image_CaptureTime.InputControl_ValueChanged(this);
            }
        }

    }

}
