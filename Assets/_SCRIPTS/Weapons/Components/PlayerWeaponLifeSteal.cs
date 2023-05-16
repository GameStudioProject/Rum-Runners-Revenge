using Tomas.Core.CoreStatsSystem;
using Tomas.Weapons.Components;
using UnityEngine;


public class PlayerWeaponLifeSteal : PlayerWeaponComponent<PlayerWeaponLifeStealData, PlayerWeaponAttackLifeSteal>
{
    private PlayerWeaponActionHitBox _weaponHitBox;

    private StatsComponent _statsComponent;
        
    private void HandleWeaponDetectCollider2D(Collider2D[] weaponColliders)
    {
        foreach (var item in weaponColliders)
        {
            _statsComponent.EntityHealth.IncreaseStat(currentAttackData.LifeStealAmount);
        }
    }

    protected override void Start()
    {
        base.Start();

        _weaponHitBox = GetComponent<PlayerWeaponActionHitBox>();

        _statsComponent = PlayerManager.instance.player.Core.GetCoreComponent<StatsComponent>();

        _weaponHitBox.HitBoxDetectedCollider2D += HandleWeaponDetectCollider2D;
    }
        
    protected override void OnDestroy()
    {
        base.OnDestroy();

        _weaponHitBox.HitBoxDetectedCollider2D -= HandleWeaponDetectCollider2D;
    }
}
