using UnityEngine;

namespace Sources.BoundedContexts.Weapons.Interfaces.Views
{
	public interface IWeaponView
	{
		Vector3 ShootPoint { get; }
		Quaternion ShootRotation { get; }
	}
}