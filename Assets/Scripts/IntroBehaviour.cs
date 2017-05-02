using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBehaviour : MonoBehaviour {

    const string NEXT = "Next";

    public Animator animator;


    private void Update()
    {
        if(InputSystem.Interact(PlayerIndex.Player1))
        {
            animator.SetTrigger(NEXT);
        }
    }

    public void OnEnd()
    {
        FindObjectOfType<PlayerMovementBehaviour>().canMove = true;
        Destroy(gameObject);
    }

}
