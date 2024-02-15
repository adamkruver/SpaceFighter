using System;

namespace Sources.Common.StateMachines.Interfaces.Services
{
    public interface IUpdateService
    {
        event Action<float> Updated; 
    }
}