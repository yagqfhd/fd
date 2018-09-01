using FuDong.Common;
using GanGao.Data.Models.CheckOnWork;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Web;

namespace GanGao.Data.Configurations.CheckOnWork
{
    /// <summary>
    /// 调休工作时间安排
    /// </summary>
    public class AdjustWorkTimeConfiguration : EntityTypeConfiguration<AdjustWorkTimeEntity>, IEntityMapperDataBase
    {
        public AdjustWorkTimeConfiguration()
        {
            // 表名次定义
            this.ToTable("Sys_AdjustWorkTimes");
            //主键定义
            this.HasKey(m => m.Id);
            //索引定义
            this.HasIndex(m => m.Name);
            //属性定义
            this.Property(m => m.Id).HasMaxLength(64);
            this.Property(m => m.Name).HasMaxLength(16);
            this.Property(m => m.Description).HasMaxLength(128);
            //关系映射
            this.Property(m => m.StartTime).IsRequired();
            this.Property(m => m.EndTime).IsRequired();
            
        }

        public void RegistTo(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }
}