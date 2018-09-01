﻿using FuDong.Common;
using GanGao.Data.Models;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace GanGao.Data.Configurations
{
    /// <summary>
    /// 用户表配置类
    /// </summary>
    public class UserConfiguration : EntityTypeConfiguration<UserEntity>, IEntityMapperDataBase
    {
        public UserConfiguration()
        {
            // 表名次定义
            this.ToTable("Sys_Users");
            //主键定义
            this.HasKey(m => m.Id);
            //索引定义
            this.HasIndex(m => m.Name);
            this.HasIndex(m => m.Email);
            //属性定义
            this.Property(m => m.Id).HasMaxLength(64);
            //.HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(m => m.Name).HasMaxLength(16);
            this.Property(m => m.Email).HasMaxLength(128);
            this.Property(m => m.Description).HasMaxLength(128);
            this.Property(m => m.Nick).HasMaxLength(16);
            this.Property(m => m.TrueName).HasMaxLength(8);
            this.Property(m => m.IdCard).HasMaxLength(19);
            this.Property(m => m.WX).HasMaxLength(128);
            //关系映射
            this.HasMany(m => m.Departments).WithOptional().HasForeignKey(k => k.UserId);
        }

        public void RegistTo(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }

    /// <summary>
    /// 用户部门表配置类
    /// </summary>
    public class UserDepartmentConfiguration : EntityTypeConfiguration<UserDepartmentRelation>, IEntityMapperDataBase
    {
        public UserDepartmentConfiguration()
        {
            // 表名次定义
            this.ToTable("Sys_UserDepartments");
            
            //主键定义
            this.HasKey((UserDepartmentRelation m) => new { UserId = m.UserId, DepartmentId = m.DepartmentId });
            //索引定义
            this.HasIndex(m => m.UserId);
            this.HasIndex(m => m.DepartmentId);
            //属性定义
            this.Property(m => m.UserId).HasMaxLength(64);
            this.Property(m => m.DepartmentId).HasMaxLength(64);
            //关系映射
            //this.HasRequired(m=>m.u)
            this.HasMany(m => m.Roles).WithOptional().HasForeignKey( k => new { UserId = k.UserId, DepartmentId = k.DepartmentId});
            this.HasRequired(m => m.Department)
                .WithMany()
                .HasForeignKey(k => k.DepartmentId);
            //    .Map(m => m.MapKey("Department_Id"));

            //.Map(m => m.MapKey("Id"));//
        }

        public void RegistTo(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }

    /// <summary>
    /// 用户部门角色表配置类
    /// </summary>
    public class UserDepartmentRoleConfiguration : EntityTypeConfiguration<UserDepartmentRoleRelation>, IEntityMapperDataBase
    {
        public UserDepartmentRoleConfiguration()
        {
            // 表名次定义
            this.ToTable("Sys_UserDepartmentRoles");

            //主键定义
            this.HasKey((UserDepartmentRoleRelation m) => new { UserId = m.UserId, DepartmentId = m.DepartmentId, RoleId = m.RoleId});
            //索引定义
            this.HasIndex(m => m.UserId);
            this.HasIndex(m => m.DepartmentId);
            this.HasIndex(m => m.RoleId);
            //属性定义
            this.Property(m => m.UserId).HasMaxLength(64);
            this.Property(m => m.DepartmentId).HasMaxLength(64);
            this.Property(m => m.RoleId).HasMaxLength(64);
            //关系映射
            this.HasRequired(m => m.Role).WithMany().HasForeignKey(k => k.RoleId);

        }

        public void RegistTo(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }
}