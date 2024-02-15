using Sources.BoundedContexts.Players.Implementation.Presenters;
using Sources.BoundedContexts.Players.Interfaces.Views;
using Sources.BoundedContexts.Spaceships.Implementation.Views;
using Sources.BoundedContexts.Spaceships.Interfaces.Views;
using Sources.Common.Mvp.Implememntation.Views;
using UnityEditor.Search;

namespace Sources.BoundedContexts.Players.Implementation.Views
{
    public class PlayerView : PresentableView<PlayerPresenter>, IPlayerView
    {
        public ISpaceshipView Spaceship { get; set; }
    }
}