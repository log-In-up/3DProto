using UnityEngine;

namespace Humanoid.Character
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class GroundCheck : MonoBehaviour
    {
        #region Fields
        [SerializeField] private Movement _playerController = null;
        [SerializeField] private FootprintSpawner _footprintSpawner = null;
        #endregion

        #region MonoBehaviour API
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == _playerController.gameObject) return;

            _playerController.SetGroundedState(true);
            _footprintSpawner.SetGroundedState(true);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject == _playerController.gameObject) return;

            _playerController.SetGroundedState(false);
            _footprintSpawner.SetGroundedState(false);
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject == _playerController.gameObject) return;

            _playerController.SetGroundedState(true);
            _footprintSpawner.SetGroundedState(true);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject == _playerController.gameObject) return;

            _playerController.SetGroundedState(true);
            _footprintSpawner.SetGroundedState(true);
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject == _playerController.gameObject) return;

            _playerController.SetGroundedState(false);
            _footprintSpawner.SetGroundedState(false);
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject == _playerController.gameObject) return;

            _playerController.SetGroundedState(true);
            _footprintSpawner.SetGroundedState(true);
        }
        #endregion
    }
}