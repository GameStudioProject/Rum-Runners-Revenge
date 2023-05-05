using UnityEngine;

namespace Tomas.Core.CoreComponents
{
    public class CoreDamageReceiver : CoreComponent, DamageInterface
    {
        [SerializeField] private GameObject _damageParticles;
        
        public void Damage(float _damageAmount)
        {
            Debug.Log(core.transform.parent.name + " Damaged!");
            coreStats?.EntityHealth.DecreaseStat(_damageAmount);
            coreParticleManager?.SpawnParticles(_damageParticles);
        }
    }
}