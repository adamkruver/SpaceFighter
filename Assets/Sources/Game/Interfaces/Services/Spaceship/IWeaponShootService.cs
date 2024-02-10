using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Domain;

namespace Sources.Interfaces.Services.Spaceship
{
	public interface IWeaponShootService
	{
		void SetSpeed(IPhysicsMovement physicsMovement, float delta);
	}
}