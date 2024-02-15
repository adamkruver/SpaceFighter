using System;
using Sources.BoundedContexts.Assets.Implementation;
using Sources.BoundedContexts.Players.Implementation.Models;
using Sources.BoundedContexts.Players.Implementation.Views;
using Sources.BoundedContexts.Players.Interfaces.Views;
using Sources.BoundedContexts.Spaceships.Implementation.Factories;
using Object = UnityEngine.Object;

namespace Sources.BoundedContexts.Players.Implementation.Factories
{
    public class PlayerViewFactory
    {
        private readonly PlayerPresenterFactory _presenterFactory;
        private readonly SpaceshipViewFactory _spaceshipViewFactory;
        private readonly PlayerAssetProvider _assetProvider;

        public PlayerViewFactory(
            PlayerPresenterFactory presenterFactory,
            PlayerAssetProvider assetProvider,
            SpaceshipViewFactory spaceshipViewFactory
        )
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
            _spaceshipViewFactory =
                spaceshipViewFactory ?? throw new ArgumentNullException(nameof(spaceshipViewFactory));
            _assetProvider = assetProvider ?? throw new ArgumentNullException(nameof(assetProvider));
        }

        public IPlayerView Create(Player player)
        {
            var view = Instantiate(player);
            view.Spaceship = _spaceshipViewFactory.Create(player.Spaceship);

            return view;
        }

        private PlayerView Instantiate(Player player)
        {
            var view = Object.Instantiate(_assetProvider.PlayerView);
            var presenter = _presenterFactory.Create(player, view);
            view.Construct(presenter);

            return view;
        }
    }
}