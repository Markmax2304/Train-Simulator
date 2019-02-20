using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public class Carriage : TrainElement
    {
        public override void Awake()
        {
            base.Awake();
            SetSprite(TypeCarriage.Carriage);
        }

        protected override void ConnectFrontCarriage(TrainElement carriage)
        {
            frontTrainElement = carriage;
        }

        protected override void DisconnectFrontCarriage()
        {
            frontTrainElement = null;
        }
    }
}
