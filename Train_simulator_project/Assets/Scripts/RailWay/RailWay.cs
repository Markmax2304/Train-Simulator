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

        List<SidesLink> links;

        void Awake()
        {
            spriteRend = GetComponent<SpriteRenderer>();
            _transform = transform;
        }

        public List<TileSides> GetPossibleSidesToWay(TileSides from)
        {
            List<TileSides> sides = new List<TileSides>();
            for(int i = 0; i < links.Count; i++) {
                if (links[i].begin == links[i].end)
                    continue;

                if(links[i].begin == from) {
                    sides.Add(links[i].end);
                }
                else if(links[i].end == from) {
                    sides.Add(links[i].begin);
                }
            }
            return sides;
        }

        public void SetLinks(List<SidesLink> list)
        {
            links = list;
        }

        public Vector2 Position {
            get { return _transform.position; }
            set { _transform.position = value; }
        }

        public virtual void SetRotate(int degree) { }
        public abstract void SetSprite(TypeRailWay type);

        public abstract int GetTimeOut();
    }
}
