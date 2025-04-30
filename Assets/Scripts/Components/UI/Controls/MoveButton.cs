using System;
using DI.Controllers;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using Zenject;

public class MoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private int _direction;

    [Inject] private InputControllers _controllers;
    private static int _currentInput = 0;

    private IDisposable _disposable;

    public void OnPointerDown(PointerEventData eventData)
    {
        _currentInput = _direction;
        SetInput();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _currentInput = 0;
        SetInput();
    }

    private void SetInput()
    {
        _disposable?.Dispose();
        if (_currentInput != 0)
            _disposable = Observable.EveryEndOfFrame().Subscribe(_ => { _controllers?.Move?.Execute(_currentInput); });
    }
}