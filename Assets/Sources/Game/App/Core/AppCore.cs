﻿using System;
using Sources.BoundedContexts.Scenes.Interfaces;
using Sources.BoundedContexts.Scenes.Interfaces.Services;
using Sources.Common.StateMachines.Interfaces.Services;
using UniCtor.Attributes;
using UnityEngine;

namespace Sources.App.Core
{
    public class AppCore : MonoBehaviour
    {
        private ISceneService _sceneService;

        private void Awake() => 
            DontDestroyOnLoad(this);

        private void Update() => 
            _sceneService?.Update(Time.deltaTime);
        
        private void FixedUpdate() => 
            _sceneService?.UpdateFixed(Time.fixedDeltaTime);
        
        private void LateUpdate() => 
            _sceneService?.UpdateLate(Time.deltaTime);

        [Constructor]
        private void Construct(ISceneService sceneService) => 
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
    }
}