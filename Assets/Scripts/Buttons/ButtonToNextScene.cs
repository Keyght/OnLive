namespace Buttons
{
    public class ButtonToNextScene : BaseButtonPlayerPerform
    {
        protected override async void PerformAction()
        {
            await AssetProvider.LoadSceneSingle("Hub");
        }
    }
}
