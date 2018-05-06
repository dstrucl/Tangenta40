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

        private string column_name = null;

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

        public string ColumnName
        {
            get
            {
                return ColumnName;
            }
        }

        public ReferenceFromTable(SQLTable xtable, string xcolumn_name)
        {
            table = xtable;
            column_name = xcolumn_name;
        }

    }
}