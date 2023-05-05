namespace Tomas.Weapons.Components
{
    public class PlayerWeaponAttackDamageData : PlayerWeaponComponentData<PlayerWeaponAttackDamage>
    {
        public PlayerWeaponAttackDamageData()
        {
            WeaponComponentDependency = typeof(PlayerWeaponDamage);
        }
    }
}