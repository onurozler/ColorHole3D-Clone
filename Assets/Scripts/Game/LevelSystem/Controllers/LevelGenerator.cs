using Game.CollectableObjectSystem.Managers;
using Game.LevelSystem.Managers;
using UnityEngine;
using Zenject;

namespace Game.LevelSystem.Controllers
{
    public class LevelGenerator : MonoBehaviour
    {
        private LevelManager _levelManager;
        private CollectablePool _collectablePool;
        
        [Inject]
        private void OnInstaller(CollectablePool collectablePool, LevelManager levelManager)
        {
            _collectablePool = collectablePool;
            _levelManager = levelManager;
        }
        
    }
}
