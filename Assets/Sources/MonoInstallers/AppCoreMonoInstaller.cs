using System.ComponentModel;
using Sources.Game.Implementation.App.Core;
using UniCtor.Installers;
using UniCtor.Services;
using UnityEngine;

namespace Sources.MonoInstallers
{
    public class AppCoreMonoInstaller : MonoInstaller
    {
        [SerializeField] private AppCore _appCorePrefab;


        public override void OnConfigure(IServiceCollection services)
        {
            Instantiate(_appCorePrefab);
        }
    }
}