using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public abstract class AbstractTrainFactory
    {
        protected ObjectPool locomotivesPool;
        protected ObjectPool carriagesPool;

        public AbstractTrainFactory(ObjectPool locomotives, ObjectPool carriages)
        {
            locomotivesPool = locomotives;
            carriagesPool = carriages;
        }

        public abstract Train CreateTrain(TrainInfo tile);
        public abstract TrainElement GetCarriage();
    }

    public class TrainFactory : AbstractTrainFactory
    {
        public TrainFactory(ObjectPool locomotives, ObjectPool carriages) : base(locomotives, carriages) { }

        public override Train CreateTrain(TrainInfo element)
        {
            TrainElement locomotive = locomotivesPool.RealeseObject().GetComponent<TrainElement>();
            locomotive.Position = element.headPosition.position;
            locomotive.Rotation = element.headPosition.rotateDegree;

            Train train = null;
            if(element.type == TypeTrain.Suburban) {
                train = new SuburbanTrain(locomotive, element.trainColor);
            }
            else if(element.type == TypeTrain.Express) {
                train = new ExpressTrain(locomotive, element.trainColor);
            }

            for(int i = 0; i < element.carriagePositions.Count; i++) {
                TrainElement carriage = carriagesPool.RealeseObject().GetComponent<TrainElement>();
                train.AddCarriage(carriage, element.carriagePositions[i]);
            }

            return train;
        }

        public override TrainElement GetCarriage()
        {
            return carriagesPool.RealeseObject().GetComponent<TrainElement>();
        }
    }
}
