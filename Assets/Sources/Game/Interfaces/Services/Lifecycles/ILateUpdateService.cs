using System;

namespace Sources.Interfaces.Services.Lifecycles
{
    public interface ILateUpdateService
    {
        event Action<float> LateUpdated;
    }
}