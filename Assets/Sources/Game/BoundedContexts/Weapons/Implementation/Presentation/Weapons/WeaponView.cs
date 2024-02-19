using Sources.BoundedContexts.Weapons.Implementation.Controllers;
using Sources.BoundedContexts.Weapons.Interfaces.Weapons;
using Sources.Common.Mvp.Implememntation.Views;
using UnityEngine;

namespace Sources.BoundedContexts.Weapons.Implementation.Presentation.Weapons
{
	public class WeaponView : PresentableView<WeaponPresenter>, IWeaponView
	{
		public Vector3 GetPosition() =>
			transform.position;

		public Quaternion GetRotation() =>
			transform.localRotation;
	}
}