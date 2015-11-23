using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DBTypes;

namespace SQLTableControl
{
    public class Document_Box : GroupBox
    {
        public const int const_DocumentPictureWidth = 320;
        public const int const_DocumentPictureHeight = 320;

        //public FileInfo_Box FileInfo_Box;
        public DBm_Document DBm_Document;
        public PictureBox Picture;
        public Document_Box(usrc_InputControl inpCtrl)
        {
            DBm_Document = new DBm_Document();
            //FileInfo_Box = new FileInfo_Box(inpCtrl,this);
            Picture = new PictureBox();
            Picture.Parent = this;
            Picture.Top = this.Height;
            Picture.Width = const_DocumentPictureWidth;
            Picture.Height = const_DocumentPictureHeight;
            this.Height += Picture.Height;
        }

    }

}
