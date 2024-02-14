using System;
using System.Threading.Tasks;

namespace Sources.Assets.Interfaces
{
	public interface IAssetService 
	{
		Task LoadAsync();

		void Release();
	}
}