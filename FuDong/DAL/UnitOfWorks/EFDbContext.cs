using FuDong.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Globalization;
using System.Linq;
using System.Web;

namespace FuDong.DAL.UnitOfWorks
{
    /// <summary>
    ///     EF数据访问上下文
    /// </summary>
    [Export(typeof(DbContext))]
    public class EFDbContext : DbContext
    {
        static EFDbContext()
        {

        }
        public EFDbContext()
            : base("default") { }

        public EFDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString) { }

        [ImportMany]
        public IEnumerable<IEntityMapperDataBase> EntityMappers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            if (EntityMappers == null)
            {
                //return;
                throw new DataAccessException(string.Format(CultureInfo.CurrentCulture, Resources.EntityMappersIsZero));
            }

            foreach (var mapper in EntityMappers)
            {
                mapper.RegistTo(modelBuilder.Configurations);
            }


        }
    }
}