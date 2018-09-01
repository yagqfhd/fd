﻿using FuDong.Common;
using GanGao.Data.Models;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace GanGao.Data.Configurations
{
    /// <summary>
    /// 部门表配置类
    /// </summary>
    public class DepartmentConfiguration : EntityTypeConfiguration<DepartmentEntity>, IEntityMapperDataBase
    {
        public DepartmentConfiguration()
        {
            // 表名次定义
            this.ToTable("Sys_Departments");
            //主键定义
            this.HasKey(m => m.Id);
            //索引定义
            this.HasIndex(m => m.Name);
            //属性定义
            this.Property(m => m.Id).HasMaxLength(64);
            this.Property(m => m.Name).HasMaxLength(16);
            this.Property(m => m.Description).HasMaxLength(128);
            //关系映射
            // 部门无关系映射      
            this.HasMany(m => m.Childs).WithOptional(k => k.Parent);      
        }

        public void RegistTo(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }
}