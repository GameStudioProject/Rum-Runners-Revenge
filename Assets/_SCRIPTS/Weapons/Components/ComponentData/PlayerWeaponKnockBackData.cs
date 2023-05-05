namespace Tomas.Weapons.Components
{
    public class PlayerWeaponKnockBackData : PlayerWeaponComponentData<PlayerWeaponAttackKnockBack>
    {
        protected override void SetWeaponComponentDependency()
        {
            WeaponComponentDependency = typeof(PlayerWeaponKnockBack);
        }
    }
}