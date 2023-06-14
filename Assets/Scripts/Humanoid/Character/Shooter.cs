using Humanoid.GameData;
using UnityEngine;

namespace Humanoid.Character
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class Shooter : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private AnimatorController _animator = null;
        [SerializeField] private Transform _shootingPoint = null;
        [SerializeField] private WeaponData _weaponData = null;
        #endregion

        #region Fields
        private float _currentDelay;

        private const float SECONDS_IN_MINUTE = 60.0f;
        #endregion

        #region MonoBehaviour API
        private void Start()
        {
            _currentDelay = 0.0f;
        }

        private void Update()
        {
            if (_currentDelay > 0.0f)
            {
                _currentDelay -= Time.deltaTime;
            }
        }
        #endregion

        #region Public Methods
        internal void MakeShot()
        {
            if (_currentDelay > 0.0f) return;

            GameObject bullet = Instantiate(_weaponData.Bullet, _shootingPoint.position, _shootingPoint.rotation);

            _currentDelay = SECONDS_IN_MINUTE / _weaponData.ShotsPerMinute;

            Destroy(bullet, _weaponData.BulletLifetime);
        }

        internal void StopShooting()
        {
            _animator.CallShot(false);
        }

        internal void StartShooting()
        {
            _animator.CallShot(true);
        }
        #endregion
    }
}