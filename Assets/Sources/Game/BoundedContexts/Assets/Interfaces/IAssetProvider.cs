using System.Threading.Tasks;

namespace Sources.BoundedContexts.Assets.Interfaces
{
	public interface IAssetProvider
	{
		Task LoadAsync();
		void Release();
	}
}