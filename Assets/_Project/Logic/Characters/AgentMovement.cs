using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.Vector3;

namespace _Project.Characters
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AgentMovement : MonoBehaviour
    {
        private const float STOPPING_DISTANCE_DELTA = .1f;
        
        public event Action OnReachedDestination;
        
        [SerializeField] private float _moveSpeed = 5f;
        
        private NavMeshAgent _agent;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.speed = _moveSpeed;
        }

        public void Move(Vector3 toDestination)
        {
            _agent.SetDestination(toDestination);
            StartCoroutine(ReachDestination());
        }

        private IEnumerator ReachDestination()
        {
            yield return new WaitUntil(() =>
            {
                float distance = Distance(_agent.destination, transform.position);

                return distance <= _agent.stoppingDistance + STOPPING_DISTANCE_DELTA;
            });
            
            OnReachedDestination?.Invoke();
        }
    }
}