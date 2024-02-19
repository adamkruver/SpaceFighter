using System;
using Sources.BoundedContexts.Bullets.Implementation.Controllers;
using Sources.BoundedContexts.Bullets.Implementation.Domain;
using Sources.BoundedContexts.Bullets.Implementation.Presentation;
using Sources.BoundedContexts.MoveWithPhysics.Implementation.Factories;
using Sources.BoundedContexts.MoveWithPhysics.Implementation.Views;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Factories;
using Sources.Common.Mvp.Implememntation.Views;

namespace Sources.BoundedContexts.Bullets.Implementation.Factories
{
    public class BulletViewFactory
    {
        private readonly PhysicsTorqueViewFactory _torqueViewFactory;
        private readonly PhysicsMovementViewFactory<PhysicsMovementView> _movementViewFactory;

        public BulletViewFactory(
            PhysicsTorqueViewFactory torqueViewFactory,
            PhysicsMovementViewFactory<PhysicsMovementView> movementViewFactory
            )
        {
            _torqueViewFactory = torqueViewFactory ?? throw new ArgumentNullException(nameof(torqueViewFactory));
            _movementViewFactory = movementViewFactory ?? throw new ArgumentNullException(nameof(movementViewFactory));
        }

        public BulletView Create(Bullet model, BulletView view)
        {
            BulletPresenter presenter = new BulletPresenter(model, view);
            view.Construct(presenter);
            
            _torqueViewFactory.Create(model.Torque, view.TorqueView);
            _movementViewFactory.Create(model.Movement, view.MovementView);

            return view;
        }
    }
}