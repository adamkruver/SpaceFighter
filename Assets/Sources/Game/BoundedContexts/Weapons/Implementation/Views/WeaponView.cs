using Sources.BoundedContexts.Weapons.Implementation.Presenters;
using Sources.BoundedContexts.Weapons.Interfaces.Views;
using Sources.Common.Mvp.Implementation.Views;
using UnityEngine;

namespace Sources.BoundedContexts.Weapons.Implementation.Views
{
    public class WeaponView : PresentableView<WeaponPresenter>, IWeaponView
    {
        [SerializeField] private Transform _shootPoint;

        public Vector3 ShootPoint =>
            _shootPoint.position;

        public Quaternion ShootRotation =>
            _shootPoint.rotation;
    }
}