using Modules.UI.MVPPassiveView._Samples.Domain;
using Modules.UI.MVPPassiveView._Samples.Presenters;
using Modules.UI.MVPPassiveView._Samples.Views;
using Modules.UI.MVPPassiveView.Runtime.Presenters;
using UnityEngine;

namespace Modules.UI.MVPPassiveView._Samples
{
    public class SampleComposition : MonoBehaviour
    {
        [SerializeField] private SampleView _sampleView;

        public void Start()
        {
            SampleModel sampleModel = new SampleModel();
            IPresenter samplePresenter = new SamplePresenter(_sampleView, sampleModel);
            _sampleView.Construct(samplePresenter);
        }
    }
}