using UnityEngine;
using Zenject;

public class BackgroundController : MonoBehaviour
{
    private Transform _playerTransform;
    private bool _isFallowing = false;
    private Vector3 _vector3;
    public void Init(Transform playerTransform)
    {
        _playerTransform = playerTransform;
        _isFallowing = true;
    }

    private void Update()
    {
        if (_isFallowing)
        {
            _vector3 = transform.position;
            _vector3.x = _playerTransform.position.x;
            transform.position = Vector3.Lerp(transform.position, _vector3, Time.deltaTime/2);
        }
    }
}
