﻿using FuDong.Common;
using GanGao.Data.Models;
using GanGao.Data.Models.Work;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace GanGao.Data.Configurations.Work
{
    /// <summary>
    /// 角色表配置类
    /// </summary>
    public class WorkArrangementConfiguration : EntityTypeConfiguration<WorkArrangementEntity>, IEntityMapperDataBase
    {
        public WorkArrangementConfiguration()
        {
            // 表名次定义
            this.ToTable("Sys_WorkArrangements");
            //主键定义
            this.HasKey(m => m.Id);
            //索引定义
            this.HasIndex(m => m.Name);
            //属性定义
            this.Property(m => m.Id).HasMaxLength(64);
            this.Property(m => m.Name).HasMaxLength(16);
            this.Property(m => m.Description).HasMaxLength(128);
            //关系映射
            
            // 关系映射            
        }

        public void RegistTo(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }
}