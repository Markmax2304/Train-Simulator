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

        public override void Initialize(Vector2 position, int rotateDegree, TypeRailWay type)
        {
            Debug.Log(position + "| Rotate = " + rotateDegree);      //test
            SetPosition(position);
            SetRotate(rotateDegree);
            SetSprite(type);
        }

        void SetPosition(Vector2 pos)
        {
            _transform.position = pos;
        }

        void SetRotate(int degree)
        {
            // вращаем по часовой стрелке вокруг оси Z
            _transform.Rotate(Vector3.back * degree);
        }

        void SetSprite(TypeRailWay type)
        {
            for (int i = 0; i < spriteStorage.railSprites.Length; i++) {
                if (type == spriteStorage.railSprites[i].type) {
                    spriteRend.sprite = spriteStorage.railSprites[i].sprite;
                    return;
                }
            }
            Debug.Log("Error. Dont found sprite type - " + type.ToString());
        }
    }   
}
