using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public abstract class RailWay : MonoBehaviour
    {
        [SerializeField] protected RailSpriteStorage spriteStorage;

        protected SpriteRenderer spriteRend;
        protected Transform _transform;

        void Awake()
        {
            spriteRend = GetComponent<SpriteRenderer>();
            _transform = transform;
        }

        public abstract void SetPosition(Vector2 pos);
        public virtual void SetRotate(int degree) { }
        public abstract void SetSprite(TypeRailWay type);

        //public abstract int GetTimeOut();
    }
}
