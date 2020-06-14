using System;
using Game.CollectableObjectSystem.Base;
using UnityEngine;

namespace Game.CollectableObjectSystem.Model
{
    [Serializable]
    public class CollectableData
    {
        public Vector3 Position;
        public CollectableType CollectableType;

        public CollectableData(Vector3 pos, CollectableType type)
        {
            Position = pos;
            CollectableType = type;
        }
    }
}
