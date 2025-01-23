using _Project.Characters;
using _Project.Input;
using _Project.UI;
using UnityEngine;
using Zenject;

namespace _Project.Infrastructure
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Player _player;
        [SerializeField] private HealthView _healthView;
        
        public override void InstallBindings()
        {
            Container.Bind<Player>().FromInstance(_player).AsSingle();
            Container.BindInterfacesTo<InputController>().AsSingle();
            
            Container.Bind<HealthView>().FromInstance(_healthView).AsSingle();
            Container.BindInterfacesAndSelfTo<HealthPresenter>().AsSingle();
        }
    }
}