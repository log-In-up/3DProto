using Humanoid.Character;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utility;

public class HumanoidUICore : MonoBehaviour
{
    #region Editor Fields
    [SerializeField] private Button _exit = null;
    [SerializeField] private Button _jump = null;
    #endregion

    #region Fields
    private bool _buttonIsHold;

    private Movement _playerMovement = null;
    private Shooter _shooter = null;
    #endregion

    #region MonoBehaviour API
    private void OnEnable()
    {
        _exit.onClick.AddListener(OnClickExit);
        _jump.onClick.AddListener(OnClickJump);
    }

    private void Update()
    {
        if (_buttonIsHold)
        {
            _shooter.MakeShot();
        }
    }

    private void OnDisable()
    {
        _exit.onClick.RemoveListener(OnClickExit);
        _jump.onClick.RemoveListener(OnClickJump);
    }
    #endregion

    #region Button Handlers
    private void OnClickExit() => SceneManager.LoadScene((int)Scenes.Main);

    private void OnClickJump()
    {
        if (_playerMovement == null) return;

        _playerMovement.Jump();
    }
    #endregion

    #region Public Methods
    internal void SetCharacterData(Movement playerMovement, Shooter shooter)
    {
        _playerMovement = playerMovement;
        _shooter = shooter;
    }
    #endregion

    #region Button Handlers
    public void OnStartShooting(BaseEventData eventData)
    {
        _shooter.StartShooting();
        _buttonIsHold = true;
    }

    public void OnEndShoot(BaseEventData eventData)
    {
        _shooter.StopShooting();
        _buttonIsHold = false;
    }
    #endregion
}
