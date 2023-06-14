using Utility;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class MainUICore : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private Button _humanoidScene = null;
        [SerializeField] private Button _rotatingObjectScene = null;
        [SerializeField] private Button _vehicleScene = null;
        #endregion

        #region MonoBehaviour API
        private void OnEnable()
        {
            _humanoidScene.onClick.AddListener(OnClickHumanoidScene);
            _rotatingObjectScene.onClick.AddListener(OnClickRotatingObjectScene);
            _vehicleScene.onClick.AddListener(OnClickVehicleScene);
        }

        private void OnDisable()
        {
            _humanoidScene.onClick.RemoveListener(OnClickHumanoidScene);
            _rotatingObjectScene.onClick.RemoveListener(OnClickRotatingObjectScene);
            _vehicleScene.onClick.RemoveListener(OnClickVehicleScene);
        }
        #endregion

        #region Button Handlers
        private void OnClickHumanoidScene() => SceneManager.LoadScene((int)Scenes.Humanoid);

        private void OnClickRotatingObjectScene() => SceneManager.LoadScene((int)Scenes.RotatingObject);

        private void OnClickVehicleScene() => SceneManager.LoadScene((int)Scenes.Vehicle);
        #endregion
    }
}