using Sources.BoundedContexts.Weapons.Implementation.Presenters;
using Sources.BoundedContexts.Weapons.Interfaces.Views;
using Sources.Common.Mvp.Implementation.Views;
using Sources.Common.Observables.Transforms.Implementation.Views;
using UnityEngine;

namespace Sources.BoundedContexts.Weapons.Implementation.Views
{
    public class WeaponView : ObservableTransformView<WeaponPresenter>, IWeaponView
    {
        [SerializeField] private Transform _shootPoint;

        public Vector3 ShootPoint =>
            _shootPoint.position;
    }
}