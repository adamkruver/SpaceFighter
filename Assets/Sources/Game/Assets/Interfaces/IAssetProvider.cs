using System.Threading.Tasks;

namespace Sources.Assets.Interfaces
{
	public interface IAssetProvider
	{
		Task LoadAsync();
		void Release();
	}
}