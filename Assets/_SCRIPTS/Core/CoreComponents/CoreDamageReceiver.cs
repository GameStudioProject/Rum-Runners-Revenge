using UnityEngine;

namespace Tomas._SCRIPTS.Core.CoreComponents
{
    public class CoreDamageReceiver : CoreComponent, DamageInterface
    {
        [SerializeField] private GameObject _damageParticles;
        
        public void Damage(float _damageAmount)
        {
            Debug.Log(core.transform.parent.name + " Damaged! UWU");
            coreStats?.DecreaseHealth(_damageAmount);
            coreParticleManager?.SpawnParticles(_damageParticles);
        }
    }
}