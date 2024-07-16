using System;
using System.Collections.Generic;
using GameCore.Controllers;
using Modules.UI.WindowFsm.Runtime.Abstract;

namespace Modules.UI.WindowFsm.Runtime.Implementation
{
    public class Test
    {
        public Test()
        {
            var a = new EnumWindowFsm<WindowType>(new Dictionary<WindowType, Window<WindowType>>()
                {
                    [WindowType.None] = new Window<WindowType>(WindowType.None)
                },
                WindowType.None);
        }
    }

    public readonly struct Window<T> where T : Enum
    {
        public readonly T Type;

        public Window(T type) =>
            Type = type;
    }

    public class EnumWindowFsm<T> : IWindowFsm<T> where T : Enum
    {
        private readonly Dictionary<T, Window<T>> _windowsByType;
        private readonly Stack<T> _stack;
        private readonly T _defaultValue;

        private T _currentWindow;

        public EnumWindowFsm(Dictionary<T, Window<T>> windowsByType, T initialWindow)
        {
            _windowsByType = windowsByType;
            _stack = new Stack<T>();
            _defaultValue = (T) Enum.GetValues(typeof(T)).GetValue(0);
            OpenWindow(initialWindow);
        }

        public event Action<T> Opened;
        public event Action<T> Closed;

        public T CurrentWindow => _currentWindow;

        public void OpenWindow(T windowType)
        {
            if (Equals(_windowsByType[windowType].Type, _currentWindow))
                return;

            _stack.Push(windowType);

            if (Equals(_currentWindow, _defaultValue) == false)
                Closed?.Invoke(_currentWindow);

            _currentWindow = _stack.Peek();
            Opened?.Invoke(_currentWindow);
        }

        public void Close(T windowType)
        {
            if (Equals(_windowsByType[windowType].Type, _currentWindow) == false)
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