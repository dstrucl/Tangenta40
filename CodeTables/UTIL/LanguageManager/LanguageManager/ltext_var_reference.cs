using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageManager
{
    public class ltext_var_reference
    {
        private string class_name = "";
        private string var_name = "";
        private string constructor_call = "";

        public string Class_name
        {
            get { return class_name; }
            set { class_name = value; }
        }
        public string Var_name
        {
            get { return var_name; }
            set { var_name = value; }
        }
        public string Class_and_Var
        {
            get { return Class_name + "." + Var_name; }
        }

        public string Constructor_call
        {
            get { return constructor_call; }
            set { constructor_call = value; }
        }
        public List<int> Positions = new List<int>();

        public string Static_ltext_Definition()
        {
            return "\r\n public static ltext " + var_name + " = new ltext( new string[]{"+GetArgument()+"});";
        }

        private string GetArgument()
        {
            int istart = constructor_call.IndexOf('(');
            int iend = constructor_call.LastIndexOf(')');
            if ((istart>0) &&(iend > istart))
            {
                string s = constructor_call.Substring(istart+1, iend - istart-1);
                return s;
            }
            else
            {
                return "/* CONSTRUCTOR PARAMS NOT FOUND for "+ Class_and_Var + " !!!! */";
            }


        }

      

        internal void AddPositions(List<Ordered_ltext_position> lordered_List)
        {
            foreach (int ipos in Positions)
            {
                if (lordered_List.Count > 0)
                {
                    foreach (Ordered_ltext_position olp in lordered_List)
                    {
                        if (ipos < olp.iPos)
                        {
                            Ordered_ltext_position op = new Ordered_ltext_position();
                            op.Var_name = this.Var_name;
                            op.Class_name = this.Class_name;
                            op.iPos = ipos;
                            lordered_List.Insert(0, op);
                            break;
                        }
                    }
                    Ordered_ltext_position xop = new Ordered_ltext_position();
                    xop.Var_name = this.Var_name;
                    xop.Class_name = this.Class_name;
                    xop.iPos = ipos;
                    lordered_List.Add(xop);
                }
                else
                {
                    Ordered_ltext_position op = new Ordered_ltext_position();
                    op.Var_name = this.Var_name;
                    op.Class_name = this.Class_name;
                    op.iPos = ipos;
                    lordered_List.Add(op);
                }
            }
        }
    }
}
