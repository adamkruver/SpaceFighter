using Sources.BoundedContexts.Inputs.Implementation.Models;
using Sources.Common.StateMachines.Interfaces.Handlers;

namespace Sources.BoundedContexts.Inputs.Interfaces.Services
{
    public interface IInputService : IUpdateHandler
    {
        InputData InputData { get;}
    }
}