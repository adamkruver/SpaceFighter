using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Domain;

namespace Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Services
{
    public interface ITorqueService
    {
        void UpdateTorque(IPhysicsTorque torque, float deltaTime);
    }
}