using System;
using Sources.Game.Interfaces.Infrastructure.Handlers;
using Sources.Game.Interfaces.Infrastructure.StateMachine;
using UnityEngine;
using IState = Sources.Game.Interfaces.Infrastructure.States.IState;

namespace Sources.Game.Implementation.Infrastructure.StateMachines.Decorators
{
	public class StateMachineUpdatable<T> : IStateMachine<T>, IUpdateHandler where T : class, IState 
	{
		private readonly IStateMachine<T> _stateMachine;

		public StateMachineUpdatable(IStateMachine<T> stateMachine) =>
			_stateMachine = stateMachine ?? throw new ArgumentNullException(nameof(stateMachine));

		public T CurrentState { get; private set; }

		public void Change(T state)
		{
			_stateMachine.Change(state);
			CurrentState = _stateMachine.CurrentState;
		}

		public void Update(float deltaTime)
		{
			(CurrentState as IUpdateHandler)?.Update(deltaTime);
			Debug.Log("сеня красауик");
		}
	}
}