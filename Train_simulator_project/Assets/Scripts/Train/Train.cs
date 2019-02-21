using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public abstract class Train
    {
        TrainElement head;
        Color trainColor;

        // -------------- Initialize ------------------
        public Train(TrainElement head, Color color)
        {
            trainColor = color;
            this.head = head;
            head.SetColor(color);
        }

        public void SetColor(Color color)
        {
            trainColor = color;
            head.SetChainColor(color);
        }

        // --------------- Manage of carriage ---------------------
        public void AddCarriage(TrainElement carriage, StateTrainElement state)
        {
            carriage.SetColor(trainColor);
            carriage.Position = state.position;
            carriage.Rotation = state.rotateDegree;
            head.AddCarriage(carriage);
        }

        public void DeleteCarriage()
        {
            head.DeleteCarriage();
        }
    }
}
