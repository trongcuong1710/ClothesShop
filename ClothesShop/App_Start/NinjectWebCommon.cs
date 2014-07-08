[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ClothesShop.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ClothesShop.App_Start.NinjectWebCommon), "Stop")]

namespace ClothesShop.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using ClothesShop.Repository.Interface;
    using ClothesShop.Repository;
    using System.Reflection;
    using ClothesShop.Services.Interface;
    using ClothesShop.Services;

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

                //bind category repository
                kernel.Bind<ICategoryRepository>().To<CategoryRepository>();

                //bind news repository
                kernel.Bind<INewsRepository>().To<NewsRepository>();

                //bind product repository
                kernel.Bind<IProductRepository>().To<ProductRepository>();

                //bind promotion repository
                kernel.Bind<IPromotionRepository>().To<PromotionRepository>();

                //bind user repository
                kernel.Bind<IUserRepository>().To<UserRepository>();

                //bind category service
                kernel.Bind<ICategoryService>().To<CategoryService>();

                //bind news Service
                kernel.Bind<INewsService>().To<NewsService>();

                //bind product Service
                kernel.Bind<IProductService>().To<ProductService>();

                //bind promotion Service
                kernel.Bind<IPromotionService>().To<PromotionService>();

                //bind user Service
                kernel.Bind<IUserService>().To<UserService>();

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
            try
            {
                kernel.Load(Assembly.GetExecutingAssembly());
            }
            catch (Exception)
            {                
                throw;
            }
        }        
    }
}
