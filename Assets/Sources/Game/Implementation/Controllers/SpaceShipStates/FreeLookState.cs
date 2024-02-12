using System;
using Sources.BoundedContexts.Common.Interfaces;
using Sources.BoundedContexts.MoveWithPhysics.Implementation.Presenters;
using Sources.Interfaces.Services.Inputs;
using Sources.Interfaces.Services.Lifecycles;
using Sources.Interfaces.SpaceshipStates;
using UnityEngine;

namespace Sources.Implementation.Controllers.SpaceShipStates
{
	public class FreeLookState : ISpaceshipState
	{
		private readonly IPresenter _presenterBase;
		private readonly PhysicsMovementPresenter _physicsMovementPresenter;
		private readonly IInputService _inputService;
		private readonly IUpdateService _updateService;

		/// <summary>
		///	Отключть передвижение игрока 
		///	Отключить поворот за мышкой
		/// Отключить выстрел из пушки
		/// 
		/// Оставить передвижение камеры 
		/// </summary>
		/// <param name="inputService"></param>
		/// <param name="updateService"></param>
		/// <exception cref="ArgumentNullException"></exception>
		// public FreeLookState(PhysicsMovementPresenter physicsMovementPresenter)
		// {
		// 	_physicsMovementPresenter = physicsMovementPresenter ?? throw new ArgumentNullException(nameof(physicsMovementPresenter));
		// }
	
		public void Enter()
		{
			Debug.Log(nameof(FreeLookState) + " enter");
		}

		public void Exit()
		{
			Debug.Log(nameof(FreeLookState) + " exit");
		}

		private void OnUpdated(float obj)
		{
		}
	}
}