using Sources.BoundedContexts.Movements.Interfaces.Domain;
using Sources.BoundedContexts.Weapons.Interfaces.Services;

namespace Sources.BoundedContexts.Weapons.Implementation.Domain.Services
{
	public class WeaponShootService : IWeaponShootService 
	{
		public void SetSpeed(IMovement movement, float delta) =>
			movement.Speed = movement.MaxSpeed;
	}
}