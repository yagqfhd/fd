using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Web.Http.Dependencies;

namespace GanGao.OAuth
{
    /// <summary>
    /// MEF IOC
    /// </summary>
    public class MefDependencySolver : IDependencyResolver
    {
        private readonly ComposablePartCatalog _catalog;
        private const string MefContainerKey = "GanGao_MefContainerKey";

        private static CompositionContainer _container = null;
        /// <summary>
        /// MefDependencySolver
        /// </summary>
        /// <param name="catalog"></param>
        public MefDependencySolver(ComposablePartCatalog catalog)
        {
            _catalog = catalog;
        }

        /// <summary>
        /// Container
        /// </summary>
        public CompositionContainer Container
        {
            get
            {
                //if (!HttpContext.Current.Items.Contains(MefContainerKey))
                //{
                //    HttpContext.Current.Items.Add(MefContainerKey, new CompositionContainer(_catalog));
                //}
                //CompositionContainer container = (CompositionContainer)HttpContext.Current.Items[MefContainerKey];
                //HttpContext.Current.Application["Container"] = container;
                if(_container==null)
                    _container = new CompositionContainer(_catalog, CompositionOptions.Default);
                return _container;
            }
        }

        #region IDependencyResolver Members

        /// <summary>
        /// GetService
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            string contractName = AttributedModelServices.GetContractName(serviceType);
            return Container.GetExportedValueOrDefault<object>(contractName);
        }

        /// <summary>
        /// GetServices
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
        }

        /// <summary>
        /// BeginScope
        /// </summary>
        /// <returns></returns>
        public IDependencyScope BeginScope()
        {
            return new MefDependencySolver(_catalog);
        }

        #endregion

        public void Dispose()
        {
            //ToDo
        }
    }
}