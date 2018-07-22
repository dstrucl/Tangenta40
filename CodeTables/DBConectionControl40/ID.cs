using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectionControl40
{

    public class ID
    {
        public static ID Invalid = new ID(null);

        public enum IDType { INT32, INT64, GUID };

        private IDType m_Type = IDType.INT64;


        public string cond = null;

        public string value = null;

        public IDType IDtype
        {
            get
            {
                return m_Type;
            }
            set
            {
                m_Type = value;
            }
        }

        private object m_V = null;

        public ID()
        {
            m_Type = IDType.INT64;
        }

        public ID(object xv)
        {
            m_Type = IDType.INT64;
            if (xv is null)
            {
                MakeInvalid();
                return;
            }
            switch (IDtype)
            {
                case IDType.INT64:
                    {
                        if (xv is long)
                        {
                            m_V = (long)xv;
                        }
                        else if (xv is string)
                        {
                            try
                            {
                                m_V = Convert.ToInt64(xv);
                            }
                            catch
                            {
                                LogFile.Error.Show("ERROR:DBTypes:ID:Constructor ID(object xv):m_Type is INT64, assigned object value is string " + (xv.GetType().ToString()));
                            }
                        }
                        else if (xv is ID)
                        {
                            if (((ID)xv).IDtype == m_Type)
                            {
                                m_V = ((ID)xv).V;
                                return;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:DBTypes:ID:constructor ID(object xv):ID Types are not matching, xv.IDtype is of type " + ((ID)xv).IDtype.ToString() + " this type is " + this.IDtype.ToString());
                                return;
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:DBTypes:ID:Property object V:ID Type is INT64, assigned object value is type of " + xv.GetType().ToString());
                        }
                    }
                    break;

                case IDType.INT32:
                    {
                        if (xv is int)
                        {
                            m_V = (int)xv;
                        }
                        else if (xv is string)
                        {
                            try
                            {
                                m_V = Convert.ToInt32(xv);
                            }
                            catch
                            {
                                LogFile.Error.Show("ERROR:DBTypes:ID:Constructor ID(object xv):m_Type is INT32, assigned object value is string " + (xv.GetType().ToString()));
                            }
                        }
                        else if (xv is ID)
                        {
                            if (((ID)xv).IDtype == m_Type)
                            {
                                m_V = ((ID)xv).V;
                                return;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:DBTypes:ID:constructor ID(object xv):ID Types are not matching, xv.IDtype is of type " + ((ID)xv).IDtype.ToString() + " this type is " + this.IDtype.ToString());
                                return;
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:DBTypes:ID:Property object V:ID Type is INT32, assigned object value is type of " + xv.GetType().ToString());
                        }
                    }
                    break;

                case IDType.GUID:
                    {
                        if (xv is Guid)
                        {
                            m_V = (Guid)xv;
                        }
                        else if (xv is string)
                        {
                            try
                            {
                                m_V = new Guid((string)xv);
                            }
                            catch
                            {
                                LogFile.Error.Show("ERROR:DBTypes:ID:Constructor ID(object xv):m_Type is GUID, assigned object value is string " + (xv.GetType().ToString()));
                            }
                        }
                        else if (xv is ID)
                        {
                            if (((ID)xv).IDtype == m_Type)
                            {
                                m_V = ((ID)xv).V;
                                return;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:DBTypes:ID:constructor ID(object xv):ID Types are not matching, xv.IDtype is of type " + ((ID)xv).IDtype.ToString() + " this type is " + this.IDtype.ToString());
                                return;
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:DBTypes:ID:Property object V:ID Type is Guid, assigned object value is type of " + xv.GetType().ToString());
                        }
                    }
                    break;
            }
        }

        public object V
        {
            get
            {
                return m_V;
            }
            set
            {
                object ov = value;
                switch (IDtype)
                {
                    case IDType.INT64:
                        {
                            if (ov is long)
                            {
                                m_V = (long)ov;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:DBTypes:ID:Property object V:ID Type is INT64, assigned object value is type of " + ov.GetType().ToString());
                            }
                        }
                        break;

                    case IDType.INT32:
                        {
                            if (ov is int)
                            {
                                m_V = (int)ov;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:DBTypes:ID:Property object V:ID Type is INT32, assigned object value is type of " + ov.GetType().ToString());
                            }
                        }
                        break;

                    case IDType.GUID:
                        {
                            if (ov is Guid)
                            {
                                m_V = (Guid)ov;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:DBTypes:ID:Property object V:ID Type is Guid, assigned object value is type of " + ov.GetType().ToString());
                            }
                        }
                        break;
                }
                m_V = value;
            }
        }

        public override string  ToString()
        {
            try
            {
                return V.ToString();
            }
            catch (Exception ex)
            {
                LogFile.Error.Show("ERROR:DBTypes:ID:ToString(): conversion failed Exception=" + ex.Message);
                return null;
            }
        }

        public bool Equals(ID id)
        {
            try
            {
                if (this.m_Type == id.IDtype)
                {
                    switch(this.m_Type)
                    {
                        case IDType.INT64:
                            if (((long)this.m_V)==((long)id.V))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        case IDType.INT32:
                            if (((int)this.m_V) == ((int)id.V))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        case IDType.GUID:
                            if (((Guid)this.m_V).CompareTo((Guid)id.V)==0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        default:
                            LogFile.Error.Show("ERROR:DBTypes:ID:Equals(): unsuported IDType :" + this.m_Type.ToString());
                            return false;

                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:DBTypes:ID:Equals(): IDType not equal this.m_Type = " + this.m_Type.ToString()+" id.IDtype="+id.IDtype.ToString());
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogFile.Error.Show("ERROR:DBTypes:ID:ToString(): conversion failed Exception=" + ex.Message);
                return false;
            }
        }

        public void MakeInvalid()
        {
            switch (IDtype)
            {
                case IDType.INT64:
                    m_V = (long)-1;
                    break;

                case IDType.INT32:
                    m_V = (int)-1;
                    break;

                case IDType.GUID:
                    m_V = Guid.Empty;
                    break;
            }
        }

        public object InvalidID
        {
            get
            {
                switch (IDtype)
                {
                    case IDType.INT64:
                        return (long)-1;

                    case IDType.INT32:
                        return (int)-1;

                    case IDType.GUID:
                        return Guid.Empty;

                    default:
                        LogFile.Error.Show("ERROR:DBTypes:ID:Property object V:ID Type is INT32, assigned object value is type of " + IDtype.ToString());
                        return null;

                }
            }
        }

        private bool IsValid
        {
            get
            {
                switch (IDtype)
                {
                    case IDType.INT64:
                        return (((long)m_V) >= 0);
                    case IDType.INT32:
                        return (((int)m_V) >= 0);
                    case IDType.GUID:
                        return (((Guid)m_V).CompareTo(Guid.Empty) != 0);
                    default:
                        return false;
                }
            }
        }

        public static bool Validate(ID oID)
        {
            if (oID!=null)
            {
                return oID.IsValid;
            }
            else
            {
                return false;
            }
        }

        private bool defined = false;
        public bool Defined
        {
            get
            {
                return defined;
            }
            set
            {
                defined = value;
            }
        }

        public static void SetInvalid(ref ID x_ID)
        {
            if (x_ID != null)
            {
                x_ID.MakeInvalid();
            }
            else
            {
                LogFile.Error.Show("ERROR:DBTypes:ID:SetInvalid(ref ID x_ID):x_ID==null!");
            }

        }

        //public void Set(string text)
        //{
        //    try
        //    {
        //        switch (IDtype)
        //        {
        //            case IDType.INT64:
        //                m_V = Convert.ToInt64(text);
        //                break;
        //            case IDType.INT32:
        //                m_V = Convert.ToInt32(text);
        //                break;
        //            case IDType.GUID:
        //                m_V = new Guid(text);
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogFile.Error.Show("ERROR:DBConnectionControl40:ID:Set:Can not set ID for string =\"" + text + "\" when IDtype=" + IDtype.ToString());
        //    }
        //}

        public bool Set(object v)
        {
            if (v is ID)
            {
                if (this.m_Type == ((ID)v).m_Type)
                {
                    this.m_V = ((ID)v).V;
                    this.cond = ((ID)v).cond;
                    this.value = ((ID)v).value;
                    this.defined = ((ID)v).Defined;
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:DBTypes:ID:Constructor Set(object v):m_Type is "+this.m_Type.ToString()+", assigned object value is ID and its m_Type is " + ((ID)v).m_Type.ToString());
                    return false;
                }
            }
            try
            {
                switch (IDtype)
                {
                    case IDType.INT64:
                        if (v is long)
                        {
                            m_V = v;
                        }
                        else if (v is string)
                        {
                            try
                            {
                                m_V = Convert.ToInt64(v);
                            }
                            catch
                            {
                                LogFile.Error.Show("ERROR:DBTypes:ID:Constructor Set(object v):m_Type is INT64, assigned object value is string " + (string)v);
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:DBConnectionControl40:ID:Set(object v):Can not set ID for value type="+v.GetType().ToString()+" value =\"" + v.ToString() + "\" when IDtype=" + IDtype.ToString());
                            return false;
                        }
                        break;
                    case IDType.INT32:
                        if (v is int)
                        {
                            m_V = Convert.ToInt32(v);
                        }
                        else if(v is string)
                        {
                            try
                            {
                                m_V = Convert.ToInt32(v);
                            }
                            catch
                            {
                                LogFile.Error.Show("ERROR:DBTypes:ID:Constructor Set(object v):m_Type is INT32, assigned object value is string " + (string)v);
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:DBConnectionControl40:ID:Set:Can not set ID for int value =\"" + v.ToString() + "\" when IDtype=" + IDtype.ToString());
                            return false;
                        }
                        break;
                    case IDType.GUID:
                        if (v is string)
                        {
                            m_V = new Guid((string)v);
                        }
                        else if (v is Guid)
                        {
                            m_V = (Guid)v;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:DBConnectionControl40:ID:Set:Can not set ID for guid value =\"" + v.ToString() + "\" when IDtype=" + IDtype.ToString());
                            return false;
                        }
                        break;
                }
                return true;
            }
            catch 
            {
                LogFile.Error.Show("ERROR:DBConnectionControl40:ID:Set:Can not set ID for string =\"" + v.ToString() + "\" when IDtype=" + IDtype.ToString());
                return false;
            }
        }

        public void setsqlp(ref List<SQL_Parameter> lpar, string column_name, ref string scond, ref string sval)
        {
            string spar_name = null;
            SQL_Parameter par = null;
            spar_name = "@par_" + column_name;
            if (V == null)
            {
                cond = " " + column_name + " is null ";
                value = " null ";
                scond = cond;
                sval = value;
            }
            else
            {
                switch (IDtype)
                {
                    case IDType.INT64:
                        par = new SQL_Parameter(spar_name, SQL_Parameter.eSQL_Parameter.Bigint, false, m_V);
                        break;
                    case IDType.INT32:
                        par = new SQL_Parameter(spar_name, SQL_Parameter.eSQL_Parameter.Int, false, m_V);
                        break;
                    case IDType.GUID:
                        par = new SQL_Parameter(spar_name, SQL_Parameter.eSQL_Parameter.Varchar, false, m_V);
                        break;
                    default:
                        LogFile.Error.Show("ERROR:DBConnectionControl40:ID:setsqlp:unsuported type=" + IDtype.ToString());
                        return;
                }
                cond = " " + column_name + " = " + spar_name + " ";
                value = spar_name;
                scond = cond;
                sval = value;
                lpar.Add(par);
            }
        }
    }
}
