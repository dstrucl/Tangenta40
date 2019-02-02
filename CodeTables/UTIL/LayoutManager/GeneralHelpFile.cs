using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayoutManager
{
    public class GeneralHelpFile
    {
        private string m_Name = "";
        public string Name
        {
            get { return m_Name; }
            set
            {
                m_Name = value;
            }
        }
        private string m_FileName = "";
        public string FileName
        {
            get { return m_FileName; }
            set
            {
                m_FileName = value;
            }
        }

        public GeneralHelpFile(string basepath,string xName, string file_extension)
        {
            m_Name = xName;
            m_FileName = GeneralHelpFile.SetFile(basepath, xName, file_extension);
        }

        public static string SetFile(string basepath, string xName, string file_extension)
        {
            return basepath + xName + file_extension; 
        }
    }
}
