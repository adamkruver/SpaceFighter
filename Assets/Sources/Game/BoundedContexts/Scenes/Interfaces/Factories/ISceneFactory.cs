namespace Sources.BoundedContexts.Scenes.Interfaces.Factories
{
	public interface ISceneFactory
	{
		public IScene Create(ISceneSwitcher sceneSwitcher);
	}
}