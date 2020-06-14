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

        public Action<int> OnLevelGenerated;
        
        [Inject]
        private void OnInstaller(CollectablePool collectablePool, LevelManager levelManager, AssetManager assetManager)
        {
            _collectablePool = collectablePool;
            _levelManager = levelManager;
            _assetManager = assetManager;
            
            Start();
        }

        private void Start()
        {
            var level = _levelManager.LoadLevel(1);
            
            foreach (var collectableData in level.CollectableDatas)
            {
                var collectable = _collectablePool.Spawn();
                collectable.SetValues(collectableData.CollectableType,collectableData.Position,
                    _assetManager.GetCollectableMaterial(collectableData.CollectableType));
                
                OnLevelGenerated.SafeInvoke(level.CollectableDatas.Count);
            }
        }
    }
}
