using UnityEngine;

namespace Sources.BoundedContexts.Bullets.Interfaces.Presentation
{
	public interface IBulletView
	{
		void SetVelocity(Vector3 velocity);

		void SetPosition(Vector3 position);

		void SetForward(Vector3 forward);

		void SetRotation(Quaternion rotation);
	}
}