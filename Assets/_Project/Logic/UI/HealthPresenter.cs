using System;
using _Project.Characters;
using Zenject;

namespace _Project.UI
{
    public class HealthPresenter : IInitializable, IDisposable
    {
        private readonly Player _player;
        private readonly HealthView _healthView;

        public HealthPresenter(Player player, HealthView healthView)
        {
            _player = player;
            _healthView = healthView;
        }

        public void Initialize()
        {
            _player.Health.OnChanged += UpdateHealth;
            UpdateHealth();
        }

        public void Dispose() => 
            _player.Health.OnChanged -= UpdateHealth;

        private void UpdateHealth()
        {
            float relativeHealth = _player.Health.Current / _player.Health.Origin;
            _healthView.UpdateValue(relativeHealth);
        }
    }
}