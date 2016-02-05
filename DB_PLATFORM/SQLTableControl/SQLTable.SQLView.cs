#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBConnectionControl40;
using System.Data;
using System.Windows.Forms;

namespace SQLTableControl
{
    partial class SQLTable
    {
        internal StringBuilder SQLCreateView(ref ViewXml xViewXml, DBTableControl m_DBTables, bool bLimit, int limit_number, bool b_order_by_id_desc)
        {
            StringBuilder SQL_View = null;
            if (m_DBTables.m_con.DBType == DBConnection.eDBType.SQLITE)
            {
                SQL_View = new StringBuilder("");
            }
            else
            {
                SQL_View = new StringBuilder("USE " + m_DBTables.m_con.DataBase + "\n");
            }

            string sLimit = "";

            string order_by_id = "";
            if (b_order_by_id_desc)
            {
                order_by_id = " Order by " + TableName + ".ID desc";
            }

            if (bLimit)
            {
                switch (m_DBTables.m_con.DBType) 
                {
                    case DBConnection.eDBType.MSSQL:
                        sLimit = " TOP " + limit_number.ToString() + " ";
                        SQL_View.Append("\nSELECT " + sLimit);
                        break;
                    case DBConnection.eDBType.MYSQL:
                        sLimit = " TOP " + limit_number.ToString() + " ";
                        SQL_View.Append("\nSELECT ");
                        break;

                    case DBConnection.eDBType.SQLITE:
                        sLimit = " LIMIT " + limit_number.ToString() + " ";
                        SQL_View.Append("\nSELECT ");
                        break;
                }

            }

            SQL_View.Append("\n  "+ TableName + ".ID");
            foreach (ColumnXml xColumnXml in xViewXml.m_ColumnXml)
            {
                SQL_View.Append(",\n  "+ xColumnXml.m_col.ownerTable.TableName + "." + xColumnXml.m_col.Name);

            }

            SQL_View.Append("\n FROM " + TableName );
            JoinList xInnerJoinList = new JoinList();
 
            foreach (ColumnXml xColumnXml in xViewXml.m_ColumnXml)
            {
                Join FullJoin = GetTopJoin(xColumnXml.m_col.ownerTable.CreateInnerJoin(null));
                if (FullJoin != null)
                {
                    xInnerJoinList.Insert(FullJoin);
                }
                else
                {
                    // this is Member of current table!
                }
            }

            string sWhere = "";
            int i=0;
            foreach (ColumnXml xColumnXml in xViewXml.m_ColumnXml)
            {
                if (xColumnXml.bUseSqlFilter)
                {
                    if (xColumnXml.SqlFilter != null)
                    {
                        if (xColumnXml.SqlFilter.Length > 0)
                        {
                            if (i == 0)
                            {
                                sWhere += xColumnXml.SqlFilter;
                            }
                            else
                            {
                                sWhere += "\nAND " + xColumnXml.SqlFilter;
                            }
                            i++;
                        }
                    }
                }
           }
            if (sWhere.Length>0)
            {
                sWhere = "\nWHERE " + sWhere;
            }
            string sInnerJoins = xInnerJoinList.SQL_InnerJoins();

            if (sInnerJoins.Length > 0)
            {
                sInnerJoins = " INNER JOIN " + sInnerJoins;
            }

            SQL_View.Append(sInnerJoins);

            SQL_View.Append(sWhere);

            if (!((sWhere.ToLower().Contains("order by"))
                  ||
                  (sWhere.ToLower().Contains("order  by"))))
            {
                SQL_View.Append(order_by_id);
            }

            if (bLimit)
            {
                switch (m_DBTables.m_con.DBType)
                {
                    case DBConnection.eDBType.MSSQL:
                        break;
                    case DBConnection.eDBType.MYSQL:
                        sLimit = " LIMIT " + limit_number.ToString() + " ";
                        SQL_View.Append(sLimit);
                        break;

                    case DBConnection.eDBType.SQLITE:
                        sLimit = " LIMIT " + limit_number.ToString() + " ";
                        SQL_View.Append(sLimit);
                        break;
                }

            }

            xViewXml.SQLView = SQL_View.ToString();
            return SQL_View;

        }

        private Join GetTopJoin(Join innerJoin)
        {
            if (innerJoin != null)
            {
                while (innerJoin.m_prev != null)
                {
                    innerJoin = innerJoin.m_prev;
                }
                return innerJoin;
            }
            else
            {
                return null;
            }
        }
        // Join     Join   Join        Join
        // m_next->m_next->m_next->..->m_next->null
        //   null<-m_prev<-m_prev<-..<-m_prev<-m_prev
        private Join CreateInnerJoin(Join pNext)
        {
            if (pParentTable != null)
            {
                Join IJoin = new Join();
                IJoin.tbl = this;
                IJoin.m_next = pNext;
                IJoin.sJoin = this.TableName + " ON " + this.pParentTable.TableName + "." + this.TableName + "_ID = " + this.TableName + ".ID";
                if (pNext != null)
                {
                    IJoin.sFullJoin = IJoin.sJoin + " INNER JOIN\n" + pNext.sFullJoin;
                }
                else
                {
                    IJoin.sFullJoin = IJoin.sJoin;
                }
                IJoin.m_prev = this.pParentTable.CreateInnerJoin(IJoin);
                return IJoin;
            }
            else
            {
                return null;
            }
        }
    }

    public class JoinList
    {
        public List<Join> items = new List<Join>();

        public void Insert(Join IJoin)
        {
            int iCount;
            int i;
            iCount = items.Count;
            if (items.Count == 0)
            {
                items.Add(IJoin);
                return;
            }
            for (i = 0; i < iCount; i++)
            {
                if (IJoin.NextItemsCount() >= items[i].NextItemsCount())
                {
                    items.Insert(i, IJoin);
                    return;
                }
                i++;
            }
            items.Add(IJoin);
        }

        internal string SQL_InnerJoins()
        {
            string sFullJoin = "";
            int iCount;
            int i;
            iCount = items.Count;
            for (i = 0; i < iCount; i++)
            {
                Join IJoin = items[i];
                if (i == 0)
                {
                    sFullJoin = IJoin.sFullJoin;
                }
                else
                {
                    sFullJoin = sFullJoin +  ThoseWhichNotExistInList(IJoin, i);
                }
            }
            return sFullJoin;
        }

        public string ThoseWhichNotExistInList(Join IJoin, int iCount)
        {
            string sFullJoin = "";
            Join curJoin = IJoin;
            while (curJoin != null)
            {
                if (!ExistInList(curJoin,iCount))
                {
                    sFullJoin = sFullJoin + " INNER JOIN\n" + curJoin.sJoin;
                }
                curJoin = curJoin.m_next;
            }
            return sFullJoin;
        }

        private bool ExistInList(Join IJoin, int iCount)
        {
            int j;
            for (j = 0; j < iCount; j++)
            {
                Join xcurJoin = items[j];
                while (xcurJoin != null)
                {
                    if (xcurJoin.sJoin.Equals(IJoin.sJoin))
                    {
                        // Allready Exist !
                        return true;
                    }
                    xcurJoin = xcurJoin.m_next;
                }
            }
            return false;
        }


    }

    public class Join
    {
        public SQLTable tbl;
        public string    sJoinType;
        public string    sFullJoin;
        public string    sJoin;
        public Join m_next;
        public Join m_prev;
        public ForeignKey m_fK;
        public SQLTable m_tbl;

        internal int NextItemsCount()
        {
            int iCount = 0;
            Join Cur = this;
            while (Cur.m_next != null)
            {
                iCount++;
                Cur = Cur.m_next;
            }
            return iCount;
        }
    }
}
