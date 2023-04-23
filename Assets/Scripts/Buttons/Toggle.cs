using System.Threading.Tasks;
using Mirror;
using UnityEngine;

namespace Buttons
{
    public class Toggle : NetworkBehaviour
    {
        [SyncVar] private bool _state;
        private bool _first;
        
        private async void OnTriggerStay(Collider other)
        {
            if (!isClient) return;
            if (!other.gameObject.CompareTag("Player")) return;
            if (Input.GetKeyDown(KeyCode.F) && !_first)
            {
                _first = true;
                await Task.Delay(1500);
                Rotate();
            }
        }

        private void Rotate()
        {
            _state = !_state;
            _first = false;
        }
        
        private void Update()
        {
            transform.rotation = _state ? Quaternion.Euler(-135, -90, 90) : Quaternion.Euler(-45, -90, 90);
        }
    }
}
