using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "PlayerConfigs", menuName = "ScriptableObjects/PlayerConfigs", order = 0)]
    public class PlayerConfigs : ScriptableObject
    {
        [SerializeField] private float _maxSpeed = 100f;
        [SerializeField] private float _moveForce = 25f;
        [SerializeField] private float _jumpForce = 250f;
        [SerializeField] private float _groundCheckRadius = 0.5f;
        
        public float MaxSpeed => _maxSpeed;

        public float MoveForce => _moveForce;

        public float JumpForce => _jumpForce;

        public float GroundCheckRadius => _groundCheckRadius;
    }
}