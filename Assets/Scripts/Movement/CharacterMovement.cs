using Mirror;
using UnityEngine;

namespace Movement
{
    /// <summary>
    /// Class for player movement
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterMovement : NetworkBehaviour
    {
        [SerializeField] private float _baseSpeed = 3;
        [SerializeField] private Transform _mesh;

        private float _movementSpeed;
        private Vector3 _movementVector;
        private Rigidbody _rigidbody;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            _movementSpeed = _baseSpeed;
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected void Update()
        {
            if (!isLocalPlayer) return;
            var character = transform;
            _movementVector = character.right * Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") * character.forward;
            if (_movementVector.magnitude == 0) return;
            _mesh.rotation = Quaternion.LookRotation(_movementVector);
            _rigidbody.MovePosition(character.position + _movementVector * (_movementSpeed * Time.deltaTime));
        }

        public void Run()
        {
            if (_movementSpeed < _baseSpeed * 2) _movementSpeed += Time.deltaTime;
        }
        public void Walk()
        {
            if (_movementSpeed > _baseSpeed) _movementSpeed -= 2* Time.deltaTime;
        }
    }
}
