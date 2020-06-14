using System.Collections.Generic;
using UnityEngine;

namespace Game.LevelSystem.Model
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Level/Create New Level", order = 1)]
    public class LevelData : ScriptableObject
    {
        public int ID;
        public List<Vector3> CollectablePositions;
    }
}
