using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HUDCMS
{
    public class hctrl
    {
        public Control ctrl = null;
        public hctrl parentctrl = null;
        public List<hctrl> subctrl = null;
        public int xScr = -1;
        public int yScr = -1;
        public int width = 0;
        public int height = 0;
        public Form pForm = null;
        public Screen pScreen = null;
        public Bitmap ctrlbmp = null;

        public int Bottom {
            get
            {
                if (ctrl!=null)
                {
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

        public hctrl(Form pForm)
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
                    AddSubCtrl(c);
                }
                else if (c is SplitContainer)
                {
                    AddSubCtrl(c);
                }
                else if (c is Panel)
                {
                    AddSubCtrl(c);
                }
                else if (c is CheckBox)
                {
                    AddSubCtrl(c);
                }
                else if (c is RadioButton)
                {
                    AddSubCtrl(c);
                }
                else if (c is DateTimePicker)
                {
                    AddSubCtrl(c);
                }
                else if (c is GroupBox)
                {
                    AddSubCtrl(c);
                }
                else if (c is Label)
                {
                    AddSubCtrl(c);
                }
                else if (c is Button)
                {
                    AddSubCtrl(c);
                }
                else if (c is TextBox)
                {
                    AddSubCtrl(c);
                }
                else if (c is ComboBox)
                {
                    AddSubCtrl(c);
                }
                else if (c is NumericUpDown)
                {
                    AddSubCtrl(c);
                }
            }
            Create_position_sorted_subctrl();
        }

       

        public hctrl(Control xc,hctrl xparent)
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
                    AddSubCtrl(c);
                }
                else if (c is SplitContainer)
                {
                    AddSubCtrl(c);
                }
                else if (c is Panel)
                {
                    AddSubCtrl(c);
                }
                else if (c is CheckBox)
                {
                    AddSubCtrl(c);
                }
                else if (c is RadioButton)
                {
                    AddSubCtrl(c);
                }
                else if (c is DateTimePicker)
                {
                    AddSubCtrl(c);
                }
                else if (c is GroupBox)
                {
                    AddSubCtrl(c);
                }
                else if (c is Label)
                {
                    AddSubCtrl(c);
                }
                else if (c is Button)
                {
                    AddSubCtrl(c);
                }
                else if (c is TextBox)
                {
                    AddSubCtrl(c);
                }
                else if (c is ComboBox)
                {
                    AddSubCtrl(c);
                }
                else if (c is NumericUpDown)
                {
                    AddSubCtrl(c);
                }
            }
            Create_position_sorted_subctrl();
        }

        private void AddSubCtrl(Control c)
        {
            if (subctrl==null)
            {
                subctrl = new List<hctrl>();
            }
            subctrl.Add(new hctrl(c,this));
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
                string sctrlname = "ERROR";
                if (ctrl != null)
                {
                    sctrlname = ctrl.Name;
                }
                else if (pForm != null)
                {
                    sctrlname = pForm.Name;
                }
                else
                {
                    MessageBox.Show("ERROR:HUDCSM:hctrl:(ctrl == null)&&(pForm != null)!");
                    return "ERROR";
                }

                string sname =parentctrl.GetName()+"."+ sctrlname;
                return sname;
            }
            else
            {
                if (ctrl != null)
                {
                    return ctrl.Name;
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
