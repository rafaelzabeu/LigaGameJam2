using UnityEngine;
using System.Collections;
using System;

public class KeyBoard : IControl
{
    public PlayerIndex index
    {
        get { return PlayerIndex.Player1; }
        set { }
    }

    public ControlType controlType
    {
        get { return ControlType.KeyBoard; }
    }

    public bool Right
    {
        get { return Input.GetKeyDown(KeyCode.RightArrow); }
    }

    public bool RightPressing
    {
        get { return Input.GetKey(KeyCode.RightArrow); }
    }

    public bool Up
    {
        get { return Input.GetKeyDown(KeyCode.UpArrow); }
    }

    public bool UpPressing
    {
        get { return Input.GetKey(KeyCode.UpArrow); }
    }

    public bool Left
    {
        get { return Input.GetKeyDown(KeyCode.LeftArrow); }
    }

    public bool LeftPresing
    {
        get { return Input.GetKey(KeyCode.LeftArrow); }
    }

    public bool Down
    {
        get { return Input.GetKeyDown(KeyCode.DownArrow); }
    }

    public bool DownPressing
    {
        get { return Input.GetKey(KeyCode.DownArrow); }
    }

    public bool AngleUpDigital
    {
        get { return Input.GetKey(KeyCode.UpArrow); }
    }

    public bool AngleDownDigital
    {
        get { return Input.GetKey(KeyCode.DownArrow); }
    }

    public float AngleUpAnalogic
    {
        get { return 0; }
    }

    public float AngleDownAnalogic
    {
        get { return 0; }
    }

    public Vector2 LeftAnalogic
    {
        get
        {
            var x = Input.GetKey(KeyCode.RightArrow) ? 1 : (Input.GetKey(KeyCode.LeftArrow)) ? -1 : 0;
            var y = Input.GetKey(KeyCode.UpArrow) ? 1 : (Input.GetKey(KeyCode.DownArrow)) ? -1 : 0;

            return new Vector2(x, y);
        }
            
    }

    public Vector2 RightAnalogic
    {
        get { return Vector2.zero; }
    }

    public bool Cancel
    {
        get { return Input.GetKeyDown(KeyCode.LeftControl); }
    }

    public bool Start
    {
        get { return Input.GetKeyDown(KeyCode.Escape); }
    }

    public bool Back
    {
        get { return Input.GetKeyDown(KeyCode.Escape); }
    }

    public bool Round
    {
        get { return Input.GetKeyDown(KeyCode.Tab); }
    }
    
    public bool Action
    {
        get { return Input.GetKeyDown(KeyCode.Space); }
    }

    public bool Confirm
    {
		get { return Input.GetKeyDown(KeyCode.Space); }
    }

    public bool Select
    {
        get { return Input.GetKeyDown(KeyCode.T); }
    }

    public bool Jump
    {
        get
        {
            return Input.GetKeyDown(KeyCode.UpArrow);
        }
    }

    public bool JumpPressing
    {
        get
        {
            return Input.GetKey(KeyCode.UpArrow);
        }
    }

    public bool Dash
    {
        get
        {
            return Input.GetKeyDown(KeyCode.RightAlt);
        }
    }

    public bool Interact
    {
        get
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
    }

    public bool Drop
    {
        get
        {
            return Input.GetKeyDown(KeyCode.DownArrow);
        }
    }

    public bool EspecificButton(XboxCtrlrInput.XboxButton button)
    {
        switch (button)
        {
            case XboxCtrlrInput.XboxButton.A:
                return Input.GetKeyDown(KeyCode.A);
            case XboxCtrlrInput.XboxButton.B:
                return Input.GetKeyDown(KeyCode.B);
            case XboxCtrlrInput.XboxButton.X:
                return Input.GetKeyDown(KeyCode.X);
            case XboxCtrlrInput.XboxButton.Y:
                return Input.GetKeyDown(KeyCode.Y);
            case XboxCtrlrInput.XboxButton.Start:
                return Input.GetKeyDown(KeyCode.Return);
            case XboxCtrlrInput.XboxButton.Back:
                return Input.GetKeyDown(KeyCode.Backspace);
            case XboxCtrlrInput.XboxButton.LeftStick:
            case XboxCtrlrInput.XboxButton.RightStick:
            case XboxCtrlrInput.XboxButton.LeftBumper:
            case XboxCtrlrInput.XboxButton.RightBumper:
            default:
                return false;
        }
    }
}
