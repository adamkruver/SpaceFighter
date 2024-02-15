using Sources.Common.StateMachines.Interfaces.Contexts.Generic;

namespace Sources.Common.StateMachines.Implementation.Contexts.Generic
{
    public class Context<T> : IContext<T>
    {
        public T Value { get; set; }
    }
}