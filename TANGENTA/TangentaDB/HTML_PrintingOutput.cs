using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheArtOfDev.HtmlRenderer.Core;

namespace TangentaDB
{

    public class HTML_PrintingOutput
    {
        public HTML_PrintingElement style = null;
        public HTML_PrintingElement pagenumber = null;
        public HTML_PrintingElement doctop = null;
        public HTML_PrintingElement tableitems = null;
        public List<HTML_PrintingElement> items = null;
        public HTML_PrintingElement totalneto = null;
        public List<HTML_PrintingElement> taxsum = null;
        public HTML_PrintingElement grandtotal = null;
        public HTML_PrintingElement docbottom = null;

        public List<HTML_PrintingElement> elements = new List<HTML_PrintingElement>();

        public int iItemsCount = 0;
        public int taxsum_count = 0;
        public int rows_count = 0;
        public int NumberOfPages = 1;

        public bool SetLayout(PageLayout pglayout)
        {
            elements.Clear();
            iItemsCount = 0;
            rows_count = 0;
            if (pagenumber != null)
            {
                if (!pglayout.SetElementLayout("div", "pagenumbers",ref pagenumber.TagName,ref pagenumber.ClassName, ref pagenumber.Ypos, ref pagenumber.Height))
                {
                    return false;
                }
                elements.Add(pagenumber);
            }
            if (doctop != null)
            {
                if (pglayout.SetElementLayout("div", "invoicetop", ref doctop.TagName, ref doctop.ClassName, ref doctop.Ypos, ref doctop.Height))
                {
                    elements.Add(doctop);
                }
                else
                {
                    return false;
                }
            }
            if (tableitems != null)
            {
                if (pglayout.SetElementLayout("table", "tableitems", ref tableitems.TagName, ref tableitems.ClassName, ref tableitems.Ypos, ref tableitems.Height))
                {
                    elements.Add(tableitems);
                }
                else
                {
                    return false;
                }
            }
            int iItem = 0;
            if (items!=null)
            {
                iItemsCount = items.Count;
                List<PageLayout> ItemsPageLayout_list = null;
                pglayout.GetPageLayout("tr", "item", ref ItemsPageLayout_list);
                iItemsCount = ItemsPageLayout_list.Count;
                if (iItemsCount == items.Count)
                {
                    for (iItem = 0; iItem < iItemsCount; iItem++)
                    {
                        items[iItem].index = iItem;
                        items[iItem].TagName = ItemsPageLayout_list[iItem].html_tag_name;
                        items[iItem].ClassName = ItemsPageLayout_list[iItem].ClassName;
                        items[iItem].Ypos = ItemsPageLayout_list[iItem].HtmlTagRect.Y;
                        items[iItem].Height = ItemsPageLayout_list[iItem].HtmlTagRect.Height;
                        elements.Add(items[iItem]);
                        items[iItem].row_index = rows_count;
                        rows_count++;

                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:HTML_PrintingOutput:SetLayout:ItemsPageLayout_list.Count != items.Count");
                    return false;
                }
            }

            if (totalneto!=null)
            {
                if (pglayout.SetElementLayout("tr", "totalneto", ref totalneto.TagName, ref totalneto.ClassName, ref totalneto.Ypos, ref totalneto.Height))
                {
                    totalneto.row_index = rows_count;
                    rows_count++;
                    elements.Add(totalneto);
                }
                else
                {
                    return false;
                }
            }

            int jTaxsumCount = 0;
            int jTaxSum = 0;

            if (taxsum != null)
            {
                List<PageLayout> TaxSumPageLayout_list = null;
                pglayout.GetPageLayout("tr", "taxsum",  ref TaxSumPageLayout_list);
                jTaxsumCount = TaxSumPageLayout_list.Count;
                if (jTaxsumCount == taxsum.Count)
                {
                    for (jTaxSum = 0; jTaxSum < jTaxsumCount; jTaxSum++)
                    {
                        taxsum[jTaxSum].TagName = TaxSumPageLayout_list[jTaxSum].html_tag_name;
                        taxsum[jTaxSum].ClassName = TaxSumPageLayout_list[jTaxSum].ClassName;
                        taxsum[jTaxSum].Ypos = TaxSumPageLayout_list[jTaxSum].HtmlTagRect.Y;
                        taxsum[jTaxSum].Height = TaxSumPageLayout_list[jTaxSum].HtmlTagRect.Height;
                        elements.Add(taxsum[jTaxSum]);
                        taxsum[jTaxSum].index = jTaxSum;
                        taxsum[jTaxSum].row_index = rows_count;
                        rows_count++;

                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:HTML_PrintingOutput:SetLayout:TaxSumPageLayout_list.Count != taxsum.Count");
                    return false;
                }
            }

            if (grandtotal != null)
            {
                if (pglayout.SetElementLayout("tr", "grandtotal", ref grandtotal.TagName, ref grandtotal.ClassName, ref grandtotal.Ypos, ref grandtotal.Height))
                {
                    grandtotal.row_index = rows_count;
                    rows_count++;
                    elements.Add(grandtotal);
                }
                else
                {
                    return false;
                }
            }

            if (docbottom != null)
            {
                if (pglayout.SetElementLayout("div", "invoicebottom", ref docbottom.TagName, ref docbottom.ClassName, ref docbottom.Ypos, ref docbottom.Height))
                {
                    elements.Add(docbottom);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public double GetScreenPageHeight(PageLayout pglayout)
        {
            if (pglayout.html_tag_name != null)
            {
                if (pglayout.html_tag_name.Equals("page"))
                {
                    return pglayout.HtmlTagRect.Height;
                }
                else if (pglayout.html_tag_name.Equals("style"))
                {
                    return -1;
                }
            }
            foreach (PageLayout pgl in pglayout.Child_HtmlTag_PageLayout)
            {
                double page_height = GetScreenPageHeight(pgl);
                if (page_height > 0)
                {
                    return page_height;
                }
            }
            return -1;
        }
    }
}
