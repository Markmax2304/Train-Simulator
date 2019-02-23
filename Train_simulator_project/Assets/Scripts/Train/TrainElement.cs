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

        bool nextRotation = false;
        int rotateDegree = 0;
        TileSides localFromArrive = TileSides.None;

        public virtual void Awake()
        {
            spriteRend = GetComponent<SpriteRenderer>();
            _transform = transform;
        }

        // ------------------------ Movement -------------------
        public virtual void MoveForwardChainPosition(Vector2 movePos)
        {
            Vector2 backPos = _transform.position;
            _transform.position = movePos;
            if (backTrainElement != null) {
                backTrainElement.MoveForwardChainPosition(backPos);
            }
            // define to need rotation
            if (nextRotation) {
                SetRotation(rotateDegree);
                nextRotation = false;
                if (backTrainElement != null) {
                    backTrainElement.SetReadyToRotation(localFromArrive);
                }
            }
        }

        public void SetReadyToRotation(TileSides from)
        {
            nextRotation = true;
            switch (from) {
                case TileSides.Right:
                    rotateDegree = 0;
                    break;
                case TileSides.Bottom:
                    rotateDegree = 90;
                    break;
                case TileSides.Left:
                    rotateDegree = 180;
                    break;
                case TileSides.Top:
                    rotateDegree = 270;
                    break;
            }
            localFromArrive = from;
        }

        public virtual void SetRotation(int degree)
        {
            // вращаем по часовой стрелке вокруг оси Z
            _transform.rotation = Quaternion.Euler(Vector3.back * degree);
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

        public int Rotation {
            get { return (int)_transform.rotation.eulerAngles.z; }
            set { _transform.Rotate(Vector3.back * value); }
        }

        public void SetColor(Color color)
        {
            spriteRend.color = color;
        }

        public void SetChainColor(Color color)
        {
            spriteRend.color = color;
            if (backTrainElement != null) {
                backTrainElement.SetChainColor(color);
            }
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
