using System.Collections.Generic;
using UnityEngine;

public class LevelsContainerView : MonoBehaviour
{
    [SerializeField] private RectTransform _levelsContainer;
    [SerializeField] private LevelButton _levelButtonPrefab;
    private List<LevelButton> _levelButtons;

    private void Start()
    {
        _levelButtons = new List<LevelButton>();
        bool isBlocked = false;
        for (int i = 0; i < LevelsManager.instance.LevelsConfig.GetLevelsCount(); i++)
        {
            isBlocked = LevelsManager.instance.LevelsConfig.GetOpenedLevelsCount() < i;
            _levelButtons.Add(Instantiate(_levelButtonPrefab, _levelsContainer));
            _levelButtons[i].Init(OnSelectLevel, i, isBlocked);
        }
    }

    private void OnSelectLevel(int levelIndex)
    {
        Debug.unityLogger.Log("Selected level: " + levelIndex);
        ScenesLoadManager.instance.OpenGameScene();
    }
}