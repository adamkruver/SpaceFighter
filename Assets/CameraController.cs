using System;
using Sources.BoundedContexts.Spaceships.Implementation.Domain.Models;
using Sources.Common.StateMachines.Interfaces.Services;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private Camera _camera;
	[SerializeField] private float _shipDistance = 35f;
	[SerializeField] private float _yOffset = 10f;

	private Spaceship _spaceship;
	private ILateUpdateService _lateUpdateService;
	private Vector3 _nextPosition;
	private Quaternion _rotation;
	private Vector3 _direction;

	public void Construct(Spaceship spaceship, ILateUpdateService lateUpdateService)
	{
		_lateUpdateService = lateUpdateService ?? throw new ArgumentNullException(nameof(lateUpdateService));
		_spaceship = spaceship ?? throw new ArgumentNullException(nameof(spaceship));

		_lateUpdateService.LateUpdated += OnLateUpdated;
	}

	private void Update()
	{
		if (_spaceship == null)
			return;

		float halfScreenWidth = Screen.width / 2;
		float halfScreenHeight = Screen.height / 2;

		_nextPosition = _spaceship.Position - ((_spaceship.Forward * _shipDistance) + (_spaceship.Upward * _yOffset));

		Vector3 mousePosition = Input.mousePosition - new Vector3(halfScreenWidth, halfScreenHeight);

		float maxAngle = 100f;
		Vector2 clampedMousePosition = new Vector2(mousePosition.x, -mousePosition.y) * maxAngle / Screen.height;

		_rotation.eulerAngles = new Vector3(clampedMousePosition.y, clampedMousePosition.x, 0);
	}

	private void OnLateUpdated(float delta)
	{
		_camera.transform.rotation = Quaternion.Lerp(_camera.transform.rotation, _rotation, delta);
		_camera.transform.position = Vector3.Lerp(_camera.transform.position, _nextPosition, delta);
	}
}