using Sources.Game.Implementation.App.Core;
using UnityEngine;
using Zenject;

namespace Sources.MonoInstallers
{
    public class AppCoreMonoInstaller : MonoInstaller
    {
        [SerializeField] private AppCore _appCorePrefab;

        public override void InstallBindings()
        {
            Container.InstantiatePrefab(_appCorePrefab);
        }
    }
}