using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace usrc_Item_InsidePageGroup_Handler
{
    public partial class usrc_Item_InsidePageGroupHandler : UserControl
    {
        private List<object> oItemsList = null;
        private object[] oItemsArray = null;
        private DataRow[] drItems = null;

        public delegate void delegate_CreateControl(ref Control ctrl);
        public event delegate_CreateControl CreateControl = null;

        public delegate void delegate_FillControl(Control ctrl, object oData);
        public event delegate_FillControl FillControl = null;

        public delegate bool delegate_LoadItemsArray(string[] groups, ref object[] arr);
        public event delegate_LoadItemsArray LoadItemsArray = null;

        public delegate bool delegate_LoadItemsList(string[] groups, ref List<object> list);
        public event delegate_LoadItemsList LoadItemsList = null;


        public delegate bool delegate_SetName(object oData, ref string name);
        public event delegate_SetName SetName = null;


        public delegate void delegate_SelectControl(Control ctrl, object oData, int index, bool selected);
        public event delegate_SelectControl SelectControl = null;

        //public delegate void delegate_Select(object oData, int index);
        //public event delegate_Select Select = null;

        public delegate void delegate_SelectionChanged(Control ctrl, object oData, int index);
        public event delegate_SelectionChanged SelectionChanged = null;

        public delegate void delegate_ControlClick(Control ctrl, object oData, int index, bool selected);
        public event delegate_ControlClick ControlClick = null;

        public delegate void delegate_PageChanged(int iPage);
        public event delegate_PageChanged PageChanged = null;

        //public delegate void delegate_Deselect(object oData, int index);
        //public event delegate_Deselect Deselect = null;


        public usrc_Item_InsidePageGroupHandler()
        {
            InitializeComponent();
            usrc_Item_InsidePageHandler1.SetName += Usrc_Item_InsidePageHandler1_SetName;
            usrc_Item_InsidePageHandler1.CreateControl += Usrc_Item_InsidePageHandler1_CreateControl;
            usrc_Item_InsidePageHandler1.FillControl += Usrc_Item_InsidePageHandler1_FillControl;
            usrc_Item_InsidePageHandler1.SelectControl += Usrc_Item_InsidePageHandler1_SelectControl;
            usrc_Item_InsidePageHandler1.Paint += Usrc_Item_InsidePageHandler1_SelectionChanged;
        }

        private void Usrc_Item_InsidePageHandler1_SelectionChanged(Control ctrl, object oData, int index)
        {
            if (SelectionChanged != null)
            {
                SelectionChanged(ctrl, oData, index);
            }
        }

        private void Usrc_Item_InsidePageHandler1_SelectControl(Control ctrl, object oData, int index, bool selected)
        {
            if (SelectControl != null)
            {
                SelectControl(ctrl, oData, index, selected);
            }
        }

  
        private void Usrc_Item_InsidePageHandler1_FillControl(Control ctrl, object oData)
        {
            if (FillControl != null)
            {
                FillControl(ctrl, oData);
            }
        }

        private void Usrc_Item_InsidePageHandler1_CreateControl(ref Control ctrl)
        {
            if (CreateControl != null)
            {
                CreateControl(ref ctrl);
            }
        }

        private bool Usrc_Item_InsidePageHandler1_SetName(object oData, ref string name)
        {
            if (SetName!=null)
            {
                return SetName(oData, ref name);
            }
            return false;
        }

        public void Init(DataTable dtItm)
        {
            this.usrc_Item_InsideGroup_Handler1.Init(dtItm);
        }

        private void usrc_Item_InsideGroup_Handler1_SizeChanged(int height)
        {
            int dheight = this.Height - height;
            usrc_Item_InsidePageHandler1.Height = dheight;
            this.usrc_Item_InsideGroup_Handler1.Top = dheight;
        }

        private bool LoadItems(string[] sgroup)
        {
            if (LoadItemsArray != null)
            {
                if (LoadItemsArray(sgroup, ref oItemsArray))
                {
                    this.usrc_Item_InsidePageHandler1.Init(oItemsArray);
                    this.usrc_Item_InsidePageHandler1.ShowPage(0);
                    return true;
                }
            }
            else if (LoadItemsList != null)
            {
                if (LoadItemsList(sgroup, ref oItemsList))
                {
                    this.usrc_Item_InsidePageHandler1.Init(oItemsList);
                    this.usrc_Item_InsidePageHandler1.ShowPage(0);
                    return true;

                }
            }
            return false;
        }

        private void usrc_Item_InsideGroup_Handler1_SelectionChanged(string[] sgroup)
        {
            if (LoadItems(sgroup))
            {
                return;
            }
            else
            {
                string s1_name = sgroup[0];
                string s2_name = sgroup[1];
                string s3_name = sgroup[2];
                string selection = "";
                if (s1_name != null)
                {
                    selection = "s1_name = '" + s1_name + "'";
                }
                else
                {
                    selection = "s1_name is null ";
                }

                if (s2_name != null)
                {
                    selection += "and s2_name = '" + s2_name + "'";
                }
                else
                {
                    selection += " and s2_name is null ";
                }

                if (s3_name != null)
                {
                    selection += "and s3_name = '" + s3_name + "'";
                }
                else
                {
                    selection += " and s3_name is null ";
                }


                drItems = usrc_Item_InsideGroup_Handler1.m_dt_Group.Select(selection);
                this.usrc_Item_InsidePageHandler1.Init(drItems);
                this.usrc_Item_InsidePageHandler1.ShowPage(0);
            }
        }

        private void usrc_Item_InsidePageHandler1_ControlClick(Control ctrl, object oData, int index, bool selected)
        {
            if (ControlClick!=null)
            {
                ControlClick(ctrl, oData, index, selected);
            }
        }
    }
}
