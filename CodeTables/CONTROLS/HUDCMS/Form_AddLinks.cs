using BrightIdeasSoftware;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HUDCMS
{
    public partial class Form_AddLinks : Form
    {
        ArrayList roots = new ArrayList();
        SysImageListHelper helperControlType = null;
        ImageRenderer helperImageRenderer = null;
        Form_HUDCMS frm_HUDCMS = null;
        MyControl myroot = null;
        MyControl SelectedControl = null;
        int iAllControls = 0;

        public Form_AddLinks(Form_HUDCMS xfrm_HUDCMS)
        {
            InitializeComponent();
            frm_HUDCMS = xfrm_HUDCMS;
            InitializeMyTreeListView(ref iAllControls);
        }

        //private void SetLinks()
        //{
        //   MyControl roor myctrl.Parent
        //   while (myctrl.Parent!=null)
            
            
        //}

        private void lbl_SnapShotMargin_Click(object sender, EventArgs e)
        {

        }

        private void nmUpDn_SnapShotMargin_ValueChanged(object sender, EventArgs e)
        {

        }

        void InitializeMyTreeListView(ref int iAllCount)
        {

            this.MyTreeListView.HierarchicalCheckboxes = false;
            this.MyTreeListView.HideSelection = false;
            this.MyTreeListView.UseCellFormatEvents = true;
            this.MyTreeListView.FormatRow += MyTreeListView_FormatRow;
            this.MyTreeListView.CanExpandGetter = delegate (object x) {
                return ((MyControl)x).HasChildren;
            };
            this.MyTreeListView.ChildrenGetter = delegate (object x) {
                MyControl myControl = (MyControl)x;
                try
                {
                    return myControl.GetChildren();
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show(this, ex.Message, "ObjectListViewDemo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return new ArrayList();
                }
            };

           

            //this.treeListView.CheckBoxes = false;

            // You can change the way the connection lines are drawn by changing the pen
            TreeListView.TreeRenderer renderer = this.MyTreeListView.TreeColumnRenderer;
            renderer.LinePen = new Pen(Color.Firebrick, 0.5f);
            renderer.LinePen.DashStyle = DashStyle.Dot;

            //-------------------------------------------------------------------
            // Eveything after this is the same as the Explorer example tab --
            // nothing specific to the TreeListView. It doesn't have the grouping
            // delegates, since TreeListViews can't show groups.

            // Draw the system icon next to the name

            helperControlType = new SysImageListHelper(this.MyTreeListView);

            this.olvc_ControlType.ImageGetter = delegate (object x)
            {
                return helperControlType.GetControlTypeImageIndex(((MyControl)x).ControlType);
            };


            this.olvc_ControlImage.ImageGetter = delegate (object x)
            {
                int idx = helperImageRenderer.ImageList.Images.IndexOfKey(((MyControl)x).ControlUniqueName);
                return idx;
            };

            helperImageRenderer = new ImageRenderer();
            this.olvc_ControlImage.Renderer = helperImageRenderer;

            // List all drives as the roots of the tree
            myroot = Form_HUDCMS.CreateMyControls(0, 0, ref iAllCount,frm_HUDCMS.hc, null, ref helperControlType,  ref frm_HUDCMS.mH);

            Form_HUDCMS.SetLinks(myroot, ref helperImageRenderer);

            this.helperImageRenderer.Aspect = (System.Int32)0;

            roots.Add(myroot);
            this.MyTreeListView.Roots = roots;
        }


        private void MyTreeListView_FormatRow(object sender, FormatRowEventArgs e)
        {
            if (sender is TreeListView)
            {
                if (e.Item.RowObject is MyControl)
                {
                    MyControl myctrl = (MyControl)e.Item.RowObject;
                    if (myctrl.HasTitle)
                    {
                        e.Item.ForeColor = Color.Blue;
                    }
                    else
                    {
                        e.Item.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void MyTreeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is TreeListView)
            {
                TreeListView treeListView = (TreeListView)sender;
                int selectedindex = treeListView.SelectedIndex;
                OLVListItem olvi = treeListView.SelectedItem;
                if (olvi != null)
                {
                    if (olvi.RowObject is MyControl)
                    {
                        this.SelectedControl = (MyControl)olvi.RowObject;
                        if (frm_HUDCMS.hc.dgvc == null)
                        {
                            if (SelectedControl.hc.ctrlbmp != null)
                            {
                                this.pictureBox1.Image = SelectedControl.hc.ctrlbmp;
                                this.txt_ControlUniqueName.Text = SelectedControl.ControlUniqueName;
                            }
                            //xfrm_HUDCMS.HideLinks();
                            //xfrm_HUDCMS.ShowAvailableLinks();
                        }
                        else
                        {

                        }
                    }
                }
            }
        }

        private void btn_AddLink_Click(object sender, EventArgs e)
        {
            if (SelectedControl!=null)
            {
                frm_HUDCMS.usrc_EditControl1.AddLink(SelectedControl);
            }
        }
    }
}
