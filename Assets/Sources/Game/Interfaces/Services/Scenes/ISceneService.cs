using Sources.Implementation.Services.Lifecycles;
using Sources.Interfaces.Infrastructure.Handlers;

namespace Sources.Interfaces.Services.Scenes
{
    public interface ISceneService : IUpdateHandler, IFixedUpdateHandler, ILateUpdateHandler
    {
    }
}