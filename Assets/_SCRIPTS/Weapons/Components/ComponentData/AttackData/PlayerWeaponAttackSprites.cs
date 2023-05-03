using System;
using UnityEngine;

namespace Tomas.Weapons.Components
{
    [Serializable]
    public class PlayerWeaponAttackSprites : PlayerWeaponAttackData
    {
        [field: SerializeField] public Sprite[] PlayerSprites { get; private set; }
    }
}