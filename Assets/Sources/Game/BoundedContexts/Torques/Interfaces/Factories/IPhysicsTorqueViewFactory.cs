using Sources.BoundedContexts.Torques.Implementation.Presenters;
using Sources.BoundedContexts.Torques.Interfaces.Domain;
using Sources.BoundedContexts.Torques.Interfaces.Views;
using Sources.Common.Mvp.Interfaces.Views;

namespace Sources.BoundedContexts.Torques.Interfaces.Factories
{
    public interface IPhysicsTorqueViewFactory<T> where T : IPhysicsTorqueView, IPresentableView<SpaceshipPhysicsTorquePresenter>
    {
        IPhysicsTorqueView Create(IPhysicsTorque torque, T view);
    }
}