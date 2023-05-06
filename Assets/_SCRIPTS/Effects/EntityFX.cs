using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFX : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    [Header("Flash FX")] 
    [SerializeField] private float _flashDuration;
    [SerializeField] private Material _hitMaterial;
    private Material _originalSpriteMaterial;

    private void Start()
    {
        _spriteRenderer = GetComponentInParent<SpriteRenderer>();
        _originalSpriteMaterial = _spriteRenderer.material;
    }

    private IEnumerator FlashHitFX()
    {
        _spriteRenderer.material = _hitMaterial;

        yield return new WaitForSeconds(_flashDuration);

        _spriteRenderer.material = _originalSpriteMaterial;
    }
}
