using System;
using Sources.BoundedContexts.Bullets.Implementation.Controllers;
using Sources.BoundedContexts.Bullets.Implementation.Domain;
using Sources.BoundedContexts.Bullets.Implementation.Presentation;
using Sources.BoundedContexts.MoveWithPhysics.Implementation.Factories;
using Sources.BoundedContexts.MoveWithPhysics.Implementation.Views;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Factories;
using UnityEngine;

namespace Sources.BoundedContexts.Bullets.Implementation.Factories
{
	public class BulletViewFactory
	{
		private readonly PhysicsTorqueViewFactory _torqueViewFactory;
		private readonly PhysicsMovementViewFactory<PhysicsMovementView> _movementViewFactory;
		private readonly BulletFactory _bulletFactory;

		public BulletViewFactory(PhysicsTorqueViewFactory torqueViewFactory,
			PhysicsMovementViewFactory<PhysicsMovementView> movementViewFactory,
			BulletFactory bulletFactory)
		{
			_torqueViewFactory = torqueViewFactory ?? throw new ArgumentNullException(nameof(torqueViewFactory));
			_movementViewFactory = movementViewFactory ?? throw new ArgumentNullException(nameof(movementViewFactory));
			_bulletFactory = bulletFactory ?? throw new ArgumentNullException(nameof(bulletFactory));
		}

		public BulletView Create(BulletView view, Vector3 position, Quaternion rotation, float speed)
		{
			Bullet model = _bulletFactory.Create(position, rotation, speed);
			BulletPresenter presenter = new BulletPresenter(model, view);
			view.Construct(presenter);

			//_torqueViewFactory.Create(model.Torque, view.TorqueView);
			_movementViewFactory.Create(model.Movement, view.MovementView);
			view.SetPosition(position);
			view.SetRotation(rotation);
			view.SetSpeed(speed);

			return view;
		}
	}
}