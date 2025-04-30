using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _endPosition;
    [SerializeField] private BackgroundController _backgroundController;
    [SerializeField] private FinishTrigger _finishTrigger;

    public FinishTrigger FinishTrigger => _finishTrigger;

    public void Init(Transform playerTransform)
    {
        _backgroundController.Init(playerTransform);
    }

    public Vector3 GetStartPosition()
    {
        return _startPosition.position;
    }

    public Vector3 GetEndPosition()
    {
        return _endPosition.position;
    }
}