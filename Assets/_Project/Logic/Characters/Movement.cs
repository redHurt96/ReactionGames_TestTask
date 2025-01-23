using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Characters
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5f;
        
        private CharacterController _controller;

        private void Awake() => 
            _controller = GetComponent<CharacterController>();

        public void Move(Vector3 delta)
        {
            _controller.Move(delta * (_moveSpeed * Time.deltaTime));
            transform.forward = delta;
        }
    }
}
