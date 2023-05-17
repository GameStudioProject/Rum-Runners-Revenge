using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DeathComponent : CoreComponent
    {
        [SerializeField] private GameObject[] _deathParticles;

        private PlayerUIBarScript _playerUIBar;

        public bool isDead = false;
        
        public void Die()
        {
            
            foreach (var particle in _deathParticles)
            {
                coreParticleManager.SpawnParticles(particle);
            }

            isDead = true;
            
            StartCoroutine(DeathWait());
            
            Time.timeScale = 1;
            if(_playerUIBar != null)
                _playerUIBar.gameObject.SetActive(false);

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
