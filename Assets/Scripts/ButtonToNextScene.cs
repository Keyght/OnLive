using UnityEngine;

public class ButtonToNextScene : MonoBehaviour
{
    private bool _first;

    private async void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        if (!_first)
        {
            _first = true;
            await AssetProvider.LoadSceneAdditive("Hub");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            await AssetProvider.LoadSceneSingle("Hub");
        }
    }
}
