using System;
using Game.CollectableObjectSystem.Managers;
using UnityEngine;
using Zenject;

namespace Game.LevelSystem
{
    public class LevelGenerator : MonoBehaviour
    {
        private CollectablePool _collectablePool;
        
        [Inject]
        private void OnInstaller(CollectablePool collectablePool)
        {
            _collectablePool = collectablePool;
        }
        
    }
}
