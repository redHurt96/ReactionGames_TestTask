using System;
using UnityEngine;

namespace _Project.Characters
{
    public class MovementBreaker : MonoBehaviour
    {
        public event Action<MovementBreakReason> BreakRequested;
        
        public void Emit(MovementBreakReason reason) => 
            BreakRequested?.Invoke(reason);
    }
}