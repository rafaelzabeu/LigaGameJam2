using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugBehaviour : MonoBehaviour, ICollectble
{
    public bool IsBeingHeld
    {
        get
        {
            return m_isBeingHeld;
        }
    }

    private bool m_isBeingHeld;

    public CollectbleInfo CollectbleInfo
    {
        get
        {
            return m_collectbleInfo;
        }

        set
        {
            m_collectbleInfo = value;
        }
    }

    public bool IsPlugged
    {
        get
        {
            return m_isPlugged;
        }
    }

    public int Group
    {
        get
        {
            return m_group;
        }

        set
        {
            m_group = value;
        }
    }

    [SerializeField]
    private int m_group;

    private bool m_isPlugged;

    [SerializeField]
    private CollectbleInfo m_collectbleInfo;

    public new Rigidbody2D rigidbody;
    public PlayerDetectorBehaviour playerDetector;

    private PlayerInteractBehaviour m_currentPlayer;


    private void Awake()
    {
        playerDetector.callback_OnPlayerEnter += onPlayerEnter;
        playerDetector.callback_OnPlayerExit += onPlayerExit;

    }

    public void Drop()
    {
        if (m_currentPlayer != null)
            OnDrop(m_currentPlayer);
        m_currentPlayer = null;
    }

    public CollectbleInfo OnCollect(PlayerInteractBehaviour player)
    {
        transform.SetParent(player.transform);
        transform.localPosition = m_collectbleInfo.localPosition;
        rigidbody.bodyType = RigidbodyType2D.Kinematic;
        rigidbody.velocity = Vector2.zero;
        rigidbody.angularVelocity = 0f;
        m_currentPlayer = player;
        m_isBeingHeld = true;
        return CollectbleInfo;
    }

    public void OnReceived(ICollectbleReceiver receiver)
    {
        Drop();
        transform.SetParent(receiver.GameObject.transform);
        transform.localPosition = receiver.LocalPos;
        rigidbody.bodyType = RigidbodyType2D.Kinematic;
        rigidbody.velocity = Vector2.zero;
        rigidbody.angularVelocity = 0f;
        m_isPlugged = true;
    }

    public void OnRemovedFromReceiver()
    {
        transform.SetParent(null);
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
        m_isPlugged = false;
    }

    public void OnDrop(PlayerInteractBehaviour player)
    {
        transform.SetParent(null);
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
        player.OnDropItem();
        m_isBeingHeld = false;
    }

    private void onPlayerEnter(PlayerDetectorBehaviour detector, PlayerInteractBehaviour player)
    {
        if (!m_isPlugged && (player.currentCollectble == null || !player.currentCollectble.IsBeingHeld))
            player.currentCollectble = this;
    }

    private void onPlayerExit(PlayerDetectorBehaviour detector,PlayerInteractBehaviour player)
    {
        if(player.currentCollectble == this)
        {
            player.currentCollectble = null;
        }
    }

    
}
