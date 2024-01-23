using Sources.Game.Interfaces.Infrastructure.Handlers;
using Sources.Game.Interfaces.Infrastructure.Scenes;

namespace Sources.Game.Interfaces.Services.SceneServices
{
	public interface ISceneService : IUpdateHandler, ISceneSwitcher
	{
		
	}
}