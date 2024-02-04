using UniCtor.Contexts;
using UnityEngine;

namespace Sources.Implementation.App.Core
{
    public class AppCoreFactory
    {
        public AppCore Create(ISceneContext sceneContext)
        {
            var appCore = new GameObject(nameof(AppCore))
                .AddComponent<AppCore>();
            
            sceneContext.DependencyResolver.Resolve(appCore.gameObject);

            return appCore;
        }
    }
}