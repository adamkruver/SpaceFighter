using System.Threading.Tasks;
using Sources.BoundedContexts.Players.Implementation.Views;
using Sources.BoundedContexts.Spaceships.Implementation.Views;

namespace Sources.BoundedContexts.Assets.Implementation
{
    public class PlayerAssetProvider : AssetProviderBase
    {
        public PlayerView PlayerView { get; private set; }
        public SpaceshipView SpaceshipView { get; private set; }

        public override async Task LoadAsync()
        {
            PlayerView = await Load<PlayerView>(nameof(PlayerView));
            SpaceshipView = await Load<SpaceshipView>(nameof(SpaceshipView));
        }
    }
}