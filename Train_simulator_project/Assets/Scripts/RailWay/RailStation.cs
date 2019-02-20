using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public class RailStation : RailWay
    {
        public override void SetPosition(Vector2 pos)
        {
            _transform.position = pos;
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
    }
}
