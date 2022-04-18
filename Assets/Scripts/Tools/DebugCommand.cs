using System;

public class DebugEventBase
{
    private string _eventId;
    private string _eventFormat;

    public string eventId { get { return _eventId; } }
    public string eventFormat { get { return _eventFormat; } }

    public DebugEventBase(string id, string format)
    {
        _eventId = id;
        _eventFormat = format;
    }
}

public class DebugEvent : DebugEventBase
{
    private Action eventAction;

    public DebugEvent(string id, string format, Action action) : base (id, format)
    {
        this.eventAction = action;
    }

    public void Invoke()
    {
        eventAction.Invoke();
    }
}

public class DebugEvent<T1> : DebugEventBase
{
    private Action<T1> eventAction;

    public DebugEvent(string id, string format, Action<T1> action) : base(id, format)
    {
        this.eventAction = action;
    }

    public void Invoke(T1 value)
    {
        eventAction.Invoke(value);
    }
}

public class DebugEvent<T1, T2> : DebugEventBase
{
    private Action<T1, T2> eventAction;

    public DebugEvent(string id, string format, Action<T1, T2> action) : base(id, format)
    {
        this.eventAction = action;
    }

    public void Invoke(T1 value, T2 value2)
    {
        eventAction.Invoke(value, value2);
    }
}