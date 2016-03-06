#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidXSD
{
    using System;
    using System.Xml;
    using System.Xml.Schema;
    using System.IO;

    public class ValidXSD
    {
        public static int Main()
        {

            FileStream fs;
            XmlSchema schema;
            try
            {
                fs = new FileStream("FiscalVerificationSchema.xsd", FileMode.Open);
                schema = XmlSchema.Read(fs, new ValidationEventHandler(ShowCompileError));

                XmlSchemaSet schemaSet = new XmlSchemaSet();
                schemaSet.ValidationEventHandler += new ValidationEventHandler(ShowCompileError);
                schemaSet.Add(schema);
                schemaSet.Compile();

                XmlSchema compiledSchema = null;

                foreach (XmlSchema schema1 in schemaSet.Schemas())
                {
                    compiledSchema = schema1;
                }

                schema = compiledSchema;

                if (schema.IsCompiled)
                {
                    // Schema is successfully compiled. 
                    // Do something with it here.

                }
                return 0;
            }
            catch (XmlSchemaException e)
            {
                Console.WriteLine("LineNumber = {0}", e.LineNumber);
                Console.WriteLine("LinePosition = {0}", e.LinePosition);
                Console.WriteLine("Message = {0}", e.Message);
                return -1;
            }

        }

        private static void ShowCompileError(object sender, ValidationEventArgs e)
        {
            Console.WriteLine("Validation Error: {0}", e.Message);
        }
    }

}
