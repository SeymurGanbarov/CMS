﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CMS.API.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CMS.API.Resources.Messages", typeof(Messages).Assembly);
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
        ///   Looks up a localized string similar to Bu sahə boş ola bilməz.
        /// </summary>
        internal static string CannotBeEmpty {
            get {
                return ResourceManager.GetString("CannotBeEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Müştəri sahəsi boş ola bilməz.
        /// </summary>
        internal static string CustomerId {
            get {
                return ResourceManager.GetString("CustomerId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Əməliyyat zamanı xəta baş verdi.
        /// </summary>
        internal static string ErrorOccured {
            get {
                return ResourceManager.GetString("ErrorOccured", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Qrup sahəsi boş ola bilməz.
        /// </summary>
        internal static string GroupId {
            get {
                return ResourceManager.GetString("GroupId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Id sahəsi boş ola bilməz.
        /// </summary>
        internal static string IdRequired {
            get {
                return ResourceManager.GetString("IdRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Xidmət sahəsi boş ola bilməz.
        /// </summary>
        internal static string MaintenanceIdRequired {
            get {
                return ResourceManager.GetString("MaintenanceIdRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Simvol sayı düzgün deyil.
        /// </summary>
        internal static string MustBeProperLength {
            get {
                return ResourceManager.GetString("MustBeProperLength", resourceCulture);
            }
        }
    }
}