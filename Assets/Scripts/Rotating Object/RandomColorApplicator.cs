using UnityEngine;

namespace RotatingObject
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class RandomColorApplicator : MonoBehaviour
    {
        #region Editor Field
        [SerializeField] private MeshRenderer _meshRenderer = null;
        #endregion

        #region Fields
        private Material _material = null;

        private const float MIN_INCLUSIVE = 0.0f, MAX_INCLUSIVE = 1.0f;
        private const string NEW_MATERIAL_NAME = "Temporary Material";
        #endregion

        #region MonoBehaviour API
        private void Awake()
        {
            _material = new Material(_meshRenderer.material);
            _material.name = NEW_MATERIAL_NAME;

            _meshRenderer.material = _material;
        }
        #endregion

        #region Public Methods
        internal void ChangeColor()
        {
            float red = Random.Range(MIN_INCLUSIVE, MAX_INCLUSIVE);
            float green = Random.Range(MIN_INCLUSIVE, MAX_INCLUSIVE);
            float blue = Random.Range(MIN_INCLUSIVE, MAX_INCLUSIVE);

            _material.color = new Color(red, green, blue);
            _meshRenderer.material = _material;
        }
        #endregion
    }
}