using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    // maybe singleton but without free access from any point
    public class GameController : MonoBehaviour
    {
        [SerializeField] Tile testTile;

        AbstractRailFactory railFactory;

        void Start()
        {
            railFactory = GetComponent<AbstractRailFactory>();
            RailTrackController trackController = new RailTrackController(testTile, railFactory);
        }

        void Update()
        {

        }
    }

    [System.Serializable]
    public struct Tile
    {
        public Transform prefab;
        public Vector2 position;
        public bool isStation;
        public List<SidesLink> links;
    }

    [System.Serializable]
    public struct SidesLink
    {
        public TileSides begin;
        public TileSides end;

        public SidesLink(TileSides begin, TileSides end)
        {
            this.begin = begin;
            this.end = end;
        }
    }
}
