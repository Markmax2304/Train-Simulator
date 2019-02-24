using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public class RailTrackController
    {
        AbstractRailFactory railFactory;

        List<RailWay> railWays;
        RailWay[,] railWayMap;

        int height;
        int width;

        public RailTrackController(List<Tile> tiles, ObjectPool railPool, ObjectPool stationPool)
        {
            railFactory = new RailTrackFactory(railPool, stationPool);
            railWays = new List<RailWay>();
            for (int i = 0; i < tiles.Count; i++) {
                railWays.Add(railFactory.CreateRailWay(tiles[i]));
            }

            CalculateMapSize(out height, out width);
            CreateRailMap();
        }

        public int GetHaltTimeByPosition(Vector2 pos)
        {
            RailWay rail = railWayMap[(int)pos.x, (int)pos.y];
            if (rail != null) {
                return rail.GetTimeOut();
            }
            else {
                Debug.Log("Checked position(" + pos + ") is beyond limits of rail track.");
                return 0;
            }
        }

        public bool GetPossibleWay(Vector2 point, TileSides from, out Vector2 nextPoint)
        {
            List<TileSides> possibleWays = railWayMap[(int)point.x, (int)point.y].GetPossibleSidesToWay(from);

            //define one of sides
            nextPoint = point;
            if (possibleWays.Count == 0)
                return false;

            int randomSideIndex = Random.Range(0, possibleWays.Count);
            TileSides side = possibleWays[randomSideIndex];

            switch (side) {
                case TileSides.Top:
                    nextPoint += Vector2.up;
                    break;
                case TileSides.Right:
                    nextPoint += Vector2.right;
                    break;
                case TileSides.Bottom:
                    nextPoint += Vector2.down;
                    break;
                case TileSides.Left:
                    nextPoint += Vector2.left;
                    break;
            }

            return true;
        }

        void CreateRailMap()
        {
            railWayMap = new RailWay[width, height];
            for (int i = 0; i < railWays.Count; i++) {
                int x = (int)railWays[i].Position.x;
                int y = (int)railWays[i].Position.y;
                railWayMap[x, y] = railWays[i];
            }
        }

        void CalculateMapSize(out int height, out int width)
        {
            int minH = (int)railWays[0].Position.y;
            int minW = (int)railWays[0].Position.x;

            int maxH = (int)railWays[0].Position.y;
            int maxW = (int)railWays[0].Position.x;

            for (int i = 1; i < railWays.Count; i++) {
                if (maxH < (int)railWays[i].Position.y)
                    maxH = (int)railWays[i].Position.y;
                if (maxW < (int)railWays[i].Position.x)
                    maxW = (int)railWays[i].Position.x;

                if (minH > (int)railWays[i].Position.y)
                    minH = (int)railWays[i].Position.y;
                if (minW > (int)railWays[i].Position.x)
                    minW = (int)railWays[i].Position.x;
            }

            height = maxH - minH + 1;
            width = maxW - minW + 1;
        }
    }
}
