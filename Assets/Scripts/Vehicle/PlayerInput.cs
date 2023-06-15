using UnityEngine;

namespace Vehicle
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class PlayerInput : MonoBehaviour
    {
        #region Fields
        private float _vertical, _horizontal;
        #endregion

        #region Properties
        public float Horizontal => _horizontal;
        public float Vertical => _vertical;
        #endregion

        #region Public Methods
        internal void IncreaseHorizontal() => _horizontal += 1.0f;

        internal void DecreaseHorizontal() => _horizontal -= 1.0f;

        internal void IncreaseVertical() => _vertical += 1.0f;

        internal void DecreaseVertical() => _vertical -= 1.0f;
        #endregion
    }
}