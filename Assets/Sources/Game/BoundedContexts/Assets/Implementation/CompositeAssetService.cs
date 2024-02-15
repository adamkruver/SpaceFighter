using System;
using System.Threading.Tasks;
using Sources.BoundedContexts.Assets.Interfaces;

namespace Sources.BoundedContexts.Assets.Implementation
{
	public class CompositeAssetService : IAssetService
	{
		private readonly IAssetService[] _assetServices;

		public CompositeAssetService(params IAssetService[] assetServices) =>
			_assetServices = assetServices ?? throw new ArgumentNullException(nameof(assetServices));

		public async Task LoadAsync()
		{
			foreach (IAssetService assetService in _assetServices)
				await assetService.LoadAsync();
		}

		public void Release()
		{
			foreach (IAssetService assetService in _assetServices)
				assetService.Release();
		}
	}
}