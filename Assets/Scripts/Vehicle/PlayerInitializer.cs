using UnityEngine;
using Utility;

namespace Vehicle
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class PlayerInitializer : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private GameObject _car = null;
        [SerializeField] private PlayerInput _playerInput = null;
        #endregion

        #region Fields
        private VehicleUICore _vehicleUICore = null;

        private const string PLAYER_TAG = "Player";
        #endregion

        #region MonoBehaviour API
        private void Awake()
        {
            _vehicleUICore = FindObjectOfType<VehicleUICore>();
        }

        private void Start()
        {
            InitializePlayer();
        }
        #endregion

        #region Methods
        private void InitializePlayer()
        {
            GameObject playerCar = GameObject.FindWithTag(PLAYER_TAG);

            if (playerCar == null)
            {
                playerCar = Instantiate(_car);
            }

            playerCar.GetSafeComponent(out CarMovement carMovement);
            carMovement.Init(_playerInput);

            playerCar.GetSafeComponent(out Speedometer speedometer);
            speedometer.Init(_vehicleUICore.SpeedometerView);
        }
        #endregion
    }
}