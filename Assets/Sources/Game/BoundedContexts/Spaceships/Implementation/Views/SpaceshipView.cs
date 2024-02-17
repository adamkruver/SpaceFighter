using Sources.BoundedContexts.MoveWithPhysics.Implementation.Views;
using Sources.BoundedContexts.Radars.Implementation.Presentation;
using Sources.BoundedContexts.Spaceships.Implementation.Presenters;
using Sources.BoundedContexts.Spaceships.Interfaces.Views;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Views;
using Sources.BoundedContexts.Weapons.Implementation.Presentation.Weapons;
using Sources.Common.Mvp.Implememntation.Views;
using UnityEngine;

namespace Sources.BoundedContexts.Spaceships.Implementation.Views
{
    public class SpaceshipView : PresentableView<SpaceshipPresenter>, ISpaceshipView
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        [field: SerializeField] public PhysicsMovementView PhysicsMovementView { get; private set; }
        [field: SerializeField] public PhysicsTorqueView PhysicsTorqueView { get; private set; }
        [field: SerializeField] public WeaponView WeaponView { get; private set; }
        
        [field: SerializeField] public RadarView RadarView { get; private set; }
          

        public void SetVelocity(Vector3 velocity) =>
            _rigidbody.velocity = velocity;
    }
}