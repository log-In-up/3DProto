using Humanoid.Character;
using Humanoid.GameData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Humanoid
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class PlayerInitializer : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private PlayerData _playerData = null;
        [SerializeField] private GameObject _character = null;
        [SerializeField] private Joystick _joystick = null;
        [SerializeField] private HumanoidUICore _humanoidUICore = null;
        #endregion

        #region Fields
        private const string PLAYER_TAG = "Player";
        #endregion

        #region MonoBehaviour API
        private void Start()
        {
            InitializePlayer();
        }
        #endregion

        #region Methods
        private void InitializePlayer()
        {
            GameObject player = GameObject.FindWithTag(PLAYER_TAG);

            if (player == null)
            {
                player = Instantiate(_character);
            }

            player.GetSafeComponent(out Movement playerMovement);
            playerMovement.Init(_joystick, _playerData);

            player.GetSafeComponent(out Shooter shooter);

            _humanoidUICore.SetCharacterData(playerMovement, shooter);
        }
        #endregion
    }
}