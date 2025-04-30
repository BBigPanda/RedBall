using DG.Tweening;
using UnityEngine;

public class CameraFollowingController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private SpriteRenderer _spriteFade;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Transform _cameraFadeTransform;
    [SerializeField] private float _maxY;
    [SerializeField] private float _minY;

    private Vector3 _vector3;
    private bool _isFollowing;

    public void SetPlayerTransform(Transform target)
    {
        _target = target;
        _isFollowing = true;
    }

    public void FadeOut(float duration = 0.5f)
    {
        _spriteFade?.transform.DOKill();
        _spriteFade?.DOKill();
        _spriteFade.DOFade(0, duration).SetDelay(duration/2);
        if (_spriteFade != null)
        {
            _spriteFade.transform.localScale = Vector3.one;
            _spriteFade.transform.position = _target.position;
            _spriteFade.transform.DOScale(4, duration);
        }
    }

    public void FadeIn(float duration = 1.5f)
    {
        _spriteFade?.transform.DOKill();
        _spriteFade?.DOKill();
        _spriteFade.DOFade(1, duration);
        if (_spriteFade != null)
        {
            _spriteFade.transform.localScale = Vector3.one * 4;
            _spriteFade.transform.position = _target.position;
            _spriteFade.transform.DOScale(1, duration).SetDelay(duration/2);;
        }
    }

    void Update()
    {
        if (!_isFollowing)
            return;
        _vector3 = Vector3.Lerp(transform.position, _target.position + _offset, _offset.magnitude * Time.deltaTime);
        if (_vector3.y > _maxY)
        {
            _vector3.y = _maxY;
        }
        else if (_vector3.y < _minY)
        {
            _vector3.y = _minY;
        }

        _cameraFadeTransform.position = _target.position;
        transform.position = _vector3;
    }
}