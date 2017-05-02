using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractBehaviour : MonoBehaviour
{

    readonly int IS_HOLDING_ITEM = Animator.StringToHash("isHoldingSomething");
    readonly int PICK_UP = Animator.StringToHash("PickUp");

    public PlayerIndex playerIndex { get { return movement.playerIndex; } }

    public Animator animator;

    public PlayerMovementBehaviour movement;

    public Transform collectblePivot;

    public bool CanMove { get { return movement.canMove; } set { movement.canMove = value; } }

    public bool CanInteract;

    public ICollectbleReceiver currentReceiver;

    public ICollectble currentCollectble;

    private void Update()
    {
        if (CanInteract && InputSystem.Interact(playerIndex))
        {
            if (currentCollectble != null && !currentCollectble.IsBeingHeld)
            {
                CollectItem();
            }
            else if (currentReceiver != null)
            {
                if (currentCollectble != null)
                    DeliverCollectble();
                else
                    RemoveItem();
            }
        }
        if (InputSystem.Drop(playerIndex) && currentCollectble != null && currentCollectble.IsBeingHeld)
        {
            currentCollectble.Drop();
        }
    }

    public void DeliverCollectble()
    {
        currentReceiver.ReceiveCollectble(currentCollectble);
    }

    public void CollectItem()
    {
        CollectbleInfo info = currentCollectble.OnCollect(this);
        movement.canDoubleJump = false;
        animator.SetTrigger(info.animation);
        animator.SetBool(IS_HOLDING_ITEM, true);
    }

    public void CollectItem(ICollectble collectble)
    {
        if (currentCollectble != null && currentCollectble.IsBeingHeld)
            currentCollectble.Drop();
        currentCollectble = collectble;
        CollectItem();
        animator.SetBool(IS_HOLDING_ITEM, true);
    }

    private void RemoveItem()
    {
        currentReceiver.RemoveCollectble(this);
    }

    public void OnDropItem()
    {
        currentCollectble = null;
        movement.canDoubleJump = true;
        animator.SetBool(IS_HOLDING_ITEM, false);
    }

}
