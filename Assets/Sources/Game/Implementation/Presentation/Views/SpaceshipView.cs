using Sources.BoundedContexts.PhysicsMovement.Implementation.Views;
using Sources.BoundedContexts.PhysicsTorque.Implementation.Views;
using Sources.Implementation.Controllers;
using Sources.Interfaces.Presentation.Views;
using UnityEngine;

namespace Sources.Implementation.Presentation.Views
{
    public class SpaceshipView : PresentableView<SpaceshipPresenter>, ISpaceshipView
    {
        [field: SerializeField] public PhysicsMovementView PhysicsMovementView { get; private set; }
        [field: SerializeField] public PhysicsTorqueView PhysicsTorqueView { get; private set; }
    }
}