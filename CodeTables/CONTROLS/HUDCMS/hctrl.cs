using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UniqueControlNames;

namespace HUDCMS
{
    public class hctrl
    {
        public Control ctrl = null;
        public Form pForm = null;
        public DataGridViewColumn dgvc = null;
        public hctrl parentctrl = null;
        public List<hctrl> subctrl = null;
        public int xScr = -1;
        public int yScr = -1;
        public int width = 0;
        public int height = 0;
        public Screen pScreen = null;
        public Bitmap ctrlbmp = null;

        public int Bottom {
            get
            {
                if (ctrl!=null)
                {
                    if (ctrl.Parent !=null)
                    {
                        if (ctrl.Parent is Form)
                        {

                            Point locationOnForm = RelativeToFormPosition(ctrl, (Form)ctrl.Parent);
                            if (locationOnForm.Y != ctrl.Top)
                            {
                                int TopMargin = locationOnForm.Y - ctrl.Top;
                                return ctrl.Bottom+ TopMargin; 
                            }
                        }
                    }
                    return ctrl.Bottom;
                }
                else
                {
                    if (pForm != null)
                    {
                        return pForm.Bottom;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
        }

        public int Top
        {
            get
            {
                if (ctrl != null)
                {
                    if (ctrl.Parent != null)
                    {
                        if (ctrl.Parent is Form)
                        {
                            Point locationOnForm = RelativeToFormPosition(ctrl, (Form)ctrl.Parent);
                            return locationOnForm.Y;
                        }
                    }
                    return ctrl.Top;
                }
                else
                {
                    if (pForm != null)
                    {
                        return pForm.Top;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
        }

        public int Left
        {
            get
            {
                if (ctrl != null)
                {
                    if (ctrl.Parent != null)
                    {
                        if (ctrl.Parent is Form)
                        {
                            Point locationOnForm = RelativeToFormPosition(ctrl, (Form)ctrl.Parent);
                            return locationOnForm.X;
                        }
                    }
                    return ctrl.Left;
                }
                else
                {
                    if (pForm != null)
                    {
                        return pForm.Left;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
        }

        public int Right
        {
            get
            {
                if (ctrl != null)
                {
                    if (ctrl.Parent != null)
                    {
                        if (ctrl.Parent is Form)
                        {
                            Point locationOnForm = RelativeToFormPosition(ctrl, (Form)ctrl.Parent);
                            if (locationOnForm.X != ctrl.Left)
                            {
                                int LeftMargin = locationOnForm.X - ctrl.Left;
                                return ctrl.Right + LeftMargin;
                            }
                        }
                    }
                    return ctrl.Right;
                }
                else
                {
                    if (pForm != null)
                    {
                        return pForm.Right;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
        }

        public hctrl(Form pForm, UniqueControlName xuctrln)
        {
            this.pForm = pForm;
            xScr = pForm.Left;
            yScr = pForm.Top;
            pScreen = Screen.FromControl(pForm);
            ctrlbmp = new Bitmap(pForm.Width, pForm.Height);
            pForm.DrawToBitmap(ctrlbmp, new Rectangle(0, 0, pForm.Width, pForm.Height));
            foreach (Control c in pForm.Controls)
            {
                if (c is UserControl)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is SplitContainer)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is SplitterPanel)
                {
                    ((SplitterPanel)c).AccessibleName = "spl" + xuctrln.Get_SplitterPanel_UniqueIndex();
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is Panel)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is CheckBox)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is RadioButton)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is DateTimePicker)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is GroupBox)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is Label)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is Button)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is TextBox)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is RichTextBox)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is HScrollBar)
                {
                    if (c.Parent != null)
                    {
                        if (!(c.Parent is DataGridView))
                        {
                            AddSubCtrl(c, xuctrln);
                        }
                    }
                    else
                    {
                        AddSubCtrl(c, xuctrln);
                    }
                }
                else if (c is VScrollBar)
                {
                    if (c.Parent != null)
                    {
                        if (!(c.Parent is DataGridView))
                        {
                            AddSubCtrl(c, xuctrln);
                        }
                    }
                    else
                    {
                        AddSubCtrl(c, xuctrln);
                    }
                }
                else if (c is ComboBox)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is NumericUpDown)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is DataGridView)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is PictureBox)
                {
                    AddSubCtrl(c, xuctrln);
                }
            }
            Create_position_sorted_subctrl();
        }

       

        public hctrl(Control xc,hctrl xparent, UniqueControlName xuctrln)
        {
            this.ctrl = xc;
            this.parentctrl = xparent;
            xScr = xparent.xScr + xc.Left;
            yScr = xparent.yScr + xc.Top;
            if ((xc.Width > 0) && (xc.Height > 0))
            {
                ctrlbmp = new Bitmap(xc.Width, xc.Height);
                xc.DrawToBitmap(ctrlbmp, new Rectangle(0, 0, xc.Width, xc.Height));
            }
            else
            {
                ctrlbmp = null;
            }
            foreach (Control c in xc.Controls)
            {
                if (c is UserControl)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is SplitContainer)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is SplitterPanel)
                {
                    ((SplitterPanel)c).AccessibleName = "spl" + xuctrln.Get_SplitterPanel_UniqueIndex();
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is Panel)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is CheckBox)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is RadioButton)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is DateTimePicker)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is GroupBox)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is Label)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is Button)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is TextBox)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is RichTextBox)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is HScrollBar)
                {
                    if (c.Parent != null)
                    {
                        if (!(c.Parent is DataGridView))
                        {
                            AddSubCtrl(c, xuctrln);
                        }
                    }
                    else
                    {
                        AddSubCtrl(c, xuctrln);
                    }
                }
                else if (c is VScrollBar)
                {
                    if (c.Parent != null)
                    {
                        if (!(c.Parent is DataGridView))
                        {
                            AddSubCtrl(c, xuctrln);
                        }
                    }
                    else
                    {
                        AddSubCtrl(c, xuctrln);
                    }
                }
                else if (c is ComboBox)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is NumericUpDown)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is PictureBox)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else if (c is DataGridView)
                {
                    AddSubCtrl(c, xuctrln);
                }
                else
                {
                    MessageBox.Show("Control not implemented: type=" + c.GetType().ToString() + " Name =\"" + c.Name + "\"");
                }
            }
            Create_position_sorted_subctrl();
        }

        public hctrl(DataGridViewColumn dgvc, hctrl xparent)
        {
            this.ctrl = null;
            this.pForm = null;
            this.dgvc = dgvc;
            this.parentctrl = xparent;
            this.ctrlbmp = null;
            xScr = 0;
            yScr = 0;
        }


        private Point RelativeToFormPosition(Control xctrl, Form form)
        {
            Point controlLoc = form.PointToScreen(xctrl.Location);
            Point relativeLoc = new Point(controlLoc.X - form.Location.X, controlLoc.Y - form.Location.Y);
            return relativeLoc;
        }




        private void AddSubCtrl(Control c, UniqueControlName xuctrln)
        {
            if (subctrl==null)
            {
                subctrl = new List<hctrl>();
            }
            hctrl newhc = new hctrl(c, this, xuctrln);
            subctrl.Add(newhc);
            if (c is DataGridView)
            {
                foreach (DataGridViewColumn dgvc in ((DataGridView)c).Columns)
                {
                    if (dgvc.Visible)
                    {
                        newhc.AddSubCtrl(dgvc);
                    }
                }
            }
        }

        private void AddSubCtrl(DataGridViewColumn dgvc)
        {
            if (subctrl == null)
            {
                subctrl = new List<hctrl>();
            }
            hctrl newhc = new hctrl(dgvc, this);
            subctrl.Add(newhc);
        }

        private void Create_position_sorted_subctrl()
        {
            if (subctrl != null)
            {
                int iCount = subctrl.Count;

                for (int i=0;i<iCount;i++)
                {
                    for (int j = i + 1; j < iCount; j++)
                    {
                        if (subctrl_j_before_subctrl_i(j,i))
                        {
                            raplace(j, i);
                        }
                    }
                }
            }
        }

        private void raplace(int j, int i)
        {
            var item = subctrl[j];
            subctrl.RemoveAt(j);
            if (i > j) i--;
            // the actual index could have shifted due to the removal
            subctrl.Insert(i, item);
        }

        private bool subctrl_j_before_subctrl_i(int j, int i)
        {
            hctrl hcj = subctrl[j];
            hctrl hci = subctrl[i];
            if ((midy(hcj) < midy(hci)-10)&& (midy(hcj) < midy(hci) + 10))
            {
                //above
                return true;

            }
            else if ((midy(hcj) > midy(hci) - 10) && (midy(hcj) > midy(hci) + 10))
            {
                //below
                return false;
            }
            else
            {
                // in same row compare xScr
                if (hcj.xScr < hci.xScr)
                {
                    //before
                    return true;
                }
                else
                {
                    //after
                    return false;
                }
            }

        }

        private int midy(hctrl hcj)
        {
           return hcj.yScr + hcj.height / 2;
        }

        public string GetName()
        {
            if (parentctrl != null)
            {
                string sctrlname = "";
                if (ctrl != null)
                {
                    if (ctrl is SplitterPanel)
                    {
                        sctrlname = ((SplitterPanel)ctrl).AccessibleName;
                    }
                    else if (ctrl is HScrollBar)
                    {
                        if (ctrl.Parent != null)
                        {
                            if (ctrl.Parent is DataGridView)
                            {
                                if (((HScrollBar)ctrl).Name.Length == 0)
                                {
                                    sctrlname = "hscrl";
                                }
                            }
                        }
                    }
                    else if (ctrl is VScrollBar)
                    {
                        if (ctrl.Parent != null)
                        {
                            if (ctrl.Parent is DataGridView)
                            {
                                if (((HScrollBar)ctrl).Name.Length == 0)
                                {
                                    sctrlname = "hscrl";
                                }
                            }
                        }
                    }
                    else
                    {
                        sctrlname = ctrl.Name;
                    }
                }
                else if (pForm != null)
                {
                    sctrlname = pForm.Name;
                }
                else if (dgvc != null)
                {
                    //string sdgvcname = dgvc.Name.Replace("_$", "_");
                    //sdgvcname = sdgvcname.Replace("$", "");
                    //sctrlname = sdgvcname;
                    sctrlname = dgvc.Name;
                }
                else
                {
                    MessageBox.Show("ERROR:HUDCSM:hctrl:(ctrl == null)&&(pForm != null)!");
                    return "ERROR";
                }

                if (sctrlname.Length==0)
                {
                    MessageBox.Show("ERROR:HUDCSM:sctrlname.Length==0!");
                }
                string sname =parentctrl.GetName()+"."+ sctrlname;

                return sname;
            }
            else
            {
                if (ctrl != null)
                {
                    if (ctrl is SplitterPanel)
                    {
                        string xsctrlname = ((SplitterPanel)ctrl).AccessibleName;
                        if (xsctrlname.Length == 0)
                        {
                            MessageBox.Show("ERROR:HUDCSM:xsctrlname.Length==0!");
                        }
                        return ((SplitterPanel)ctrl).AccessibleName;
                    }
                    else
                    {
                        string xsctrlname = ctrl.Name;
                        if (xsctrlname.Length == 0)
                        {
                            MessageBox.Show("ERROR:HUDCSM:xsctrlname.Length==0!");
                        }
                        return ctrl.Name;
                    }
                }
                else if (pForm != null)
                {
                    return pForm.Name;
                }
                else
                {
                    MessageBox.Show("ERROR:HUDCSM:hctrl:(ctrl == null)&&(pForm != null)!");
                    return "ERROR";
                }
            }
        }

    }
}
