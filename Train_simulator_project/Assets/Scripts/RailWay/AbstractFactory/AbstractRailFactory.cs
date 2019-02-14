using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public abstract class AbstractRailFactory : MonoBehaviour
    {
        public abstract RailWay CreateRailWay(Tile tile);
        public abstract void DeleteRailWay(RailWay rail);

        public abstract Station CreateStation(Tile tile);
        public abstract void DeleteStation(Station station);
    }
}
