using System;
using Sources.App.Core;
using Sources.Interfaces.Services.Scenes;
using UniCtor.Attributes;
using UniCtor.Contexts;
using UnityEngine;

namespace Sources.App
{
    [DefaultExecutionOrder(-1)]
    public class Bootstrapper : MonoBehaviour
    {
        private ISceneContext _sceneContext;

        private void Awake()
        {
            var appCore = FindObjectOfType<AppCore>() ?? new AppCoreFactory().Create(_sceneContext);
        }

        [Constructor]
        private void Construct(ISceneContext sceneContext, ISceneConstructor sceneConstructor)
        {
            _sceneContext = sceneContext ?? throw new ArgumentNullException(nameof(sceneContext));

            if (sceneConstructor == null)
                throw new ArgumentNullException(nameof(sceneConstructor));

            sceneConstructor.ConstructScene(sceneContext);
        }
    }
}