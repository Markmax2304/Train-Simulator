using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public abstract class AbstractRailFactory
    {
        public abstract RailWay CreateRailWay(Tile tile);
    }

    public class RailTrackFactory : AbstractRailFactory
    {
        ObjectPool railPool;

        public RailTrackFactory(ObjectPool rails)
        {
            railPool = rails;
        }

        public override RailWay CreateRailWay(Tile tile)
        {
            RailWay rail = railPool.RealeseObject().GetComponent<RailWay>();
            rail.Initialize(tile.position, tile.links);
            return rail;
        }
    }
}
