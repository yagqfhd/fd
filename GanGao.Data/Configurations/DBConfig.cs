using FuDong.Common;
using FuDong.DAL.UnitOfWorks;
using GanGao.Data.Models;
using GanGao.Data.Models.CheckOnWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace GanGao.Data.Configurations
{
    /// <summary>
    /// 数据库初始化操作类
    /// </summary>
    public static class DatabaseInitializer
    {

        /// <summary>
        /// 数据库初始化
        /// </summary>
        //导出私有方法(有参数)
        //[Export(typeof(Func<>))]
        public static void Initialize()
        {
            //if (Database.Exists("default")) return;
            //Database.SetInitializer<EFDbContext>(new DropAlwaysConfig());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFDbContext, DBConfig>());
        }
    }

    internal class DropAlwaysConfig : DropCreateDatabaseAlways<EFDbContext>
    {
        /// <summary>
        /// 密码校验生成对象
        /// </summary>
        [Import]
        IPasswordValidator _passwordValidator { get; set; }

        protected override void Seed(EFDbContext context)
        {
            var _defaultPassword = "123456";
            if (_passwordValidator != null)
                _defaultPassword = _passwordValidator.HashPassword("123456");
            #region /// 初始化角色
            List<RoleEntity> roles = new List<RoleEntity>
            {
                new RoleEntity{ Name = "系统管理", Description = "系统管理角色，拥有整个系统的管理权限。"},
                new RoleEntity{ Name = "校长", Description = "正校长"},
                new RoleEntity{ Name = "副校长", Description = "副校长"},
                new RoleEntity{ Name = "主任", Description = "正主任"},
                new RoleEntity{ Name = "副主任", Description = "副主任"},
                new RoleEntity{ Name = "班主任", Description = "带班教师"},
                new RoleEntity{ Name = "教师", Description = "任课教师"},
            };
            DbSet<RoleEntity> roleSet = context.Set<RoleEntity>();
            roleSet.AddOrUpdate(m => new { m.Name }, roles.ToArray());
            context.SaveChanges();

            var adminRole = roles.FirstOrDefault(d => d.Name == "系统管理");
            #endregion

            #region /// 初始化部门
            List<DepartmentEntity> departments = new List<DepartmentEntity>
            {
                new DepartmentEntity { Name = "甘泉高级中学" },
                new DepartmentEntity { Name = "办公室" },
                new DepartmentEntity { Name = "教务处" },
                new DepartmentEntity { Name = "德育处" },
                new DepartmentEntity { Name = "宣招办" },
                new DepartmentEntity { Name = "保卫科" },
                new DepartmentEntity { Name = "党办" },
                new DepartmentEntity { Name = "团委" },
                new DepartmentEntity { Name = "工会" },
                new DepartmentEntity { Name = "年级组(连亏)" },
                new DepartmentEntity { Name = "年级组(张宏斌)" },
                new DepartmentEntity { Name = "年级组(李志斌)" },
                new DepartmentEntity { Name = "总务处" }
            };
            var xxBm = departments.FirstOrDefault(d => d.Name == "甘泉高级中学");
            departments.FirstOrDefault(d => d.Name == "办公室").Parent = xxBm;
            departments.FirstOrDefault(d => d.Name == "总务处").Parent = xxBm;
            departments.FirstOrDefault(d => d.Name == "教务处").Parent = xxBm;
            departments.FirstOrDefault(d => d.Name == "德育处").Parent = xxBm;
            departments.FirstOrDefault(d => d.Name == "宣招办").Parent = xxBm;
            departments.FirstOrDefault(d => d.Name == "保卫科").Parent = xxBm;
            departments.FirstOrDefault(d => d.Name == "党办").Parent = xxBm;
            departments.FirstOrDefault(d => d.Name == "团委").Parent = xxBm;
            departments.FirstOrDefault(d => d.Name == "工会").Parent = xxBm;
            departments.FirstOrDefault(d => d.Name == "年级组(连亏)").Parent = xxBm;
            departments.FirstOrDefault(d => d.Name == "年级组(张宏斌)").Parent = xxBm;
            departments.FirstOrDefault(d => d.Name == "年级组(李志斌)").Parent = xxBm;

            DbSet<DepartmentEntity> departmentSet = context.Set<DepartmentEntity>();
            departmentSet.AddOrUpdate(m => new { m.Name }, departments.ToArray());
            context.SaveChanges();
            #endregion

            #region /// 初始化用户
            List<UserEntity> users = new List<UserEntity>
            {
                new UserEntity { Name = "admin",Email="admin@qq.com",Nick="管理员",TrueName="管理员",PasswordHash = _defaultPassword  },
                new UserEntity { Name = "fhd",Email="fhd@qq.com",Nick="无所谓",TrueName="付宏达",PasswordHash = _defaultPassword }
            };
            var admin = users.FirstOrDefault(d => d.Name == "admin");

            var adminUserDepartment = new UserDepartmentRelation
            {
                DepartmentId = xxBm.Id,
                UserId = admin.Id
            };
            adminUserDepartment.Roles.Add(new UserDepartmentRoleRelation
            {
                RoleId = adminRole.Id,
                UserId = admin.Id,
                DepartmentId = xxBm.Id
            });
            admin.Departments.Add(adminUserDepartment);

            DbSet<UserEntity> userSet = context.Set<UserEntity>();
            userSet.AddOrUpdate(m => new { m.Name }, users.ToArray());
            context.SaveChanges();

            #endregion

            #region ///////// 初始化工作时间
            List<WorkTimeEntity> workTimes = new List<WorkTimeEntity>()
            {
                new WorkTimeEntity { Name="上午签到" , StartTime = 420 , EndTime = 510 },
                new WorkTimeEntity {Name = "上午签离" , StartTime = 660, EndTime = 750 },
                new WorkTimeEntity { Name = "下午签到" , StartTime = 810, EndTime = 930 },
                new WorkTimeEntity { Name = "下午签离", StartTime = 990,EndTime = 1080  }
            };
            DbSet<WorkTimeEntity> workTimeSet = context.Set<WorkTimeEntity>();
            workTimeSet.AddOrUpdate(m => new { m.Name }, workTimes.ToArray());
            context.SaveChanges();
            #endregion


            // 初始化权限            
            Console.WriteLine("开始初始化权限");
            //var permissions = AutoCreatePermissions.GetPermissions("APIBaseController", "GanGao.WebAPI");
            //Console.WriteLine("获取权限数量:{0}", permissions.Count);
            //DbSet<SysPermission> permissionSet = context.Set<SysPermission>();
            //permissionSet.AddOrUpdate(m => new { m.Name }, permissions.ToArray());
            //try
            //{
            //    context.SaveChanges();
            //}
            //catch (DbEntityValidationException ex)
            //{
            //    ex.EntityValidationErrors.ToList().ForEach((err) => {
            //        err.ValidationErrors.ToList().ForEach((ve) => {
            //            Console.WriteLine("PropertyName:{0},Msg={1}", ve.PropertyName, ve.ErrorMessage);
            //        });
            //    });
            //}

        }
    }

    internal sealed class DBConfig : DbMigrationsConfiguration<EFDbContext>
    {
        string _defaultPassword = "123456";

        /// <summary>
        /// 密码校验生成对象
        /// </summary>
        [Import]
        IPasswordValidator _passwordValidator { get; set; } // = new DefaultPasswordValidator()

        public DBConfig()
        {

            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EFDbContext context)
        {
            if (_passwordValidator != null)
                _defaultPassword = _passwordValidator.HashPassword("123456");
            #region /// 初始化角色
            List<RoleEntity> roles = new List<RoleEntity>
            {
                new RoleEntity{ Name = "系统管理", Description = "系统管理角色，拥有整个系统的管理权限。"},
                new RoleEntity{ Name = "校长", Description = "正校长"},
                new RoleEntity{ Name = "副校长", Description = "副校长"},
                new RoleEntity{ Name = "主任", Description = "正主任"},
                new RoleEntity{ Name = "副主任", Description = "副主任"},
                new RoleEntity{ Name = "班主任", Description = "带班教师"},
                new RoleEntity{ Name = "教师", Description = "任课教师"},
            };
            DbSet<RoleEntity> roleSet = context.Set<RoleEntity>();
            roleSet.AddOrUpdate(m => new { m.Name }, roles.ToArray());
            context.SaveChanges();

            var adminRole = roles.FirstOrDefault(d => d.Name == "系统管理");
            #endregion

            #region /// 初始化部门
            List<DepartmentEntity> departments = new List<DepartmentEntity>
            {
                new DepartmentEntity { Name = "甘泉高级中学" },
                new DepartmentEntity { Name = "办公室" },
                new DepartmentEntity { Name = "教务处" },
                new DepartmentEntity { Name = "德育处" },
                new DepartmentEntity { Name = "宣招办" },
                new DepartmentEntity { Name = "保卫科" },
                new DepartmentEntity { Name = "党办" },
                new DepartmentEntity { Name = "团委" },
                new DepartmentEntity { Name = "工会" },
                new DepartmentEntity { Name = "年级组(连亏)" },
                new DepartmentEntity { Name = "年级组(张宏斌)" },
                new DepartmentEntity { Name = "年级组(李志斌)" },
                new DepartmentEntity { Name = "总务处" }
            };
            var xxBm = departments.FirstOrDefault(d => d.Name == "甘泉高级中学");
            departments.FirstOrDefault(d => d.Name == "办公室").Parent = xxBm;
            departments.FirstOrDefault(d => d.Name == "总务处").Parent = xxBm;
            departments.FirstOrDefault(d => d.Name == "教务处").Parent = xxBm;
            departments.FirstOrDefault(d => d.Name == "德育处").Parent = xxBm;
            departments.FirstOrDefault(d => d.Name == "宣招办").Parent = xxBm;
            departments.FirstOrDefault(d => d.Name == "保卫科").Parent = xxBm;
            departments.FirstOrDefault(d => d.Name == "党办").Parent = xxBm;
            departments.FirstOrDefault(d => d.Name == "团委").Parent = xxBm;
            departments.FirstOrDefault(d => d.Name == "工会").Parent = xxBm;
            departments.FirstOrDefault(d => d.Name == "年级组(连亏)").Parent = xxBm;
            departments.FirstOrDefault(d => d.Name == "年级组(张宏斌)").Parent = xxBm;
            departments.FirstOrDefault(d => d.Name == "年级组(李志斌)").Parent = xxBm;

            DbSet<DepartmentEntity> departmentSet = context.Set<DepartmentEntity>();
            departmentSet.AddOrUpdate(m => new { m.Name }, departments.ToArray());
            context.SaveChanges();
            #endregion

            #region /// 初始化用户
            List<UserEntity> users = new List<UserEntity>
            {
                new UserEntity { Name = "admin",Email="admin@qq.com",Nick="管理员",TrueName="管理员",PasswordHash = _defaultPassword  },
                new UserEntity { Name = "fhd",Email="fhd@qq.com",Nick="无所谓",TrueName="付宏达",PasswordHash = _defaultPassword }
            };
            var admin = users.FirstOrDefault(d => d.Name == "admin");

            var adminUserDepartment = new UserDepartmentRelation
            {
                DepartmentId = xxBm.Id,
                UserId = admin.Id
            };
            adminUserDepartment.Roles.Add(new UserDepartmentRoleRelation
            {
                RoleId = adminRole.Id,
                UserId = admin.Id,
                DepartmentId = xxBm.Id
            });
            admin.Departments.Add(adminUserDepartment);

            DbSet<UserEntity> userSet = context.Set<UserEntity>();
            userSet.AddOrUpdate(m => new { m.Name }, users.ToArray());
            context.SaveChanges();

            #endregion

            #region ///////// 初始化工作时间
            List<WorkTimeEntity> workTimes = new List<WorkTimeEntity>()
            {
                new WorkTimeEntity { Name="上午签到" , StartTime = 420 , EndTime = 510 },
                new WorkTimeEntity {Name = "上午签离" , StartTime = 660, EndTime = 750 },
                new WorkTimeEntity { Name = "下午签到" , StartTime = 810, EndTime = 930 },
                new WorkTimeEntity { Name = "下午签离", StartTime = 990,EndTime = 1080  }
            };
            DbSet<WorkTimeEntity> workTimeSet = context.Set<WorkTimeEntity>();
            workTimeSet.AddOrUpdate(m => new { m.Name }, workTimes.ToArray());
            context.SaveChanges();
            #endregion


            // 初始化权限            
            Console.WriteLine("开始初始化权限");
            //var permissions = AutoCreatePermissions.GetPermissions("APIBaseController", "GanGao.WebAPI");
            //Console.WriteLine("获取权限数量:{0}", permissions.Count);
            //DbSet<SysPermission> permissionSet = context.Set<SysPermission>();
            //permissionSet.AddOrUpdate(m => new { m.Name }, permissions.ToArray());
            //try
            //{
            //    context.SaveChanges();
            //}
            //catch (DbEntityValidationException ex)
            //{
            //    ex.EntityValidationErrors.ToList().ForEach((err) => {
            //        err.ValidationErrors.ToList().ForEach((ve) => {
            //            Console.WriteLine("PropertyName:{0},Msg={1}", ve.PropertyName, ve.ErrorMessage);
            //        });
            //    });
            //}

        }
    }

}