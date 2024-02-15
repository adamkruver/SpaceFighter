using System.Threading.Tasks;
using Sources.BoundedContexts.Assets.Interfaces;

namespace Sources.BoundedContexts.Assets.Implementation
{
	public class AssetService<T> : IAssetService where T : IAssetProvider, new()
	{
		public T Provider { get; } = new T();
		
		public async Task LoadAsync() =>
			await Provider.LoadAsync();

		public void Release() =>
			Provider.Release();
	}
	
	public interface IAssetProviderFactory<T> where T :  IAssetProvider
	{
		T Create();
	}
}