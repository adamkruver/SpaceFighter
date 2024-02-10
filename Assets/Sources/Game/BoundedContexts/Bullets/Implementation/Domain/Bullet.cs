using Sources.BoundedContexts.Bullets.Interfaces.Domain;
using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Domain;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Domain;

namespace Sources.BoundedContexts.Bullets.Implementation.Domain
{
	public class Bullet : IBullet
	{
		public Bullet(IPhysicsMovement physicsMovement, IPhysicsTorque physicsTorque)
		{
			PhysicsMovement = physicsMovement;
			PhysicsTorque = physicsTorque;
		}

		public IPhysicsMovement PhysicsMovement { get; }

		public IPhysicsTorque PhysicsTorque { get; }
	}
}