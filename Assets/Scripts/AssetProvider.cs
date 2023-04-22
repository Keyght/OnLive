using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public class AssetProvider : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private async void Start()
    {
        await LoadSceneSingle("PrivateRoom");
    }

    public static async Task LoadSceneSingle(string sceneId)
    {
        var op = Addressables.LoadSceneAsync(sceneId);
        await op.Task;
    }
}
