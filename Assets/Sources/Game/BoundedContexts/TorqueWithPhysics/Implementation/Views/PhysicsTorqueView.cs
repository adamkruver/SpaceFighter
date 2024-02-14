using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Presenters;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Views;
using Sources.Implementation.Presentation.Views;
using UnityEngine;

namespace Sources.BoundedContexts.TorqueWithPhysics.Implementation.Views
{
    public class PhysicsTorqueView : PresentableView<SpaceshipPhysicsTorquePresenter>, IPhysicsTorqueView
    {
        public void SetRotation(Quaternion rotation) => 
            transform.rotation = rotation;
    }
}