using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Domain;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Domain;

namespace Sources.BoundedContexts.Bullets.Interfaces.Domain
{
	public interface IBullet
	{
		IPhysicsMovement PhysicsMovement { get; }

		IPhysicsTorque PhysicsTorque { get; }
	}
}