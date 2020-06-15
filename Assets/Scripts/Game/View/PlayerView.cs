using DG.Tweening;
using Game.LevelSystem.Controllers;
using Game.LevelSystem.Model;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.View
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] 
        private Image _levelFill;

        private float _fillAmount = 0;

        private LevelCollectableController _levelCollectableController;
        
        [Inject]
        private void OnInstaller(LevelCollectableController levelCollectableController)
        {
            _levelCollectableController = levelCollectableController;
            
            _fillAmount = 0;
            _levelCollectableController.OnCollected += UpdateFill;

            MessageBroker.Default.Receive<LevelEvent>().Subscribe((level) =>
            {
                _levelFill.fillAmount = 0;
                _fillAmount = 0;
            });
        }

        private void UpdateFill(float fillAmount)
        {
            _fillAmount += fillAmount;
            DOVirtual.Float(_levelFill.fillAmount, _fillAmount, 0.2f,(value) =>
            {
                _levelFill.fillAmount = value;
            });
            
        }
    }
}
