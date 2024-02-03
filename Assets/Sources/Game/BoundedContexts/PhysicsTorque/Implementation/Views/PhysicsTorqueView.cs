using Sources.Game.BoundedContexts.PhysicsTorque.Implementation.Presenters;
using Sources.Game.BoundedContexts.PhysicsTorque.Interfaces.Views;
using Sources.Game.Implementation.Presentation.Views;
using UnityEngine;

namespace Sources.Game.BoundedContexts.PhysicsTorque.Implementation.Views
{
    public class PhysicsTorqueView : PresentableView<PhysicsTorquePresenter>, IPhysicsTorqueView
    {
        public void SetRotation(Quaternion rotation) => 
            transform.rotation = rotation;
    }
}