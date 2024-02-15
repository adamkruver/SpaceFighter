using Sources.BoundedContexts.Players.Implementation.Presenters.States;
using Sources.BoundedContexts.Players.Implementation.Presenters.Transitions.Rules;
using Sources.BoundedContexts.Players.Interfaces.Models;
using Sources.Common.StateMachines.Implementation.Contexts.Transitions;

namespace Sources.BoundedContexts.Players.Implementation.Presenters.Transitions
{
    public class ToCameraControlState : Transition<IPlayerState>
    {
        public ToCameraControlState(CameraControlState nextState) : base(
            PlayerPresenterTransitionRules.CanTransitToCameraControlState,
            nextState
        )
        {
        }
    }
}