using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web.Http;

namespace GanGao.OAuth
{
    /// <summary>
    /// MEF IOC 配置
    /// </summary>
    public class MefConfig
    {

        public static void RegisterMef(HttpConfiguration config)
        {
            AggregateCatalog aggregateCatalog = new AggregateCatalog();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine(path);
            var thisAssembly = new DirectoryCatalog(path, "*.dll");
            if (thisAssembly.Count() == 0)
            {
                path = path + "bin\\";
                Console.WriteLine(path);
                thisAssembly = new DirectoryCatalog(path, "*.dll");
            }
            aggregateCatalog.Catalogs.Add(thisAssembly);
            
            //DirectoryCatalog catalog = new DirectoryCatalog(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath);
            MefDependencySolver solver = new MefDependencySolver(aggregateCatalog);
            
            config.DependencyResolver = solver;
            
        }
    }
    
}