using Humanoid.GameData;
using UnityEngine;

namespace Humanoid.Character
{
#if UNITY_EDITOR
    [DisallowMultipleComponent, RequireComponent(typeof(Rigidbody))]
#endif
    public sealed class Movement : MonoBehaviour
    {
        #region Editor fields
        [SerializeField] private AnimatorController _animator = null;
        [SerializeField] private Transform _model = null;
        [SerializeField] private float _rotatingOffset = 135.0f;
        #endregion

        #region Fields
        private bool _isGrounded;
        private Quaternion _rotationOffset;
        private Vector3 _currentVelocity, _moveAmount;

        private Joystick _joystick = null;
        private PlayerData _playerData = null;
        private Rigidbody _rigidbody = null;

        private const float ZERO = 0.0f;
        #endregion

        #region MonoBehaviour API
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            _rotationOffset = Quaternion.Euler(ZERO, _rotatingOffset, ZERO);
        }

        private void Update()
        {
            if (_joystick == null) return;

            Move();
            Look();

            Animation();
        }

        private void FixedUpdate()
        {
            if (_joystick == null) return;

            _rigidbody.MovePosition(_rigidbody.position + (transform.TransformDirection(_rotationOffset * _moveAmount) * Time.fixedDeltaTime));
        }
        #endregion

        #region Methods
        private void Move()
        {
            Vector3 moveDirection = new Vector3(_joystick.Horizontal, ZERO, _joystick.Vertical).normalized;

            _moveAmount = Vector3.SmoothDamp(_moveAmount, moveDirection * _playerData.MovementSpeed, ref _currentVelocity, _playerData.SmoothTime);
        }

        private void Look()
        {
            if (_joystick.Direction == Vector2.zero) return;

            float angle = Mathf.Atan2(_joystick.Horizontal, _joystick.Vertical) * Mathf.Rad2Deg;

            _model.rotation = Quaternion.Euler(ZERO, angle + _rotatingOffset, ZERO);
        }

        private void Animation()
        {
            float movementValue = Mathf.Clamp(_moveAmount.magnitude / _playerData.MovementSpeed, ZERO, _playerData.MovementSpeed);

            _animator.SetMovement(movementValue);
        }
        #endregion

        #region Public Methods
        internal void Init(Joystick joystick, PlayerData playerData)
        {
            _joystick = joystick;
            _playerData = playerData;
        }

        internal void Jump()
        {
            if (!_isGrounded) return;

            _rigidbody.AddForce(Vector3.up * _playerData.JumpForce, ForceMode.Impulse);
        }

        internal void SetGroundedState(bool value) => _isGrounded = value;
        #endregion
    }
}
