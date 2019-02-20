using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    // maybe singleton but without free access from any point
    public class GameController : MonoBehaviour
    {
        [SerializeField] List<Tile> testTiles;
        [SerializeField] List<TrainInfo> testTrains;

        PoolManager poolManager;

        RailTrackController trackController;
        TrainController trainController;

        void Start()
        {
            poolManager = GetComponent<PoolManager>();
            trackController = new RailTrackController(testTiles, 
                poolManager.GetObjectPool(TypeObjectPool.Rail), 
                poolManager.GetObjectPool(TypeObjectPool.Station));
            trainController = new TrainController(testTrains,
                poolManager.GetObjectPool(TypeObjectPool.Lokomotive),
                poolManager.GetObjectPool(TypeObjectPool.Carriage));
        }
    }

    [System.Serializable]
    public struct TrainInfo
    {
        public Vector2 headPosition;
        public List<Vector2> carriagePositions;
        public Color trainColor;
        public TypeTrain type;
    }

    [System.Serializable]
    public struct Tile
    {
        public Vector2 position;
        public bool isStation;
        public List<SidesLink> links;
    }

    [System.Serializable]
    public struct SidesLink
    {
        public TileSides begin;
        public TileSides end;
    }
}
