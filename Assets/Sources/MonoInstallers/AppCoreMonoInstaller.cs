using Sources.Game.Implementation.App.Core;
using UnityEngine;
using Zenject;

public class AppCoreMonoInstaller : MonoInstaller
{
    [SerializeField] private AppCore _appCorePrefab;

    public override void InstallBindings()
    {
        Container.InstantiatePrefab(_appCorePrefab);
    }
}