using DI.Controllers;
using UnityEngine;
using Zenject;

public class GamesSceneObjectInstaller : MonoInstaller
{
    [SerializeField] private LevelView _levelView;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<LevelController>().AsSingle().WithArguments(_levelView);
    }
}