using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Domain;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Services;
using UnityEngine;

namespace Sources.BoundedContexts.TorqueWithPhysics.Implementation.Services
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