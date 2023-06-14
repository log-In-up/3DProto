using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utility;

namespace RotatingObject
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class RotatingObjectUICore : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private Button _close = null;
        #endregion

        #region MonoBehaviour API
        private void OnEnable()
        {
            _close.onClick.AddListener(OnClickClose);
        }

        private void OnDisable()
        {
            _close.onClick.RemoveListener(OnClickClose);
        }
        #endregion

        #region Button Handlers
        private void OnClickClose()
        {
            SceneManager.LoadScene((int)Scenes.Main);
        }
        #endregion
    }
}