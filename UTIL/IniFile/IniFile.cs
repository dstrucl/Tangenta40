using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.CodeDom.Compiler;
using System.CodeDom;
using System.Globalization;
using System.Windows.Forms;
using System.Threading;

namespace IniFile
{
    public static class IniFile
    {

    /// <summary>
    /// Create a New INI file to store or load data
    /// </summary>
        public static string path;
        public static int Ini_Mutex_Timeout = 30000;
        private static Mutex mutex = new Mutex();

        public static Ini ini = null;

        //[DllImport("kernel32")]
        //private static extern long WritePrivateProfileString(string section,
        //    string key, string val, string filePath);
        //[DllImport("kernel32")]
        //private static extern int GetPrivateProfileString(string section,
        //         string key, string def, StringBuilder retVal,
        //    int size, string filePath);

        /// <summary>
        /// INIFile Constructor.
        /// </summary>
        /// <PARAM name="INIPath"></PARAM>
        /// <summary>
        /// Write Data to the INI File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// Section name
        /// <PARAM name="Key"></PARAM>
        /// Key Name
        /// <PARAM name="Value"></PARAM>
        /// Value Name
        /// 

        public static bool Check_Section_And_Key(string sSection, string Key)
        {
            //MessageBox.Show("IniFile:bool Check_Section_And_Key(string sSection, string Key)");
            //if (mutex == null)
            //{
            //    MessageBox.Show("IniFile:mutex = null");
            //}

            if (mutex.WaitOne(Ini_Mutex_Timeout))
            {
//                MessageBox.Show("IniFile:bool Check_Section_And_Key(string sSection, string Key) GOT MUTEX");
                bool bRes = false;
                if (ini == null)
                {
                    ini = new Ini(path);
                }
                bRes = ini.Check_Section_And_Key(sSection, Key);
                mutex.ReleaseMutex();
                return bRes;
            }
            else
            {
                MessageBox.Show("ERROR:Check_Section_And_Key MUTEX TIMEOUT");
                return false;
            }
        }

        public static bool IniWriteValue(string Section, string Key, string sValue, ref string Err)
        {
            if (mutex.WaitOne(Ini_Mutex_Timeout))
            {
                if (ini == null)
                {
                    ini = new Ini(path);
                }
                ini.inifile = path;
                //MessageBox.Show("IniWriteValue(Section="+Section+",  Key = " + Key+ ", sValue ="+sValue+", ref string Err)");
                string sLiteralString = ToLiteral(sValue);
                bool breswrite = ini.WritePrivateProfileString(Section, Key, sLiteralString, ref Err);
                mutex.ReleaseMutex();
                return breswrite;
            }
            else
            {
                MessageBox.Show("ERROR:IniWriteValue MUTEX TIMEOUT");
                return false;
            }
                
        }


        
        /// <summary>
        /// Read Data Value From the Ini File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// <PARAM name="Key"></PARAM>
        /// <PARAM name="Path"></PARAM>
        /// <returns></returns>
        public static bool IniReadValue(string Section,string Key, ref string sValue, ref string Err)
        {
            if (mutex.WaitOne(Ini_Mutex_Timeout))
            {
                string sLiteral = null;
                if (ini == null)
                {
                    ini = new Ini(path);
                }
                if (ini.GetPrivateProfileString(Section, Key, ref sLiteral, ref Err))
                {
                    string sv = StringFromCSharpLiteral(sLiteral);
                    sValue = take_from_partanthesis(sv);
                    mutex.ReleaseMutex();
                    return true;
                }
                mutex.ReleaseMutex();
                return false;
            }
            else
            {
                MessageBox.Show("ERROR:IniReadValue MUTEX TIMEOUT");
                return false;
            }
        }

        private static string take_from_partanthesis(string sv)
        {
            int iLen = sv.Length;
            int iStart = -1;
            int i;
            for (i = 0; i < iLen; i++)
            {
                char ch = sv[i];
                {
                    if ((ch == ' ') || (ch == '\t'))
                    {
                        continue;
                    }
                    else if (ch == '"')
                    {
                        iStart = i;
                        iStart++;
                        int j = -1;
                        for (j = iLen - 1; j > iStart; j--)
                        {
                            if ((ch == ' ') || (ch == '\t'))
                            {
                                continue;
                            }
                            else if (ch == '"')
                            {
                                int iEnd = j;
                                int islen = iEnd - iStart;
                                if (islen > 0)
                                {
                                    return sv.Substring(iStart, islen);
                                }
                            }
                        }
                    }
                }
            }
           return sv;
        }

        private static string ToLiteral( string input)
        {
            var literal = new StringBuilder(input.Length + 2);
            literal.Append("\"");
            foreach (var c in input)
            {
                switch (c)
                {
                    case '\'': literal.Append(@"\'"); break;
                    case '\"': literal.Append("\\\""); break;
                    case '\\': literal.Append(@"\\"); break;
                    case '\0': literal.Append(@"\0"); break;
                    case '\a': literal.Append(@"\a"); break;
                    case '\b': literal.Append(@"\b"); break;
                    case '\f': literal.Append(@"\f"); break;
                    case '\n': literal.Append(@"\n"); break;
                    case '\r': literal.Append(@"\r"); break;
                    case '\t': literal.Append(@"\t"); break;
                    case '\v': literal.Append(@"\v"); break;
                    default:
                        if (Char.GetUnicodeCategory(c) != UnicodeCategory.Control)
                        {
                            literal.Append(c);
                        }
                        else
                        {
                            literal.Append(@"\u");
                            literal.Append(((ushort)c).ToString("x4"));
                        }
                        break;
                }
            }
            literal.Append("\"");
            return literal.ToString();
        }

        //private static string ToLiteral(string input)
        //{
        //    using (var writer = new StringWriter())
        //    {
        //        using (var provider = CodeDomProvider.CreateProvider("CSharp"))
        //        {
        //            provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, null);
        //            return writer.ToString();
        //        }
        //    }
        //}


        private static string StringFromCSharpLiteral(string source)
        {

            StringBuilder sb = new StringBuilder(source.Length);

            int pos = 0;

            while (pos < source.Length)
            {

                char c = source[pos];

                if (c == '\\')
                {

                    // --- Handle escape sequences

                    pos++;

                    if (pos >= source.Length) throw new ArgumentException("Missing escape sequence");

                    switch (source[pos])
                    {

                        // --- Simple character escapes

                        case '\'': c = '\''; break;

                        case '\"': c = '\"'; break;

                        case '\\': c = '\\'; break;

                        case '0': c = '\0'; break;

                        case 'a': c = '\a'; break;

                        case 'b': c = '\b'; break;

                        case 'f': c = '\f'; break;

                        case 'n': c = ' '; break;

                        case 'r': c = ' '; break;

                        case 't': c = '\t'; break;

                        case 'v': c = '\v'; break;

                        case 'x':

                            // --- Hexa escape (1-4 digits)

                            StringBuilder hexa = new StringBuilder(10);

                            pos++;

                            if (pos >= source.Length)

                                throw new ArgumentException("Missing escape sequence");

                            c = source[pos];

                            if (Char.IsDigit(c) || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F'))
                            {

                                hexa.Append(c);

                                pos++;

                                if (pos < source.Length)
                                {

                                    c = source[pos];

                                    if (Char.IsDigit(c) || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F'))
                                    {

                                        hexa.Append(c);

                                        pos++;

                                        if (pos < source.Length)
                                        {

                                            c = source[pos];

                                            if (Char.IsDigit(c) || (c >= 'a' && c <= 'f') ||

                                              (c >= 'A' && c <= 'F'))
                                            {

                                                hexa.Append(c);

                                                pos++;

                                                if (pos < source.Length)
                                                {

                                                    c = source[pos];

                                                    if (Char.IsDigit(c) || (c >= 'a' && c <= 'f') ||

                                                      (c >= 'A' && c <= 'F'))
                                                    {

                                                        hexa.Append(c);

                                                        pos++;

                                                    }

                                                }

                                            }

                                        }

                                    }

                                }

                            }

                            c = (char)Int32.Parse(hexa.ToString(), NumberStyles.HexNumber);

                            pos--;

                            break;

                        case 'u':

                            // Unicode hexa escape (exactly 4 digits)

                            pos++;

                            if (pos + 3 >= source.Length)

                                throw new ArgumentException("Unrecognized escape sequence");

                            try
                            {

                                uint charValue = UInt32.Parse(source.Substring(pos, 4),

                                  NumberStyles.HexNumber);

                                c = (char)charValue;

                                pos += 3;

                            }

                            catch (SystemException)
                            {

                                throw new ArgumentException("Unrecognized escape sequence");

                            }

                            break;

                        case 'U':

                            // Unicode hexa escape (exactly 8 digits, first four must be 0000)

                            pos++;

                            if (pos + 7 >= source.Length)

                                throw new ArgumentException("Unrecognized escape sequence");

                            try
                            {

                                uint charValue = UInt32.Parse(source.Substring(pos, 8),

                                  NumberStyles.HexNumber);

                                if (charValue > 0xffff)

                                    throw new ArgumentException("Unrecognized escape sequence");

                                c = (char)charValue;

                                pos += 7;

                            }

                            catch (SystemException)
                            {

                                throw new ArgumentException("Unrecognized escape sequence");

                            }

                            break;

                        default:

                            throw new ArgumentException("Unrecognized escape sequence");

                    }

                }

                pos++;

                sb.Append(c);

            }

            return sb.ToString();
        }
        
    }

    public class Ini
    {
        public enum eReadSections { OK, FILE_NOT_EXISTS, ERROR };
        public enum eFind {OK,SECTION_NOT_FOUND,KEY_NOT_FOUND};
        public List<Section> Sections = new List<Section>();
        public string inifile;


        public Ini(string sfile)
        {
            inifile = sfile;
        }
        internal bool WritePrivateProfileString(string sSection, string Key, string sLiteralString, ref string Err)
        {
            Sections.Clear();
            eReadSections eres = ReadSections(ref Sections, ref Err);
            switch (eres)
            {
                case eReadSections.OK:
                    Key mykey = null;
                    Section sect = null;
                    eFind efres = Find(this.Sections,sSection,Key,ref  sect, ref mykey);
                    switch (efres)
                    {
                        case eFind.OK:
                            mykey.sValue = sLiteralString;
                            if (Write(ref Err))
                            {
                                return true;
                            }
                            break;
                        case eFind.SECTION_NOT_FOUND:
                            sect = new Section(sSection);
                            mykey = new Key(Key, sLiteralString);
                            sect.Keys.Add(mykey);
                            Sections.Add(sect);
                            if (Write(ref Err))
                            {
                                return true;
                            }
                            break;

                        case eFind.KEY_NOT_FOUND:
                            mykey = new Key(Key, sLiteralString);
                            sect.Keys.Add(mykey);
                            if (Write(ref Err))
                            {
                                return true;
                            }
                            break;
                    }
                    return false;
                case eReadSections.FILE_NOT_EXISTS:
                    sect = new Section(sSection);
                    mykey = new Key(Key, sLiteralString);
                    sect.Keys.Add(mykey);
                    Sections.Add(sect);
                    if (Write(ref Err))
                    {
                        return true;
                    }
                    return false;
                case eReadSections.ERROR:
                    return false;
            }
            return false;
        }

        private bool Write(ref string Err)
        {
            List<string> sline_list = new List<string>();
            sline_list.Clear();
            foreach (Section sect in Sections)
            {
                sline_list.Add("[" + sect.Name + "]");
                foreach (Key ky in sect.Keys)
                {
                    if (ky.sValue.Length > 0)
                    {
                        if (ky.sValue[0] == '"')
                        {
                            sline_list.Add(ky.Name + "=" + ky.sValue);
                        }
                        else
                        {
                            sline_list.Add(ky.Name + "=\"" + ky.sValue + "\"");
                        }
                    }
                    else
                    {
                        sline_list.Add(ky.Name + "=\"\"");
                    }
                }
            }
            int iCount = sline_list.Count;
            string[] sLines = new string[iCount];
            int i = 0;
            for (i = 0; i < iCount; i++)
            {
                sLines[i] = sline_list[i];
            }
            try
            {
                
                File.WriteAllLines(inifile, sLines);
                return true;
            }
            catch (Exception ex)
            {
               Err = "ERROR:IniFile:ini:Write Exception = " + ex.Message;
               return false;
            }
        }

        internal eFind Find(List<Section> mySections,string sSection, string Key, ref Section sect, ref Key xKey)
        {
            eFind eres = eFind.SECTION_NOT_FOUND;
            foreach (Section sec in mySections)
            {
                if (sec.Name.Equals(sSection))
                {
                    sect = sec;
                    eres = eFind.KEY_NOT_FOUND;
                    foreach (Key xkey in sec.Keys)
                    {
                        if (xkey.Name.Equals(Key))
                        {
                            xKey = xkey;
                            return eFind.OK;
                        }
                    }
                    return eres;
                }
            }
            return eres;
        }

        internal eReadSections ReadSections(ref List<Section> mySections, ref string Err)
        {
            Sections.Clear();
            string mySectionName = null;
            Section CurrentSection = null;
            if (File.Exists(inifile))
            {
                try
                {
                    string[] sLines = File.ReadAllLines(inifile);
                    foreach (string sline in sLines)
                    {
                        if (IsNewSection(ref mySectionName,sline))
                        {
                            if (CurrentSection != null)
                            {
                                CurrentSection = new Section(mySectionName);
                                mySections.Add(CurrentSection);
                            }
                            else
                            {
                                CurrentSection = new Section(mySectionName);
                                mySections.Add(CurrentSection);
                            }
                        }
                        else
                        {
                            string Key = null;
                            string sValue = null;
                            if (GetKeyAndValue(sline, ref Key, ref sValue))
                            {
                                Key key = new Key(Key, sValue);
                                CurrentSection.Keys.Add(key);
                            }
                        }
                    }
                    return eReadSections.OK;
                }
                catch (Exception ex)
                {
                    Err = "ERROR:IniFile Exception = " + ex.Message;
                    return eReadSections.ERROR;
                }
            }
            else
            {
                return eReadSections.FILE_NOT_EXISTS;
            }
        }

        private bool GetKeyAndValue(string sline, ref string Key, ref string sValue)
        {
            int idx = -1;
            int iLen_sLine = sline.Length;
            if (MoveToFirstAlpha(sline, ref idx, new char[] { ' ', '\t' }))
            {
                int idx_key_start = idx;
                if (MoveTo(sline, ref idx, '=', null))
                {
                    int idx_key_end = idx;
                    int idx_key_len = idx_key_end - idx_key_start;
                    Key = sline.Substring(idx_key_start, idx_key_len);
                    idx++;
                    if (sline[idx] == '"')
                    {
                        idx++;
                        int idx_val_start = idx;
                        
                        int iLen_sValue = sline.Length;
                        int i = iLen_sValue - 1;
                        while (i > 0)
                        {
                            if (sline[i] == '"')
                            {
                                if (i > idx_val_start)
                                {
                                    int ilen_val = i - idx_val_start;
                                    sValue = sline.Substring(idx_val_start, ilen_val);
                                    return true;
                                }
                                else if (i == idx_val_start)
                                {
                                    sValue = "";
                                    return true;
                                }
                            }
                            i--;
                        }
                    }
                }
            }
            return false;
        }

        private bool IsNewSection(ref string mySectionName,string sLine)
        {
            int idx = 0;
            if (MoveTo(sLine,ref idx,'[',new char[]{' ','\t'}))
            {
                int id_section_start = idx + 1;
                if (MoveTo(sLine, ref idx, ']',null))
                {
                    int id_section_end = idx;
                    int iLen = id_section_end - id_section_start;
                    string section = sLine.Substring(id_section_start, iLen);
                    if (mySectionName == null)
                    {
                        mySectionName = section;
                        return true;
                    }
                    if (mySectionName.Equals(section))
                    {
                        return false;
                    }
                    else
                    {
                        mySectionName = section;
                        return true;
                    }

                }
            }
            return false;
        }

        private bool MoveToFirstAlpha(string sLine, ref int idx, char[] ignore)
        {
            int i;
            int iLen;
            iLen = sLine.Length;
            for (i = 0; i < iLen; i++)
            {
                char ch = sLine[i]; 
                if (IsIn(ch, ignore))
                {
                    continue;
                }
                else
                {
                    idx = i;
                    return true;
                }
            }
            return false;
        }

        private bool MoveTo(string sLine, ref int idx, char ctoken, char[] ignore)
        {
            int i;
            int iLen;
            iLen = sLine.Length;
            if (ignore != null)
            {
                for (i = 0; i < iLen; i++)
                {
                    char ch = sLine[i];
                    if (ch == ctoken)
                    {
                        idx = i;
                        return true;
                    }
                    else
                    {
                        if (IsIn(ch, ignore))
                        {
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                for (i = 0; i < iLen; i++)
                {
                    char ch = sLine[i];
                    if (ch == ctoken)
                    {
                        idx = i;
                        return true;
                    }
                }
            }
            return false;
        }

        private bool IsIn(char ch, char[] clist)
        {
            foreach (char c in clist)
            {
                if (ch == c)
                {
                    return true;
                }
            }
            return false;
        }

        internal bool Check_Section_And_Key(string sSection, string Key)
        {

            string Err = null;
            List<Section> mySections = new List<Section>();
            eReadSections eRes = ReadSections(ref mySections, ref Err);
            if (eRes == eReadSections.OK)
            {
                Section sect = null;
                Key mykey = null;
                eFind efres = Find(mySections,sSection, Key, ref  sect, ref mykey);
                switch (efres)
                {
                    case eFind.OK:
                        return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        internal bool GetPrivateProfileString(string sSection, string Key,ref string sVal, ref string Err)
        {
            eReadSections eRes = ReadSections(ref Sections, ref Err);
            if (eRes == eReadSections.OK)
            {
                Section sect = null;
                Key mykey = null;
                eFind efres = Find(this.Sections,sSection, Key, ref  sect, ref mykey);
                switch (efres)
                {
                    case eFind.OK:
                        sVal = mykey.sValue;
                        return true;
                    case eFind.SECTION_NOT_FOUND:
                        Err = "ERROR:IniFile:ini:GetPrivateProfileString: eFind.SECTION_NOT_FOUND !";
                        return false;

                    case eFind.KEY_NOT_FOUND:
                        Err = "ERROR:IniFile:ini:GetPrivateProfileString: eFind.KEY_NOT_FOUND !";
                        return false;
                        break;
                }
            }
            return false;
        }
    }

    public class Section
    {
        public string Name;
        public List<Key> Keys = new List<Key>();

        public Section(string name)
        {
            Name = name;
        }
    }

    public class Key
    {
        public string Name;
        public string sValue;
        public Key(string name, string value)
        {
            Name = name;
            sValue = value;
        }
    }


}
