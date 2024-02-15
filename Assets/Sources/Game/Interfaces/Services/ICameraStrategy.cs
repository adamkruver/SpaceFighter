using System;
using Sources.Interfaces.Domain;

namespace Sources.Interfaces.Services
{
    public interface ICameraFollower
    {
        event Action<ITarget> TargetChanged; 
        void Follow(ITarget target);
    }
}