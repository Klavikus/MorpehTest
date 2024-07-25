using System;
using System.Collections.Generic;

namespace GameCore.Controllers.Implementation
{
    public class EnumWindowFsm<T> : IWindowFsm<T> where T : Enum
    {
        private readonly Stack<T> _stack;
        private readonly T _defaultValue;

        private T _currentWindow;

        public EnumWindowFsm(T initialWindow)
        {
            _stack = new Stack<T>();
            _defaultValue = (T) Enum.GetValues(typeof(T)).GetValue(0);
            OpenWindow(initialWindow);
        }

        public event Action<T> Opened;
        public event Action<T> Closed;

        public T CurrentWindow => _currentWindow;

        public void OpenWindow(T windowType)
        {
            if (Equals(windowType, _currentWindow))
                return;

            _stack.Push(windowType);

            if (Equals(_currentWindow, _defaultValue) == false)
                Closed?.Invoke(_currentWindow);

            _currentWindow = _stack.Peek();
            Opened?.Invoke(_currentWindow);
        }

        public void Close(T windowType)
        {
            if (Equals(windowType, _currentWindow) == false)
                return;

            CloseCurrentWindow();
        }

        public void CloseCurrentWindow()
        {
            if (_currentWindow == null)
                return;

            _stack.Pop();
            Closed?.Invoke(_currentWindow);
            _stack.TryPeek(out _currentWindow);

            if (Equals(_currentWindow, _defaultValue) == false)
                Opened?.Invoke(_currentWindow);
        }

        public void ClearHistory()
        {
            _stack.Clear();

            if (Equals(_currentWindow, _defaultValue) == false)
                _stack.Push(_currentWindow);
        }
    }
}