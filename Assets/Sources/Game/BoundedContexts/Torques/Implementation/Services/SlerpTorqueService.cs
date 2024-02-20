using Sources.BoundedContexts.Torques.Interfaces.Domain;
using Sources.BoundedContexts.Torques.Interfaces.Services;
using UnityEngine;

namespace Sources.BoundedContexts.Torques.Implementation.Services
{
	public class SlerpTorqueService : ITorqueService
	{
		public void UpdateTorqueWithSlerp(IPhysicsTorque torque, float deltaTime)
		{
			torque.Rotation = Quaternion.Slerp(torque.Rotation,
				Quaternion.Euler(torque.Destination),
				deltaTime);
		}
	}
}