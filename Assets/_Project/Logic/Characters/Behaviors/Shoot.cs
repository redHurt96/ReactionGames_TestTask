using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Characters.Behaviors
{
    [RequireComponent(typeof(FieldOfView))]
    public class Shoot : MonoBehaviour
    {
        [SerializeField, Required] private Projectile _projectilePrefab;
        [SerializeField, Required] private FieldOfView _fov;
        [SerializeField, Required] private Transform _shootPoint;
        
        [Space]
        [SerializeField] private float _cooldownTime;
        [SerializeField] private float _projectileSpeed;
        [SerializeField] private float _damage;
        
        private WaitForSeconds _cooldown;
        private Coroutine _routine;

        private void Awake()
        {
            _cooldown = new WaitForSeconds(_cooldownTime);
            _fov.PlayerSpotted += StartShooting;
        }

        private void OnDestroy() => 
            _fov.PlayerSpotted -= StartShooting;

        private void StartShooting(Player target) => 
            _routine ??= StartCoroutine(ShootingRoutine(target));

        private IEnumerator ShootingRoutine(Player target)
        {
            while (target is { IsAlive : true })
            {
                ShootToTarget(target.transform);
                
                yield return _cooldown;
            }
        }

        private void ShootToTarget(Transform target)
        {
            Vector3 direction = (target.position - _shootPoint.position).normalized;
            transform.forward = direction;
            Projectile projectile = Instantiate(_projectilePrefab, _shootPoint.position, Quaternion.identity);
            projectile.Launch(direction, _projectileSpeed, _damage);
        }
    }
}