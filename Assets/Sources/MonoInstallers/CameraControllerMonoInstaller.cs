using UniCtor.Installers;
using UniCtor.Services;
using UnityEngine;

namespace Sources.MonoInstallers
{
    public class CameraControllerMonoInstaller : MonoInstaller
    {
        [SerializeField] private CameraController _cameraController;
        
        public override void OnConfigure(IServiceCollection services)
        {
            services.RegisterAsScoped<CameraController>(_cameraController);
        }
    }
}