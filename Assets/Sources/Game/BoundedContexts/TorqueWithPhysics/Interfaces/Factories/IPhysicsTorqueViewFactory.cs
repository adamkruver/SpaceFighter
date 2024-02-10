using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Presenters;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Domain;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Views;
using Sources.Interfaces.Presentation.Views;

namespace Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Factories
{
    public interface IPhysicsTorqueViewFactory<T> where T : IPhysicsTorqueView, IPresentableView<PhysicsTorquePresenter>
    {
        IPhysicsTorqueView Create(IPhysicsTorque torque, T view);
    }
}