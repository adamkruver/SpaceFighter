using Sources.BoundedContexts.Spaceships.Implementation.Domain.Models;
using Sources.BoundedContexts.Spaceships.Implementation.Presenters;
using Sources.BoundedContexts.Spaceships.Interfaces.Views;

namespace Sources.BoundedContexts.Spaceships.Implementation.Factories
{
    public class SpaceshipPresenterFactory
    {
        public SpaceshipPresenter Create(Spaceship spaceship, ISpaceshipView spaceshipView) =>
            new SpaceshipPresenter(spaceship, spaceshipView);
    }
}