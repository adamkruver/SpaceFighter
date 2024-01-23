using Sources.Game.Implementation.Services.SceneServices;
using Sources.Game.Interfaces.Infrastructure.Scenes;

namespace Sources.Game.Interfaces.Infrastructure.StateMachine.Factories
{
	public interface ISceneFactory
	{
		public IScene Create(ISceneSwitcher sceneSwitcher);
	}
}