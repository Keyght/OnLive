using System.Threading.Tasks;
using Network;
using UnityEngine;
using UnityEngine.AddressableAssets;

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
        NetMan.singleton.OnServerChangeScene(sceneId);
    }
}
