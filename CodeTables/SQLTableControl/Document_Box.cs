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
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DBTypes;
using UniqueControlNames;

namespace CodeTables
{
    public class Document_Box : GroupBox
    {
        public const int const_DocumentPictureWidth = 320;
        public const int const_DocumentPictureHeight = 320;

        //public FileInfo_Box FileInfo_Box;
        public DBm_Document DBm_Document;
        public PictureBox Picture;
        public Document_Box(usrc_InputControl inpCtrl,UniqueControlName xuctrln)
        {
            this.Name ="docbox"+ xuctrln.Get_Document_Box_UniqueIndex();
            DBm_Document = new DBm_Document();
            //FileInfo_Box = new FileInfo_Box(inpCtrl,this);
            Picture = new PictureBox();
            Picture.Name = "pic_" + xuctrln.Get_PictureBox_UniqueIndex();
            Picture.Parent = this;
            Picture.Top = this.Height;
            Picture.Width = const_DocumentPictureWidth;
            Picture.Height = const_DocumentPictureHeight;
            this.Height += Picture.Height;
        }

    }

}
