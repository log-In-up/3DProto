using System;
using UnityEngine;

namespace Humanoid.Character
{
#if UNITY_EDITOR
    [DisallowMultipleComponent, RequireComponent(typeof(Animator))]
#endif
    public sealed class AnimatorController : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private string _movementRatio = "MovementRatio";
        [SerializeField] private string _shot = "Shot";
        #endregion

        #region Fields
        private Animator _animator = null;

        #endregion

        #region MonoBehaviour API
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        #endregion

        #region Public methods
        internal void SetMovement(float movementValue) => _animator.SetFloat(_movementRatio, movementValue);

        internal void CallShot(bool value) => _animator.SetBool(_shot, value);
        #endregion
    }
}