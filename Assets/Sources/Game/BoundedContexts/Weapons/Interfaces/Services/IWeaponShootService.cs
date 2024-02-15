using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Domain;

namespace Sources.BoundedContexts.Weapons.Interfaces.Services
{
	public interface IWeaponShootService
	{
		void SetSpeed(IPhysicsMovement physicsMovement, float delta);
	}
}