using System;
using System.ComponentModel;
using Sources.BoundedContexts.Bullets.Implementation.Services;
using Sources.BoundedContexts.Spaceships.Implementation.Services;
using Sources.BoundedContexts.Weapons.Implementation.Domain.Models;
using Sources.BoundedContexts.Weapons.Interfaces.Views;
using Sources.Common.Mvp.Implementation.Presenters;
using Sources.Common.Observables.Transforms.Implementation.Presenters;
using Sources.Common.StateMachines.Interfaces.Services;

namespace Sources.BoundedContexts.Weapons.Implementation.Presenters
{
	public class WeaponPresenter : TransformPresenter
	{
		private readonly Weapon _model;
		private readonly IWeaponView _view;
		private readonly BulletService _bulletService;
		private readonly SpaceshipService _shipService;

		public WeaponPresenter(Weapon model,
			IWeaponView view,
			IUpdateService updateService,
			BulletService bulletService,
			SpaceshipService shipService, IFixedUpdateService fixedUpdateService)
			: base(model, view, updateService, fixedUpdateService)
		{
			_model = model ?? throw new ArgumentNullException(nameof(model));
			_view = view ?? throw new ArgumentNullException(nameof(view));
			_bulletService = bulletService ?? throw new ArgumentNullException(nameof(bulletService));
			_shipService = shipService ?? throw new ArgumentNullException(nameof(shipService));
		}

		public override void Enable()
		{
			base.Enable();
			_model.PropertyChanged += OnModelPropertyChanged;
		}

		public override void Disable()
		{
			base.Disable();
			_model.PropertyChanged -= OnModelPropertyChanged;
		}

		private void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(Weapon.LastShootTime))
				_bulletService.Shoot(_view.ShootPoint, _model.Rotation, _shipService.Speed);

			// TODO: Get speed from ship+bullet
			//todo: <_weaponView.GetPosition(),_weaponView.GetRotation(),_weapon.Sped> переработать 
		}
	}
}