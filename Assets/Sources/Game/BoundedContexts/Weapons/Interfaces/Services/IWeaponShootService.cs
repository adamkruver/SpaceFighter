using Sources.BoundedContexts.Movements.Interfaces.Domain;

namespace Sources.BoundedContexts.Weapons.Interfaces.Services
{
	public interface IWeaponShootService
	{
		void SetSpeed(IMovement movement, float delta);
	}
}