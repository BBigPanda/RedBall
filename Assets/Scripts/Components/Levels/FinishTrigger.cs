using System;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private Action _onFinish;

    public void Init(Action onFinish)
    {
        _onFinish = onFinish;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _onFinish?.Invoke();
        }
    }
}