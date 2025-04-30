using DI.Controllers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class JumpButton : MonoBehaviour, IPointerDownHandler
{
    [Inject] private InputControllers _inputControllers;

    public void OnPointerDown(PointerEventData eventData)
    {
        _inputControllers.Jump?.Execute();
    }
}