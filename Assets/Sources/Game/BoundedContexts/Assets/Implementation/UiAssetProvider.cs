using System.Threading.Tasks;
using Sources.BoundedContexts.Radars.Implementation.Presentation;

namespace Sources.BoundedContexts.Assets.Implementation
{
    public class UiAssetProvider : AssetProviderBase
    {
        public RadarView Radar { get; private set; }
        
        public override async Task LoadAsync()
        {
            Radar = await Load<RadarView>(nameof(Radar));
        }
        
    }
}