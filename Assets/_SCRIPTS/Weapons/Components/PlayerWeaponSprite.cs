using System;
using Tomas.Weapons.Components;
using UnityEngine;

namespace Tomas.Weapons.Components
{
    public class PlayerWeaponSprite : PlayerWeaponComponent<PlayerWeaponSpriteData, PlayerWeaponAttackSprites>
    {
        private SpriteRenderer _baseWeaponSpriteRenderer;
        private SpriteRenderer _weaponSpriteRenderer;

        private int _weaponSpriteIndex;

        protected override void WeaponComponentHandleEnter()
        {
            base.WeaponComponentHandleEnter();
            
            _weaponSpriteIndex = 0;
        }

        private void HandleWeaponBaseSpriteChange(SpriteRenderer _spriteRenderer)
        {
            if (!_isWeaponAttackActive)
            {
                _weaponSpriteRenderer.sprite = null;
                return;
            }

            var currentAttackSprite = currentAttackData.PlayerSprites;

            if (_weaponSpriteIndex >= currentAttackSprite.Length)
            {
                Debug.LogWarning($"{_playerWeapon.name} weapon sprites length mismatching");
                return;
            }

            _weaponSpriteRenderer.sprite = currentAttackSprite[_weaponSpriteIndex];

            _weaponSpriteIndex++;
        }

        protected override void Awake()
        {
            base.Awake();

            _baseWeaponSpriteRenderer = transform.Find("Base").GetComponent<SpriteRenderer>();
            _weaponSpriteRenderer = transform.Find("WeaponSprite").GetComponent<SpriteRenderer>();

            // TODO: Fix this when weapon data is created.
            //_baseWeaponSpriteRenderer = _playerWeapon.BaseWeaponGameObject.GetComponent<SpriteRenderer>();
            //_weaponSpriteRenderer = _playerWeapon.WeaponSpriteGameObject.GetComponent<SpriteRenderer>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            
            _baseWeaponSpriteRenderer.RegisterSpriteChangeCallback(HandleWeaponBaseSpriteChange);

            _playerWeapon.OnWeaponEnter += WeaponComponentHandleEnter;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
        
            _baseWeaponSpriteRenderer.UnregisterSpriteChangeCallback(HandleWeaponBaseSpriteChange);

            _playerWeapon.OnWeaponEnter -= WeaponComponentHandleEnter;
        }
    }
}