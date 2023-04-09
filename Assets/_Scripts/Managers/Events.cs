
using System;


public class Events
{
    public static readonly Evt OnGameStart = new Evt();
    public static readonly Evt OnGameOver = new Evt();
}

public class Evt
{
    private event  Action _action = delegate {  };

    public void Invoke() => _action?.Invoke();
    public void AddListener(Action listener) => _action += listener;
    public void RemoveListener(Action listener) => _action -= listener;
    public void DisableEvent() => _action = null;
}
