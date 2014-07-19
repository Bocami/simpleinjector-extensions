using System.Reflection;
using Bocami.Practices.Command;
using SimpleInjector;
using SimpleInjector.Extensions;

namespace Bocami.Practices.SimpleInjector.Extensions
{
    public static class CommandContainerExtensions
    {
        public static void RegisterCommandHandlers(this Container container, params Assembly[] assemblies)
        {
            container.RegisterOpenGeneric(typeof(ICommandHandler<>), typeof(NullCommandHandler<>));
            container.RegisterManyForOpenGeneric(typeof(ICommandHandler<>), assemblies);
        }
    }
}
