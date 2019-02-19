using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public class PoolManager : MonoBehaviour
    {
        Dictionary<TypeObjectPool, ObjectPool> pools;
        [SerializeField] PoolInfo[] poolInfo;

        void Awake()
        {
            pools = new Dictionary<TypeObjectPool, ObjectPool>();
            for(int i = 0; i < poolInfo.Length; i++) {
                Transform parent = poolInfo[i].parent == null ? transform : poolInfo[i].parent;
                pools.Add(poolInfo[i].type, new ObjectPool(poolInfo[i].prefab, parent, poolInfo[i].count));
            }

            InitializePools();
        }

        void InitializePools()
        {
            foreach(ObjectPool pool in pools.Values) {
                pool.InitializePool();
            }
        }

        public ObjectPool GetObjectPool(TypeObjectPool type)
        {
            return pools[type];
        }

        [System.Serializable]
        public struct PoolInfo
        {
            public TypeObjectPool type;
            public int count;
            public GameObject prefab;
            public Transform parent;
        }
    }
}
