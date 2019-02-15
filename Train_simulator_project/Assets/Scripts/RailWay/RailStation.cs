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

        public override void Initialize(Vector2 pos, List<SidesLink> links)
        {
            _transform.position = pos;
        }

        void SetSprite(Sprite sprite)
        {
            spriteRend.sprite = sprite;
        }
    }
}
