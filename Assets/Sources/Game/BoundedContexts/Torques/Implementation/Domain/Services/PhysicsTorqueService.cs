using Sources.BoundedContexts.Spaceships.Implementation.Domain.Models;
using UnityEngine;

namespace Sources.BoundedContexts.Torques.Implementation.Domain.Services
{
	public class PhysicsTorqueService
	{
		public void AddTorque(Spaceship spaceship, float rotationX, float rotationY)
		{
			spaceship.Destination += new Vector3(-rotationY, rotationX, 0);
		}

		public void Rotate(Spaceship spaceship, float delta)
		{
			spaceship.Rotation = Quaternion.Lerp(spaceship.Rotation,
				Quaternion.Euler(spaceship.Destination),
				delta);
		}
		
		// TODO брать относительные координаты для spaceship.Rotation * spaceship.Destination
	}
}