using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAfterImage : MonoBehaviour
{
    [SerializeField]
    private float _activeTime = 0.1f;
    private float _timeActivated;
    private float _alpha;
    [SerializeField]
    private float _alphaSet = 0.8f;
    [SerializeField]
    private float _alphaDecay = 0.85f;

    private Transform _playerTransform;

    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _playerSpriteRenderer;

    private Color _color;

    private void OnEnable()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _playerSpriteRenderer = _playerTransform.GetComponent<SpriteRenderer>();

        _alpha = _alphaSet;
        _spriteRenderer.sprite = _playerSpriteRenderer.sprite;
        transform.position = _playerTransform.position;
        transform.rotation = _playerTransform.rotation;
        _timeActivated = Time.time;
    }

    private void Update()
    {
        _alpha -= _alphaDecay * Time.deltaTime;
        _color = new Color(1f, 1f, 1f, _alpha);
        _spriteRenderer.color = _color;

        if(Time.time >= (_timeActivated + _activeTime))
        {
            PlayerAfterImagePool.Instance.AddToPool(gameObject);
        }

    }
}
