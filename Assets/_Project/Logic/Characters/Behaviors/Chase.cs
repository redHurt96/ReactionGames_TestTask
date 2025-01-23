using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Characters.Behaviors
{
    [RequireComponent(typeof(AgentMovement), typeof(MovementBreaker))]
    public class Chase : MonoBehaviour
    {
        [SerializeField, Required] private FieldOfView _fov;
        
        private MovementBreaker _movementBreaker;
        private AgentMovement _agent;
        private Coroutine _routine;

        private void Awake()
        {
            _agent = GetComponent<AgentMovement>();
            _movementBreaker = GetComponent<MovementBreaker>();
            
            _fov.PlayerSpotted += StartChasing;
            _movementBreaker.BreakRequested += TryBreakChase;
        }

        private void OnDestroy()
        {
            _fov.PlayerSpotted -= StartChasing;
            _movementBreaker.BreakRequested += TryBreakChase;
        }

        private void StartChasing(Player target)
        {
            _movementBreaker.Emit(MovementBreakReason.Chase);
            _routine ??= StartCoroutine(ChaseRoutine(target));
        }

        private IEnumerator ChaseRoutine(Player target)
        {
            while (target is { IsAlive : true })
            {
                _agent.Move(target.Position);
                yield return null;
            }
        }

        private void TryBreakChase(MovementBreakReason reason)
        {
            if (reason is not MovementBreakReason.Chase)
                StopCoroutine(_routine);
        }
    }
}