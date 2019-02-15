using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public class RailTrack
    {
        AbstractRailFactory railFactory;

        List<RailWay> railWays;
        List<Station> railStations;

        public RailTrack(List<Tile> tiles, ObjectPool railPool, ObjectPool stationPool)
        {
            railFactory = new RailTrackFactory(railPool, stationPool);
            railWays = new List<RailWay>();
            railStations = new List<Station>();

            for(int i = 0; i < tiles.Count; i++) {
                // create tile
            }
        }
    }
}
