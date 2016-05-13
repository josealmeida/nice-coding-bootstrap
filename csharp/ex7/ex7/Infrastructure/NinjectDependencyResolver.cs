using Ninject;
using System;
using System.Collections.Generic;
using ex7.Models;
using System.Web.Mvc;

namespace ex7.Infrastructure
{
    public class NinjectDependencyResolver: IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver() {
            kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType) {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings() {
            kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            kernel.Bind<Discount.IDiscountHelper>().To<Discount.DefaultDiscountHelper>();
        }
    }
}