using System;
using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float _baseSpeed = 5;

        private float _movementSpeed;
        private Vector3 _movementVector;
        private Rigidbody _rigidbody;

        private void Start()
        {
            _movementSpeed = _baseSpeed;
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected void Update()
        {
            var character = transform;
            _movementVector = character.right * Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") * character.forward;
            _rigidbody.MovePosition(character.position + _movementVector * (_movementSpeed * Time.deltaTime));
        }

        public void Run()
        {
            _movementSpeed = _baseSpeed * 3;
        }
        public void Walk()
        {
            _movementSpeed = _baseSpeed;
        }
    }
}