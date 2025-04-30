using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;
using Zenject;

namespace DI.Controllers
{
    public class LevelController : IInitializable
    {
        private LevelView _levelView;

        public LevelController(LevelView levelView)
        {
            _levelView = levelView;
            Init();
        }


        private void Init()
        {
            _levelView.Init();
        }

        public void Initialize()
        {
        }
    }
}