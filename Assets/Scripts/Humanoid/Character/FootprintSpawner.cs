using System;
using UnityEngine;

namespace Humanoid.Character
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class FootprintSpawner : MonoBehaviour
    {
        #region Editor Field
        [SerializeField] private GameObject _footprint = null;
        [SerializeField] private Transform _leftFoot = null;
        [SerializeField] private Transform _rightFoot = null;
        [SerializeField, Min(0.0f)] private float _footprintLifetime = 5.0f;
        [SerializeField, Min(0.0f)] private float _verticalOffset = 0.01f;
        #endregion

        #region Fields
        private bool _isGrounded;
        #endregion

        #region Methods
        private void SpawnFootprint(Transform transform)
        {
            if (!_isGrounded) return;

            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + _verticalOffset, transform.position.z);
            GameObject footprint = Instantiate(_footprint, spawnPosition, _footprint.transform.rotation);

            Destroy(footprint, _footprintLifetime);
        }
        #endregion

        #region Public Methods
        internal void SpawnLeftFootprint()
        {
            SpawnFootprint(_leftFoot);
        }

        internal void SpawnRightFootprint()
        {
            SpawnFootprint(_rightFoot);
        }

        internal void SetGroundedState(bool value)
        {
            _isGrounded = value;
        }
        #endregion
    }
}