using CodeTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tangenta
{
    public static class ShopsUse
    {

        public static string ShopsInUse_Get(SettingsUserValues xSettingsUserValues)
        {
            if (xSettingsUserValues != null)
            {
                return xSettingsUserValues.eShopsInUse;
            }
            else
            {
                return Properties.Settings.Default.eShopsInUse;
            }
        }
        public static void ShopsInUse_Set(SettingsUserValues xSettingsUserValues, string shopsinuse)
        { 
            if (xSettingsUserValues != null)
            {
                xSettingsUserValues.eShopsInUse = shopsinuse;
            }
            else
            {
                Properties.Settings.Default.eShopsInUse = shopsinuse;
                Properties.Settings.Default.Save();
            }
        }

        public static string ShowShops_Get(SettingsUserValues xSettingsUserValues)
        {
            if (xSettingsUserValues != null)
            {
                return xSettingsUserValues.eShowShops;
            }
            else
            {
                return Properties.Settings.Default.eShowShops;
            }
        }
        public static void ShowShops_Set(SettingsUserValues xSettingsUserValues, string showshops)
        {
            if (xSettingsUserValues != null)
            {
            xSettingsUserValues.eShowShops = showshops;
            }
            else
            {
                Properties.Settings.Default.eShowShops = showshops;
            }
        }

      

        public static bool isCompatibleWithShopsInUse(SettingsUserValues xSettingsUserValues,string eShowShops)
        {
            foreach (char ch in eShowShops)
            {
                if (xSettingsUserValues.eShopsInUse.Contains(ch))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public static string setCompatibleWithShopsInUse(SettingsUserValues xSettingsUserValues, string eShowShops)
        {
            if (isCompatibleWithShopsInUse(xSettingsUserValues,eShowShops))
            {
                return eShowShops;
            }
            else
            {
                return xSettingsUserValues.eShopsInUse;
            }
        }

        public static void SetRadioButtons(
            int topm,
            int ydist,
            int bdist,
            Form frm,
            Button btn_Cancel,
            SettingsUserValues xSettingsUserValues,
            RadioButton rdb_A,
            RadioButton rdb_B,
            RadioButton rdb_C,
            RadioButton rdb_AB,
            RadioButton rdb_BC,
            RadioButton rdb_AC,
            RadioButton rdb_ABC
            )
        {
            bool bDoAgain = false;

Goto_SetChecksAgain:
            string shinuse = ShopsUse.ShopsInUse_Get(xSettingsUserValues);

            if (shinuse.Equals("A"))
            {
                rdb_A.Checked = true;
                rdb_A.Enabled = false;
                rdb_A.Visible = true;
                rdb_B.Visible = false;
                rdb_C.Visible = false;
                rdb_AB.Visible = false;
                rdb_AC.Visible = false;
                rdb_ABC.Visible = false;
                rdb_A.Top = topm;
                btn_Cancel.Top = rdb_A.Bottom + ydist;
                frm.Height = btn_Cancel.Bottom + bdist;
            }

            if (shinuse.Equals("B"))
            {
                rdb_B.Checked = true;
                rdb_B.Enabled = false;
                rdb_B.Visible = true;
                rdb_A.Visible = false;
                rdb_C.Visible = false;
                rdb_AB.Visible = false;
                rdb_AC.Visible = false;
                rdb_ABC.Visible = false;
                rdb_B.Top = topm;
                btn_Cancel.Top = rdb_B.Bottom + ydist;
                frm.Height = btn_Cancel.Bottom + bdist;
            }

            if (shinuse.Equals("C"))
            {
                rdb_A.Visible = false;
                rdb_C.Checked = true;
                rdb_C.Enabled = false;
                rdb_C.Visible = true;
                rdb_B.Visible = false;
                rdb_AB.Visible = false;
                rdb_AC.Visible = false;
                rdb_ABC.Visible = false;
                rdb_C.Top = topm;
                btn_Cancel.Top = rdb_C.Bottom + ydist;
                frm.Height = btn_Cancel.Bottom + bdist;
            }

            if (shinuse.Equals("AB"))
            {
                rdb_A.Enabled = true;
                rdb_A.Visible = true;
                rdb_B.Visible = true;
                rdb_B.Enabled = true;
                rdb_AB.Visible = true;
                rdb_AB.Enabled = true;

                rdb_C.Visible = false;
                rdb_AC.Visible = false;
                rdb_ABC.Visible = false;

                rdb_A.Top = topm;
                rdb_B.Top = rdb_A.Bottom + ydist;
                rdb_AB.Top = rdb_B.Bottom + ydist;
                btn_Cancel.Top = rdb_AB.Bottom + ydist;
                frm.Height = btn_Cancel.Bottom + bdist;
            }

            if (shinuse.Equals("AC"))
            {
                rdb_A.Enabled = true;
                rdb_A.Visible = true;
                rdb_C.Visible = true;
                rdb_C.Enabled = true;
                rdb_AC.Visible = true;
                rdb_AC.Enabled = true;

                rdb_B.Visible = false;
                rdb_AB.Visible = false;
                rdb_ABC.Visible = false;

                rdb_A.Top = topm;
                rdb_C.Top = rdb_A.Bottom + ydist;
                rdb_AC.Top = rdb_C.Bottom + ydist;
                btn_Cancel.Top = rdb_AC.Bottom + ydist;
                frm.Height = btn_Cancel.Bottom + bdist;
            }

            if (shinuse.Equals("BC"))
            {
                rdb_B.Enabled = true;
                rdb_B.Visible = true;
                rdb_C.Visible = true;
                rdb_C.Enabled = true;
                rdb_BC.Visible = true;
                rdb_BC.Enabled = true;

                rdb_A.Visible = false;
                rdb_AB.Visible = false;
                rdb_AC.Visible = false;
                rdb_ABC.Visible = false;

                rdb_B.Top = topm;
                rdb_C.Top = rdb_B.Bottom + ydist;
                rdb_BC.Top = rdb_C.Bottom + ydist;
                btn_Cancel.Top = rdb_BC.Bottom + ydist;
                frm.Height = btn_Cancel.Bottom + bdist;
            }

            if (shinuse.Equals("ABC"))
            {
                rdb_A.Visible = true;
                rdb_A.Enabled = true;
                rdb_B.Enabled = true;
                rdb_B.Visible = true;
                rdb_C.Visible = true;
                rdb_C.Enabled = true;
                rdb_AB.Visible = true;
                rdb_AB.Enabled = true;
                rdb_AC.Visible = true;
                rdb_AC.Enabled = true;
                rdb_BC.Visible = true;
                rdb_BC.Enabled = true;
                rdb_ABC.Visible = true;
                rdb_ABC.Enabled = true;

                rdb_A.Top = topm;
                rdb_B.Top = rdb_A.Bottom + ydist;
                rdb_C.Top = rdb_B.Bottom + ydist;
                rdb_AB.Top = rdb_C.Bottom + ydist;
                rdb_AC.Top = rdb_AB.Bottom + ydist;
                rdb_BC.Top = rdb_AC.Bottom + ydist;
                rdb_ABC.Top = rdb_BC.Bottom + ydist;
                btn_Cancel.Top = rdb_ABC.Bottom + ydist;
                frm.Height = btn_Cancel.Bottom + bdist;
            }

            string showshops = ShopsUse.ShowShops_Get(xSettingsUserValues);
            if (showshops.Equals("A"))
            {
                rdb_A.Checked = true;
            }
            else if (showshops.Equals("B"))
            {
                rdb_B.Checked = true;
            }
            else if (showshops.Equals("C"))
            {
                rdb_C.Checked = true;
            }
            else if (showshops.Equals("AB"))
            {
                rdb_AB.Checked = true;
            }
            else if (showshops.Equals("BC"))
            {
                rdb_BC.Checked = true;
            }
            else if (showshops.Equals("AC"))
            {
                rdb_AC.Checked = true;
            }
            else if (showshops.Equals("ABC"))
            {
                rdb_ABC.Checked = true;
            }
            else
            {
                string shops_in_use = ShopsUse.ShopsInUse_Get(xSettingsUserValues);
                if ((shops_in_use.Length > 0) && (!bDoAgain))
                {
                    ShopsUse.ShowShops_Set(xSettingsUserValues, shops_in_use);
                    bDoAgain = true;
                    goto Goto_SetChecksAgain;
                }
                else
                {
                    LogFile.Error.Show("ERROR:Tangenta:ShopsUse: shops_in_use is not valid shops_in_use = " + shops_in_use);
                }

            }

        }
    }
}
