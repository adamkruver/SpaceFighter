using Sources.BoundedContexts.Players.Implementation.Presenters;
using Sources.BoundedContexts.Spaceships.Interfaces.Views;
using Sources.Common.Mvp.Interfaces.Views;

namespace Sources.BoundedContexts.Players.Interfaces.Views
{
    public interface IPlayerView : IPresentableView<PlayerPresenter>
    {
        ISpaceshipView Spaceship { get; }
    }
}