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

        public RailTrack(Tile tile, AbstractRailFactory railFactory)
        {
            this.railFactory = railFactory;
            railWays = new List<RailWay>();
            railStations = new List<Station>();

            if (tile.isStation)
                railStations.Add(railFactory.CreateStation(tile));
            else
                railWays.Add(railFactory.CreateRailWay(tile));
        }
    }
}
