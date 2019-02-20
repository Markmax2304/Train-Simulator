using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public class TrainController
    {
        AbstractTrainFactory trainFactory;

        List<Train> trainsList;

        public TrainController(List<TrainInfo> trains, ObjectPool lokomotivePool, ObjectPool carriagePool)
        {
            trainFactory = new TrainFactory(lokomotivePool, carriagePool);

            trainsList = new List<Train>();
            for(int i = 0; i < trains.Count; i++) {
                trainsList.Add(trainFactory.CreateTrain(trains[i]));
            }
        }
    }
}
