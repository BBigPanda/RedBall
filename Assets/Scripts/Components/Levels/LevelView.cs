using System;
using Cysharp.Threading.Tasks;
using DI.Controllers;
using DI.Interfaces;
using UnityEngine;
using Zenject;

public class LevelView : MonoBehaviour
{
    [SerializeField] private CameraFollowingController _cameraFollowingController;
    [SerializeField] private PlayerController _playerPrefab;
    private Level _level;
    private PlayerController _player;
    [Inject] private IPrefabFactory _prefabFactory;
    [Inject] private InputControllers _inputControllers;

    public void Init()
    {
    }

    public void Start()
    {
        _player = _prefabFactory.Create(_playerPrefab, transform);
        _level = LevelsManager.instance.LevelsConfig.GetLevel(LevelsManager.instance.LevelsConfig.SelectedLevelIndex);
        _level = Instantiate(_level, transform);
        _level.Init(_player.transform);
        _level.FinishTrigger.Init(OnLevelFinished);
        _player.transform.position = _level.GetStartPosition();
        _cameraFollowingController.SetPlayerTransform(_player.transform);
        _cameraFollowingController.FadeOut();
    }

    private async void OnLevelFinished()
    {
        _player.ForceStopForces();
        _inputControllers.ForceUnSubscribe();
        float durationFadeIn = 1.5f;
        _cameraFollowingController.FadeIn(durationFadeIn);
        await UniTask.Delay(TimeSpan.FromSeconds(durationFadeIn));
        LevelsManager.instance.LevelsConfig.LevelFinished();
        ScenesLoadManager.instance.OpenGameScene();
    }
}