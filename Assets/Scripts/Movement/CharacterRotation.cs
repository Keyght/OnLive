using System;
using UnityEngine;

namespace Movement
{
    public class CharacterRotation : MonoBehaviour
    {
        [SerializeField] private float _sensivity = 1.2f;
        [SerializeField] private float _smooth = 10;
        [SerializeField] private Transform _character;

        private float _xRotation;
        private float _yRotation;

        private void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        protected void Update()
        {
            _yRotation += Input.GetAxis("Mouse X") * _sensivity;
            _xRotation -= Input.GetAxis("Mouse Y") * _sensivity;

            _xRotation = Mathf.Clamp(_xRotation, -75f, 75f);
            
            _character.rotation = Quaternion.Lerp(_character.rotation, Quaternion.Euler(0, _yRotation, 0), Time.deltaTime * _smooth);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_xRotation, _yRotation, 0), Time.deltaTime * _smooth);
        }
    }
}
