using Mirror;

namespace Network
{
    public class NetMan : NetworkManager
    {
        public override void OnServerChangeScene(string newSceneName)
        {
            if (newSceneName == "Hub")
            {
                
                //Addressables.InstantiateAsync("Toggler");
            }
        }
    }
}
