using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectorBehaviour : MonoBehaviour {

    public Action<PlayerDetectorBehaviour, PlayerInteractBehaviour> callback_OnPlayerEnter;
    public Action<PlayerDetectorBehaviour, PlayerInteractBehaviour> callback_OnPlayerExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInteractBehaviour player = collision.GetComponent<PlayerInteractBehaviour>();
        if(player != null)
        {
            if (callback_OnPlayerEnter != null)
            {
                foreach (var item in callback_OnPlayerEnter.GetInvocationList())
                {
                    item.DynamicInvoke(this, player);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerInteractBehaviour player = collision.GetComponent<PlayerInteractBehaviour>();
        if (player != null)
        {
            if (callback_OnPlayerExit != null)
            {
                foreach (var item in callback_OnPlayerExit.GetInvocationList())
                {
                    item.DynamicInvoke(this,player);
                }
            }
        }
    }

}
