using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using BioscoopB3Web.Domain.Abstract;
using BioscoopB3Web.Domain.Concrete;
using BioscoopB3Web.Domain.Entities;

namespace BioscoopB3Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IHallMovieRepository>().To<EfHallMovieRepository>();
            kernel.Bind<IMovieRepository>().To<EfMovieRepository>();
            kernel.Bind<IAccountRepository>().To<EFAccountRepository>();
            kernel.Bind<IHallLayoutRepository>().To<EFHallLayoutRepository>();
            kernel.Bind<ITicketRepository>().To<EfTicketRepository>();
            kernel.Bind<IOrderRepository>().To<EFOrderRepository>();
            kernel.Bind<IHallRepository>().To<EFHallRepository>();
            kernel.Bind<ISurveyRepository>().To<EFSurveyRepository>();
            kernel.Bind<BioscoopModel>().ToConstant(new BioscoopModel());
        }
    }
}