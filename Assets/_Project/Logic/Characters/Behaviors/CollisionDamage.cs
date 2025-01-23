using UnityEngine;

namespace _Project.Characters.Behaviors
{
    [RequireComponent(typeof(Destroy), typeof(Rigidbody))]
    public class CollisionDamage : MonoBehaviour
    {
        [SerializeField] private float _amount;
        
        private Destroy _destroy;

        private void Awake() => 
            _destroy = GetComponent<Destroy>();

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out Player player))
            {
                player.Health.TakeDamage(_amount);
                _destroy.Execute();
            }
        }
    }
}