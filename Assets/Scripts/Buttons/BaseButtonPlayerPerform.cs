using System.Threading.Tasks;
using UnityEngine;

namespace Buttons
{
    public abstract class BaseButtonPlayerPerform : MonoBehaviour
    {
        private bool _first;

        private async void OnTriggerStay(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            if (Input.GetKeyDown(KeyCode.F) && !_first)
            {
                await Task.Delay(1500);
                PerformAction();
            }
        }

        protected abstract void PerformAction();
    }
}
