﻿using System;

namespace Modules.UI.MVPPassiveView._Samples.Domain
{
    public class SampleModel
    {
        public event Action<int> ClicksCountChanged;
        public int ClicksCount { get; private set; }

        public void HandleClick()
        {
            ClicksCount++;
            ClicksCountChanged?.Invoke(ClicksCount);
        }
    }
}