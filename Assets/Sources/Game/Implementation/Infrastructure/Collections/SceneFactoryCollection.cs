using System;
using System.Collections.Generic;
using Sources.Implementation.Controllers.Scenes;
using Sources.Implementation.Infrastructure.Factories.Scenes;
using Sources.Interfaces.Infrastructure.Scenes;
using Sources.Interfaces.Infrastructure.StateMachine.Factories;
using UniCtor.Builders;
using UniCtor.Contexts;

namespace Sources.Implementation.Infrastructure.Collections
{
    public class SceneFactoryCollection : ISceneFactoryProvider
    {
        private readonly Dictionary<string, Func<IDependencyResolver, ISceneFactory>> _sceneFactories;

        public SceneFactoryCollection()
        {
            _sceneFactories = new Dictionary<string, Func<IDependencyResolver, ISceneFactory>>()
            {
                [nameof(GameplayScene)] = ResolveFactory<GameplaySceneFactory>
            };
        }

        public ISceneFactory GetFactory(string sceneName, ISceneContext sceneContext)
        {
            if (sceneContext == null)
                throw new ArgumentNullException(nameof(sceneContext));

            if (string.IsNullOrWhiteSpace(sceneName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(sceneName));

            if (_sceneFactories.ContainsKey(sceneName) == false)
                throw new InvalidOperationException(sceneName);

            return _sceneFactories[sceneName](sceneContext.DependencyResolver);
        }

        private ISceneFactory ResolveFactory<T>(IDependencyResolver resolver) where T : class, ISceneFactory =>
            resolver.Resolve<T>();
    }
}