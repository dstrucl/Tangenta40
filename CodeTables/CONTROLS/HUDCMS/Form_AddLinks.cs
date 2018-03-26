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
        MyControl myroot = null;
        //DataTable dtPLink = new DataTable();
        //DataTable dtLink = new DataTable();
        int iAllControls = 0;

        public Form_AddLinks(MyControl xmyroot, SysImageListHelper xhelperControlType,ImageRenderer xhelperImageRenderer)
        {
            InitializeComponent();
            helperControlType = xhelperControlType;
            helperImageRenderer = xhelperImageRenderer;
            myroot = xmyroot;
            InitializeMyTreeListView(ref iAllControls);
            //DataColumn dcolPLink = new DataColumn("PLink", typeof(string));
            //DataColumn dcolLink = new DataColumn("Link", typeof(string));
            //dtPLink.Columns.Add(dcolPLink);
            //dtLink.Columns.Add(dcolLink);
            //SetLinks();

            //DataGridViewButtonColumn dgvbc = new DataGridViewButtonColumn();

            //dataGridView1.Columns.Add
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

            this.MyTreeListView.HierarchicalCheckboxes = true;
            this.MyTreeListView.HideSelection = false;
            //this.MyTreeListView.RowHeight = 32;
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
            //this.olvc_ControlName.ImageGetter = null;
            helperControlType.Init(this.MyTreeListView, helperControlType.SmallImageList, helperControlType.LargeImageList);

            //helper.AddImageToCollection("root1", helper.LargeImageList, Properties.Resources.nav_CommandLineHelp_Form);
            //helper.AddImageToCollection("root2", helper.LargeImageList, Properties.Resources.nav_CommandLineHelp_Form_grp_CommandLineParameters);
            //helper.AddImageToCollection("r1_ch1", helper.LargeImageList, Properties.Resources.limeleaf);
            //helper.AddImageToCollection("r1_ch2", helper.LargeImageList, Properties.Resources.coffee);
            this.olvc_ControlType.ImageGetter = delegate (object x)
            {
                return helperControlType.GetControlTypeImageIndex(((MyControl)x).ControlType);
            };

            //this.olvc_ControlName.ImageGetter = delegate (object x)
            //{
            //    return helperControlName.GetControlImageIndex(((MyControl)x).ControlName);
            //};

            this.olvc_ControlImage.ImageGetter = delegate (object x)
            {
                int idx = helperImageRenderer.ImageList.Images.IndexOfKey(((MyControl)x).ControlUniqueName);
                return idx;
            };

            // Show the size of files as GB, MB and KBs. Also, group them by
            // some meaningless divisions
            //this.treeColumnSize.AspectGetter = delegate (object x) {
            //    MyControl myControl = (MyControl)x;

            //    if (!myControl.HasChildren)
            //        return (long)-1;

            //    try
            //    {
            //        return 27061962;
            //    }
            //    catch (System.IO.FileNotFoundException)
            //    {
            //        // Mono 1.2.6 throws this for hidden files
            //        return (long)-2;
            //    }
            //};
            //this.treeColumnSize.AspectToStringConverter = delegate (object x) {
            //    if ((long)x == -1) // folder
            //        return "";

            //    return this.FormatFileSize((long)x);
            //};

            //// Show the system description for this object
            //this.treeColumnFileType.AspectGetter = delegate (object x) {
            //    return ShellUtilities.GetFileType(((MyFileSystemInfo)x).FullName);
            //};

            //// Show the file attributes for this object
            //this.treeColumnAttributes.AspectGetter = delegate (object x) {
            //    return ((MyFileSystemInfo)x).Attributes;
            //};
            //helperImageRenderer = new ImageRenderer();
            this.olvc_ControlImage.Renderer = helperImageRenderer;

            // List all drives as the roots of the tree
            //MyControl myroot = Form_HUDCMS.CreateMyControls(0, 0, ref iAllCount, hc, null, ref helperControlType, ref helperImageRenderer);

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
    }
}
