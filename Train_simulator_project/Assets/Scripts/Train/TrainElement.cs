using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public abstract class TrainElement : MonoBehaviour
    {
        [SerializeField] protected TrainSpriteStorage spriteStorage;

        protected SpriteRenderer spriteRend;
        protected Transform _transform;

        protected TrainElement frontTrainElement;
        protected TrainElement backTrainElement;

        public virtual void Awake()
        {
            spriteRend = GetComponent<SpriteRenderer>();
            _transform = transform;
        }

        // ------------------------ Movement -------------------
        public virtual void MoveChainPosition(Vector2 movePos)
        {
            Vector2 backPos = _transform.position;
            _transform.position = movePos;
            if (backTrainElement != null) {
                backTrainElement.MoveChainPosition(backPos);
            }
        }

        public virtual void SetRotation(int degree)
        {
            // вращаем по часовой стрелке вокруг оси Z
            _transform.Rotate(Vector3.back * degree);
        }

        // --------------------- Connection ----------------------
        public virtual void AddCarriage(TrainElement carriage)
        {
            if(backTrainElement != null) {
                backTrainElement.AddCarriage(carriage);
            }
            else {
                ConnectBackCarriage(carriage);
            }
        }

        public virtual void DeleteCarriage()
        {
            if(backTrainElement != null) {
                backTrainElement.DeleteCarriage();
            }
            else {
                frontTrainElement.DisconnectBackCarriage();
                GetComponent<PoolingObject>().ReturnToPool();
            }
        }

        protected virtual void ConnectFrontCarriage(TrainElement carriage) { }

        public virtual void ConnectBackCarriage(TrainElement carriage)
        {
            backTrainElement = carriage;
            carriage.ConnectFrontCarriage(this);
        }

        protected virtual void DisconnectFrontCarriage() { }

        public virtual void DisconnectBackCarriage()
        {
            if (backTrainElement == null) {
                return;
            }
            backTrainElement.DisconnectFrontCarriage();
            backTrainElement = null;
        }

        // ------------------- Initialize ----------------------
        public Vector2 Position {
            get { return _transform.position; }
            set { _transform.position = value; }
        }

        public void SetSprite(TypeCarriage type)
        {
            for(int i = 0; i < spriteStorage.trainSprites.Length; i++) {
                if(spriteStorage.trainSprites[i].type == type) {
                    spriteRend.sprite = spriteStorage.trainSprites[i].sprite;
                    return;
                }
            }
            Debug.Log("Error. Dont found sprite type - " + type.ToString());
        }
    }
}
