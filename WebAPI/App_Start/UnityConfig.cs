using System.Web.Http;
using Unity;
using Unity.WebApi;
using WebAPI.Repository;

namespace WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            //container.RegisterType<IContactRepository, ContactRepo>();
            container.RegisterType(typeof(IContactRepository<>), typeof(ContactRepo<>));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}