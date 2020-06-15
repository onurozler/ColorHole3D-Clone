using System.Linq;
using Game.CollectableObjectSystem.Base;
using Game.CollectableObjectSystem.Managers;
using Game.HoleSystem.Base;
using Game.LevelSystem.Managers;
using Game.LevelSystem.Model;
using Game.Managers;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.LevelSystem.Controllers
{
    public class LevelGenerator
    {
        private HoleBase _holeBase;
        private AssetManager _assetManager;
        private LevelManager _levelManager;
        private CollectablePool _collectablePool;

        private static int _currentLevel;
        
        [Inject]
        private void OnInstaller(CollectablePool collectablePool, LevelManager levelManager, AssetManager assetManager,
            HoleBase holeBase)
        {
            _holeBase = holeBase;
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
            _collectablePool.ResetPool();
            var level = _levelManager.LoadLevel(_currentLevel);
            if (level != null)
            {
                _currentLevel++;
                _holeBase.transform.position = new Vector3(3.25f,0.1f,-3f);
                foreach (var collectableData in level.CollectableDatas)
                {
                    var collectable = _collectablePool.Spawn();
                    collectable.SetValues(collectableData.CollectableType,collectableData.Position,
                        _assetManager.GetCollectableMaterial(collectableData.CollectableType));
                }

                var badCount = level.CollectableDatas.Count(x => x.CollectableType == CollectableType.BAD);
                MessageBroker.Default.Publish(level.CollectableDatas.Count - badCount);
            }
            else
            {
                _currentLevel = 1;
                GenerateNewLevel();
            }
        }
    }
}
