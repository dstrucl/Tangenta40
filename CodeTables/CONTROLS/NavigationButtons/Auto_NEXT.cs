using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NavigationButtons
{
    public class Auto_NEXT
    {
        public int NextButtonPressedInMiliSeconds = 1000;
        public List<CheckBox> CheckBoxTrue_list = null;
        public List<RadioButton> RadioButtonTrue_list = null;
        private int v;

        public Auto_NEXT(int PressNextInMiliseconds)
        {
            NextButtonPressedInMiliSeconds = PressNextInMiliseconds;
        }
    }
}
