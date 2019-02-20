using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public abstract class AbstractTrainFactory
    {
        protected ObjectPool suburbanPool;
        protected ObjectPool expressPool;

        public AbstractTrainFactory(ObjectPool suburbans, ObjectPool express)
        {
            suburbanPool = suburbans;
            expressPool = express;
        }

        public abstract Train CreateTrain(TrainInfo tile);
    }

    public class TrainFactory : AbstractTrainFactory
    {
        public TrainFactory(ObjectPool suburbans, ObjectPool express) : base(suburbans, express) { }

        public override Train CreateTrain(TrainInfo tile)
        {
            return null; // continue point
        }
    }
}
