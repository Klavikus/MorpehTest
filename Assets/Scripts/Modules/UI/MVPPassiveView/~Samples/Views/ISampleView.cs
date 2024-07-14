using UnityEngine.UI;

namespace Modules.UI.MVPPassiveView._Samples.Views
{
    public interface ISampleView
    {
        Button SampleButton { get; }
        void SetClicksCountText(string clicksCount);
    }
}