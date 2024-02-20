using System.ComponentModel;
using Sources.BoundedContexts.Movements.Interfaces.Domain;
using Sources.BoundedContexts.Torques.Interfaces.Domain;

namespace Sources.BoundedContexts.Bullets.Interfaces.Domain
{
	public interface IBullet : INotifyPropertyChanged
	{
		IMovement Movement { get; }

		IPhysicsTorque Torque { get; }
	}
}