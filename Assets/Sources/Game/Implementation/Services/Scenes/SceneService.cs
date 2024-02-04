﻿using System;
using Sources.Implementation.Infrastructure.StateMachines;
using Sources.Implementation.Infrastructure.StateMachines.Decorators;
using Sources.Implementation.Services.Lifecycles;
using Sources.Interfaces.Infrastructure.Handlers;
using Sources.Interfaces.Infrastructure.Scenes;
using Sources.Interfaces.Infrastructure.StateMachine.Factories;
using Sources.Interfaces.Services.Scenes;
using UniCtor.Contexts;
using UnityEngine.SceneManagement;

namespace Sources.Implementation.Services.Scenes
{
    public class SceneService : ISceneService, ISceneSwitcher, ISceneConstructor
    {
        private readonly ISceneFactoryProvider _sceneFactoryProvider;
        private readonly StateMachine<IScene> _stateMachine;
        private readonly IFixedUpdateHandler _fixedUpdateHandler;
        private readonly IUpdateHandler _updateHandler;
        private readonly ILateUpdateHandler _lateUpdateHandler;

        public SceneService(ISceneFactoryProvider sceneFactoryProvider)
        {
            _sceneFactoryProvider =
                sceneFactoryProvider ?? throw new ArgumentNullException(nameof(sceneFactoryProvider));
            _stateMachine = new StateMachine<IScene>();

            _updateHandler = new StateMachineUpdatable<IScene>(_stateMachine);
            _fixedUpdateHandler = new StateMachineFixedUpdatable<IScene>(_stateMachine);
            _lateUpdateHandler = new StateMachineLateUpdatable<IScene>(_stateMachine);
        }

        public void Update(float deltaTime) =>
            _updateHandler.Update(deltaTime);

        public void UpdateFixed(float deltaTime) => 
            _fixedUpdateHandler.UpdateFixed(deltaTime);

        public void UpdateLate(float deltaTime) => 
            _lateUpdateHandler.UpdateLate(deltaTime);

        public void Change(string sceneName) => 
            SceneManager.LoadScene(sceneName);

        public void ConstructScene(ISceneContext sceneContext)
        {
            ISceneFactory factory = _sceneFactoryProvider.GetFactory(SceneManager.GetActiveScene().name, sceneContext);
            IScene state = factory.Create(this);
            _stateMachine.Change(state);
        }
    }
}