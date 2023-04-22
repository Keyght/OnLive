using Mirror;
using UnityEngine;

public class CatchCamera : NetworkBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    
    private void Start()
    {
        if (!isLocalPlayer) return;
        var maincam = Camera.main;
        maincam.transform.SetParent(_cameraTransform);
    }
}
