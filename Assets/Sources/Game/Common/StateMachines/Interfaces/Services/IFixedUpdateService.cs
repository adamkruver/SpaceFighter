using System;

namespace Sources.Common.StateMachines.Interfaces.Services
{
    public interface IFixedUpdateService
    {
        event Action<float> FixedUpdated;
    }
}