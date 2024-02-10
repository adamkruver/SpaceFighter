using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Domain;
using Sources.Interfaces.Services.Spaceship;

namespace Sources.Implementation.Services.Spaceships
{
	public class WeaponShootService : IWeaponShootService 
	{
		public void SetSpeed(IPhysicsMovement physicsMovement, float delta) =>
			physicsMovement.SetSpeed(physicsMovement.MaxSpeed);
	}
}