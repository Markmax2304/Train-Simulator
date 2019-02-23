using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public class TrainController
    {
        AbstractTrainFactory trainFactory;

        List<Train> trainList;
        Queue<Train> trainQueue;

        public TrainController(List<TrainInfo> trains, ObjectPool lokomotivePool, ObjectPool carriagePool)
        {
            trainFactory = new TrainFactory(lokomotivePool, carriagePool);

            trainList = new List<Train>();
            trainQueue = new Queue<Train>();
            for(int i = 0; i < trains.Count; i++) {
                trainList.Add(trainFactory.CreateTrain(trains[i]));
            }
        }

        public List<Train> GetTrainList()
        {
            return trainList;
        }

        public bool CanGetNextTrain()
        {
            return trainQueue.Count > 0;
        }

        public Train GetNextTrain()
        {
            if(CanGetNextTrain()) {
                Train train = trainQueue.Dequeue();
                return train;
            }
            return null;
        }

        public void ResetTrainQueue()
        {
            trainQueue.Clear();
            for(int i = 0; i < trainList.Count; i++) {
                trainQueue.Enqueue(trainList[i]);
            }
        }
    }
}
