using System;

namespace Modules.UI.WindowFsm.Runtime.Implementation
{
    public interface IWindowFsm<T> where T : Enum
    {
        event Action<T> Opened;
        event Action<T> Closed;
        T CurrentWindow { get; }
        void OpenWindow(T windowType);
        void Close(T windowType);
        void CloseCurrentWindow();
        void ClearHistory();
    }
}