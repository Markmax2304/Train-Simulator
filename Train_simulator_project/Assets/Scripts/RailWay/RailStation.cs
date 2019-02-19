using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public class RailStation : RailWay
    {
        [SerializeField] RailSpriteStorage spriteStorage;

        SpriteRenderer spriteRend;
        Transform _transform;

        void Awake()
        {
            spriteRend = GetComponent<SpriteRenderer>();
            _transform = transform;
        }

        public override void Initialize(Vector2 position, int rotateDegree, TypeRailWay type)
        {
            _transform.position = position;
        }

        void SetSprite(Sprite sprite)
        {
            spriteRend.sprite = sprite;
        }
    }
}
