using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Domain;
using Sources.BoundedContexts.Weapons.Interfaces.Services;

namespace Sources.BoundedContexts.Weapons.Implementation.Domain.Services
{
	public class WeaponShootService : IWeaponShootService 
	{
		public void SetSpeed(IPhysicsMovement physicsMovement, float delta) =>
			physicsMovement.SetSpeed(physicsMovement.MaxSpeed);
	}
}