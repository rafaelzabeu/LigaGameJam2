using UnityEngine;
using System.Collections;

public interface IControl
{

    PlayerIndex index { get; set; }
    ControlType controlType { get; }

    bool Cancel { get; }
    bool Start { get; }
    bool Back { get; }
    bool Action { get; }
    bool Round { get; }

    bool Jump { get; }
    bool JumpPressing { get; }

    bool Dash { get; }
    bool Interact { get; }
    bool Drop { get; }

    bool Right { get; }
    bool RightPressing { get; }

    bool Up { get; }
    bool UpPressing { get; }

    bool Left { get; }
    bool LeftPresing { get; }

    bool Down { get; }
    bool DownPressing { get; }

    bool AngleUpDigital { get; }
    bool AngleDownDigital { get; }
    float AngleUpAnalogic { get; }
    float AngleDownAnalogic { get; }
    Vector2 LeftAnalogic { get; }
    Vector2 RightAnalogic { get; }
    bool Confirm { get; }
    bool Select { get; }

    bool EspecificButton(XboxCtrlrInput.XboxButton button);


}
