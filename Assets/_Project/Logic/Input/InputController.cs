using _Project.Characters;
using UnityEngine;
using Zenject;
using static UnityEngine.Input;

namespace _Project.Input
{
    public class InputController : ITickable
    {
        private readonly Player _player;

        public InputController(Player player) => 
            _player = player;

        public void Tick()
        {
            Vector3 direction = new Vector3(
                    GetAxis("Horizontal"),
                    0f,
                    GetAxis("Vertical"))
                .normalized;
            
            if (direction != Vector3.zero && _player is { IsAlive: true })
                _player.Move(direction);
        }
    }
}