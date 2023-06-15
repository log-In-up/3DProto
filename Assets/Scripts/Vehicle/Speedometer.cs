using TMPro;
using UnityEngine;

namespace Vehicle
{
#if UNITY_EDITOR
    [DisallowMultipleComponent, RequireComponent(typeof(Rigidbody))]
#endif
    public sealed class Speedometer : MonoBehaviour
    {
        #region Fields
        private Rigidbody _rigidbody = null;
        private TextMeshProUGUI _speedometerView = null;

        private const float Multiplier_From_MPS_to_KPH = 3.6f;
        #endregion

        #region MonoBehaviour API
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _speedometerView.text = $"{_rigidbody.velocity.magnitude * Multiplier_From_MPS_to_KPH:f1} km/h";
        }
        #endregion

        #region Public methods
        internal void Init(TextMeshProUGUI speedometerView)
        {
            _speedometerView = speedometerView;
        }
        #endregion
    }
}