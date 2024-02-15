using System;
using Sources.BoundedContexts.Inputs.Interfaces.Services;
using Sources.Common.StateMachines.Implementation.Contexts.States;
using Sources.Common.StateMachines.Interfaces.Handlers;

namespace Sources.BoundedContexts.Players.Implementation.Presenters.States
{
    public class CameraControlState : ContextStateBase, IUpdateHandler
    {
        private readonly IInputService _inputService;

        public CameraControlState(IInputService inputService)
        {
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
        }

        public void Update(float deltaTime)
        {
            var inputData = _inputService.InputData;
        }
    }
}