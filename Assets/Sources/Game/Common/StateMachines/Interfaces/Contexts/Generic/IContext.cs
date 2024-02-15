namespace Sources.Common.StateMachines.Interfaces.Contexts.Generic
{
    public interface IContext<T> : IContext
    {
        T Value { get; }
    }
}