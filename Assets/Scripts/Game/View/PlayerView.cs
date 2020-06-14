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

        private LevelCollectableController _levelCollectableController;
        
        [Inject]
        private void OnInstaller(LevelCollectableController levelCollectableController)
        {
            _levelCollectableController = levelCollectableController;
            
            _levelFill.fillAmount = 0;
            _levelCollectableController.OnCollected += UpdateFill;

            MessageBroker.Default.Receive<LevelEvent>().Subscribe((level) => _levelFill.fillAmount = 0);
        }

        private void UpdateFill(float fillAmount)
        {
            _levelFill.fillAmount += fillAmount;
        }
    }
}
