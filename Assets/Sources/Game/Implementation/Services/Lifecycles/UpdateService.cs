using System;
using Sources.Interfaces.Infrastructure.Handlers;
using Sources.Interfaces.Services.Lifecycles;

namespace Sources.Implementation.Services.Lifecycles
{
    public class UpdateService : IUpdateService, IUpdateHandler
    {
        public event Action<float> Updated = delegate { };

        public void Update(float deltaTime) =>
            Updated.Invoke(deltaTime);
    }
}