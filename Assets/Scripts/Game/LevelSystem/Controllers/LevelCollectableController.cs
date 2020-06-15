using System;
using Game.CollectableObjectSystem.Base;
using Game.CollectableObjectSystem.Managers;
using Game.LevelSystem.Model;
using UniRx;
using UnityEngine;
using Utils;
using Zenject;

namespace Game.LevelSystem.Controllers
{
    public class LevelCollectableController : MonoBehaviour
    {
        private CollectablePool _collectablePool;
        private float _currentLevelIncrease;

        public Action<float> OnCollected;

        [Inject]
        private void OnInstaller(CollectablePool collectablePool)
        {
            _collectablePool = collectablePool;
            _currentLevelIncrease = 0;
            
            MessageBroker.Default.Receive<int>().Subscribe(GetCurrentLevelDetails);
        }

        private void OnCollisionEnter(Collision other)
        {
            var collectable = other.gameObject.GetComponent<CollectableBase>();
            if (collectable != null)
            {
                _collectablePool.Despawn(collectable);
                
                if(collectable.CollectableType == CollectableType.BAD)
                    MessageBroker.Default.Publish(LevelEvent.LEVEL_FAIL);
                else 
                    CheckLevelStatus();
            }
        }

        private void GetCurrentLevelDetails(int levelCount)
        {
            _currentLevelIncrease = 1f/levelCount;
        }

        private void CheckLevelStatus()
        {
            if(_collectablePool.NumActive <= 0)
            {
                Observable.Timer(TimeSpan.FromSeconds(1)).Subscribe(_ =>
                {
                    MessageBroker.Default.Publish(LevelEvent.LEVEL_SUCCESSFUL);
                });
            }
            
            OnCollected.SafeInvoke(_currentLevelIncrease);
        }
    }
}
