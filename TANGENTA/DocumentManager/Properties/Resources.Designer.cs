﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DocumentManager.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DocumentManager.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Exit {
            get {
                object obj = ResourceManager.GetObject("Exit", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot;?&gt;
        ///&lt;fu:InvoiceRequest xmlns:fu=&quot;http://www.fu.gov.si/&quot; Id=&quot;test&quot;&gt;
        ///	&lt;fu:Invoice&gt;
        ///		&lt;fu:TaxNumber&gt;@@Moja_Organizacija_DavčnaŠtevilka&lt;/fu:TaxNumber&gt;
        ///		&lt;fu:IssueDateTime&gt;@@Račun_Datum_izdaje_računa&lt;/fu:IssueDateTime&gt;
        ///		&lt;fu:NumberingStructure&gt;B&lt;/fu:NumberingStructure&gt;
        ///		&lt;fu:InvoiceIdentifier&gt;
        ///			&lt;fu:BusinessPremiseID&gt;@@Moja_Organizacija_PoslovnaEnota&lt;/fu:BusinessPremiseID&gt;
        ///			&lt;fu:ElectronicDeviceID&gt;@@Račun_OznakaBlagajne&lt;/fu:ElectronicDeviceID&gt;
        ///			&lt;fu:InvoiceNumber&gt;@@ [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string FVI_SLO_Invoice {
            get {
                return ResourceManager.GetString("FVI_SLO_Invoice", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Tangenta_Logo_SMALL {
            get {
                object obj = ResourceManager.GetObject("Tangenta_Logo_SMALL", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}
