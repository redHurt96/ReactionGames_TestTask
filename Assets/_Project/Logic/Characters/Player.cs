using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Characters
{
    [RequireComponent(typeof(Movement), typeof(Health), typeof(Destroy))]
    public class Player : MonoBehaviour
    {
        public bool IsAlive => Health.Current > 0f;
        public Vector3 Position => transform.position;
        
        public Health Health { get; private set; }
        
        private Movement _movement;
        private Destroy _destroy;

        private void Awake()
        {
            Health = GetComponent<Health>();
            _movement = GetComponent<Movement>();
            _destroy = GetComponent<Destroy>();
        }

        public void Move(Vector3 toDirection) => 
            _movement.Move(toDirection);

        private void Start() => 
            Health.OnDeath += _destroy.Execute;

        private void OnDestroy() => 
            Health.OnDeath -= _destroy.Execute;
    }
}