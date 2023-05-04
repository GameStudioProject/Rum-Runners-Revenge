using UnityEngine;

namespace Tomas._SCRIPTS.Core.CoreComponents
{
    public class CoreDamageReceiver : CoreComponent, DamageInterface
    {
        [SerializeField] private GameObject _damageParticles;
        
        public void Damage(float _damageAmount)
        {
            Debug.Log(core.transform.parent.name + " Damaged! UWU");
            Stats.Component?.DecreaseHealth(_damageAmount);
            ParticleManager?.Component.SpawnParticles(_damageParticles);
        }
    }
}