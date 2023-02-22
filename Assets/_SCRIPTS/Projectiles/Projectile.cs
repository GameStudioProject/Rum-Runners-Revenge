using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _speed;
    private float _projectileTravelDistance;
    private float _projectileXStartPosition;

    [SerializeField] private float _projectileGravity;
    [SerializeField] private float _damageRadius;

    private Rigidbody2D _projectileRB;
    
    private bool _isProjectileGravityOn;
    private bool _hasProjectileHitGround;

    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private LayerMask _whatIsPlayer;
    [SerializeField] private Transform _projectileDamagePosition;
    

    private void Start()
    {
        _projectileRB = GetComponent<Rigidbody2D>();

        _projectileRB.gravityScale = 0.0f;
        _projectileRB.velocity = transform.right * _speed;

        _projectileXStartPosition = transform.position.x;

        _isProjectileGravityOn = false;
    }

    private void Update()
    {
        if (!_hasProjectileHitGround)
        {
            //_attackDetails.position = transform.position;
            
            if (_isProjectileGravityOn)
            {
                float angle = Mathf.Atan2(_projectileRB.velocity.y, _projectileRB.velocity.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!_hasProjectileHitGround)
        {
            Collider2D damageHit = Physics2D.OverlapCircle(_projectileDamagePosition.position, _damageRadius, _whatIsPlayer);
            Collider2D groundHit = Physics2D.OverlapCircle(_projectileDamagePosition.position, _damageRadius, _whatIsGround);

            if (damageHit)
            {
                //damageHit.transform.SendMessage("Damage", _attackDetails);
                Destroy(gameObject);
            }

            if (groundHit)
            {
                _hasProjectileHitGround = true;
                _projectileRB.gravityScale = 0;
                _projectileRB.velocity = Vector2.zero;
            }
            
            if (Mathf.Abs(_projectileXStartPosition - transform.position.x) >= _projectileTravelDistance && !_isProjectileGravityOn)
            {
                _isProjectileGravityOn = true;
                _projectileRB.gravityScale = _projectileGravity;
            }
        }
    }

    public void ShootProjectile(float speed, float travelDistance, float damage)
    {
        _speed = speed;
        _projectileTravelDistance = travelDistance;
        //_attackDetails.damageAmount = damage;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_projectileDamagePosition.position, _damageRadius);
    }
}
