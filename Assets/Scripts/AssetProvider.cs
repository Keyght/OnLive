using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

/// <summary>
/// Class for loading Addressables
/// </summary>
public class AssetProvider : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private async void Start()
    {
        await LoadSceneSingle("Hub");
    }

    public static async Task LoadSceneSingle(string sceneId)
    {
        var op = Addressables.LoadSceneAsync(sceneId);
        await op.Task;
    }
}
