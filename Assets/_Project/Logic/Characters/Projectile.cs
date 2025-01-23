using UnityEngine;

namespace _Project.Characters
{
    [RequireComponent(typeof(Rigidbody), typeof(Destroy))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _autoDestroyTime;
        
        private Rigidbody _rigidbody;
        private Destroy _destroy;
        
        private float _damage;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _destroy = GetComponent<Destroy>();
        }

        public void Launch(Vector3 direction, float speed, float damage)
        {
            _damage = damage;
            _rigidbody.linearVelocity = direction * speed;
            _destroy.ExecuteDelayed(_autoDestroyTime);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out Player player))
            {
                player.Health.TakeDamage(_damage);
                _destroy.Execute();
            }
        }
    }
}