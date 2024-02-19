using System.ComponentModel;

namespace Sources.BoundedContexts.Weapons.Interfaces.Domain.Models
{
	public interface IWeapon : INotifyPropertyChanged
	{
		void Shoot();

		float Speed { get;  }
	}
}