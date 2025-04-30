using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
  [SerializeField] private Button _button;

  private void Start()
  {
    _button.onClick.RemoveAllListeners();
    _button.onClick.AddListener(OnClick);
  }

  private void OnClick()
  {
    ScenesLoadManager.instance.OpenMainMenuScene();
  }
}
