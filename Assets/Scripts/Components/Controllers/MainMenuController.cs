using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
  [SerializeField] private Button _playButton;
  [SerializeField] private Button _levelsButton;
  [SerializeField] private RectTransform _mainMenuPanel;
  [SerializeField] private RectTransform _levelsPanel;
  private void Start()
  {
    _playButton.onClick.RemoveAllListeners();
    _playButton.onClick.AddListener(PlayButtonOnClick);
    _levelsButton.onClick.RemoveAllListeners();
    _levelsButton.onClick.AddListener(OnLevelsButtonClick);
  }

  private void OnLevelsButtonClick()
  {
    _levelsPanel.gameObject.SetActive(true);
    _mainMenuPanel.gameObject.SetActive(false);
  }

  private void PlayButtonOnClick()
  {
    ScenesLoadManager.instance.OpenGameScene();
  }
}
