using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ActivatedObjectBehaviour))]
public class OnOffBehaviour : MonoBehaviour {

    private void Awake()
    {
        GetComponent<ActivatedObjectBehaviour>().callback_ChangedState = (active) => { gameObject.SetActive(active); };
    }

}
