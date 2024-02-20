using System;
using Sources.Common.Observables.Rigidbodies.Implementation.Models;

namespace Sources.BoundedContexts.Spaceships.Implementation.Services
{
	public class SpaceshipService
	{
		private readonly ObservableRigidbody _rigidbody;

		public SpaceshipService(ObservableRigidbody rigidbody) =>
			_rigidbody = rigidbody ?? throw new ArgumentNullException(nameof(rigidbody));

		public float Speed => _rigidbody.Speed;
	}
}