using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    // maybe singleton but without free access from any point
    public class GameController : MonoBehaviour
    {
        [SerializeField] List<Tile> testTiles;

        PoolManager poolManager;

        void Start()
        {
            poolManager = GetComponent<PoolManager>();
            RailTrackController trackController = new RailTrackController(testTiles, poolManager.GetObjectPool(TypeObjectPool.Rail));
        }
    }

    [System.Serializable]
    public struct Train
    {

    }

    [System.Serializable]
    public struct Tile
    {
        public Vector2 position;
        public List<SidesLink> links;
    }

    [System.Serializable]
    public struct SidesLink
    {
        public TileSides begin;
        public TileSides end;
    }
}
