using System.Collections.Generic;
using UnityEngine;

namespace Game.CollectableObjectSystem.Model
{
    [CreateAssetMenu(fileName = "CollectableType", menuName = "Collectable Type/Create New Type", order = 1)]
    public class CollectablePack : ScriptableObject
    {
        public string CollectableName;
        public List<Vector3> CollectablePositions;
    }
}
