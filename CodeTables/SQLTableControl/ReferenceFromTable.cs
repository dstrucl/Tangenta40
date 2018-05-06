namespace CodeTables
{
    public class ReferenceFromTable
    {
        private SQLTable table = null;
        public SQLTable Table
        {
            get
            {
                return table;
            }
        }


        public string TableName
        {
            get
            {
                if (table != null)
                {
                    return table.TableName;
                }
                else
                {
                    return null;
                }
            }
        }

        private string column_name = null;

        public string ColumnName
        {
            get
            {
                return column_name;
            }
        }

        public ReferenceFromTable(SQLTable xtable, string xcolumn_name)
        {
            table = xtable;
            column_name = xcolumn_name;
        }

    }
}