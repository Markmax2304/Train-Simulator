using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public class GameLooper : MonoBehaviour
    {
        public float clock = 1f;

        TrainController trainContr;
        RailTrackController railContr;

        public void Initialize(TrainController trainController, RailTrackController railController)
        {
            trainContr = trainController;
            railContr = railController;
        }

        void Update()
        {
            if (Input.GetMouseButtonUp(0)) {
                Tick();
            }
        }

        void Tick()
        {
            trainContr.ResetTrainQueue();
            while (trainContr.CanGetNextTrain()) {
                Train train = trainContr.GetNextTrain();
                TrainTurn(train);
            }

            // Verify Colliding part
        }

        void TrainTurn(Train train)
        {
            if (!train.IsTrainEnable())
                return;

            Vector2 currentPos = train.GetPositionHead();
            TileSides from = train.GetFromArrive();
            Vector2 nextPos;
            if (railContr.GetPossibleWay(currentPos, from, out nextPos)) {
                train.MoveToPosition(nextPos);
            }
            else {
                Debug.Log("Train is in endup.");
            }
        }
    }
}
