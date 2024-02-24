using System;
using System.ComponentModel;
using Sources.BoundedContexts.Torques.Interfaces.Domain;
using Sources.BoundedContexts.Torques.Interfaces.Services;
using Sources.BoundedContexts.Torques.Interfaces.Views;
using Sources.Common.Mvp.Implementation.Presenters;
using Sources.Common.StateMachines.Interfaces.Services;

namespace Sources.BoundedContexts.Torques.Implementation.Presenters
{
    public class SpaceshipPhysicsTorquePresenter : PresenterBase
    {
        private readonly IPhysicsTorque _model;
        private readonly IPhysicsTorqueView _view;
        private readonly IUpdateService _updateService;
        private readonly ITorqueService _torqueService;

        public SpaceshipPhysicsTorquePresenter(
            IPhysicsTorque model,
            IPhysicsTorqueView view,
            IUpdateService updateService,
            ITorqueService torqueService
        )
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _torqueService = torqueService ?? throw new ArgumentNullException(nameof(torqueService));
        }

        public override void Enable()
        {
            _updateService.Updated += OnUpdate;
            _model.PropertyChanged += OnModelPropertyChanged;
        }

        public override void Disable()
        {
            _model.PropertyChanged -= OnModelPropertyChanged;
            _updateService.Updated -= OnUpdate;
        }

        private void OnUpdate(float deltaTime)
        {
            //_torqueService.UpdateTorqueWithSlerp(_model, deltaTime);
        }

        private void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is not IPhysicsTorque torque)
                return;

            Action action = e.PropertyName switch
            {
                nameof(IPhysicsTorque.Rotation) => OnRotationChanged,
                _ => null
            };

            action?.Invoke();
        }
        
        

        private void OnRotationChanged() =>
            _view.SetRotation(_model.Rotation);
    }
}