using LanguageControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Data;

namespace usrc_Item_InsidePageHandler
{
    public class SampleDB
    {
        public DataTable dtItm = null;
        public SampleDB_Price_ShopC_Item[] SampleDB_Price_ShopC_Item_List = null;
        public string col_ItemName = "ItemName";
        public string col_pg1 = "s1_name";
        public string col_pg2 = "s2_name";
        public string col_pg3 = "s3_name";



        private void SetCValues(ref string ShopC_Item_Abbreviation,
            ref string ShopC_Item_Name,
            ref int iItem1,
            ref int iItem2,
            int ig,
            string Abbreviation_sufix,
            string Name_sufix
            )
        {
            ShopC_Item_Abbreviation = SetCAbbreviation(ref iItem1, ig, Abbreviation_sufix);
            ShopC_Item_Name = SetCName(ref iItem2, ig, Name_sufix);
        }

        private void GetRandomTaxation(ref string taxation_Name_B, ref decimal taxation_Rate_B, DataTable dt_Taxation)
        {
            int imin = 0;
            int imax = dt_Taxation.Rows.Count - 1;
            int irand = Program.GetRandomNumber(imin, imax);
            taxation_Name_B = (string)dt_Taxation.Rows[irand]["Name"];
            taxation_Rate_B = (decimal)dt_Taxation.Rows[irand]["Rate"];
        }

        private decimal GetBRandomPrice(int Currency_DecimalPlaces)
        {
            return Program.GetRandomPrice(1.0M, 200.0M, Currency_DecimalPlaces);
        }

        private decimal GetCRandomPrice(int Currency_DecimalPlaces)
        {
            return Program.GetRandomPrice(10.0M, 400.0M, Currency_DecimalPlaces);
        }

        private string SetCAbbreviation(ref int iItem, int ig, string sufix)
        {
            iItem++;
            return "Itm " + iItem.ToString() + "    " + ig.ToString() + sufix;
        }

        private string SetCName(ref int iItem, int ig, string sufix)
        {
            iItem++;
            return "Item_" + iItem.ToString() + "    " + ig.ToString() + sufix;
        }

        public bool Write_ShopC_Items(Form_Items_Samples frm_Items_Samples)
        {
            int iItem1 = 0;
            int iItem2 = 0;
            int iNumberOfGroupsInLevel3 = frm_Items_Samples.iNumberOfGroupsInLevel3;
            int iNumberOfGroupsInLevel2 = frm_Items_Samples.iNumberOfGroupsInLevel2;
            int iNumberOfGroupsInLevel1 = frm_Items_Samples.iNumberOfGroupsInLevel1;
            int iNumberOfItemsPerGroup = frm_Items_Samples.iNumberOfItemsPerGroup;
            int iNumberOfAll = frm_Items_Samples.iNumberOffAll();

            SampleDB_Price_ShopC_Item_List = new SampleDB_Price_ShopC_Item[iNumberOfAll];
            int j = 0;
            string ShopC_Item_Abbreviation = null;
            string ShopC_Item_Name = null;
            string sl3 = null;
            string sl2 = null;
            string sl1 = null;
            int i1 = 0;
            int i2 = 0;
            int i3 = 0;
            int ig = 0;
            if (iNumberOfGroupsInLevel3 > 0)
            {
                for (i3 = 0; i3 < iNumberOfGroupsInLevel3; i3++)
                {
                    string sln3 = "L3g" + i3.ToString();
                    sl3 = "." + sln3;
                    for (i2 = 0; i2 < iNumberOfGroupsInLevel2; i2++)
                    {
                        string sln2 = sln3 + "L2g" + i2.ToString();
                        sl2 = "." + sln2;
                        for (i1 = 0; i1 < iNumberOfGroupsInLevel1; i1++)
                        {
                            string sln1 = sln3 + sln2 + "L1g" + i1.ToString();
                            sl1 = "." + sln1;
                            for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                            {
                                SetCValues(
                                        ref ShopC_Item_Abbreviation,
                                        ref ShopC_Item_Name,
                                        ref iItem1,
                                        ref iItem2,
                                            ig,
                                            sln1,
                                            sln1
                                            );

                                SampleDB_Price_ShopC_Item_List[j] = new SampleDB_Price_ShopC_Item(
                                                                ShopC_Item_Name,
                                                                sl1,
                                                                sl2,
                                                                sl3
                                                                );

                                j++;
                            }
                        }
                        for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                        {
                            SetCValues(ref ShopC_Item_Abbreviation,
                                        ref ShopC_Item_Name,
                                        ref iItem1,
                                        ref iItem2,
                                        ig,
                                        sln2,
                                        sln2
                                        );
                            SampleDB_Price_ShopC_Item_List[j] = new SampleDB_Price_ShopC_Item(
                                                            ShopC_Item_Name,
                                                            sl2,
                                                            sl3,
                                                            null
                                                            );
                            j++;
                        }

                    }
                    for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                    {
                        SetCValues(ref ShopC_Item_Abbreviation,
                                ref ShopC_Item_Name,
                                ref iItem1,
                                ref iItem2,
                                ig,
                                sln3,
                                sln3
                                );
                        SampleDB_Price_ShopC_Item_List[j] = new SampleDB_Price_ShopC_Item(ShopC_Item_Name,
                                                                                                    sl3,
                                                                                                    null,
                                                                                                    null
                                                                                                    ); j++;
                    }
                }
                for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                {
                    SetCValues(ref ShopC_Item_Abbreviation,
                                ref ShopC_Item_Name,
                                ref iItem1,
                                ref iItem2,
                                ig,
                                " noL1noL2noL3",
                                " noL1noL2noL3"
                                );
                    SampleDB_Price_ShopC_Item_List[j] = new SampleDB_Price_ShopC_Item(
                                                                                                ShopC_Item_Name,
                                                                                                null,
                                                                                                null,
                                                                                                null
                                                                                                ); j++;
                }
            }
            else if (iNumberOfGroupsInLevel2 > 0)
            {
                for (i2 = 0; i2 < iNumberOfGroupsInLevel2; i2++)
                {
                    sl2 = ".L2g" + i2.ToString();
                    for (i1 = 0; i1 < iNumberOfGroupsInLevel1; i1++)
                    {
                        sl1 = ".L1g" + i1.ToString();
                        for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                        {
                            SetCValues(ref ShopC_Item_Abbreviation,
                                ref ShopC_Item_Name,
                                ref iItem1,
                                ref iItem2,
                                ig,
                                sl2 + sl1,
                                sl2 + sl1
                                );
                            SampleDB_Price_ShopC_Item_List[j] = new SampleDB_Price_ShopC_Item(
                                                            ShopC_Item_Name,
                                                            sl1,
                                                            sl2,
                                                            null
                                                            );
                            j++;
                        }
                    }
                }
                for (i2 = 0; i2 < iNumberOfGroupsInLevel2; i2++)
                {
                    sl2 = ".L2g" + i2.ToString() + "(...)";
                    for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                    {
                        SetCValues(ref ShopC_Item_Abbreviation,
                            ref ShopC_Item_Name,
                            ref iItem1,
                            ref iItem2,
                            ig,
                            sl2,
                            sl2
                            );
                        SampleDB_Price_ShopC_Item_List[j] = new SampleDB_Price_ShopC_Item(
                                                        ShopC_Item_Name,
                                                        sl2,
                                                        null,
                                                        null
                                                        );
                        j++;
                    }
                }
                sl2 = "(...)";
                for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                {
                    SetCValues(ref ShopC_Item_Abbreviation,
                                ref ShopC_Item_Name,
                                ref iItem1,
                                ref iItem2,
                                ig,
                                sl2,
                                sl2
                                );

                    SampleDB_Price_ShopC_Item_List[j] = new SampleDB_Price_ShopC_Item(
                                                    ShopC_Item_Name,
                                                    null,
                                                    null,
                                                    null
                                                    );

                    j++;
                }
            }
            else if (iNumberOfGroupsInLevel1 > 0)
            {
                for (i1 = 0; i1 < iNumberOfGroupsInLevel1; i1++)
                {
                    sl1 = ".L1g" + i1.ToString();
                    for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                    {
                        SetCValues(ref ShopC_Item_Abbreviation,
                                ref ShopC_Item_Name,
                                ref iItem1,
                                ref iItem2,
                                ig,
                                sl1,
                                sl1
                                );
                        SampleDB_Price_ShopC_Item_List[j] = new SampleDB_Price_ShopC_Item(
                                                                                        ShopC_Item_Name,
                                                                                        sl1,
                                                                                        null,
                                                                                        null
                                                                                        );
                        j++;
                    }
                }
                sl1 = "(...)";
                for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                {
                    SetCValues(ref ShopC_Item_Abbreviation,
                                ref ShopC_Item_Name,
                                ref iItem1,
                                ref iItem2,
                                ig,
                                sl1,
                                sl1
                                );

                    SampleDB_Price_ShopC_Item_List[j] = new SampleDB_Price_ShopC_Item(
                                                                                    ShopC_Item_Name,
                                                                                    null,
                                                                                    null,
                                                                                    null
                                                                                    );
                    j++;
                }
            }
            else
            {
                sl1 = "(...)";
                for (ig = 0; ig < iNumberOfItemsPerGroup; ig++)
                {
                    SetCValues(ref ShopC_Item_Abbreviation,
                                ref ShopC_Item_Name,
                                ref iItem1,
                                ref iItem2,
                                ig,
                                sl1,
                                sl1
                                );
                    SampleDB_Price_ShopC_Item_List[j] = new SampleDB_Price_ShopC_Item(
                                                                                        ShopC_Item_Name,
                                                                                        null,
                                                                                        null,
                                                                                        null

                                                                                        ); j++;
                }
            }
            //{new 
            if (j != iNumberOfAll)
            {
                LogFile.Error.Show("ERROR:SampleDB:Write_ShopB_Items:Calculated number of items " + iNumberOfAll.ToString() + " is not equal to iterating number j in loop:" + j.ToString());
            }
            int k = 0;
            int SampleDB_Price_ShopC_Item_List_Count = SampleDB_Price_ShopC_Item_List.Count();
            if (dtItm!=null)
            {
                dtItm.Dispose();
                dtItm = null;
            }
            dtItm = new DataTable();
            DataColumn dcol_ItemName = new DataColumn(col_ItemName,typeof(string));
            DataColumn dcol_pg1 = new DataColumn(col_pg1, typeof(string));
            DataColumn dcol_pg2 = new DataColumn(col_pg2, typeof(string));
            DataColumn dcol_pg3 = new DataColumn(col_pg3, typeof(string));
            dtItm.Columns.Add(dcol_ItemName);
            dtItm.Columns.Add(dcol_pg1);
            dtItm.Columns.Add(dcol_pg2);
            dtItm.Columns.Add(dcol_pg3);

            for (k=0;k< SampleDB_Price_ShopC_Item_List_Count;k++)
            {
                SampleDB_Price_ShopC_Item spsci = SampleDB_Price_ShopC_Item_List[k];

                DataRow dr = dtItm.NewRow();
                dr[dcol_ItemName] = spsci.ShopC_Item_Name;
                dr[dcol_pg1] = spsci.ShopC_Item_ParentGroup1;
                dr[dcol_pg2] = spsci.ShopC_Item_ParentGroup2;
                dr[dcol_pg3] = spsci.ShopC_Item_ParentGroup3;
                dtItm.Rows.Add(dr);
            }
            return true;
        }

    }
}
