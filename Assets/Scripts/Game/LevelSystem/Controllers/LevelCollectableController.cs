﻿using System;
using Game.CollectableObjectSystem.Base;
using Game.CollectableObjectSystem.Managers;
using UniRx;
using UnityEngine;
using Utils;
using Zenject;

namespace Game.LevelSystem.Controllers
{
    public class LevelCollectableController : MonoBehaviour
    {
        private CollectablePool _collectablePool;

        public Action<float> OnCollected;

        [Inject]
        private void OnInstaller(CollectablePool collectablePool)
        {
            _collectablePool = collectablePool;
        }

        private void OnCollisionEnter(Collision other)
        {
            var collectable = other.gameObject.GetComponent<CollectableBase>();
            if (collectable != null)
            {
                _collectablePool.Despawn(collectable);
                CheckLevelStatus();
                OnCollected.SafeInvoke(1f/_collectablePool.NumActive);
            }
        }

        private void CheckLevelStatus()
        {
            
        }
    }
}
