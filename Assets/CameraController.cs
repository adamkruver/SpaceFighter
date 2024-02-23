using System;
using Sources.BoundedContexts.Spaceships.Implementation.Domain.Models;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _shipDistance = 35f;
    [SerializeField] private float _yOffset = 10f;

    private Spaceship _spaceship;

    private void Update()
    {
        if (_spaceship == null)
            return;

        _spaceship.Speed = 100;

        float halfScreenWidth = Screen.width / 2;
        float halfScreenHeight = Screen.height / 2;
        var ray = _camera.ScreenPointToRay(new Vector3(halfScreenWidth, halfScreenHeight));
        Physics.Raycast(ray, out RaycastHit hit);

        var lookPoint = ray.GetPoint(1000);

        Debug.Log($"distance: {hit.distance}, point: {hit.point}");

        Vector3 direction;

        if (hit.distance < 1)
            direction = lookPoint - _spaceship.Position;
        else
            direction = hit.point - _spaceship.Position;

        _spaceship.Rotation = Quaternion.Lerp(
            _spaceship.Rotation,
            Quaternion.LookRotation(direction),
            Time.deltaTime *20
        );
    }

    private void LateUpdate()
    {
        if (_spaceship == null)
            return;

        
        var nextPosition = _spaceship.Position - _spaceship.Forward * _shipDistance + _spaceship.Upward * _yOffset;
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, nextPosition, Time.deltaTime * 10);
        
        // Vector2 mouseAxis = new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));
        float halfScreenWidth = Screen.width / 2;
        float halfScreenHeight = Screen.height / 2;

        Vector3 mousePosition = Input.mousePosition - new Vector3(halfScreenWidth, halfScreenHeight);

        float maxAngle = 100f;
        Vector2 clampedMousePosition = new Vector2(mousePosition.x, -mousePosition.y)
            * maxAngle / Screen.height;

        var rotation = transform.rotation;
        rotation.eulerAngles = new Vector3(clampedMousePosition.y, clampedMousePosition.x, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime);
    }

    public void Construct(Spaceship spaceship) =>
        _spaceship = spaceship ?? throw new ArgumentNullException(nameof(spaceship));
}