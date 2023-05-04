using UnityEngine;

namespace Tomas._SCRIPTS.Core.CoreComponents
{
    public class CoreDamageReceiver : CoreComponent, DamageInterface
    {
        [SerializeField] private GameObject _damageParticles;
        
        public void Damage(float _damageAmount)
        {
            Debug.Log(core.transform.parent.name + " Damaged! UWU");
            statsComponent.Component?.DecreaseHealth(_damageAmount);
            particleManagerComponent?.Component.SpawnParticles(_damageParticles);
        }
    }
}