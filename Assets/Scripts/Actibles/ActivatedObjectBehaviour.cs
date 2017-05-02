using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedObjectBehaviour : MonoBehaviour {

    public Action<bool> callback_ChangedState;
	
    public void ChangeState(bool state)
    {
        if(callback_ChangedState != null)
        {
            callback_ChangedState(state);
        }
    }

}
