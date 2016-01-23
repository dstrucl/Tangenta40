using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace InvoiceDB
{
    public class xUnitList
    {
        public List<xUnit> m_UnitList = new List<xUnit>();
        public xUnitList()
        {
            m_UnitList.Add(new xUnit("komad", "kom.", 0,true, "Artikli kot komadi."));
            m_UnitList.Add(new xUnit("ura", "h", 2,false, "Za vse, kar se meri v urah"));
            m_UnitList.Add(new xUnit("dan", "dan", 2, false, "Za vse, kar se meri v dnevih"));
            m_UnitList.Add(new xUnit("mesec", "mes", 2, false, "Za vse, kar se meri v mesecih"));
            m_UnitList.Add(new xUnit("leto", "mes", 2,false, "Za vse, kar se meri v mesecih"));
            m_UnitList.Add(new xUnit("meter", "m", 2, true, "Za kar se, prodaja na dolžinsko enoto"));
            m_UnitList.Add(new xUnit("kvadratni meter", "m2", 2, true, "Za vse kar se prodaja glede na površino"));
            m_UnitList.Add(new xUnit("kubični meter", "m3", 2, true, "Za vse kar se prodaja glede na prostornino"));
            m_UnitList.Add(new xUnit("kilowatna ura", "kWh", 2, false, "Prodaja energije"));
            m_UnitList.Add(new xUnit("kilometrina", "km", 0, false, "Obračun kilometrine"));
            m_UnitList.Add(new xUnit("kilogram", "kg", 2, true, "Masa artikla"));
            m_UnitList.Add(new xUnit("liter", "l", 2, true, "Za snovi, ki se prodajajo glede na prostornino"));
        }
    }

    public class xUnit
    {
        public long ID = -1;
        public string Name = null;
        public string Symbol = null;
        public int DecimalPlaces = -1;
        public bool StorageOption = false;
        public string Description = null;

        public xUnit()
        {
        }

        public xUnit(string xName, string xSymbol, short xDecimalPlaces,bool xStorageOption, string xDescription)
        {
            Name = xName;
            Symbol = xSymbol;
            DecimalPlaces = xDecimalPlaces;
            StorageOption = xStorageOption;
            Description = xDescription;
        }

        internal bool SetUnit(long unit_id, ref string Err)
        {
            string sql_BaseUnit = "select Name,Symbol,DecimalPlaces,StorageOption,Description from Unit where ID = " + unit_id.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_BaseUnit, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    ID = unit_id;
                    Name = (string)dt.Rows[0]["Name"];
                    Symbol = (string)dt.Rows[0]["Symbol"];
                    DecimalPlaces = (int)dt.Rows[0]["DecimalPlaces"];
                    StorageOption = (bool)dt.Rows[0]["StorageOption"];
                    object oDescription = dt.Rows[0]["Description"];
                    if (oDescription.GetType() == typeof(string))
                    {
                        Description = (string)oDescription;
                    }
                    else
                    {
                        Description = null;
                    }

                    return true;
                }
                else
                {
                    Err = "ERROR:Unit id = " + unit_id.ToString() + " not found in table Unit";
                    return false;
                }
            }
            else
            {
                Err = "ERROR:xUnit:SetUnit:Err=" + Err;
                return false;
            }
        }
    }
}
