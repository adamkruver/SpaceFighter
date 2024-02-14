using System.Threading.Tasks;
using Sources.Implementation.Presentation.Views;
using UnityEngine;

namespace Sources.Assets.Implementation
{
	public class PlayerAssetProvider : AssetProviderBase
	{
		public SpaceshipView SpaceshipView { get; private set; }

		public override async Task LoadAsync()
		{
			SpaceshipView = await Load<SpaceshipView>(nameof(SpaceshipView));
			Debug.Log(SpaceshipView);
				
		}
	}
}