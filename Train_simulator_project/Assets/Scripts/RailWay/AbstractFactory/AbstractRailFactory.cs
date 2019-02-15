using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public abstract class AbstractRailFactory
    {
        public abstract RailWay CreateRailWay(Tile tile);
        public abstract Station CreateStation(Tile tile);
    }

    public class RailTrackFactory : AbstractRailFactory
    {
        ObjectPool railPool;
        ObjectPool stationPool;

        public RailTrackFactory(ObjectPool rails, ObjectPool stations)
        {
            railPool = rails;
            stationPool = stations;
        }

        public override RailWay CreateRailWay(Tile tile)
        {
            RailWay rail = railPool.RealeseObject().GetComponent<RailWay>();
            // settings regarding tile parameter
            return rail;
        }

        public override Station CreateStation(Tile tile)
        {
            Station station = stationPool.RealeseObject().GetComponent<Station>();
            // settings regarding tile parameter
            return station;
        }
    }
}
