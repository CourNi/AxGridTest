using System.Collections.Generic;
using UnityEngine;
using AxGrid;
using AxGrid.Base;

public class DebugConsole : MonoBehaviourExt
{
    private bool showConsole;
    private string input;

    public static DebugEvent<string> CALL_EVENT_FSM;
    public static DebugEvent<string> CALL_EVENT_MODEL;
    public static DebugEvent<string, bool> SET_BOOL;

    public List<object> eventList;
    private MainControl control;

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

        eventList = new List<object>
        {
            CALL_EVENT_FSM,
            CALL_EVENT_MODEL,
            SET_BOOL
        };

        control = new MainControl();
        control.Main.Console.performed += ctx => OnConsole();
        control.Main.Return.performed += ctx => OnReturn();
        control.Main.Enable();
    }

    public void OnConsole()
    {
        showConsole = !showConsole;
        Debug.Log("Console");
    }

    public void OnReturn()
    {
        if (showConsole)
        {
            HandleInput();
            input = "";
        }
    }

    private void OnGUI()
    {
        if (!showConsole) return;

        float y = 0f;

        GUI.Box(new Rect(0, y, Screen.width, 40f), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 35f), input);
        GUI.skin.textField.fontSize = 20;
    }

    private void HandleInput()
    {
        string[] properties = input.Split(' ');

        for(int i=0; i<eventList.Count; i++)
        {
            DebugEventBase eventBase = eventList[i] as DebugEventBase;
            if (input.Contains(eventBase.eventId))
            {
                if (eventList[i] as DebugEvent != null)
                {
                    (eventList[i] as DebugEvent).Invoke();
                }
                else if (eventList[i] as DebugEvent<string> != null)
                {
                    (eventList[i] as DebugEvent<string>).Invoke(properties[1]);
                }
                else if (eventList[i] as DebugEvent<string, bool> != null)
                {
                    (eventList[i] as DebugEvent<string, bool>).Invoke(properties[1], bool.Parse(properties[2]));
                }
            }
        }
    }
}
