using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    [CreateAssetMenu(fileName = "RailSprites", menuName = "ScriptObj/AddRailSpritesStorage", order = 52)]
    public class RailSpriteStorage : ScriptableObject
    {
        public RailSprite[] railSprites;
    }

    [System.Serializable]
    public struct RailSprite
    {
        public TypeRailWay type;
        public Sprite sprite;
    }
}
