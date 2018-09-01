using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FuDong.DAL.UnitOfWorks
{
    public class EFDbContextDropCreateDatabaseIfModelChanges : DropCreateDatabaseIfModelChanges<EFDbContext>
    {

    }
}