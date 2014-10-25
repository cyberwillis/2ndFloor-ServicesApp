using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using SecondFloor.Infrastructure.Repository;
using SecondFloor.Model;
using SecondFloor.RepositoryEF;
using SecondFloor.RepositoryEF.Repositories;
using SecondFloor.Service;
using SecondFloor.ServiceContracts;
using SecondFloor.Web.Mvc.Controllers;
using SecondFloor.Web.Mvc.Models;

namespace SecondFloor.Web.Mvc.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            container.RegisterType<IAnuncianteService, AnuncianteService>();
            container.RegisterType<IEnderecoService, EnderecoService>();
            container.RegisterType<IEstadoService, EstadoService>();
            container.RegisterType<IProdutoService, ProdutoService>();
            container.RegisterType<IAnuncioService, AnuncioService>();
            container.RegisterType<IUsuarioService, UsuarioService>();

            container.RegisterType<IAnuncianteRepository, AnuncianteRepository>();
            container.RegisterType<IEnderecoRepository, EnderecoRepository>();
            container.RegisterType<IEstadoRepository, EstadoRepository>();
            container.RegisterType<IProdutoRepository, ProdutoRepository>();
            container.RegisterType<IAnuncioRepository, AnuncioRepository>();
            container.RegisterType<IUsuarioRepository, UsuarioRepository>();

            container.RegisterType<AccountController>(new InjectionConstructor(container.Resolve<IUsuarioService>()));

            //container.RegisterType<ApplicationSignInManager>(new HierarchicalLifetimeManager());
            //container.RegisterType<ApplicationUserManager>(new HierarchicalLifetimeManager());
            //container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            //container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            
            //container.RegisterType<RolesAdminController>(new InjectionConstructor());
            //container.RegisterType<ManageController>(new InjectionConstructor());
            //container.RegisterType<UsersAdminController>(new InjectionConstructor());
            

            //container.RegisterType<IUserStore<ApplicationUser>>(new HierarchicalLifetimeManager());

            //The current type, Microsoft.AspNet.Identity.IUserStore`1[SecondFloor.Web.Mvc.Models.ApplicationUser], 
            //is an interface and cannot be constructed. Are you missing a type mapping? 

            //container.RegisterType<IUserStore<ApplicationUser>, ApplicationSignInManager>();

            //container.RegisterType<IUnitOfWork, EFUnitOfWork<Anunciante>>();
        }
    }
}
