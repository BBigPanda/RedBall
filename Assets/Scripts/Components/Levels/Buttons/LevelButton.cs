using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _markLocked;

    public void Init(Action<int> onClick, int levelIndex, bool isBlocked)
    {
        _button.interactable = !isBlocked;
        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(() => onClick(levelIndex));
        _text.text = levelIndex.ToString();
        _markLocked.enabled = isBlocked;
    }
}