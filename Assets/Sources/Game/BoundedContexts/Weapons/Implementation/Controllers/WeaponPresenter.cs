using System;
using System.ComponentModel;
using Sources.BoundedContexts.Bullets.Implementation.Services;
using Sources.BoundedContexts.Weapons.Implementation.Domain.Models;
using Sources.BoundedContexts.Weapons.Interfaces.Domain.Models;
using Sources.BoundedContexts.Weapons.Interfaces.Weapons;
using Sources.Common.Mvp.Implememntation.Presenters;
using UnityEngine;

namespace Sources.BoundedContexts.Weapons.Implementation.Controllers
{
	public class WeaponPresenter : PresenterBase
	{
		private readonly IWeapon _weapon;
		private readonly IWeaponView _weaponView;
		private readonly BulletService _bulletService;

		public WeaponPresenter(IWeapon weapon,
			IWeaponView weaponView,
			BulletService bulletService)
		{
			_weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
			_weaponView = weaponView ?? throw new ArgumentNullException(nameof(weaponView));
			_bulletService = bulletService ?? throw new ArgumentNullException(nameof(bulletService));
		}

		public override void Enable() =>
			_weapon.PropertyChanged += OnModelPropertyChanged;

		public override void Disable() =>
			_weapon.PropertyChanged -= OnModelPropertyChanged;

		private void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(Weapon.LastShootTime))
				_bulletService.Shoot(_weaponView.GetPosition(), _weaponView.GetRotation(), _weapon.Speed);

			//Todo: _weaponView.GetPosition(),_weaponView.GetRotation(),_weapon.Sped> переработать. Перенести в Weapon?
		}
	}
}