using System;

namespace Sources.Game.Interfaces.Services.Lifecycles
{
    public interface IUpdateService
    {
        event Action<float> Updated; 
    }
}