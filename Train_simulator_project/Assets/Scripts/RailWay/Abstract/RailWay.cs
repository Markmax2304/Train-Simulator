using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public abstract class RailWay : MonoBehaviour
    {
        public abstract void Initialize(Vector2 pos, List<SidesLink> links);

        //public abstract int GetTimeOut();
    }
}
