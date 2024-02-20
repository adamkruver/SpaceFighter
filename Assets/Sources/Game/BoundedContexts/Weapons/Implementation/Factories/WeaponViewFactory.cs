using System;
using Sources.BoundedContexts.Bullets.Implementation.Factories;
using Sources.BoundedContexts.Weapons.Implementation.Presenters;
using Sources.BoundedContexts.Weapons.Interfaces.Factories;
using Sources.BoundedContexts.Weapons.Interfaces.Views;
using Sources.Common.Mvp.Interfaces.Views;

namespace Sources.BoundedContexts.Weapons.Implementation.Factories
{
    public class WeaponViewFactory : IWeaponViewFactory
    {
        private readonly WeaponPresenterFactory _weaponPresenterFactory;

        public WeaponViewFactory(WeaponPresenterFactory weaponPresenterFactory)
        {
            _weaponPresenterFactory =
                weaponPresenterFactory ?? throw new ArgumentNullException(nameof(weaponPresenterFactory));
        }

        public IWeaponView Create<T>(T view) where T : IPresentableView<WeaponPresenter>, IWeaponView
        {
            BulletViewFactory bulletViewFactory = null;

            WeaponPresenter presenter = _weaponPresenterFactory.Create(null, view); // TODO: Replace Null
            view.Construct(presenter);

            return view;
        }
    }
}