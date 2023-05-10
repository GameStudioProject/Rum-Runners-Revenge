using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DeathComponent : CoreComponent
    {
        [SerializeField] private GameObject[] _deathParticles;

        private HealthBarScript _healthBar;

        public bool isDead = false;
        
        public void Die()
        {
            
            foreach (var particle in _deathParticles)
            {
                coreParticleManager.SpawnParticles(particle);
            }
            
            StartCoroutine(DeathWait());

            if(_healthBar != null)
                _healthBar.gameObject.SetActive(false);

        }

        private IEnumerator DeathWait()
        {
            yield return new WaitForFixedUpdate();
            core.transform.parent.gameObject.SetActive(false);
            
        }

        private void OnEnable()
        {
            coreStats.EntityHealth.OnCurrentStatValueZero += Die;
        }

        private void OnDisable()
        {
            coreStats.EntityHealth.OnCurrentStatValueZero -= Die;
        }
    }
