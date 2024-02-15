using Sources.Common.StateMachines.Interfaces.Handlers;

namespace Sources.Interfaces.Services.Scenes
{
    public interface ISceneService : IUpdateHandler, IFixedUpdateHandler, ILateUpdateHandler
    {
    }
}