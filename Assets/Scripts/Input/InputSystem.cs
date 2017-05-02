using UnityEngine;
using System.Collections;
using XboxCtrlrInput;
using System;
using System.Collections.Generic;

public class InputSystem
{
    private static Dictionary<PlayerIndex, IControl> m_controls = new Dictionary<PlayerIndex, IControl>();

    static public void AddControl(PlayerIndex index, IControl control)
    {
        if (!m_controls.ContainsKey(index))
            m_controls.Add(index, control);
    }

    #region Actions

    static public bool Confirm(PlayerIndex index)
    {
        if (!m_controls.ContainsKey(index)) return false;

        return m_controls[index].Confirm;
    }

    static public bool Action(PlayerIndex index)
    {
        if (!m_controls.ContainsKey(index)) return false;

        return m_controls[index].Action;

    }

    static public bool Back(PlayerIndex index)
    {
        if (!m_controls.ContainsKey(index)) return false;

        return m_controls[index].Back;

    }

    static public bool Round(PlayerIndex index)
    {
        if (!m_controls.ContainsKey(index)) return false;

        return m_controls[index].Round;

    }

    static public bool Cancel(PlayerIndex index)
    {
        if (!m_controls.ContainsKey(index)) return false;

        return m_controls[index].Cancel;

    }

    static public bool Start(PlayerIndex index)
    {
        if (!m_controls.ContainsKey(index)) return false;

        return m_controls[index].Start;

    }

    static public bool Select(PlayerIndex index)
    {
        if (!m_controls.ContainsKey(index)) return false;

        return m_controls[index].Select;

    }

    static public bool EspecificKeyDown(KeyCode key)
    {
        return Input.GetKeyDown(key);
    }

    static public bool GamePadButtonDown(XboxController controller, XboxButton button)
    {
        return XCI.GetButtonDown(button, controller);
    }

    static public bool AnyGamePadButtonDown(XboxButton button)
    {
        return XCI.GetButtonDown(button);
    }

    static public bool GamePadButtonDown(XboxButton button, PlayerIndex player)
    {
        if (!m_controls.ContainsKey(player) || m_controls[player].controlType != ControlType.GamePad) return false;

        return (m_controls[player]).EspecificButton(button);
    }

    static public bool Jump(PlayerIndex index)
    {
        if (!m_controls.ContainsKey(index)) return false;

        return m_controls[index].Jump;
    }

    static public bool JumpPressing(PlayerIndex index)
    {
        if (!m_controls.ContainsKey(index)) return false;

        return m_controls[index].JumpPressing;
    }

    static public bool Dash(PlayerIndex index)
    {
        if (!m_controls.ContainsKey(index)) return false;

        return m_controls[index].Dash;
    }

    static public bool Interact(PlayerIndex index)
    {
        if (!m_controls.ContainsKey(index)) return false;

        return m_controls[index].Interact;
    }

    static public bool Drop(PlayerIndex index)
    {
        if (!m_controls.ContainsKey(index)) return false;
        return m_controls[index].Drop;
    }

    #endregion

    #region Digital Directionals

    static public bool Up(PlayerIndex index)
    {
        if (!m_controls.ContainsKey(index)) return false;

        return m_controls[index].Up;

    }

    static public bool UpPressing(PlayerIndex index)
    {
        if (!m_controls.ContainsKey(index)) return false;

        return m_controls[index].UpPressing;

    }

    static public bool Down(PlayerIndex index)
    {
        if (!m_controls.ContainsKey(index)) return false;

        return m_controls[index].Down;

    }

    static public bool DownPressing(PlayerIndex index)
    {
        if (!m_controls.ContainsKey(index)) return false;

        return m_controls[index].DownPressing;

    }

    static public bool Right(PlayerIndex index)
    {
        if (!m_controls.ContainsKey(index)) return false;

        return m_controls[index].Right;

    }

    static public bool RightPressing(PlayerIndex index)
    {
        if (!m_controls.ContainsKey(index)) return false;

        return m_controls[index].RightPressing;

    }

    static public bool Left(PlayerIndex index)
    {
        if (!m_controls.ContainsKey(index)) return false;

        return m_controls[index].Left;

    }

    static public bool LeftPressing(PlayerIndex index)
    {
        if (!m_controls.ContainsKey(index)) return false;

        return m_controls[index].LeftPresing;

    }

    #endregion

    #region Digital Triggers

    static public bool AngleUpDigital(PlayerIndex index)
    {
        if (!m_controls.ContainsKey(index)) return false;

        return m_controls[index].AngleUpDigital;

    }

    static public bool AngleDownDigital(PlayerIndex index)
    {
        if (!m_controls.ContainsKey(index)) return false;

        return m_controls[index].AngleDownDigital;

    }

    #endregion

    #region Analogic Inputs

    static public float AngleUpAnalogic(PlayerIndex index)
    {
        if (!m_controls.ContainsKey(index)) return 0;

        return m_controls[index].AngleUpAnalogic;

    }

    static public float AngleDownAnalogic(PlayerIndex index)
    {
        if (!m_controls.ContainsKey(index)) return 0;

        return m_controls[index].AngleDownAnalogic;

    }

    static public Vector2 LeftAnalogic(PlayerIndex index)
    {
        if (!m_controls.ContainsKey(index)) return Vector2.zero;

        return m_controls[index].LeftAnalogic;

    }

    static public Vector2 RightAnalogic(PlayerIndex index)
    {
        if (!m_controls.ContainsKey(index)) return Vector2.zero;

        return m_controls[index].RightAnalogic;

    }

    #endregion
}


