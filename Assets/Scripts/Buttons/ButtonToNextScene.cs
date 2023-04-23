using System.Threading.Tasks;
using UnityEngine;

namespace Buttons
{
    /// <summary>
    /// Class for navigation between scenes buttons
    /// </summary>
    public class ButtonToNextScene : MonoBehaviour
    {
        [SerializeField] private string _sceneName;
        private bool _first;

        private async void OnTriggerStay(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            if (Input.GetKeyDown(KeyCode.F) && !_first)
            {
                _first = true;
                await Task.Delay(1500);
                await AssetProvider.LoadSceneSingle(_sceneName);
            }
        }
    }
}
