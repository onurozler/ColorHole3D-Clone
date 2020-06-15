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
        private bool _isActive;
        private CollectablePool _collectablePool;
        private int _currentLevelCondition;
        private float _currentLevelIncrease;

        public Action<float> OnCollected;

        [Inject]
        private void OnInstaller(CollectablePool collectablePool)
        {
            _collectablePool = collectablePool;
            _currentLevelIncrease = 0;
            _isActive = true;
            
            MessageBroker.Default.Receive<int>().Subscribe(GetCurrentLevelDetails);
            MessageBroker.Default.Receive<LevelEvent>().Subscribe((level) => _isActive = true);
        }

        private void OnCollisionEnter(Collision other)
        {
            if(!_isActive)
                return;
            
            var collectable = other.gameObject.GetComponent<CollectableBase>();
            if (collectable != null)
            {
                _collectablePool.Despawn(collectable);

                if (collectable.CollectableType == CollectableType.BAD)
                {
                    _isActive = false;

                    Observable.Timer(TimeSpan.FromSeconds(1)).Subscribe(_ =>
                    {
                        MessageBroker.Default.Publish(LevelEvent.LEVEL_FAIL);
                    });
                }
                else 
                    CheckLevelStatus();
            }
        }

        private void GetCurrentLevelDetails(int levelCount)
        {
            _currentLevelIncrease = 1f/levelCount;
            _currentLevelCondition = levelCount;
        }

        private void CheckLevelStatus()
        {
            _currentLevelCondition--;
            if(_currentLevelCondition <= 0)
            {
                _isActive = false;
                Observable.Timer(TimeSpan.FromSeconds(1)).Subscribe(_ =>
                {
                    MessageBroker.Default.Publish(LevelEvent.LEVEL_SUCCESSFUL);
                });
            }
            
            OnCollected.SafeInvoke(_currentLevelIncrease);
        }
    }
}
