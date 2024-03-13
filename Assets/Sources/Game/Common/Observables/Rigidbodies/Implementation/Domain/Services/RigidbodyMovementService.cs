using Sources.Common.Observables.Interfaces.Rigidbodies;
using UnityEngine;

namespace Sources.Common.Observables.Rigidbodies.Implementation.Domain.Services
{
	public class RigidbodyMovementService
	{
		public void CalculateSpeed(IObservableRigidbody rigidbody, float target, float deltaTime) =>
			rigidbody.Speed = Mathf.MoveTowards(rigidbody.Speed,  target, deltaTime * 35);
		
		public void Rotate(IObservableRigidbody rigidbody, Quaternion destination, float deltaTime)
		{
			rigidbody.Rotation = Quaternion.Lerp(rigidbody.Rotation,
				destination,
				deltaTime);
		}
	}
}