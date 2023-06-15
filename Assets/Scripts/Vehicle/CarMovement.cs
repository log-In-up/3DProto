using UnityEngine;
using Vehicle.GameData;

namespace Vehicle
{
#if UNITY_EDITOR
    [DisallowMultipleComponent, RequireComponent(typeof(Rigidbody))]
#endif
    public sealed class CarMovement : MonoBehaviour
    {
        #region Editor fields
        [SerializeField] private CarData _carData = null;
        [SerializeField, Min(ZERO)] private float _suspensionSpringMultiplier = 0.5f;
        [SerializeField] private WheelCollider _backLeft = null, _backRight = null;
        [SerializeField] private WheelCollider _frontLeft = null, _frontRight = null;
        #endregion

        #region Fields
        private PlayerInput _input = null;
        private Rigidbody _rigidbody = null;

        private const float ZERO = 0.0f, ONE = 1.0f;
        private const float Multiplier_From_MPS_to_KPH = 3.6f;
        #endregion

        #region MonoBehaviour API
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (_input == null) return;

            Steering();
            Movement();

            Antiroll(_backLeft, _backRight);
            Antiroll(_frontLeft, _frontRight);
        }
        #endregion

        #region Methods
        private void Movement()
        {
            if (_input.Vertical != ZERO)
            {
                _backLeft.motorTorque = _input.Vertical * _carData.MotorTorque;
                _backRight.motorTorque = _input.Vertical * _carData.MotorTorque;

                _backLeft.brakeTorque = ZERO;
                _backRight.brakeTorque = ZERO;
            }
            else
            {
                _backLeft.motorTorque = ZERO;
                _backRight.motorTorque = ZERO;

                _backLeft.brakeTorque = _carData.BrakeTorque;
                _backRight.brakeTorque = _carData.BrakeTorque;
            }

            if (_backLeft.isGrounded && _backRight.isGrounded)
            {
                if (_rigidbody.velocity.magnitude > (_carData.ForwardSpeed / Multiplier_From_MPS_to_KPH) && _input.Vertical > ZERO)
                {
                    _rigidbody.velocity = _rigidbody.velocity.normalized * (_carData.ForwardSpeed / Multiplier_From_MPS_to_KPH);
                }
                else if (_rigidbody.velocity.magnitude > (_carData.BackwardSpeed / Multiplier_From_MPS_to_KPH) && _input.Vertical < ZERO)
                {
                    _rigidbody.velocity = _rigidbody.velocity.normalized * (_carData.BackwardSpeed / Multiplier_From_MPS_to_KPH);
                }
            }
        }

        private void Steering()
        {
            _frontLeft.steerAngle = _input.Horizontal * _carData.RotationAngle;
            _frontRight.steerAngle = _input.Horizontal * _carData.RotationAngle;
        }

        private void Antiroll(WheelCollider left, WheelCollider right)
        {
            float travelL = left.GetGroundHit(out WheelHit backLeftHit)
                ? (-left.transform.InverseTransformPoint(backLeftHit.point).y - left.radius) / left.suspensionDistance
                : ONE;

            float travelR = right.GetGroundHit(out WheelHit hit)
                ? (-right.transform.InverseTransformPoint(hit.point).y - right.radius) / right.suspensionDistance
                : ONE;

            float forceDirection = travelL - travelR;

            if (left.isGrounded)
            {
                left.attachedRigidbody.AddForceAtPosition((left.suspensionSpring.spring * _suspensionSpringMultiplier) * -forceDirection * left.transform.up, left.transform.position);
            }

            if (right.isGrounded)
            {
                right.attachedRigidbody.AddForceAtPosition((right.suspensionSpring.spring * _suspensionSpringMultiplier) * forceDirection * right.transform.up, right.transform.position);
            }
        }
        #endregion

        #region Public Methods
        internal void Init(PlayerInput input)
        {
            _input = input;
        }
        #endregion
    }
}