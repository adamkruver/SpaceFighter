using System;
using Sources.BoundedContexts.Weapons.Implementation.Controllers;
using Sources.BoundedContexts.Weapons.Interfaces.Weapons;
using Sources.Implementation.Presentation.Views;
using Sources.Interfaces.Infrastructure.Handlers;

namespace Sources.BoundedContexts.Weapons.Implementation.Presentation.Weapons
{
	public class WeaponView : PresentableView<WeaponPresenter>, IWeaponView, IUpdateHandler
	{
		private WeaponPresenter _weaponPresenter;
		
		private void Update()
		{
			
		}
		public void Update(float deltaTime)
		{
			_weaponPresenter?.SetPosition(transform.position);
			_weaponPresenter?.SetRotation(transform.rotation);
		}
	}
}