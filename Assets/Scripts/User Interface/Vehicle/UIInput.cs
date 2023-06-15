using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.EventSystems.EventTrigger;

namespace Vehicle
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class UIInput : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private EventTrigger _up = null;
        [SerializeField] private EventTrigger _down = null;
        [SerializeField] private EventTrigger _left = null;
        [SerializeField] private EventTrigger _right = null;
        #endregion

        #region Fields
        private TriggerEvent _upPointerDown = null, _upPointerUp = null;
        private TriggerEvent _downPointerDown = null, _downPointerUp = null;
        private TriggerEvent _rightPointerDown = null, _rightPointerUp = null;
        private TriggerEvent _leftPointerDown = null, _leftPointerUp = null;

        private PlayerInput _playerInput = null;
        #endregion

        #region MonoBehaviour API
        private void Awake()
        {
            _playerInput = FindObjectOfType<PlayerInput>();

            _upPointerDown = _up.triggers.Find(entry => entry.eventID.Equals(EventTriggerType.PointerDown)).callback;
            _upPointerUp = _up.triggers.Find(entry => entry.eventID.Equals(EventTriggerType.PointerUp)).callback;

            _downPointerDown = _down.triggers.Find(entry => entry.eventID.Equals(EventTriggerType.PointerDown)).callback;
            _downPointerUp = _down.triggers.Find(entry => entry.eventID.Equals(EventTriggerType.PointerUp)).callback;

            _rightPointerDown = _right.triggers.Find(entry => entry.eventID.Equals(EventTriggerType.PointerDown)).callback;
            _rightPointerUp = _right.triggers.Find(entry => entry.eventID.Equals(EventTriggerType.PointerUp)).callback;

            _leftPointerDown = _left.triggers.Find(entry => entry.eventID.Equals(EventTriggerType.PointerDown)).callback;
            _leftPointerUp = _left.triggers.Find(entry => entry.eventID.Equals(EventTriggerType.PointerUp)).callback;
        }

        private void OnEnable()
        {
            _upPointerDown.AddListener(IncreaseZ);
            _upPointerUp.AddListener(DecreaseZ);

            _downPointerDown.AddListener(DecreaseZ);
            _downPointerUp.AddListener(IncreaseZ);

            _rightPointerDown.AddListener(IncreaseX);
            _rightPointerUp.AddListener(DecreaseX);

            _leftPointerDown.AddListener(DecreaseX);
            _leftPointerUp.AddListener(IncreaseX);
        }

        private void OnDisable()
        {
            _upPointerDown.RemoveListener(IncreaseZ);
            _upPointerUp.RemoveListener(DecreaseZ);

            _downPointerDown.RemoveListener(DecreaseZ);
            _downPointerUp.RemoveListener(IncreaseZ);

            _rightPointerDown.RemoveListener(IncreaseX);
            _rightPointerUp.RemoveListener(DecreaseX);

            _leftPointerDown.RemoveListener(DecreaseX);
            _leftPointerUp.RemoveListener(IncreaseX);
        }
        #endregion

        #region Button Handlers
        private void IncreaseX(BaseEventData eventData) => _playerInput.IncreaseHorizontal();

        private void DecreaseX(BaseEventData eventData) => _playerInput.DecreaseHorizontal();

        private void IncreaseZ(BaseEventData eventData) => _playerInput.IncreaseVertical();

        private void DecreaseZ(BaseEventData eventData) => _playerInput.DecreaseVertical();
        #endregion
    }
}