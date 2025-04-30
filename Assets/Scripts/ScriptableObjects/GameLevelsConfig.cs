using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameLevelsConfig", menuName = "ScriptableObjects/GameLevelsConfig", order = 0)]
    public class GameLevelsConfig : ScriptableObject
    {
        [SerializeField] private Level[] _levelsPrefab;
        [SerializeField] private int _selectedLevelIndex;
        private int _openedLevelsCount;

        public int GetOpenedLevelsCount() => _openedLevelsCount;

        public int SelectedLevelIndex
        {
            get => _selectedLevelIndex;
            set
            {
                if (value < 0 || value >= _levelsPrefab.Length)
                {
                    if (value > _openedLevelsCount)
                    {
                        _openedLevelsCount = value;
                    }
                    _selectedLevelIndex = value;
                }
            }
        }

        public void LevelFinished()
        {
            _openedLevelsCount++;
        }

        public Level GetLevel(int levelIndex)
        {
            return _levelsPrefab[levelIndex];
        }

        public int GetLevelsCount()
        {
            return _levelsPrefab.Length;
        }
    }
}