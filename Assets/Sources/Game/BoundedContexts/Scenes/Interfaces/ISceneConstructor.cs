using UniCtor.Contexts;

namespace Sources.BoundedContexts.Scenes.Interfaces
{
    public interface ISceneConstructor
    {
        void ConstructScene(ISceneContext sceneContext);
    }
}