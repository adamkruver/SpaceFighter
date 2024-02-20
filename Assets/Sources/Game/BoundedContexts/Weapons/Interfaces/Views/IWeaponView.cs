using Sources.Common.Observables.Transforms.Interfaces.Views;
using UnityEngine;

namespace Sources.BoundedContexts.Weapons.Interfaces.Views
{
	public interface IWeaponView : ITransformView
	{
		Vector3 ShootPoint { get; }
	}
}