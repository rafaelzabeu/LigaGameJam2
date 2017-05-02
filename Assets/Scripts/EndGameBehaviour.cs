﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameBehaviour : MonoBehaviour {

    public Animator animator;

    private void Update()
    {
        if(InputSystem.Interact(PlayerIndex.Player1))
        {
            animator.SetTrigger("Next");
        }
    }

    {
        FindObjectOfType<GameController>().OnDie();
    }
	
}