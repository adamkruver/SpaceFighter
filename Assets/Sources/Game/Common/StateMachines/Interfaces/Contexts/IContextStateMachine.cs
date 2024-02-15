namespace Sources.Common.StateMachines.Interfaces.Contexts
{
    public interface IContextStateMachine
    {
        void Run();
        void Stop();
        void Apply(IContext context);
    }
}