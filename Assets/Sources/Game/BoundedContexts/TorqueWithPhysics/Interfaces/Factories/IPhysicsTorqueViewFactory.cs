using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Domain;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Domain.Models.Decorators;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Presenters;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Domain;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Views;
using Sources.Common.Mvp.Interfaces.Views;

namespace Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Factories
{
    public interface IPhysicsTorqueViewFactory<T> where T : IPhysicsTorqueView, IPresentableView<SpaceshipPhysicsTorquePresenter>
    {
        IPhysicsTorqueView Create(IPhysicsTorque torque, T view);
    }
}