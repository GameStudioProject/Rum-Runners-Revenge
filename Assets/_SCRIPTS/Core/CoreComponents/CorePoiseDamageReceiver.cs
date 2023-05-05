using Tomas.Interfaces;

namespace Tomas.Core.CoreComponents
{
    public class CorePoiseDamageReceiver : CoreComponent, PoiseInterface
    {
        private StatsComponent coreStats;
        
        public void PoiseDamage(float amount)
        {
            coreStats.EntityPoise.DecreaseStat(amount);
        }

        protected override void Awake()
        {
            base.Awake();

            coreStats = core.GetCoreComponent<StatsComponent>();
        }
    }
}