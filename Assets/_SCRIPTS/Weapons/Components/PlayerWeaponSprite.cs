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

        protected override void Start()
        {
            base.Start();
            
            _baseWeaponSpriteRenderer = _playerWeapon.BaseWeaponGameObject.GetComponent<SpriteRenderer>();
            _weaponSpriteRenderer = _playerWeapon.WeaponSpriteGameObject.GetComponent<SpriteRenderer>();

            weaponComponentData = _playerWeapon.WeaponData.GetData<PlayerWeaponSpriteData>();
            
            _baseWeaponSpriteRenderer.RegisterSpriteChangeCallback(HandleWeaponBaseSpriteChange);
            
        }
        
        protected override void OnDestroy()
        {
            base.OnDestroy();
        
            _baseWeaponSpriteRenderer.UnregisterSpriteChangeCallback(HandleWeaponBaseSpriteChange);
            
        }
    }
}