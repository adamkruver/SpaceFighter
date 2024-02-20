using System;
using System.ComponentModel;
using Sources.BoundedContexts.Bullets.Implementation.Services;
using Sources.BoundedContexts.Weapons.Implementation.Domain.Models;
using Sources.BoundedContexts.Weapons.Interfaces.Views;
using Sources.Common.Mvp.Implementation.Presenters;

namespace Sources.BoundedContexts.Weapons.Implementation.Presenters
{
	public class WeaponPresenter : PresenterBase
	{
		private readonly Weapon _model;
		private readonly IWeaponView _view;
		private readonly BulletService _bulletService;

		public WeaponPresenter(
			Weapon model,
			IWeaponView view,
			BulletService bulletService)
		{
			_model = model ?? throw new ArgumentNullException(nameof(model));
			_view = view ?? throw new ArgumentNullException(nameof(view));
			_bulletService = bulletService ?? throw new ArgumentNullException(nameof(bulletService));
		}

		public override void Enable() => 
			_model.PropertyChanged += OnModelPropertyChanged;

		public override void Disable() => 
			_model.PropertyChanged -= OnModelPropertyChanged;

		private void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName != nameof(Weapon.LastShootTime))
				_bulletService.Shoot(_view.ShootPoint,_view.ShootRotation,100000); // TODO: Get speed from ship+bullet
			
			//todo: <_weaponView.GetPosition(),_weaponView.GetRotation(),_weapon.Sped> переработать 
				
		}
	}
}