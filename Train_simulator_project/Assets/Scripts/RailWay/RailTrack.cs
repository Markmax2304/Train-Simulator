using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public class RailTrack
    {
        AbstractRailFactory railFactory;

        List<RailWay> railWays;

        public RailTrack(List<Tile> tiles, ObjectPool railPool)
        {
            railFactory = new RailTrackFactory(railPool);
            railWays = new List<RailWay>();

            for(int i = 0; i < tiles.Count; i++) {
                railWays.Add(railFactory.CreateRailWay(tiles[i]));
            }
        }
    }
}
