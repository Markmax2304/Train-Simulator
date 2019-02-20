using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    [CreateAssetMenu(fileName = "TrainSprites", menuName = "ScriptObj/AddTrainSpritesStorage", order = 52)]
    public class TrainSpriteStorage : ScriptableObject
    {
        public TrainSprite[] trainSprites;
    }

    [System.Serializable]
    public struct TrainSprite
    {
        public TypeCarriage type;
        public Sprite sprite;
    }
}
