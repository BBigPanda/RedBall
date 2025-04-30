using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace DI.Controllers
{
    public class InputControllers : IInitializable, ITickable
    {
        public ReactiveCommand<float> Move;
        public ReactiveCommand Jump;

        private InputSystem_Actions _input;
        private Vector2 _moveInput;

        public void Initialize()
        {
            _input = new InputSystem_Actions();
            Move = new ReactiveCommand<float>();
            Jump = new ReactiveCommand();
            _input.Enable();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public void Tick()
        {
            Move?.Execute(_input.UI.Navigate.ReadValue<Vector2>().x);
        if (_input.Player.Jump.triggered)
        {
            Jump?.Execute();
        }
        }

        public void ForceUnSubscribe()
        {
            Move?.Dispose();
            Jump?.Dispose();
        }
    }
}