using UnityEngine;

public class ParticleManagerComponent : CoreComponent
{
    private Transform _particleContainer;

    protected override void Awake()
    {
        base.Awake();

        _particleContainer = GameObject.FindGameObjectWithTag("ParticleContainer").transform;
    }

    public GameObject SpawnParticles(GameObject particlePrefab, Vector2 particlePosition, Quaternion particleRotation)
    {
        return Instantiate(particlePrefab, particlePosition, particleRotation, _particleContainer);
    }

    public GameObject SpawnParticles(GameObject particlePrefab)
    {
        return SpawnParticles(particlePrefab, transform.position, Quaternion.identity);
    }

    public GameObject StartParticlesWithRandomRotation(GameObject particlePrefab)
    {
        var randomParticleRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
        return SpawnParticles(particlePrefab, transform.position, randomParticleRotation);
    }
}