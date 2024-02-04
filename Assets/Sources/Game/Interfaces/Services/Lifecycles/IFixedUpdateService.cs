using System;

namespace Sources.Interfaces.Services.Lifecycles
{
    public interface IFixedUpdateService
    {
        event Action<float> FixedUpdated;
    }
}