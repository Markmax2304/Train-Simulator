using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public abstract class Train
    {
        TrainElement head;
        Color trainColor;
        TileSides fromArrive;

        // -------------- Initialize ------------------
        public Train(TrainElement head, Color color, TileSides from)
        {
            this.head = head;
            trainColor = color;
            fromArrive = from;
            head.SetColor(color);
        }

        public void SetColor(Color color)
        {
            trainColor = color;
            head.SetChainColor(color);
        }

        // --------------- Manage of carriage ---------------------
        public void AddCarriage(TrainElement carriage, StateTrainElement state)
        {
            carriage.SetColor(trainColor);
            carriage.Position = state.position;
            carriage.Rotation = state.rotateDegree;
            head.AddCarriage(carriage);
        }

        public void DeleteCarriage()
        {
            head.DeleteCarriage();
        }

        // ------------------- Movement ---------------------
        public bool IsTrainEnable()
        {
            return head != null;
        }

        public Vector2 GetPositionHead()
        {
            return head.Position;
        }

        public TileSides GetFromArrive()
        {
            return fromArrive;
        }

        public void MoveToPosition(Vector2 position)
        {
            Vector2 offset = head.Position - position;
            TileSides newFromArrive = CalculateSideByOffset(offset);

            if (newFromArrive != fromArrive) {
                head.SetReadyToRotation(newFromArrive);
            }
            fromArrive = newFromArrive;

            head.MoveForwardChainPosition(position);
        }

        TileSides CalculateSideByOffset(Vector2 offset)
        {
            if(offset == Vector2.up) {
                return TileSides.Top;
            }
            else if (offset == Vector2.right) {
                return TileSides.Right;
            }
            else if (offset == Vector2.down) {
                return TileSides.Bottom;
            }
            else if (offset == Vector2.left) {
                return TileSides.Left;
            }
            else {
                return TileSides.None;
            }
        }
    }
}
