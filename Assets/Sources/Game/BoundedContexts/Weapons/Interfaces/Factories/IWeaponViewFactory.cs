using Sources.BoundedContexts.Weapons.Implementation.Presenters;
using Sources.BoundedContexts.Weapons.Interfaces.Views;
using Sources.Common.Mvp.Interfaces.Views;

namespace Sources.BoundedContexts.Weapons.Interfaces.Factories
{
	public interface IWeaponViewFactory
	{
		IWeaponView Create<T>(T view) where T : IPresentableView<WeaponPresenter>, IWeaponView;
	}
}