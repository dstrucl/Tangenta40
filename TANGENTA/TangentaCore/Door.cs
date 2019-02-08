﻿using LoginControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangentaDB;
using TangentaProperties;

namespace TangentaCore
{
    public class Door
    {
        LMOUser m_LMOUser = null;

        public Door(LMOUser xLMOUser)
        {
            m_LMOUser = xLMOUser;
        }
        public bool DoLoginAsAdministrator(Form frm)
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

        public bool OpenIfUserIsAdministrator(Form parent_form)
        {
            if (OperationMode.MultiUser)
            {
                if (m_LMOUser.IsAdministrator)
                {
                    return true;
                }
                else
                {
                    XMessage.Box.Show(parent_form, false, lng.s_YouMustHaveAdministratorRightsToEditSettings,MessageBoxIcon.Hand);
                    return false;
                }
            }
            else
            {
                return DoLoginAsAdministrator(parent_form);
            }
        }

        public bool OpenPriceList(Form parent_form)
        {
            if (OperationMode.MultiUser)
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


        public  bool OpenStockEdit(Form parent_form)
        {
            if (OperationMode.MultiUser)
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

        private bool HasLoginControlRole(string[] Roles)
        {
           return m_LMOUser.HasLoginControlRole(Roles);
        }
    }
}