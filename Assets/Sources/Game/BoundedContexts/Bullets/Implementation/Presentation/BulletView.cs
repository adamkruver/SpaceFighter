using Sources.BoundedContexts.Bullets.Interfaces.Presentation;
using UnityEngine;

namespace Sources.BoundedContexts.Bullets.Implementation.Presentation
{
	public class BulletView : MonoBehaviour, IBulletView
	{
		[SerializeField] private Rigidbody _rigidbody;
		public void SetVelocity(Vector3 velocity) =>
			_rigidbody.velocity = velocity;
	}
}