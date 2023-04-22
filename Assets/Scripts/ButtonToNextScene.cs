using UnityEngine;

public class ButtonToNextScene : MonoBehaviour
{
    private bool _first;

    private async void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        if (Input.GetKeyDown(KeyCode.F) && !_first)
        {
            _first = true;
            await AssetProvider.LoadSceneSingle("Hub");
        }
    }
}
