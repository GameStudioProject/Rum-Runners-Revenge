namespace Tomas.Weapons.Components
{
    public class PlayerWeaponAttackDamageData : PlayerWeaponComponentData<PlayerWeaponAttackDamage>
    {
        
        protected override void SetWeaponComponentDependency()
        {
            WeaponComponentDependency = typeof(PlayerWeaponDamage);
        }
    }
}