﻿using Sources.BoundedContexts.Weapons.Implementation.Controllers;
using Sources.BoundedContexts.Weapons.Interfaces.Weapons;
using Sources.Implementation.Presentation.Views;
using UnityEngine;

namespace Sources.BoundedContexts.Weapons.Implementation.Presentation.Weapons
{
	public class WeaponView : PresentableView<WeaponPresenter>, IWeaponView
	{
		public Vector3 GetPosition() =>
			transform.position;

		public Quaternion GetRotation() =>
			transform.rotation;

		public Vector3 GetForward() =>
			transform.forward;
	}
}