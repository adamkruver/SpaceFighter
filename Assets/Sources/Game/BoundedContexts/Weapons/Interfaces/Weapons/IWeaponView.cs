using Sources.BoundedContexts.Weapons.Implementation.Controllers;
using UnityEngine;

namespace Sources.BoundedContexts.Weapons.Interfaces.Weapons
{
	public interface IWeaponView
	{
		Vector3 GetPosition();

		Quaternion GetRotation();
	}
}