using System;
using Sources.Implementation.Domain;
using Sources.Interfaces.Infrastructure.Handlers;

namespace Sources.Interfaces.Services.Inputs
{
    public interface IInputService : IUpdateHandler
    {
        InputData InputData { get;}
    }
}