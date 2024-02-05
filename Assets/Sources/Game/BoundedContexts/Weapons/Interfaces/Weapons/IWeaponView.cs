using Sources.BoundedContexts.Weapons.Implementation.Controllers;

namespace Sources.BoundedContexts.Weapons.Interfaces.Weapons
{
	public interface IWeaponView
	{
		void Construct(WeaponPresenter presenter);
	}
}