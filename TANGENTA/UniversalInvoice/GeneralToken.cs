using LanguageControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniversalInvoice
{
    public class GeneralToken
    {

        public TemplateToken tPageNumber;
        public TemplateToken tNumberOfPages;
        public TemplateToken tNotice = null;
        public TemplateToken tFooter = null;

        public List<TemplateToken> list = null;

        public GeneralToken()
        {
            tPageNumber = new TemplateToken(null,lng.st_PageNumber, null, null);
            tNumberOfPages = new TemplateToken(null, lng.st_NumberOfPages, null, null);
            tNotice = new TemplateToken(null, lng.st_Notice, null, null);
            tFooter = new TemplateToken(null, lng.st_Footer, null, null);
            list = new List<TemplateToken>();
            list.Add(tPageNumber);
            list.Add(tNumberOfPages);
            list.Add(tNotice);
            list.Add(tFooter);
        }
    }
}
