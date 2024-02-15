using System.Threading.Tasks;

namespace Sources.BoundedContexts.Assets.Interfaces
{
	public interface IAssetService 
	{
		Task LoadAsync();

		void Release();
	}
}