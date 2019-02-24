using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public class UsualRailWay : RailWay
    {
        public override void SetRotate(int degree)
        {
            // вращаем по часовой стрелке вокруг оси Z
            _transform.Rotate(Vector3.back * degree);
        }

        public override void SetSprite(TypeRailWay type)
        {
            for (int i = 0; i < spriteStorage.railSprites.Length; i++) {
                if (type == spriteStorage.railSprites[i].type) {
                    spriteRend.sprite = spriteStorage.railSprites[i].sprite;
                    return;
                }
            }
            Debug.Log("Error. Dont found sprite type - " + type.ToString());
        }

        public override int GetTimeOut()
        {
            return 0;
        }
    }   
}
