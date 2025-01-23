using System;
using UnityEngine;

namespace _Project.Characters
{
    public class FieldOfView : MonoBehaviour
    {
        public event Action<Player> PlayerSpotted;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
                PlayerSpotted?.Invoke(player);
        }
    }
}