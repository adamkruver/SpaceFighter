using Sources.Interfaces.Infrastructure.Scenes;

namespace Sources.Interfaces.Infrastructure.StateMachine.Factories
{
	public interface ISceneFactory
	{
		public IScene Create(ISceneSwitcher sceneSwitcher);
	}
}