using Sources.Game.BoundedContexts.PhysicsMovement.Implementation.Views;
using Sources.Game.BoundedContexts.PhysicsTorque.Implementation.Views;
using Sources.Game.Implementation.Controllers;
using Sources.Game.Interfaces.Presentation.Views;
using UnityEngine;

namespace Sources.Game.Implementation.Presentation.Views
{
    public class SpaceshipView : PresentableView<SpaceshipPresenter>, ISpaceshipView
    {
        [field: SerializeField] public PhysicsMovementView PhysicsMovementView { get; private set; }
        [field: SerializeField] public PhysicsTorqueView PhysicsTorqueView { get; private set; }
    }
}