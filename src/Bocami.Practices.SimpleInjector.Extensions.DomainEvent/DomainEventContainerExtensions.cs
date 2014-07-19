using System.Reflection;
using Bocami.Practices.DomainEvent;
using SimpleInjector;
using SimpleInjector.Extensions;

namespace Bocami.Practices.SimpleInjector.Extensions
{
    public static class DomainEventContainerExtensions
    {
        public static void RegisterDomainEventHandlers(this Container container, params Assembly[] assemblies)
        {
            container.RegisterOpenGeneric(typeof(IDomainEventHandler<>), typeof(NullDomainEventHandler<>));
            container.RegisterManyForOpenGeneric(typeof(IDomainEventHandler<>), assemblies);
        }
    }
}
