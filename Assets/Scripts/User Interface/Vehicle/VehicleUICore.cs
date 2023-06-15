using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utility;

namespace Vehicle
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class VehicleUICore : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private Button _exit = null;
        [SerializeField] private TextMeshProUGUI _speedometerView = null;
        #endregion

        #region Properties
        public TextMeshProUGUI SpeedometerView => _speedometerView;
        #endregion

        #region MonoBehaviour API
        private void OnEnable()
        {
            _exit.onClick.AddListener(OnClickExit);
        }

        private void OnDisable()
        {
            _exit.onClick.RemoveListener(OnClickExit);
        }
        #endregion

        #region Button Handlers
        private void OnClickExit() => SceneManager.LoadScene((int)Scenes.Main);
        #endregion
    }
}