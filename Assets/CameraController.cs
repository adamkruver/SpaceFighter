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
    private IUpdateService _updateService;
    private ILateUpdateService _lateUpdateService;
    private Vector3 _nextPosition;
    private Quaternion _rotation;
    private Vector3 _direction;

    public void Construct(Spaceship spaceship, IUpdateService updateService, ILateUpdateService lateUpdateService)
    {
        _lateUpdateService = lateUpdateService ?? throw new ArgumentNullException(nameof(lateUpdateService));
        _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
        _spaceship = spaceship ?? throw new ArgumentNullException(nameof(spaceship));

        _updateService.Updated += OnUpdated;
        _lateUpdateService.LateUpdated += OnLateUpdated;
    }

    private void OnLateUpdated(float delta)
    {
            
        if (_spaceship == null)
            return;

        float halfScreenWidth = Screen.width / 2;
        float halfScreenHeight = Screen.height / 2;

        #region Spaceship Rotate

        var ray = _camera.ScreenPointToRay(new Vector3(halfScreenWidth, halfScreenHeight));
        Physics.Raycast(ray, out RaycastHit hit);
        
        var lookPoint = ray.GetPoint(1000);
        
        if (hit.distance < 1)
            _direction = lookPoint - _spaceship.Position;
        else
            _direction = hit.point - _spaceship.Position;
        
        _spaceship.Rotation = Quaternion.Lerp(
            _spaceship.Rotation,
            Quaternion.LookRotation(_direction),
            delta *20
        );
        #endregion

        #region Camera Rotate

        _nextPosition = _spaceship.Position - _spaceship.Forward * _shipDistance + _spaceship.Upward * _yOffset;
        
        Vector3 mousePosition = Input.mousePosition - new Vector3(halfScreenWidth, halfScreenHeight);
        
        float maxAngle = 100f;
        Vector2 clampedMousePosition = new Vector2(mousePosition.x, -mousePosition.y)
            * maxAngle / Screen.height;
        
        _rotation = _camera.transform.rotation;
        _rotation.eulerAngles = new Vector3(clampedMousePosition.y, clampedMousePosition.x, 0);
        
        #endregion
        


        
        _camera.transform.rotation = Quaternion.Lerp(_camera.transform.rotation, _rotation, delta);
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, _nextPosition, delta * 5);
        
        
        // _camera.transform.position = _spaceship.Position + new Vector3(0, _yOffset,_shipDistance);
        //     
        // Quaternion toRotation = Quaternion.LookRotation(_spaceship.Forward, _spaceship.Upward);
        // _camera.transform.rotation = Quaternion.Lerp( _camera.transform.rotation, toRotation, 3f * Time.deltaTime );
    }

    
    private void OnUpdated(float delta)
    {
        if (_spaceship == null)
            return;

    
    }
}