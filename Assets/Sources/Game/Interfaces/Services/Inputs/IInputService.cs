using System;
using Sources.Game.Implementation.Domain;
using Sources.Game.Interfaces.Infrastructure.Handlers;

namespace Sources.Game.Interfaces.Services.Inputs
{
    public interface IInputService : IUpdateHandler
    {
        UserInput UserInput { get;}

        event Action<bool>  CameraModeChanged;
    }
}