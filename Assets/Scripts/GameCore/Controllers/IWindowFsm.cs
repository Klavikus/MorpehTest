using System;

namespace GameCore.Controllers
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