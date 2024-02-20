using Sources.Common.Observables.Interfaces.Rigidbodies;
using UnityEngine;

namespace Sources.Common.Observables.Rigidbodies.Implementation.Domain.Services
{
	public class RigidbodyMovementService
	{
		public void CalculateSpeed(IObservableRigidbody rigidbody, float acceleration, float deltaTime) =>
			rigidbody.Speed = Mathf.MoveTowards(rigidbody.Speed, rigidbody.Speed + acceleration, deltaTime);
		
		public void Rotate(IObservableRigidbody rigidbody, Vector3 destination, float deltaTime)
		{
			rigidbody.Rotation = Quaternion.Lerp(rigidbody.Rotation,
				Quaternion.Euler(destination),
				deltaTime);
		}
	}
}