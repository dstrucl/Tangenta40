using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangentaDB;

namespace Tangenta
{
    public static class Door
    {
        internal static bool DoLoginAsAdministrator(Form frm)
        {
            string AdministratorLockedPassword = null;
            if (fs.GetAdministratorPassword(ref AdministratorLockedPassword))
            {
                if (Password.Password.Check(frm, null, AdministratorLockedPassword))
                {
                    return true;
                }
            }
            return false;
        }

        internal static bool Open(Form parent_form, Type form_Type)
        {
            if (form_Type.Equals(typeof(Form_ProgramSettings)))
            {
                if (Program.OperationMode.MultiUser)
                {
                    if (Program.IsAdministratorUser)
                    {
                        return true;
                    }
                    else
                    {
                        XMessage.Box.Show(parent_form, false, lng.s_YouMustHaveAdministratorRightsToEditSettings);
                        return false;
                    }
                }
                else
                {
                    return DoLoginAsAdministrator(parent_form);
                }
            }
            else
            {
                return false;
            }
        }

        internal static bool OpenPriceList(Form parent_form)
        {
            if (Program.OperationMode.MultiUser)
            {
                string[] possiblerole =new string[]{LoginControl.AWP.ROLE_Administrator,
                                                     LoginControl.AWP.ROLE_PriceListManagement };
                                                    
                if (HasLoginControlRole(possiblerole))
                {
                    return true;
                }
                else
                {
                    XMessage.Box.Show(parent_form,  lng.s_YouMustHaveOneOfThePossibleAccessRightsToEditPriceList,
                                      LoginControl.AWPRole.RolesInLanguages(possiblerole), 
                                      lng.s_Warning.s,
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Exclamation,
                                      MessageBoxDefaultButton.Button1
                                      );

                    return false;
                }
            }
            return true;
        }


        internal static bool OpenStockEdit(Form parent_form)
        {
            if (Program.OperationMode.MultiUser)
            {
                string[] possiblerole = new string[]{LoginControl.AWP.ROLE_Administrator,
                                                     LoginControl.AWP.ROLE_StockTakeManagement };

                if (HasLoginControlRole(possiblerole))
                {
                    return true;
                }
                else
                {
                    XMessage.Box.Show(parent_form, lng.s_YouMustHaveOneOfThePossibleAccessRightsToEditStock,
                                      LoginControl.AWPRole.RolesInLanguages(possiblerole),
                                      lng.s_Warning.s,
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Exclamation,
                                      MessageBoxDefaultButton.Button1
                                      );

                    return false;
                }
            }
            return true;
        }

        private static bool HasLoginControlRole(string[] Roles)
        {
            if (Program.MainForm!=null)
            {
                if (Program.MainForm.m_usrc_Main != null)
                {
                    if (Program.MainForm.m_usrc_Main.loginControl1 != null)
                    {
                        return Program.MainForm.m_usrc_Main.loginControl1.HasLoginControlRole(Roles);
                    }
                }
            }
            return true;
        }

    }
}
