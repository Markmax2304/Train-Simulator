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

        GameLooper gameLooper;
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

            gameLooper = GetComponent<GameLooper>();
            gameLooper.Initialize(trainController, trackController);
        }
    }

    [System.Serializable]
    public struct TrainInfo
    {
        public StateTrainElement headPosition;
        public List<StateTrainElement> carriagePositions;
        public Color trainColor;
        public TypeTrain type;
        public TileSides fromArrive;
    }

    [System.Serializable]
    public struct StateTrainElement
    {
        public Vector2 position;
        public int rotateDegree;
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
