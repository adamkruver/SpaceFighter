using System;
using Sources.BoundedContexts.Bullets.Implementation.Services;
using Sources.BoundedContexts.Weapons.Implementation.Domain.Models;
using Sources.BoundedContexts.Weapons.Implementation.Presenters;
using Sources.BoundedContexts.Weapons.Interfaces.Views;

namespace Sources.BoundedContexts.Weapons.Implementation.Factories
{
    public class WeaponPresenterFactory
    {
        private readonly BulletService _bulletService;

        public WeaponPresenterFactory(BulletService bulletService) => 
            _bulletService = bulletService ?? throw new ArgumentNullException(nameof(bulletService));

        public WeaponPresenter Create(Weapon weapon, IWeaponView view) => 
            new WeaponPresenter(weapon, view, _bulletService);

        // public WeaponPresenter Create<T>(Weapon weapon,
        // 	T weaponView,
        // 	ViewObjectPool<BulletView> viewObjectPool)
        // 	where T : IPresentableView<WeaponPresenter>, IWeaponView =>
        // 	new WeaponPresenter(weapon,
        // 		weaponView,
        // 		viewObjectPool,
        // 		_inputService,
        // 		_updateService,
        // 		_weaponShootService);
    }
}