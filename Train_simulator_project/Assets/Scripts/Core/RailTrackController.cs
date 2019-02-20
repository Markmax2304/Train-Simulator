using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public class RailTrackController
    {
        RailTrack track;

        public RailTrackController(List<Tile> tiles, ObjectPool railPool, ObjectPool stationPool)
        {
            track = new RailTrack(tiles, railPool, stationPool);
        }
    }
}
