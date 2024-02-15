using Sources.Common.StateMachines.Implementation.Contexts.Generic;
using Sources.Common.StateMachines.Interfaces.Contexts;
using Sources.Common.StateMachines.Interfaces.Contexts.Generic;

namespace Sources.Common.StateMachines.Implementation.Contexts
{
    public class Context : IContext
    {
        private Context()
        {
        }

        public static IContext<T> Create<T>(T value) =>
            new Context<T>()
            {
                Value = value
            };
    }
}