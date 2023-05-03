using System;
using UnityEngine;

namespace Tomas.Weapons.Components
{
    [Serializable]
    public class PlayerWeaponAttackActionHitBox : PlayerWeaponAttackData
    {
        public bool Debug;
        
        [field: SerializeField] public Rect WeaponHitBox { get; private set; }
    }
}