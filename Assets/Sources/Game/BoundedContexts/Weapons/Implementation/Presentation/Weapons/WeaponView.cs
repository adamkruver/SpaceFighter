using System;
using Sources.BoundedContexts.Spaceships.Implementation.Views;
using Sources.BoundedContexts.Weapons.Implementation.Controllers;
using Sources.BoundedContexts.Weapons.Interfaces.Weapons;
using Sources.Common.Mvp.Implememntation.Views;
using UnityEngine;

namespace Sources.BoundedContexts.Weapons.Implementation.Presentation.Weapons
{
	public class WeaponView : PresentableView<WeaponPresenter>, IWeaponView
	{
		[SerializeField] private SpaceshipView _spaceshipView;
		public Vector3 GetPosition() =>
			_spaceshipView.transform.position;
		
		public Quaternion GetRotation() =>
			_spaceshipView.transform.rotation;
	}
}