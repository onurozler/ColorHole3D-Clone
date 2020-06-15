using System;
using Game.CollectableObjectSystem.Managers;
using Game.LevelSystem.Managers;
using Game.LevelSystem.Model;
using Game.Managers;
using UniRx;
using UnityEngine;
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
            _currentLevel = 1;

            MessageBroker.Default.Receive<LevelEvent>().Subscribe((level) =>
            {
                if(level == LevelEvent.LEVEL_SUCCESSFUL)
                    GenerateNewLevel();
                else
                {
                    _currentLevel--;
                    GenerateNewLevel();
                }
            });
        }

        public void GenerateNewLevel()
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
                }
                
                MessageBroker.Default.Publish(level.CollectableDatas.Count);
            }
            else
            {
                _currentLevel = 1;
                GenerateNewLevel();
            }
        }
    }
}
