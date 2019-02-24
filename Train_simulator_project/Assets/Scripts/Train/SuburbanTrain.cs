using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public class SuburbanTrain : Train
    {
        public SuburbanTrain(TrainElement head, Color color, TileSides from, int rate) : base(head, color, from, rate) { }
    }
}
