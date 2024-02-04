using Sources.BoundedContexts.PhysicsTorque.Implementation.Presenters;
using Sources.BoundedContexts.PhysicsTorque.Interfaces.Domain;
using Sources.BoundedContexts.PhysicsTorque.Interfaces.Views;
using Sources.Interfaces.Presentation.Views;

namespace Sources.BoundedContexts.PhysicsTorque.Interfaces.Factories
{
    public interface IPhysicsTorqueViewFactory<T> where T : IPhysicsTorqueView, IPresentableView<PhysicsTorquePresenter>
    {
        IPhysicsTorqueView Create(IPhysicsTorque torque, T view);
    }
}