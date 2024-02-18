using System.ComponentModel;
using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Domain;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Domain;

namespace Sources.BoundedContexts.Bullets.Interfaces.Domain
{
	public interface IBullet : INotifyPropertyChanged
	{
		IPhysicsMovement Movement { get; }

		IPhysicsTorque Torque { get; }
	}
}