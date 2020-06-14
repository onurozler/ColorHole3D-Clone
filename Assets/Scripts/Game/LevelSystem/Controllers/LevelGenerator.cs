using System;
using Game.CollectableObjectSystem.Managers;
using Game.LevelSystem.Managers;
using Game.Managers;
using UniRx;
using Utils;
using Zenject;

namespace Game.LevelSystem.Controllers
{
    public class LevelGenerator
    {
        private AssetManager _assetManager;
        private LevelManager _levelManager;
        private CollectablePool _collectablePool;

        private static int _currentLevel;
        
        [Inject]
        private void OnInstaller(CollectablePool collectablePool, LevelManager levelManager, AssetManager assetManager)
        {
            _collectablePool = collectablePool;
            _levelManager = levelManager;
            _assetManager = assetManager;
            _currentLevel = 0;
        }

        public void GenerateLevel()
        {
            var level = _levelManager.LoadLevel(_currentLevel);

            if (level != null)
            {
                _currentLevel++;
                
                foreach (var collectableData in level.CollectableDatas)
                {
                    var collectable = _collectablePool.Spawn();
                    collectable.SetValues(collectableData.CollectableType,collectableData.Position,
                        _assetManager.GetCollectableMaterial(collectableData.CollectableType));
                
                    MessageBroker.Default.Publish(level.CollectableDatas);
                }
            }
        }
    }
}
