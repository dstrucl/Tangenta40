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

namespace SQLTableControl
{
    public class JoinList_for_SQLView_InDataBase
    {
      public  List<Join_for_SQLView_InDataBase> items = new List<Join_for_SQLView_InDataBase>();

      internal bool GetJoin(Join_for_SQLView_InDataBase join, ref Join_for_SQLView_InDataBase refJoin)
      {
          foreach (Join_for_SQLView_InDataBase j in items)
          {
              if (j.TableName.Equals(join.TableName))
              {
                  refJoin = j;
                  return true;
              }
          }
          return false;
      }
    }

    public class Join_for_SQLView_InDataBase
    {
        public SQLTable tbl = null;
        public Column.nullTYPE nulltype;
        public string TableName;
        public string TableName_Abbreviation;
        public string AliasTableName;
        public string Param_ID1;
        public string Param_ID2;
        public SubJoin_for_SQLView_InDataBase pSubJoin;
        public Join_for_SQLView_InDataBase(SQLTable xtbl,string xTableName,string xTableName_Abbreviation, string xAliasTableName, string xParam_ID1, string xParam_ID2, Column.nullTYPE xnulltype)
        {
            tbl = xtbl;
            nulltype = xnulltype;
            TableName = xTableName;
            TableName_Abbreviation = xTableName_Abbreviation;
            AliasTableName = xAliasTableName;
            Param_ID1 = xParam_ID1;
            Param_ID2 = xParam_ID2;
            pSubJoin = null;

        }

        internal SubJoin_for_SQLView_InDataBase GetLastSubJoin()
        {
            SubJoin_for_SQLView_InDataBase pLastSubJoin= null;
            while (pSubJoin != null)
            {
                pLastSubJoin = pSubJoin;
                pSubJoin = pSubJoin.pSubJoin;
            }
            return pLastSubJoin;
            
        }
    }
    public class SubJoin_for_SQLView_InDataBase
    {
        public string Param_ID1;
        public string Param_ID2;
        public SubJoin_for_SQLView_InDataBase pSubJoin;
        public SubJoin_for_SQLView_InDataBase(string xParam_ID1, string xParam_ID2)
        {
            Param_ID1 = xParam_ID1;
            Param_ID2 = xParam_ID2;
            pSubJoin = null;
        }
    }


}
