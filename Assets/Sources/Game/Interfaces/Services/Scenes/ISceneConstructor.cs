using UniCtor.Contexts;

namespace Sources.Interfaces.Services.Scenes
{
    public interface ISceneConstructor
    {
        void ConstructScene(ISceneContext sceneContext);
    }
}