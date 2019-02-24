using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public class GameLooper : MonoBehaviour
    {
        public float clockPerSecond = 1f;
        float timeDelay;
        float timeCounter = 0;
        int countTick = 0;

        TrainController trainContr;
        RailTrackController railContr;

        public void Initialize(TrainController trainController, RailTrackController railController)
        {
            trainContr = trainController;
            railContr = railController;
        }

        void Start()
        {
            timeDelay = 1 / clockPerSecond;
        }

        void FixedUpdate()
        {
            timeCounter += Time.fixedDeltaTime;
            if(timeCounter >= timeDelay) {
                countTick++;
                Tick();
                timeCounter = 0;
                
            }
        }

        void Tick()
        {
            trainContr.ResetTrainQueue();
            while (trainContr.CanGetNextTrain()) {
                Train train = trainContr.GetNextTrain();
                if (countTick % train.GetRate() == 0) {
                    TrainTurn(train);
                }
            }

            // Verify Colliding part
        }

        void TrainTurn(Train train)
        {
            if (!train.IsTrainEnable())
                return;

            Vector2 currentPos = train.GetPositionHead();
            TileSides from = train.GetFromArrive();
            // station halt
            /*int halt = railContr.GetHaltTimeByPosition(currentPos);
            if(halt > 0) {

            }*/

            Vector2 nextPos;
            if (railContr.GetPossibleWay(currentPos, from, out nextPos)) {
                train.MoveToPosition(nextPos);
            }
            else {
                Debug.Log("Train is in endup.");
                train.SetEnable(false);
            }
        }
    }
}
