using System.Reflection;
using Bocami.Practices.Query;
using Bocami.Practices.Query.Authorization;
using SimpleInjector;
using SimpleInjector.Extensions;

namespace Bocami.Practices.SimpleInjector.Extensions
{
    public static class QueryAuthorizationContainerExtensions
    {
        public static void RegisterQueryAuthorizers(this Container container, params Assembly[] assemblies)
        {
            container.RegisterOpenGeneric(typeof(IQueryAuthorizer<>), typeof(NullQueryAuthorizer<>));
            container.RegisterManyForOpenGeneric(typeof(IQueryAuthorizer<>), assemblies);
        }

        public static void RegisterAuthorizationQueryHandlerDecorator(this Container container)
        {
            container.RegisterDecorator(typeof(IQueryHandler<,>), typeof(AuthorizationQueryHandlerDecorator<,>));
        }
    }
}
