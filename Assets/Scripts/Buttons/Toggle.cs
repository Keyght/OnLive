using System.Threading.Tasks;
using Mirror;
using UnityEngine;

namespace Buttons
{
    public class Toggle : NetworkBehaviour
    {
        private bool _state;
        private bool _first;
        
        private async void OnTriggerStay(Collider other)
        {
            if (!isClient) return;
            if (!other.gameObject.CompareTag("Player")) return;
            if (Input.GetKeyDown(KeyCode.F) && !_first)
            {
                _first = true;
                await Task.Delay(1000);
                CmdChangeState(!_state);
                _first = false;
            }
        }

        [Command(requiresAuthority=false)]
        private void CmdChangeState(bool state)
        {
            RpcChangeState(state);
            Rotate(state);
            
        }
        [ClientRpc]
        private void RpcChangeState(bool state)
        {
            Rotate(state);
        }

        private void Rotate(bool state)
        {
            _state = state;
            var rotation = _state ? Quaternion.Euler(-135, -90, 90) : Quaternion.Euler(-45, -90, 90);
            transform.localRotation = rotation;
        }
    }
}
