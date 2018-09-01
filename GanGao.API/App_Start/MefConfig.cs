using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace GanGao.API
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

    


    ///// <summary>
    ///// MEF IOC
    ///// </summary>
    //public class MefDependencySolver : IDependencyResolver
    //{
    //    public MefDependencySolver()//(ComposablePartCatalog catalog)
    //    {
    //    }
    //    /// <summary>
    //    /// Container
    //    /// </summary>
    //    public CompositionContainer Container
    //    {
    //        get
    //        {
    //            return RegisgterMEF.regisgter();
    //        }
    //    }

    //    #region IDependencyResolver Members

    //    /// <summary>
    //    /// GetService
    //    /// </summary>
    //    /// <param name="serviceType"></param>
    //    /// <returns></returns>
    //    public object GetService(Type serviceType)
    //    {
    //        string contractName = AttributedModelServices.GetContractName(serviceType);
    //        Console.WriteLine("Name:{0}", contractName);
    //        var result = Container.GetExportedValueOrDefault<object>(contractName);
    //        return result;
    //    }

    //    /// <summary>
    //    /// GetServices
    //    /// </summary>
    //    /// <param name="serviceType"></param>
    //    /// <returns></returns>
    //    public IEnumerable<object> GetServices(Type serviceType)
    //    {
    //        var contractName = AttributedModelServices.GetContractName(serviceType);
    //        var result = Container.GetExportedValues<object>(contractName);
    //        return result;
    //    }

    //    /// <summary>
    //    /// BeginScope
    //    /// </summary>
    //    /// <returns></returns>
    //    public IDependencyScope BeginScope()
    //    {
    //        return this;
    //    }

    //    #endregion

    //    public void Dispose()
    //    {
    //        GC.SuppressFinalize(this);
    //    }
    //}

    public class RegisgterMEF
    {
        private static object obj = new object();
        private static CompositionContainer _container;
        public static CompositionContainer regisgter()
        {
            lock (obj)
            {
                try
                {
                    if (_container != null)
                    {
                        return _container;
                    }
                    AggregateCatalog aggregateCatalog = new AggregateCatalog();
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    var thisAssembly = new DirectoryCatalog(path, "*.dll");
                    if (thisAssembly.Count() == 0)
                    {
                        path = path + "bin\\";
                        thisAssembly = new DirectoryCatalog(path, "*.dll");
                    }
                    aggregateCatalog.Catalogs.Add(thisAssembly);
                    _container = new CompositionContainer(aggregateCatalog, CompositionOptions.DisableSilentRejection);
                    return _container;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("错误：{0}", ex.Message);
                    return null;
                }
            }
        }
    }
}