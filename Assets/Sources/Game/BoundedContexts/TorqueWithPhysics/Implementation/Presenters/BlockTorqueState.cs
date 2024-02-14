using System;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Domain;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Services;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Views;
using Sources.Interfaces.Infrastructure.Handlers;

namespace Sources.BoundedContexts.TorqueWithPhysics.Implementation.Presenters
{
	public class BlockTorqueState : StateBase, ITorqueState, IUpdateHandler
	{
		private readonly IPhysicsTorque _torque;
		private readonly IPhysicsTorqueView _view;
		private readonly ITorqueService _torqueService;

		public BlockTorqueState(IPhysicsTorque torque,
			IPhysicsTorqueView view,
			ITorqueService torqueService)
		{
			_torque = torque ?? throw new ArgumentNullException(nameof(torque));
			_view = view ?? throw new ArgumentNullException(nameof(view));
			_torqueService = torqueService ?? throw new ArgumentNullException(nameof(torqueService));
		}

		public void Update(float deltaTime)
		{
			 _torqueService.UpdateTorqueWithSlerp(_torque, deltaTime);
			// _view.SetRotation(_torque.Rotation);
		}
	}
}