using System;

namespace Sources.Interfaces.Services.Lifecycles
{
    public interface IUpdateService
    {
        event Action<float> Updated; 
    }
}