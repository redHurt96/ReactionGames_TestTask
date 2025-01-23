using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Characters
{
    public class Health : MonoBehaviour
    {
        public event Action OnChanged;
        public event Action OnDeath;
        
        [field:SerializeField] public float Origin { get; private set; } = 100f;
        [field:SerializeField, ReadOnly] public float Current { get; private set; }

        private void Awake() => 
            Current = Origin;

        [Button]
        public void TakeDamage(float damage)
        {
            Current = Mathf.Max(Current - damage, 0f);
            OnChanged?.Invoke();
            
            if (Mathf.Approximately(Current, 0f))
                OnDeath?.Invoke();
        }
    }
}