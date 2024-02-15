using System;
using Sources.Common.StateMachines.Interfaces.Handlers;
using Sources.Common.StateMachines.Interfaces.Services;

namespace Sources.Common.StateMachines.Implementation.Services
{
    public class UpdateService : IUpdateService, IUpdateHandler
    {
        public event Action<float> Updated = delegate { };

        public void Update(float deltaTime) =>
            Updated.Invoke(deltaTime);
    }
}