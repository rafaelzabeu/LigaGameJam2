using UnityEngine;
using System.Collections;
using XboxCtrlrInput;
using System;

public class GamePad1 : IControl
{

    public XboxController controller
    {
        get; private set;
    }

    public GamePad1()
    {
        index = PlayerIndex.Player1;
        controller = XboxController.First;
    }

    public GamePad1(XboxController controller)
    {
        this.controller = controller;
    }

    public GamePad1(PlayerIndex index, XboxController controller)
    {
        this.index = index;
        this.controller = controller;
    }

    public PlayerIndex index
    {
        get;
        set;
    }

    public ControlType controlType
    {
        get { return ControlType.GamePad; }
    }

    public bool Cancel
    {
        get { return XCI.GetButtonDown(XboxCtrlrInput.XboxButton.B, controller); }
    }

    public bool Start
    {
        get { return XCI.GetButtonUp(XboxCtrlrInput.XboxButton.Start, controller); }
    }

    public bool Back
    {
        get { return XCI.GetButtonDown(XboxCtrlrInput.XboxButton.Back, controller); }
    }

    public bool Action
    {
        get { return XCI.GetButtonDown(XboxCtrlrInput.XboxButton.A, controller); }
    }

    public bool Round
    {
        get { return false; }
    }

    public bool Right
    {
        get { return XCI.GetDPadDown(XboxDPad.Right, controller); }
    }

    public bool RightPressing
    {
        get { return XCI.GetDPad(XboxDPad.Right, controller); }
    }

    public bool Up
    {
        get { return XCI.GetDPadDown(XboxDPad.Up, controller); }
    }

    public bool UpPressing
    {
        get { return XCI.GetDPad(XboxDPad.Up, controller); }
    }

    public bool Left
    {
        get { return XCI.GetDPadDown(XboxDPad.Left, controller); }
    }

    public bool LeftPresing
    {
        get { return XCI.GetDPad(XboxDPad.Left, controller); }
    }

    public bool Down
    {
        get { return XCI.GetDPadDown(XboxDPad.Down, controller); }
    }

    public bool DownPressing
    {
        get { return XCI.GetDPad(XboxDPad.Down, controller); }
    }

    public bool AngleUpDigital
    {
        get { return XCI.GetButton(XboxButton.LeftBumper, controller); }
    }

    public bool AngleDownDigital
    {
        get { return XCI.GetButton(XboxButton.RightBumper, controller); }
    }

    public float AngleUpAnalogic
    {
        get { return XCI.GetAxis(XboxAxis.LeftTrigger, controller); }
    }

    public float AngleDownAnalogic
    {
        get { return XCI.GetAxis(XboxAxis.RightTrigger, controller); }
    }

    public Vector2 LeftAnalogic
    {
        get
        {
            return new Vector2(XCI.GetAxis(XboxAxis.LeftStickX, controller), XCI.GetAxis(XboxAxis.LeftStickY, controller));
        }
    }

    public Vector2 RightAnalogic
    {
        get
        {
            return new Vector2(XCI.GetAxis(XboxAxis.RightStickX, controller), XCI.GetAxis(XboxAxis.RightStickY, controller));
        }
    }

    public bool Confirm
    {
        get { return XCI.GetButtonDown(XboxButton.Start); }
    }

    public bool Select
    {
        get { return XCI.GetButtonDown(XboxButton.Back); }
    }

    public bool Jump
    {
        get
        {
            return XCI.GetButtonDown(XboxButton.A, controller);
        }
    }

    public bool JumpPressing
    {
        get
        {
            return XCI.GetButton(XboxButton.A, controller);
        }
    }

    public bool Dash
    {
        get
        {
            return XCI.GetButtonDown(XboxButton.RightBumper, controller);
        }
    }

    public bool Interact
    {
        get
        {
            return XCI.GetButtonDown(XboxButton.X, controller);
        }
    }

    public bool Drop
    {
        get
        {
            return XCI.GetButtonDown(XboxButton.B, controller);
        }
    }

    public bool EspecificButton(XboxCtrlrInput.XboxButton button)
    {
        return XCI.GetButtonDown(button,controller);
    }
}
