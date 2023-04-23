using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class CreateToggler : MonoBehaviour
{
    private bool _first;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !_first)
        {
            _first = true;
            Addressables.InstantiateAsync("Toggler");
            Destroy(gameObject);
        }
    }
}
