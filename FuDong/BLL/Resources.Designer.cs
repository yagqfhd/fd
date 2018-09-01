﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace FuDong.BLL {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FD.BLL.Services.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   使用此强类型资源类，为所有资源查找
        ///   重写当前线程的 CurrentUICulture 属性。
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
        ///   查找类似 业务逻辑层异常：{0} 的本地化字符串。
        /// </summary>
        internal static string BusinessException {
            get {
                return ResourceManager.GetString("BusinessException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 名称:[{0}]的部门不存在。 的本地化字符串。
        /// </summary>
        internal static string DepartmentNotExist {
            get {
                return ResourceManager.GetString("DepartmentNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Email[{0}的用户不存在 的本地化字符串。
        /// </summary>
        internal static string EmailUserNotExist {
            get {
                return ResourceManager.GetString("EmailUserNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 实体[{0}]不存在 的本地化字符串。
        /// </summary>
        internal static string NoExist {
            get {
                return ResourceManager.GetString("NoExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 分页数据错误。最多{0}页，当前{1}页 的本地化字符串。
        /// </summary>
        internal static string PageError {
            get {
                return ResourceManager.GetString("PageError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 {0} 用户密码错误 的本地化字符串。
        /// </summary>
        internal static string PasswordError {
            get {
                return ResourceManager.GetString("PasswordError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 名称:[{0}]的角色不存在。 的本地化字符串。
        /// </summary>
        internal static string RoleNotExist {
            get {
                return ResourceManager.GetString("RoleNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 未知业务逻辑层异常，详情请查看日志信息。 的本地化字符串。
        /// </summary>
        internal static string UnknownBusinessException {
            get {
                return ResourceManager.GetString("UnknownBusinessException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 用户:[{0}]已经存在部门：[{1}]中。 的本地化字符串。
        /// </summary>
        internal static string UserInDepartment {
            get {
                return ResourceManager.GetString("UserInDepartment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 用户:[{0}]已经存在部门角色：[{1}=&gt;{2}]中。 的本地化字符串。
        /// </summary>
        internal static string UserInRole {
            get {
                return ResourceManager.GetString("UserInRole", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 [{0}] 用户不存在 的本地化字符串。
        /// </summary>
        internal static string UserNoExist {
            get {
                return ResourceManager.GetString("UserNoExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 用户:[{0}]不在部门：[{1}]中。 的本地化字符串。
        /// </summary>
        internal static string UserNotInDepartment {
            get {
                return ResourceManager.GetString("UserNotInDepartment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 用户:[{0}]不在部门角色：[{1}=&gt;{2}]中。 的本地化字符串。
        /// </summary>
        internal static string UserNotInRole {
            get {
                return ResourceManager.GetString("UserNotInRole", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 用户密码为空错误 的本地化字符串。
        /// </summary>
        internal static string UserPasswordNullError {
            get {
                return ResourceManager.GetString("UserPasswordNullError", resourceCulture);
            }
        }
    }
}