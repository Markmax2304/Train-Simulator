using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public class UsualRailWay : RailWay
    {
        [SerializeField] RailSpriteStorage spriteStorage;

        SpriteRenderer spriteRend;
        Transform _transform;

        void Awake()
        {
            spriteRend = GetComponent<SpriteRenderer>();
            _transform = transform;
        }

        public override void Initialize()
        {
            SetSprite(spriteStorage.railSprites[4]);        //test
        }

        void SetSprite(Sprite sprite)
        {
            spriteRend.sprite = sprite;
        }
    }
}
