using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public class RailTrackFactory : AbstractRailFactory
    {
        List<RailWay> railPool;
        List<Station> stationPool;

        void Awake()
        {
            railPool = new List<RailWay>();
            stationPool = new List<Station>();
        }

        void SetEnableObject(GameObject obj, bool state)
        {
            obj.SetActive(state);
        }

        //===================================================================
        //          Rail Pool party
        //===================================================================

        void SetRailPool (int count)
        {
            for(int i = railPool.Count; i < count; i++) {

            }
        }

        void PushRail(RailWay rail)
        {
            if(!railPool.Contains(rail)) {
                SetEnableObject(rail.gameObject, false);
                railPool.Add(rail);
            }
            else {
                Debug.Log("Error! railPool already contain pushed object");
            }
        }

        RailWay PullRail()
        {
            if(railPool.Count > 0) {
                RailWay tempRail = railPool[0];
                SetEnableObject(tempRail.gameObject, true);
                railPool.RemoveAt(0);
                return tempRail;
            }
            else {
                // extend pool of objects and return one
            }
        }

        //===================================================================
        //          Station Pool party
        //===================================================================

        void SetStationPool(int count)
        {
            for (int i = stationPool.Count; i < count; i++) {

            }
        }

        void PushStation(Station station)
        {
            if (!stationPool.Contains(station)) {
                SetEnableObject(station.gameObject, false);
                stationPool.Add(station);
            }
            else {
                Debug.Log("Error! stationPool already contain pushed object");
            }
        }

        Station PullStation()
        {
            if (stationPool.Count > 0) {
                Station tempStation = stationPool[0];
                SetEnableObject(tempStation.gameObject, true);
                stationPool.RemoveAt(0);
                return tempStation;
            }
            else {
                // extend pool of objects and return one
            }
        }

        //===================================================================
        //          abstract factory party
        //===================================================================

        public override RailWay CreateRailWay(Tile tile)
        {
            return null;
        }

        public override void DeleteRailWay(RailWay rail)
        {
            
        }

        public override Station CreateStation(Tile tile)
        {
            return null;
        }

        public override void DeleteStation(Station station)
        {
            
        }
    }
}
