using UnityEngine;

namespace Humanoid
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class Bullet : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField, Min(0.0f)] private float _speed = 10.0f;
        #endregion

        #region MonoBehaviour API
        private void Update()
        {
            transform.Translate(_speed * Time.deltaTime * Vector3.forward);
        }
        #endregion
    }
}