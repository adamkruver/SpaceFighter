using Sources.BoundedContexts.PhysicsTorque.Implementation.Presenters;
using Sources.BoundedContexts.PhysicsTorque.Interfaces.Views;
using Sources.Implementation.Presentation.Views;
using UnityEngine;

namespace Sources.BoundedContexts.PhysicsTorque.Implementation.Views
{
    public class PhysicsTorqueView : PresentableView<PhysicsTorquePresenter>, IPhysicsTorqueView
    {
        public void SetRotation(Quaternion rotation) => 
            transform.rotation = rotation;
    }
}