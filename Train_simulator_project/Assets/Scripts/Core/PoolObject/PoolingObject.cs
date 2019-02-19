using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public class PoolingObject : MonoBehaviour
    {
        public void ReturnToPool()
        {
            // maybe move to start position and reset rotation?
            gameObject.SetActive(false);
        }
    }
}
