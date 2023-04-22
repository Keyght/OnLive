using System;
using Movement;
using UnityEngine;

namespace Animation
{
    public class PlayerAnimations : MonoBehaviour
    {
        [SerializeField] private Transform _playerMesh;

        private CharacterMovement _movement;
        private Animator _animator;
        private static readonly int _run = Animator.StringToHash("Run");
        private static readonly int _walk = Animator.StringToHash("Walk");
        private static readonly int _action = Animator.StringToHash("Action");

        private void Start()
        {
            _movement = GetComponent<CharacterMovement>();
            _animator = _playerMesh.GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            if (_animator is null) return;
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                if (_movement is null) return;
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    _movement.Run();
                    _animator.SetBool(_run, true);
                    _animator.SetBool(_walk, false);
                }
                else
                {
                    _movement.Walk();
                    _animator.SetBool(_run, false);
                    _animator.SetBool(_walk, true);
                }
            }
            else
            {
                _animator.SetBool(_run, false);
                _animator.SetBool(_walk, false);
            }
            if (Input.GetKeyDown(KeyCode.F)) _animator.SetTrigger(_action);
        }
    }
}
