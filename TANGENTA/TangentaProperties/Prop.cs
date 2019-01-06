using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaProperties
{
    public static class Prop
    {
       public static int LanguageID
        {
            get
            {
                return Properties.Settings.Default.LanguageID;
            }
        }

        
    }
}
