using UnityEngine;
using Utility;

namespace RotatingObject
{
#if UNITY_EDITOR
    [DisallowMultipleComponent, RequireComponent(typeof(Camera))]
#endif
    public sealed class TouchInputDetector : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField, Min(0.0f)] private float _maxDetectionDistance = 10.0f;
        [SerializeField] private LayerMask _coinLayer;
        #endregion

        #region Fields
        private Camera _camera = null;
        #endregion

        #region MonoBehaviour API
        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        private void Update()
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            if (Input.GetMouseButtonDown(0))
            {
                TriggerChangeColor(Input.mousePosition);
            }
#endif

#if UNITY_ANDROID
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Ended)
                {
                    TriggerChangeColor(touch.position);
                }
            }
#endif
        }

        private void TriggerChangeColor(Vector3 position)
        {
            Ray ray = _camera.ScreenPointToRay(position);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, _maxDetectionDistance, _coinLayer))
            {
                hitInfo.rigidbody.gameObject.GetSafeComponent(out RandomColorApplicator colorApplicator);

                colorApplicator.ChangeColor();
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _maxDetectionDistance);

            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, _maxDetectionDistance, _coinLayer))
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, hitInfo.point);
            }
        }
        #endregion
    }
}