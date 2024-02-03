using Sources.Game.BoundedContexts.PhysicsTorque.Implementation.Presenters;
using Sources.Game.BoundedContexts.PhysicsTorque.Interfaces.Domain;
using Sources.Game.BoundedContexts.PhysicsTorque.Interfaces.Views;
using Sources.Game.Interfaces.Presentation.Views;

namespace Sources.Game.BoundedContexts.PhysicsTorque.Interfaces.Factories
{
    public interface IPhysicsTorqueViewFactory<T> where T : IPhysicsTorqueView, IPresentableView<PhysicsTorquePresenter>
    {
        IPhysicsTorqueView Create(IPhysicsTorque torque, T view);
    }
}