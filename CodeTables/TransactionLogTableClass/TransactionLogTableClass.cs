using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnectionControl40;
using DBTypes;
using static TransactionLogTableClass.TransactionLogTableClass;

namespace TransactionLogTableClass
{
    public class TransactionLogTableClass
    {
        public class OfficeName : DB_varchar_264
        {
        }

        public class Name : DB_varchar_264
        {
        }

        public class Number : DB_Int64
        {
        }

        public class CreationTime : DB_DateTime
        {
        }

        public class ActivationTime : DB_DateTime
        {
        }

        public class CommitTime : DB_DateTime
        {
        }

        public class RollBackTime : DB_DateTime
        {
        }

        public class SQLText : DB_varchar_max
        {
        }

        public class ExecutionStart: DB_DateTime
        {
        }

        public class ExecutionEnd : DB_DateTime
        {
        }

        public class Error : DB_varchar_max
        {
        }

        public class V_Int: DB_Int32
        {
        }

        public class V_Bigint: DB_Int64
        {
        }

        public class V_Decimal: DB_decimal
        {
        }

        public class V_Float: DB_float
        {
        }
        public class V_smallInt: DB_smallInt
        {
        }
        public class V_bit: DB_bit
        {
        }
        public class V_DateTime: DB_DateTime
        {
        }
        public class V_varbinary_max: DB_varbinary_max
        {
        }

        public class V_varchar_max: DB_varchar_max
        {
        }


        public class V_Document: DB_Document
        {
        }
        public class V_Image: DB_Image
        {
        }


        public class TransactionName
        {
            public ID ID = new ID(ID.IDType.INT32);
            public Name Name = new Name();
        }

        public class TransactionLog
        {
            public ID ID = new ID(ID.IDType.INT32);
            public TransactionName m_TransactionName = new TransactionName();
            public Number Number = new Number();
            public CreationTime CreationTime = new CreationTime();
            public ActivationTime ActivationTime = new ActivationTime();
            public CommitTime CommitTime = new CommitTime();
            public RollBackTime RollBackTime = new RollBackTime();
        }



        public class CommandText
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLText SQLText = new SQLText();
        }

        public class SQLCommand
        {
            public ID ID = new ID(ID.IDType.INT32);
            public TransactionLog m_TransactionLog = new TransactionLog();
            public CommandText m_CommandText = new CommandText();
            public ExecutionStart ExecutionStart = new ExecutionStart();
            public ExecutionEnd ExecutionEnd = new ExecutionEnd();
            public Error Error = new Error();
        }

        public class ParameterName
        {
            public ID ID = new ID(ID.IDType.INT32);
            public Name Name = new Name();
        }

        public class P_Int
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public ParameterName m_ParameterName = new ParameterName();
            public V_Int V_Int = new V_Int();
        }

         public class P_Decimal
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public ParameterName m_ParameterName = new ParameterName();
            public V_Decimal V_Decimal = new V_Decimal();
        }

        public class P_Float
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public ParameterName m_ParameterName = new ParameterName();
            public V_Float V_Float = new V_Float();
        }

        public class P_bit
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public ParameterName m_ParameterName = new ParameterName();
            public V_bit V_bit = new V_bit();
        }

        public class P_DateTime
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public ParameterName m_ParameterName = new ParameterName();
            public V_DateTime V_DateTime = new V_DateTime();
        }

        public class P_Nvarchar
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public ParameterName m_ParameterName = new ParameterName();
            public V_varchar_max V_varchar_max = new V_varchar_max();
        }

        public class P_Varchar
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public ParameterName m_ParameterName = new ParameterName();
            public V_varchar_max V_varchar_max = new V_varchar_max();
        }

        public class P_Nchar
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public ParameterName m_ParameterName = new ParameterName();
            public V_varchar_max V_varchar_max = new V_varchar_max();
        }

        public class P_Bigint
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public ParameterName m_ParameterName = new ParameterName();
            public V_Bigint V_Bigint = new V_Bigint();
        }

        public class P_smallInt
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public ParameterName m_ParameterName = new ParameterName();
            public V_smallInt V_smallInt = new V_smallInt();
        }


        public class P_Varbinary
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public ParameterName m_ParameterName = new ParameterName();
            public V_varbinary_max V_varbinary_max = new V_varbinary_max();
        }
    }

    public class SQL_Database_Tables_Definition
    {

        /* 1 */
        public TransactionName m_TransactionName = new TransactionName();

        /* 2 */
        public TransactionLog m_TransactionLog = new TransactionLog();

        /* 3 */
        public CommandText m_CommandText = new CommandText();

        /* 4 */
        public SQLCommand m_SQLCommand = new SQLCommand();

        /* 5 */
        public ParameterName m_ParameterName = new ParameterName();

        /* 6 */
        public P_Int m_P_Int = new P_Int();

        /* 7 */
        public P_Decimal m_P_Decimal = new P_Decimal();

        /* 8 */
        public P_Float m_P_Float = new P_Float();

        /* 9 */
        public P_bit m_P_bit = new P_bit();

        /* 10 */
        public P_DateTime m_P_DateTime = new P_DateTime();

        /* 11 */
        public P_Nvarchar m_P_Nvarchar = new P_Nvarchar();

        /* 12 */
        public P_Varchar m_P_Varchar = new P_Varchar();

        /* 13 */
        public P_Nchar m_P_Nchar = new P_Nchar();

        /* 14 */
        public P_Bigint m_P_Bigint = new P_Bigint();

        /* 15 */
        public P_smallInt m_P_smallInt = new P_smallInt();

        /* 16 */
        public P_Varbinary m_P_Varbinary = new P_Varbinary();

    }
}
