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

        public class CommandText : DB_varchar_max
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

        public class V_Int32: DB_Int32
        {
        }
        public class V_Int64: DB_Int64
        {
        }
        public class V_Money: DB_Money
        {
        }
        public class V_Decimal: DB_decimal
        {
        }
        public class V_Percent: DB_Percent
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
        public class V_varchar_264: DB_varchar_264
        {
        }
        public class V_varchar_250: DB_varchar_250
        {
        }
        public class V_varchar_64: DB_varchar_64
        {
        }
        public class V_varchar_50: DB_varchar_50
        {
        }
        public class V_varchar_45: DB_varchar_45
        {
        }
        public class V_varchar_32: DB_varchar_32
        {
        }
        public class V_varchar_25: DB_varchar_25
        {
        }
        public class V_varchar_10: DB_varchar_10
        {
        }
        public class V_varchar_5: DB_varchar_5
        {
        }
        public class V_varchar_2000: DB_varchar_2000
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

        public class Office
        {
            public ID ID = new ID(ID.IDType.INT32);
            public OfficeName OfficeName = new OfficeName();
        }

        public class TransactionLog
        {
            public ID ID = new ID(ID.IDType.INT32);
            public Office m_Office= new Office();
            public Name Name = new Name();
            public Number Number = new Number();
            public CreationTime CreationTime = new CreationTime();
            public ActivationTime ActivationTime = new ActivationTime();
            public CommitTime CommitTime = new CommitTime();
            public RollBackTime RollBackTime = new RollBackTime();
        }

        public class SQLCommand
        {
            public ID ID = new ID(ID.IDType.INT32);
            public TransactionLog m_TransactionLog = new TransactionLog();
            public CommandText CommandText = new CommandText();
            public ExecutionStart ExecutionStart = new ExecutionStart();
            public ExecutionEnd ExecutionEnd = new ExecutionEnd();
            public Error Error = new Error();
        }

        public class P_Int32
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public V_Int32 V_Int32 = new V_Int32();
            public Name Name = new Name();
        }
        public class P_Int64
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public V_Int64 V_Int64 = new V_Int64();
            public Name Name = new Name();
        }
        public class P_Money
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public V_Money V_Money = new V_Money();
            public Name Name = new Name();
        }
        public class P_Decimal
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public V_Decimal V_Decimal = new V_Decimal();
            public Name Name = new Name();
        }
        public class P_Percent
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public V_Percent V_Percent = new V_Percent();
            public Name Name = new Name();
        }
        public class P_smallInt
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public V_smallInt V_smallInt = new V_smallInt();
            public Name Name = new Name();
        }
        public class P_bit
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public V_bit V_bit = new V_bit();
            public Name Name = new Name();
        }
        public class P_DateTime
        {
            public ID ID= new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public V_DateTime V_DateTime = new V_DateTime();
            public Name Name = new Name();
        }
        public class P_varbinary_max
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public V_varbinary_max V_varbinary_max = new V_varbinary_max();
            public Name Name = new Name();
        }
        public class P_varchar_264
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public V_varchar_264 V_varchar_264 = new V_varchar_264();
            public Name Name = new Name();
        }
        public class P_varchar_250
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public V_varchar_250 V_varchar_250 = new V_varchar_250();
            public Name Name = new Name();
        }
        public class P_varchar_64
        {
            public ID ID= new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public V_varchar_64 V_varchar_64 = new V_varchar_64();
            public Name Name = new Name();
        }
        public class P_varchar_50
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public V_varchar_50 V_varchar_50 = new V_varchar_50();
            public Name Name = new Name();
        }
        public class P_varchar_45
        {
            public ID ID= new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public V_varchar_45 V_varchar_45 = new V_varchar_45();
            public Name Name = new Name();
        }
        public class P_varchar_32
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public V_varchar_32 V_varchar_32 = new V_varchar_32();
            public Name Name = new Name();
        }
        public class P_varchar_25
        {
            public ID ID= new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public V_varchar_25 V_varchar_25 = new V_varchar_25();
            public Name Name = new Name();
        }
        public class P_varchar_10
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public V_varchar_10 V_varchar_10 = new V_varchar_10();
            public Name Name = new Name();
        }
        public class P_varchar_5
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public V_varchar_5 V_varchar_5 = new V_varchar_5();
            public Name Name = new Name();
        }
        public class P_varchar_2000
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public V_varchar_2000 V_varchar_2000 = new V_varchar_2000();
            public Name Name = new Name();
        }
        public class P_varchar_max
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public V_varchar_max V_varchar_max = new V_varchar_max();
            public Name Name = new Name();
        }
        public class P_Document
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public V_Document V_Document = new V_Document();
            public Name Name = new Name();
        }
        public class P_Image
        {
            public ID ID = new ID(ID.IDType.INT32);
            public SQLCommand m_SQLCommand = new SQLCommand();
            public V_Image V_Image = new V_Image();
            public Name Name = new Name();
        }

    }

    public class SQL_Database_Tables_Definition
    {

        /* 1 */
        public Office m_Office = new Office();

        /* 2 */
        public TransactionLog m_TransactionLog = new TransactionLogTableClass.TransactionLog();

        /* 3 */
        public SQLCommand m_SQLCommand = new SQLCommand();

        /* 4 */
        public P_Int32 m_P_Int32 = new P_Int32();

        /* 5 */
        public P_Int64 m_P_Int64 = new P_Int64();

        /* 6 */
        public P_Money m_P_Money = new P_Money();

        /* 7 */
        public P_Decimal m_P_Decimal = new P_Decimal();

        /* 8 */
        public P_Percent m_P_Percent = new P_Percent();

        /* 9 */
        public P_smallInt m_P_smallInt = new P_smallInt();

        /* 10 */
        public P_bit m_P_bit = new P_bit();

        /* 11 */
        public P_DateTime m_P_DateTime = new P_DateTime();

        /* 12 */
        public P_varbinary_max m_P_varbinary_max = new P_varbinary_max();

        /* 13 */
        public P_varchar_264 m_P_varchar_264 = new P_varchar_264();

        /* 14 */
        public P_varchar_250 m_P_varchar_250 = new P_varchar_250();

        /* 15 */
        public P_varchar_64 m_P_varchar_64 = new P_varchar_64();

        /* 16 */
        public P_varchar_50 m_P_varchar_50 = new P_varchar_50();

        /* 17 */
        public P_varchar_45 m_P_varchar_45 = new P_varchar_45();

        /* 18 */
        public P_varchar_32 m_P_varchar_32 = new P_varchar_32();

        /* 19 */
        public P_varchar_25 m_P_varchar_25 = new P_varchar_25();

        /* 20 */
        public P_varchar_10 m_P_varchar_10 = new P_varchar_10();

        /* 21 */
        public P_varchar_5 m_P_varchar_5 = new P_varchar_5();

        /* 22 */
        public P_varchar_2000 m_P_varchar_2000 = new P_varchar_2000();

        /* 23 */
        public P_varchar_max m_P_varchar_max = new P_varchar_max();

        /* 24 */
        public P_Document m_P_Document = new P_Document();

        /* 25 */
        public P_Image m_P_Image = new P_Image();
    }
}
