using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehaviour : MonoBehaviour {

    public PlayerDetectorBehaviour detector;

	void Start () {
        detector.callback_OnPlayerEnter = (det, player) => { FindObjectOfType<GameController>().OnDie(); };
	}
	
	
}
