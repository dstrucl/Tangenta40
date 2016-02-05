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
using System.IO.Compression;
using System.IO;

namespace SQLTableControl
{
    public partial class InputControl_DocumentBox : UserControl
    {
        usrc_InputControl inpCtrl = null;
        private const int BUFFER_SIZE = 64 * 1024; //64kB
        public Byte[] Data;
        //public FileInfo_Box FileInfo_Box;
        public InputControl_DocumentBox(usrc_InputControl xinpCtrl)
        {
            InitializeComponent();
            inpCtrl = xinpCtrl;
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog(this)==DialogResult.OK)
            {
                string file = ofd.FileName;
                Data = System.IO.File.ReadAllBytes(file);
                xDocument_Get_and_FillData(Data);
                inpCtrl.SetChanged(this);
            }
        }

        public void xDocument_Get_and_FillData(byte[] bytes)
        {
            string hash = DBtypesFunc.GetHash_SHA1(bytes);

            foreach (Column col in inpCtrl.m_ParentTbl.Column)
            {
                if (col.Name.Equals("xDocument_Hash"))
                {
                    col.InputControl.Set_xDocument_Hash(hash);
                    break;
                }
            }
        }
    }
}
