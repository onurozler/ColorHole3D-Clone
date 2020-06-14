using Game.CollectableObjectSystem.Managers;
using Game.LevelSystem.Managers;
using Game.Managers;
using UnityEngine;
using Zenject;

namespace Game.LevelSystem.Controllers
{
    public class LevelGenerator : MonoBehaviour
    {
        private AssetManager _assetManager;
        private LevelManager _levelManager;
        private CollectablePool _collectablePool;
        private CollectableManager _collectableManager;
        
        [Inject]
        private void OnInstaller(CollectablePool collectablePool, LevelManager levelManager, AssetManager assetManager,
            CollectableManager collectableManager)
        {
            _collectablePool = collectablePool;
            _levelManager = levelManager;
            _assetManager = assetManager;
            _collectableManager = collectableManager;
        }

        private void Start()
        {
            var level = _levelManager.LoadLevel(1);
            
            foreach (var collectableData in level.CollectableDatas)
            {
                var collectable = _collectablePool.Spawn();
                collectable.SetValues(collectableData.CollectableType,collectableData.Position,
                    _assetManager.GetCollectableMaterial(collectableData.CollectableType));
                
                _collectableManager.Add(collectable);
            }
        }
    }
}
