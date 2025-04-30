using DI.Controllers;
using DI.Factories;
using DI.Interfaces;
using ScriptableObjects;
using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private PlayerConfigs _playerConfigs;

    public override void InstallBindings()
    {
        Container.Bind<PlayerConfigs>().FromInstance(_playerConfigs);
        Container.BindInterfacesAndSelfTo<InputControllers>().AsSingle();
        // Container.Bind<PrefabFactory>().AsSingle().NonLazy();
        Container.Bind<IPrefabFactory>().To<PrefabFactory>().AsSingle();

    }
}