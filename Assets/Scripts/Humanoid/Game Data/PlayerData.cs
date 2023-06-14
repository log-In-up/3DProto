using UnityEngine;

namespace Humanoid.GameData
{
    [CreateAssetMenu(fileName = "Player Data", menuName = "Game Data/Humanoid/Player Data", order = 1)]
    public sealed class PlayerData : ScriptableObject
    {
        #region Editor fields
        [field: Header("Player movement")]
        [field: SerializeField, Min(0.0f)] public float MovementSpeed { get; private set; }
        [field: SerializeField, Min(0.0f)] public float SmoothTime { get; private set; }
        [field: SerializeField, Min(0.0f)] public float JumpForce { get; private set; }
        #endregion
    }
}