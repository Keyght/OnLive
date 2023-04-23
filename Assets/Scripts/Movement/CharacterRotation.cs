using Mirror;
using UnityEngine;

namespace Movement
{
    /// <summary>
    /// Class for player rotation
    /// </summary>
    public class CharacterRotation : NetworkBehaviour
    {
        [SerializeField] private float _sensivity = 1.2f;
        [SerializeField] private float _smooth = 10;
        [SerializeField] private Transform _cameraTransform;
    
        private float _xRotation;
        private float _yRotation;
    
        private void Start()
        {
            if (!isLocalPlayer) return;
            var mainCam = Camera.main;
            if (mainCam != null) mainCam.transform.SetParent(_cameraTransform);
        }
    

        protected void Update()
        {
            _yRotation += Input.GetAxis("Mouse X") * _sensivity;
            _xRotation -= Input.GetAxis("Mouse Y") * _sensivity;

            _xRotation = Mathf.Clamp(_xRotation, -75f, 75f);
            
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, _yRotation, 0), Time.deltaTime * _smooth);
            _cameraTransform.rotation = Quaternion.Lerp(_cameraTransform.rotation, Quaternion.Euler(_xRotation, _yRotation, 0), Time.deltaTime * _smooth);
        }
    }
}
