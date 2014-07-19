using System.Reflection;
using Bocami.Practices.Query;
using Bocami.Practices.Query.Validation;
using SimpleInjector;
using SimpleInjector.Extensions;

namespace Bocami.Practices.SimpleInjector.Extensions
{
    public static class QueryValidationContainerExtensions
    {
        public static void RegisterQueryValidators(this Container container, params Assembly[] assemblies)
        {
            container.RegisterOpenGeneric(typeof(IQueryValidator<>), typeof(NullQueryValidator<>));
            container.RegisterManyForOpenGeneric(typeof(IQueryValidator<>), assemblies);
        }

        public static void RegisterAuthorizationQueryHandlerDecorator(this Container container, params Assembly[] assemblies)
        {
            container.RegisterDecorator(typeof(IQueryHandler<,>), typeof(ValidationQueryHandlerDecorator<,>));
        }
    }
}
