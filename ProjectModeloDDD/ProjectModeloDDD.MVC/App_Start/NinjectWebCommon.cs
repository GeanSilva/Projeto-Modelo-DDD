using ProjectModelo.Infra.Repositorios;
using ProjectModeloDDD.Domain.Interfaces.Repositorio;
using ProjectModeloDDD.Domain.Interfaces.Servicos;
using ProjectModeloDDD.Domain.Servicos;
using ProjetcModelo.Aplication;
using ProjetcModelo.Aplication.Interface;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ProjectModeloDDD.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ProjectModeloDDD.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace ProjectModeloDDD.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IServicoAplicacaoBase<>)).To(typeof(ServicoAplicacao<>));
            kernel.Bind(typeof(IClienteAplicacaoServico)).To<ClienteAplicacaoServico>();
            kernel.Bind(typeof(IProdutoAplicacaoServico)).To<ProdutoAplicacaoServico>();

            kernel.Bind(typeof(IServicosBase<>)).To(typeof(ServicoBase<>));
            kernel.Bind(typeof(IClienteServico)).To<ClienteServico>();
            kernel.Bind(typeof(IProdutoServico)).To<ProdutoSevico>();

            kernel.Bind(typeof(IRepositorio<>)).To(typeof(Repositorio<>));
            kernel.Bind(typeof(IClienteRepositorio)).To<ClienteRepositorio>();
            kernel.Bind(typeof(IProdutoRepositorio)).To<ProdutoRepositorio>();


        }        
    }
}
