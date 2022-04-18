using System.Collections.Generic;
using UnityEngine;
using AxGrid;
using AxGrid.Base;

public class DebugConsole : MonoBehaviourExt
{
    private MainControl _control;
    private bool _showConsole;
    private string _input;

    public static DebugEvent<string> CALL_EVENT_FSM;
    public static DebugEvent<string> CALL_EVENT_MODEL;
    public static DebugEvent<string, bool> SET_BOOL;

    public List<object> EventList;

    [OnAwake]
    private void OnAwake()
    {
        CALL_EVENT_FSM = new DebugEvent<string>("call_event_fsm", "call_event_fsm", (x) =>
        {
            Settings.Fsm.Invoke(x);
        });

        CALL_EVENT_MODEL = new DebugEvent<string>("call_event_model", "call_event_model", (x) =>
        {
            Model.EventManager.Invoke(x);
        });

        SET_BOOL = new DebugEvent<string, bool>("set_bool", "set_bool", (x, y) =>
        {
            Model.Set(x, y);
        });

        EventList = new List<object>
        {
            CALL_EVENT_FSM,
            CALL_EVENT_MODEL,
            SET_BOOL
        };
    }

    [OnStart]
    private void OnStart()
    {
        _control = ControlManager.Instance.Control;
        _control.Main.Console.performed += ctx => OnConsole();
        _control.Main.Return.performed += ctx => OnReturn();
        _control.Main.Enable();
    }

    public void OnConsole()
    {
        _showConsole = !_showConsole;
        Debug.Log("Console");
    }

    public void OnReturn()
    {
        if (_showConsole)
        {
            HandleInput();
            _input = "";
        }
    }

    private void OnGUI()
    {
        if (!_showConsole) return;

        float y = 0f;

        GUI.Box(new Rect(0, y, Screen.width, 40f), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        _input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 35f), _input);
        GUI.skin.textField.fontSize = 20;
    }

    private void HandleInput()
    {
        string[] properties = _input.Split(' ');

        for(int i=0; i<EventList.Count; i++)
        {
            DebugEventBase eventBase = EventList[i] as DebugEventBase;
            if (_input.Contains(eventBase.eventId))
            {
                if (EventList[i] as DebugEvent != null)
                {
                    (EventList[i] as DebugEvent).Invoke();
                }
                else if (EventList[i] as DebugEvent<string> != null)
                {
                    (EventList[i] as DebugEvent<string>).Invoke(properties[1]);
                }
                else if (EventList[i] as DebugEvent<string, bool> != null)
                {
                    (EventList[i] as DebugEvent<string, bool>).Invoke(properties[1], bool.Parse(properties[2]));
                }
            }
        }
    }
}
