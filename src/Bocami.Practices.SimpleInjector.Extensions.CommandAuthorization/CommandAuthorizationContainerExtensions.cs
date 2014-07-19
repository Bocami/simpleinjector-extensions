using System.Reflection;
using Bocami.Practices.Command;
using Bocami.Practices.Command.Authorization;
using SimpleInjector;
using SimpleInjector.Extensions;

namespace Bocami.Practices.SimpleInjector.Extensions
{
    public static class CommandAuthorizationContainerExtensions
    {
        public static void RegisterCommandAuthorizers(this Container container, params Assembly[] assemblies)
        {
            container.RegisterOpenGeneric(typeof(ICommandAuthorizer<>), typeof(NullCommandAuthorizer<>));
            container.RegisterManyForOpenGeneric(typeof(ICommandAuthorizer<>), assemblies);
        }

        public static void RegisterAuthorizationCommandHandlerDecorator(this Container container, params Assembly[] assemblies)
        {
            container.RegisterDecorator(typeof(ICommandHandler<>), typeof(AuthorizationCommandHandlerDecorator<>));
        }
    }
}
