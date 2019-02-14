using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    [CreateAssetMenu(fileName = "RailSprites", menuName = "ScriptObj/AddRailSpritesStorage", order = 52)]
    public class RailSpriteStorage : ScriptableObject
    {
        public Sprite[] railSprites;
        public Sprite station;
    }
}
