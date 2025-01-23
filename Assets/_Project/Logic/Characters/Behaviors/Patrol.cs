using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Characters.Behaviors
{
    [RequireComponent(typeof(MovementBreaker), typeof(AgentMovement))]
    public class Patrol : MonoBehaviour
    {
        [SerializeField, Required] private Transform[] _waypoints;

        [SerializeField, ReadOnly] private int _waypointIndex;
        
        private AgentMovement _agentMovement;
        private MovementBreaker _movementBreaker;

        private void Awake()
        {
            _agentMovement = GetComponent<AgentMovement>();
            _movementBreaker = GetComponent<MovementBreaker>();
        }

        private void Start()
        {
            if (_waypoints.Length == 0)
            {
                Debug.LogError("No waypoints assigned to Patrol");
                return;
            }
            
            Move();
            _agentMovement.OnReachedDestination += MoveToNextWaypoint;
            _movementBreaker.BreakRequested += TryBreakMovement;
        }

        private void OnDestroy()
        {
            TryBreakMovement(MovementBreakReason.Manual);
            _movementBreaker.BreakRequested -= TryBreakMovement;
        }

        private void TryBreakMovement(MovementBreakReason reason)
        {
            if (reason is not MovementBreakReason.Patrol)
                _agentMovement.OnReachedDestination -= MoveToNextWaypoint;
        }

        private void MoveToNextWaypoint()
        {
            _waypointIndex = (_waypointIndex + 1) % _waypoints.Length;
            Move();
        }

        private void Move() => 
            _agentMovement.Move(_waypoints[_waypointIndex].position);
    }
}