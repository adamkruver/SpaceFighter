using System;
using Sources.Common.StateMachines.Interfaces.Handlers;
using Sources.Common.StateMachines.Interfaces.Services;

namespace Sources.Common.StateMachines.Implementation.Services
{
    public class LateUpdateService : ILateUpdateService, ILateUpdateHandler
    {
        public event Action<float> LateUpdated = delegate { };

        public void UpdateLate(float deltaTime) =>
            LateUpdated.Invoke(deltaTime);
    }
}