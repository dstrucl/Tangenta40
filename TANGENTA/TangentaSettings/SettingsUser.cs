using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangentaDB;
using DBConnectionControl40;
using DBTypes;
using System.Reflection;

namespace TangentaSettings
{
    public class SettingsUser
    {
        public SettingsUserValues mSettingsUserValues = null;

        private Setting[] item = null;
        private int icount = 0;

        public SettingsUser()
        {
            mSettingsUserValues = new SettingsUserValues();

            if (!Compatiple(Properties.Settings.Default.eShopsInUse, Properties.Settings.Default.eShowShops))
            {
                Properties.Settings.Default.eShowShops = Properties.Settings.Default.eShopsInUse;
                Properties.Settings.Default.Save();
            }

            mSettingsUserValues.eShopsInUse = Properties.Settings.Default.eShopsInUse;
            mSettingsUserValues.eShowShops = Properties.Settings.Default.eShowShops;
        }

        private bool Compatiple(string xeShopsInUse, string xeShowShops)
        {
            if (xeShowShops.Length > 0)
            {
                if (xeShowShops.Length <= xeShopsInUse.Length)
                {
                    foreach (char ch in xeShowShops)
                    {
                        if (xeShopsInUse.Contains(ch))
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
            }
            return false;
        }

        public bool Load(LoginControl.LMOUser luser, Transaction transaction)
        {
            DataTable dt = null;

            if (!ID.Validate(ProgramModuleData.ProgramModule_ID))
            {
                f_ProgramModule.Get(ProgramModuleData.AssemblyName, ref ProgramModuleData.ProgramModule_ID, transaction);
            }

            if (f_PropertiesSettings.GetTable(myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice.ID, ProgramModuleData.ProgramModule_ID, luser.myOrganisation_Person_ID, ref dt))
            {

                Type type = mSettingsUserValues.GetType();
                PropertyInfo[] properties = type.GetProperties();
                icount = properties.Length;
                item = new Setting[icount];
                int i = 0;


                foreach (PropertyInfo property in properties)
                {
                    item[i] = new Setting(property.Name);
                    i++;
                }


                foreach (PropertyInfo currentProperty in properties)
                {
                    string name = null;
                    string xtype = null;
                    string sval = null;
                    Setting xitem = finditem(currentProperty.Name);
                    ID propset_ID = null;
                    if (findintable(dt, currentProperty.Name,ref propset_ID, ref name, ref xtype, ref sval))
                    {
                        xitem.Set(currentProperty.Name, xtype, sval);
                        xitem.PropertiesSettings_ID = propset_ID;
                        currentProperty.SetValue(mSettingsUserValues, xitem.get_object());
                    }
                    else
                    {
                        //Settings is not in table so it means it was not stored
                        //Store its default value
                        ID SettingsType_ID = null;
                        string sSettingsValue = set_string_value(currentProperty.GetValue(mSettingsUserValues));
                        if (f_SattingsType.Get(currentProperty.PropertyType.ToString(), ref SettingsType_ID, transaction))
                        {
                            ID xPropertiesSettings_ID = null;
                            if (f_PropertiesSettings.Save(
                                                myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice.ID,
                                                ProgramModuleData.ProgramModule_ID,
                                                luser.myOrganisation_Person_ID,
                                                currentProperty.Name,
                                                SettingsType_ID,
                                                sSettingsValue,
                                                ref xPropertiesSettings_ID,
                                                transaction
                                                ))
                            {
                                xitem.Set(currentProperty.Name, currentProperty.PropertyType.ToString(), sSettingsValue);
                                xitem.PropertiesSettings_ID = xPropertiesSettings_ID;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }



        public bool Save(Transaction transaction)
        {
            Type type = mSettingsUserValues.GetType();
            PropertyInfo[] properties = type.GetProperties();
            icount = properties.Length;

            foreach (PropertyInfo currentProperty in properties)
            {
                Setting xitem = finditem(currentProperty.Name);
                if (xitem != null)
                {
                    string sval = set_string_value(currentProperty.GetValue(mSettingsUserValues));
                    if (xitem.Value.Equals(sval))
                    {
                        continue;
                    }
                    else
                    {
                        // property changed to loaded value
                        // so save this single property
                        if (f_PropertiesSettings.Update(xitem.PropertiesSettings_ID, sval, transaction))
                        {
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:Tangenta:SettingsUser:Save: ite, for properrty name = " + currentProperty.Name + " not found");
                    return false;
                }
            }
            return true;
        }

        private string set_string_value(object defaultValue)
        {
            try
            {
                if (defaultValue is int)
                {
                    return Convert.ToString(defaultValue);
                }
                else if (defaultValue is bool)
                {
                    return Convert.ToString(defaultValue);
                }
                else if (defaultValue is string)
                {
                    return (string)defaultValue;
                }
                else if (defaultValue is System.Drawing.Color)
                {
                    string sR = Convert.ToString(((System.Drawing.Color)defaultValue).R);
                    string sG = Convert.ToString(((System.Drawing.Color)defaultValue).G);
                    string sB = Convert.ToString(((System.Drawing.Color)defaultValue).G);
                    return sR + ";" + sG + ";" + sB;
                }
                else
                {
                    if (defaultValue == null)
                    {
                        LogFile.Error.Show("ERROR:Tangenta:SettingsUser:set_string_value: defaultValue == null ");
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:Tangenta:SettingsUser:set_string_value: Type is not implemented : " + defaultValue.GetType().ToString());
                    }
                    return null;

                }
            }
            catch (Exception ex)
            {
                LogFile.Error.Show("ERROR:Tangenta:SettingsUser:set_string_value: Conversion Error Exception =" + ex.Message + "\r\n for default type : " + defaultValue.GetType().ToString());
                return null;
            }
        }


        private Setting finditem(string name)
        {
            foreach (Setting itm in item)
            {
                if (itm.Name.Equals(name))
                {
                    return itm;
                }
            }
            return null;
        }

        private bool findintable(DataTable dt, string propname, ref ID propset_ID, ref string name, ref string xtype, ref string sval)
        {
            foreach (DataRow dr in dt.Rows)
            {
                string s = tf._set_string(dr["Name"]);
                if (propname.Equals(s))
                {
                    name = s;
                    propset_ID = tf.set_ID(dr["ID"]);
                    xtype = tf._set_string(dr["Typ"]);
                    sval = set_string_value(dr["SValue"]);
                    return true;
                }
            }
            return false;
        }
    }
}

