using System;
using UnityEngine;

namespace Tomas.Weapons.Components.ComponentData.AttackData
{
    [Serializable]
    public class PlayerAttackSprites
    {
        [field: SerializeField] public Sprite[] PlayerSprites { get; private set; }
    }
}