using Sources.BoundedContexts.Players.Implementation.Presenters;
using Sources.BoundedContexts.Players.Interfaces.Views;
using Sources.BoundedContexts.Spaceships.Interfaces.Views;
using Sources.Common.Mvp.Implememntation.Views;

namespace Sources.BoundedContexts.Players.Implementation.Views
{
    public class PlayerView : PresentableView<PlayerPresenter>, IPlayerView
    {
        // TODO 2 объекта на сцене
        public ISpaceshipView Spaceship { get; set; }
    }
}