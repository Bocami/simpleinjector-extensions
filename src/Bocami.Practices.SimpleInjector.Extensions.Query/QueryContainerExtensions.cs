using System.Reflection;
using Bocami.Practices.Query;
using SimpleInjector;
using SimpleInjector.Extensions;

namespace Bocami.Practices.SimpleInjector.Extensions
{
    public static class QueryContainerExtensions
    {
        public static void RegisterQueryHandlers(this Container container, params Assembly[] assemblies)
        {
            container.RegisterOpenGeneric(typeof(IQueryHandler<,>), typeof(NullQueryHandler<,>));
            container.RegisterManyForOpenGeneric(typeof(IQueryHandler<,>), assemblies);
        }
    }
}