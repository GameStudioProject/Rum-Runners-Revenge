using Tomas.Interfaces;

namespace Tomas.Core.CoreComponents
{
    public class CorePoiseDamageReceiver : CoreComponent, PoiseInterface
    {
        public void PoiseDamage(float amount)
        {
            coreStats.EntityPoise.DecreaseStat(amount);
        }
    }
}