using Sources.BoundedContexts.Spaceships.Implementation.Services;
using Sources.BoundedContexts.Weapons.Implementation.Domain.Models;
using Sources.BoundedContexts.Weapons.Implementation.Views;
using Sources.BoundedContexts.Weapons.Interfaces.Views;

namespace Sources.BoundedContexts.Weapons.Interfaces.Factories
{
	public interface IWeaponViewFactory
	{
		IWeaponView Create(Weapon model, WeaponView view, SpaceshipService spaceshipService);
	}
}