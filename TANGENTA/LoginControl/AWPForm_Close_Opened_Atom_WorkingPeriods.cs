using DBConnectionControl40;
using DBSync;
using DBTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangentaDB;

namespace LoginControl
{
    public partial class AWPForm_Close_Opened_Atom_WorkingPeriods : Form
    {
        private DataTable m_dtClose_Opened_Atom_WorkingPeriods= null;
        public AWPForm_Close_Opened_Atom_WorkingPeriods(DataTable xdtClose_Opened_Atom_WorkingPeriods)
        {
            InitializeComponent();
            m_dtClose_Opened_Atom_WorkingPeriods = xdtClose_Opened_Atom_WorkingPeriods;
            lng.s_Close_WorkingPeriods.Text(this.btn_Close_Opened_Atom_WorkingPeriods);
            lng.s_Close_WorkingPeriods.Text(this);
            lng.s_lbl_Instruction.Text(this.lbl_Instruction);
        }

        private void btn_Close_Opened_Atom_WorkingPeriods_Click(object sender, EventArgs e)
        {
            if (f_JOURNAL_Atom_WorkPeriod_TYPE.JOURNAL_Atom_WorkPeriod_TYPE_ID_WorkPeriodNotClosedInPreviousSession == null)
            {
                if (!f_JOURNAL_Atom_WorkPeriod_TYPE.Get_JOURNAL_Atom_WorkPeriod_TYPE_ID())
                {
                    return;
                }
            }
            foreach (DataRow dr in m_dtClose_Opened_Atom_WorkingPeriods.Rows)
            {
                ID xAtom_WorkPeriod_ID = tf.set_ID(dr["LoginSession_$_awperiod_$$ID"]);
                if (ID.Validate(xAtom_WorkPeriod_ID))
                {
                    if (!f_Atom_WorkPeriod.End(xAtom_WorkPeriod_ID, f_JOURNAL_Atom_WorkPeriod_TYPE.JOURNAL_Atom_WorkPeriod_TYPE_ID_WorkPeriodNotClosedInPreviousSession))
                    {
                        return;
                    }
                }
            }
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void AWPForm_Close_Opened_Atom_WorkingPeriods_Load(object sender, EventArgs e)
        {
            dgvx_Close_Opened_Atom_WorkingPeriods.DataSource = m_dtClose_Opened_Atom_WorkingPeriods;
            DBSync.DBSync.DB_for_Tangenta.t_LoginSession.SetVIEW_DataGridViewImageColumns_Headers(dgvx_Close_Opened_Atom_WorkingPeriods, DBSync.DBSync.DB_for_Tangenta.m_DBTables);
        }
    }
}
