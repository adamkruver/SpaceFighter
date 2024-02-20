using Sources.BoundedContexts.Radars.Implementation.Presentation;
using Sources.BoundedContexts.Spaceships.Implementation.Presenters;
using Sources.BoundedContexts.Spaceships.Interfaces.Views;
using Sources.BoundedContexts.Weapons.Implementation.Views;
using Sources.Common.Observables.Rigidbodies.Implementation.Views;
using UnityEngine;

namespace Sources.BoundedContexts.Spaceships.Implementation.Views
{
    public class SpaceshipView : ObservableRigidbodyView<SpaceshipPresenter>, ISpaceshipView
    {
        [field: SerializeField] public WeaponView WeaponView { get; private set; }
        [field: SerializeField] public RadarView RadarView { get; private set; }
    }
}