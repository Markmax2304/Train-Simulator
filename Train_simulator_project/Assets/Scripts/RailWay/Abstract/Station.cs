using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public abstract class Station : MonoBehaviour
    {
        SpriteRenderer spriteRend;

        void Start()
        {
            spriteRend = GetComponent<SpriteRenderer>();
        }

        public abstract void Initialize(Sprite sprite);

        void Update()
        {

        }
    }
}
