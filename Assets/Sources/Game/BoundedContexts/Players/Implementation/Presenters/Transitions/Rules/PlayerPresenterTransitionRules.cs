using Sources.BoundedContexts.Players.Implementation.Models.States;
using Sources.BoundedContexts.Players.Interfaces.Models;

namespace Sources.BoundedContexts.Players.Implementation.Presenters.Transitions.Rules
{
    public static class PlayerPresenterTransitionRules
    {
        public static bool CanTransitToCameraControlState(IPlayerState state) =>
            state is CameraControl;
        
        public static bool CanTransitToShipControlState(IPlayerState state) =>
            state is SpaceshipControl;
    }
}