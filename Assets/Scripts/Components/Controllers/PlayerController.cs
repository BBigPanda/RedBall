using System;
using DI.Controllers;
using ScriptableObjects;
using UniRx;
using UnityEngine;
using Zenject;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRigidbody2D;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;
    private bool _isGrounded = true;

    [Inject] private PlayerConfigs _playerConfigs;
    [Inject] private InputControllers _inputControllers;

    private void Start()
    {
        _playerRigidbody2D.simulated = true;
        _inputControllers.Move.Subscribe(HandleMovement);
        _inputControllers.Jump.Subscribe(HandleJump);
    }

    public void ForceStopForces()
    {
        _playerRigidbody2D.linearVelocity = Vector2.zero;
        _playerRigidbody2D.simulated = false;
    }

    private void HandleMovement(float moveInput)
    {
        if (Mathf.Abs(_playerRigidbody2D.linearVelocity.x) < _playerConfigs.MaxSpeed)
        {
            _playerRigidbody2D.AddForce(new Vector2(moveInput * _playerConfigs.MoveForce, 0f), ForceMode2D.Force);
        }
        else
        {
            _playerRigidbody2D.linearVelocity =
                new Vector2(Mathf.Sign(_playerRigidbody2D.linearVelocity.x) * _playerConfigs.MaxSpeed,
                    _playerRigidbody2D.linearVelocity.y);
        }

        if (transform.position.y < -10)
        {
            ScenesLoadManager.instance.ReloadScene();
        }
    }

    private void HandleJump(Unit unit)
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _playerConfigs.GroundCheckRadius, _groundLayer);

        if (_isGrounded)
        {
            _playerRigidbody2D.AddForce(Vector2.up * _playerConfigs.JumpForce, ForceMode2D.Force);
        }
    }
}