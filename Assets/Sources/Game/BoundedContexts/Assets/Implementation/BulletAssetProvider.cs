using System.Threading.Tasks;
using Sources.BoundedContexts.Bullets.Implementation.Presentation;

namespace Sources.BoundedContexts.Assets.Implementation
{
	public class BulletAssetProvider : AssetProviderBase
	{
		public BulletView View { get; private set; }
		public override async Task LoadAsync()
		{
			View = await Load<BulletView>("PhotonTorpedo");
		}
	}
}