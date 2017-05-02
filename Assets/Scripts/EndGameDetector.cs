using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameDetector : MonoBehaviour {

    public GameObject endScreen;
    public PlayerDetectorBehaviour playerDetector;

    private void Awake()
    {
        playerDetector.callback_OnPlayerEnter = OnPlayerEnter;
    }

    private void OnPlayerEnter(PlayerDetectorBehaviour det, PlayerInteractBehaviour player)
    {
        endScreen.SetActive(true);
        player.CanMove = false;
    }
	
}
