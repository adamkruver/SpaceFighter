using Sources.Common.StateMachines.Interfaces.Handlers;

namespace Sources.BoundedContexts.Scenes.Interfaces.Services
{
    public interface ISceneService : IUpdateHandler, IFixedUpdateHandler, ILateUpdateHandler
    {
    }
}