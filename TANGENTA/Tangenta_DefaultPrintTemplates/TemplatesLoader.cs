using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Tangenta_DefaultPrintTemplates
{
    public static class TemplatesLoader
    {
        /// <summary>
        /// Templates to showcase the HTML Renderer capabilities
        /// </summary>
        private static readonly List<HtmlTemplate> _templates = new List<HtmlTemplate>();



        /// <summary>
        /// Init.
        /// </summary>
        public static void Init()
        {
            LoadSamples();
        }

        /// <summary>
        /// Samples to showcase the HTML Renderer capabilities
        /// </summary>
        public static List<HtmlTemplate> Templates
        {
            get { return _templates; }
        }

    
        /// <summary>
        /// Loads the tree of document samples
        /// </summary>
        private static void LoadSamples()
        {
            var names = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            Array.Sort(names);
            foreach (string name in names)
            {
                int extPos = name.LastIndexOf('.');
                int namePos = extPos > 0 && name.Length > 1 ? name.LastIndexOf('.', extPos - 1) : 0;
                string ext = name.Substring(extPos >= 0 ? extPos : 0);
                string shortName = namePos > 0 && name.Length > 2 ? name.Substring(namePos + 1, name.Length - namePos - ext.Length - 1) : name;

                if (".htm".IndexOf(ext, StringComparison.Ordinal) >= 0)
                {
                    var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name);
                    if (resourceStream != null)
                    {
                        using (var sreader = new StreamReader(resourceStream, Encoding.Default))
                        {
                            var html = sreader.ReadToEnd();

                           _templates.Add(new HtmlTemplate(shortName, name, html));
                        }
                    }
                }
            }
        }
    }
}