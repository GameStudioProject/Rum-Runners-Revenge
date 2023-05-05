namespace Tomas.Weapons.Components
{
    public class PlayerWeaponPoiseDamageData : PlayerWeaponComponentData<PlayerWeaponAttackPoiseDamage>
    {
        protected override void SetWeaponComponentDependency()
        {
            WeaponComponentDependency = typeof(PlayerWeaponPoiseDamage);
        }
    }
}