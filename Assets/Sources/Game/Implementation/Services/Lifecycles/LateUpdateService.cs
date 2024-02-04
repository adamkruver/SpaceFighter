using System;
using Sources.Interfaces.Infrastructure.Handlers;
using Sources.Interfaces.Services.Lifecycles;

namespace Sources.Implementation.Services.Lifecycles
{
    public class LateUpdateService : ILateUpdateService, ILateUpdateHandler
    {
        public event Action<float> LateUpdated = delegate { };

        public void UpdateLate(float deltaTime) =>
            LateUpdated.Invoke(deltaTime);
    }
}