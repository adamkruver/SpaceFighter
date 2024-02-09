using Sources.BoundedContexts.PhysicsTorque.Interfaces.Domain;
using Sources.BoundedContexts.PhysicsTorque.Interfaces.Services;
using UnityEngine;

namespace Sources.BoundedContexts.PhysicsTorque.Implementation.Services
{
	public class SlerpTorqueService : ITorqueService
	{
		public void UpdateTorque(IPhysicsTorque torque, float deltaTime)
		{
			torque.Rotation = Quaternion.Slerp(torque.Rotation,
				Quaternion.Euler(torque.Destination),
				deltaTime);
		}
	}
}