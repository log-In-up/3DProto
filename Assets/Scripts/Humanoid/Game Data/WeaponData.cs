using UnityEngine;

namespace Humanoid.GameData
{
    [CreateAssetMenu(fileName = "Weapon Data", menuName = "Game Data/Humanoid/Weapon Data", order = 1)]
    public class WeaponData : ScriptableObject
    {
        #region Editor fields
        [field: SerializeField, Min(0.0f)] public float ShotsPerMinute { get; private set; }
        [field: SerializeField, Min(0.0f)] public float BulletLifetime { get; private set; }
        [field: SerializeField] public GameObject Bullet { get; private set; }
        #endregion
    }
}