using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Domain;

namespace Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Services
{
    public interface ITorqueService
    {
        void UpdateTorqueWithSlerp(IPhysicsTorque torque, float deltaTime);
    }
}