using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionVerifierBehaviour : MonoBehaviour {

    public Action<GameObject> callback_OnCollisionEnter;
    public Action<GameObject> callback_OnCollisionExit;

    public string TagToFilter = null;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (TagToFilter != null)
        {
            if(callback_OnCollisionEnter != null && col.transform.CompareTag(TagToFilter))
            {
                callback_OnCollisionEnter(col.gameObject);
            }
        }
        else
        {
            if (callback_OnCollisionEnter != null)
            {
                callback_OnCollisionEnter(col.gameObject);
            }
        }
    }


    private void OnTriggerExit2D(Collider2D col)
    {
        if (TagToFilter != null)
        {
            if (callback_OnCollisionExit != null && col.transform.CompareTag(TagToFilter))
            {
                callback_OnCollisionExit(col.gameObject);
            }
        }
        else
        {
            if (callback_OnCollisionExit != null)
            {
                callback_OnCollisionExit(col.gameObject);
            }
        }
    }

}
