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
    public class QdRecordConfiguration : EntityTypeConfiguration<QdRecordEntity>, IEntityMapperDataBase
    {
        public QdRecordConfiguration()
        {
            // 表名次定义
            this.ToTable("Sys_QdRecords");
            //主键定义
            this.HasKey(m => m.Id);
            //索引定义
            this.HasIndex(m => m.Name);
            //属性定义
            this.Property(m => m.Id).HasMaxLength(64);
            this.Property(m => m.Name).HasMaxLength(16);
            this.Property(m => m.Description).HasMaxLength(128);
            
        }

        public void RegistTo(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }
}