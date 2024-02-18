using System;
using Sources.BoundedContexts.Bullets.Implementation.Factories;
using Sources.BoundedContexts.Weapons.Implementation.Controllers;
using Sources.BoundedContexts.Weapons.Interfaces.Factories;
using Sources.BoundedContexts.Weapons.Interfaces.Weapons;
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

            WeaponPresenter presenter = _weaponPresenterFactory.Create(view);
            view.Construct(presenter);

            return view;
        }
    }
}