using System;
using Sources.BoundedContexts.Bullets.Implementation.Factories;
using Sources.BoundedContexts.Spaceships.Implementation.Services;
using Sources.BoundedContexts.Weapons.Implementation.Domain.Models;
using Sources.BoundedContexts.Weapons.Implementation.Presenters;
using Sources.BoundedContexts.Weapons.Implementation.Views;
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

        public IWeaponView Create(Weapon model, WeaponView view, SpaceshipService spaceshipService)
        {
            WeaponPresenter presenter = _weaponPresenterFactory.Create(model, view, spaceshipService); // TODO: Replace Null
            view.Construct(presenter);

            return view;
        }
    }
}