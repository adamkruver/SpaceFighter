using Sources.BoundedContexts.Torques.Implementation.Presenters;
using Sources.BoundedContexts.Torques.Interfaces.Views;
using Sources.Common.Mvp.Implementation.Views;
using UnityEngine;

namespace Sources.BoundedContexts.Torques.Implementation.Views
{
    public class PhysicsTorqueView : PresentableView<SpaceshipPhysicsTorquePresenter>, IPhysicsTorqueView
    {
        public void SetRotation(Quaternion rotation) => 
            transform.rotation = rotation;
    }
}