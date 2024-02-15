using System;

namespace Sources.Common.StateMachines.Interfaces.Services
{
    public interface ILateUpdateService
    {
        event Action<float> LateUpdated;
    }
}