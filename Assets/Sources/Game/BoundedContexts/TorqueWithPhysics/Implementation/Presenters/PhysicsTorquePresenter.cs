using System;
using Sources.BoundedContexts.Common.Implememntation;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Domain;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Services;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Views;
using Sources.Interfaces.Services.Lifecycles;
using UnityEngine;

namespace Sources.BoundedContexts.TorqueWithPhysics.Implementation.Presenters
{
    public class PhysicsTorquePresenter : PresenterBase
    {
        private readonly IPhysicsTorque _torque;
        private readonly IPhysicsTorqueView _view;
        private readonly IUpdateService _updateService;
        private readonly ITorqueService _torqueService;

        public PhysicsTorquePresenter(
            IPhysicsTorque torque,
            IPhysicsTorqueView view,
            IUpdateService updateService,
            ITorqueService torqueService
        )
        {
            _torque = torque ?? throw new ArgumentNullException(nameof(torque));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _torqueService = torqueService ?? throw new ArgumentNullException(nameof(torqueService));
        }

        public override void Enable() =>
            _updateService.Updated += OnUpdate;

        public override void Disable() =>
            _updateService.Updated -= OnUpdate;

        private void OnUpdate(float deltaTime)
        {
            if (ZaglushkaSinglton.CanUse == false)
                return;
            
            _torqueService.UpdateTorque(_torque, deltaTime);
            _view.SetRotation(_torque.Rotation);
            Debug.Log("Senya");
        }
    }

    public static class ZaglushkaSinglton
    {
        public static bool CanUse { get; set; }
    }
}