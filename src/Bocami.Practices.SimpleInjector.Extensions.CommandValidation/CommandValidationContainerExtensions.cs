using System.Reflection;
using Bocami.Practices.Command;
using Bocami.Practices.Command.Validation;
using SimpleInjector;
using SimpleInjector.Extensions;

namespace Bocami.Practices.SimpleInjector.Extensions
{
    public static class CommandValidationContainerExtensions
    {
        public static void RegisterCommandValidators(this Container container, params Assembly[] assemblies)
        {
            container.RegisterOpenGeneric(typeof(ICommandValidator<>), typeof(NullCommandValidator<>));
            container.RegisterManyForOpenGeneric(typeof(ICommandValidator<>), assemblies);
        }

        public static void RegisterValidationCommandHandlerDecorator(this Container container)
        {
            container.RegisterDecorator(typeof(ICommandHandler<>), typeof(ValidationCommandHandlerDecorator<>));
        }
    }
}
