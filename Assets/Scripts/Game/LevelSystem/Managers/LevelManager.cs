using System.Collections.Generic;
using System.Linq;
using Game.LevelSystem.Model;
using Zenject;

namespace Game.LevelSystem.Managers
{
    public class LevelManager
    {
        private List<LevelData> _levelDatas;
        
        [Inject]
        private void OnInstaller(List<LevelData> levelDatas)
        {
            _levelDatas = levelDatas;
        }
        
        public LevelData LoadLevel(int index)
        {
            return _levelDatas.FirstOrDefault(x => x.ID == index);
        }
    }
}
