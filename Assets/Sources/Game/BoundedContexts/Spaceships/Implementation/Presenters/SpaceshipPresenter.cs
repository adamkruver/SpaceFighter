using Sources.BoundedContexts.Spaceships.Implementation.Domain.Models;
using Sources.BoundedContexts.Spaceships.Interfaces.Views;
using Sources.Common.Observables.Rigidbodies.Implementation.Presenters;
using Sources.Common.StateMachines.Interfaces.Services;

namespace Sources.BoundedContexts.Spaceships.Implementation.Presenters
{
    public class SpaceshipPresenter : RigidbodyPresenter
    {
        public SpaceshipPresenter(Spaceship model, ISpaceshipView view, IUpdateService updateService) 
            : base(model, view, updateService)
        {
        }
    }
}