using System;
using Sources.Game.Interfaces.Infrastructure.Handlers;
using Sources.Game.Interfaces.Services.Lifecycles;

namespace Sources.Game.Implementation.Services.Lifecycles
{
    public class UpdateService : IUpdateService, IUpdateHandler
    {
        public event Action<float> Updated = delegate { };

        public void Update(float deltaTime) =>
            Updated.Invoke(deltaTime);
    }
}