using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;
using ECB_ExchangeRates;

namespace ECB_ExchangeRates_TEST
{
    /// <summary>
    /// Summary description for ExRate.
    /// </summary>
    /// 
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            LanguageControl.DynSettings.LanguageID = 1;
            Application.Run(new Form_Test());
        }
    }
}
