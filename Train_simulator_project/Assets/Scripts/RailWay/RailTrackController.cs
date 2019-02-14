using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public class RailTrackController
    {
        RailTrack track;

        public RailTrackController(Tile tile, AbstractRailFactory railFactory)
        {
            track = new RailTrack(tile, railFactory);
        }
    }
}
