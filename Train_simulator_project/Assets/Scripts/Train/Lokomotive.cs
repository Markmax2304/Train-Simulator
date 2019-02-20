using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public class Lokomotive : TrainElement
    {
        public override void Awake()
        {
            base.Awake();
            SetSprite(TypeCarriage.Lokomotive);
        }
    }
}
