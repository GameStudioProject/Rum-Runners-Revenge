using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tomas
{
    public class ParallaxEffect : MonoBehaviour
    {

        private GameObject _camera;

        [SerializeField] private float _parallaxEffect;

        private float _imageXPosition;

        private float _imageLength;

        void Start()
        {
            _camera = GameObject.Find("Main Camera");
            _imageLength = GetComponent<SpriteRenderer>().bounds.size.x;
            _imageXPosition = transform.position.x;
        }


        void Update()
        {
            float distanceImageMoved = _camera.transform.position.x * (1-_parallaxEffect);
            float distanceImageToMove = _camera.transform.position.x * _parallaxEffect;

            transform.position = new Vector3(_imageXPosition + distanceImageToMove, _camera.transform.position.y);
            
            if (distanceImageMoved > _imageXPosition + _imageLength)
                _imageXPosition = _imageXPosition + _imageLength;
            
            else if (distanceImageMoved < _imageXPosition - _imageLength)
                _imageXPosition = _imageXPosition - _imageLength;
        }
        
    }
}
