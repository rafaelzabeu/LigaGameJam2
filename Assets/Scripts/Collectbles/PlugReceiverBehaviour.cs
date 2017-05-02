using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugReceiverBehaviour : MonoBehaviour, ICollectbleReceiver
{
    const string CHANGE_CAP = "ChangedCap";

    public ICollectble currentCollectble;

    public bool CanInteract
    {
        get
        {
            return true;
        }
    }

    public GameObject GameObject
    {
        get
        {
            return gameObject;
        }
    }

    public Vector2 LocalPos
    {
        get
        {
            return m_plugLocalPosition;
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

    [SerializeField]
    private Vector2 m_plugLocalPosition;

    public PlayerDetectorBehaviour playerDetector;
    public new SpriteRenderer renderer;
    public Animator animator;

    [Tooltip("If set to true objsToActivate are deactivated on start")]
    public bool deactivateObjectsAtStart = true;

    public Sprite activeSprite;
    public Sprite inactiveSprite;

    public ActivatedObjectBehaviour[] objsToActivate;
    public ActivatedObjectBehaviour[] objsToDeactivate;

    private AudioClip plugAudio;
    private AudioClip wrongSphere;

    private void Awake()
    {
        playerDetector.callback_OnPlayerEnter = onPlayerEnter;
        playerDetector.callback_OnPlayerExit = onPlayerExit;
        plugAudio = Resources.Load<AudioClip>("SoundEffects/Sphere/JAM_takeOutSphere");
        wrongSphere = Resources.Load<AudioClip>("SoundEffects/Sphere/JAM_esferaErrada");

    }

    private void Start()
    {
        if (deactivateObjectsAtStart)
            SetDependentObjectsActive(false);
    }

    public void ReceiveCollectble(ICollectble collectble)
    {
        if (currentCollectble != null || collectble.Group != Group)
        {
            AudioController.Instance.Play(wrongSphere, AudioController.SoundType.SoundEffect2D);
            return;
        }
        AudioController.Instance.Play(plugAudio, AudioController.SoundType.SoundEffect2D);
        collectble.OnReceived(this);
        currentCollectble = collectble;
        renderer.sprite = activeSprite;
        animator.SetTrigger(CHANGE_CAP);
        SetDependentObjectsActive(true);
    }

    public void RemoveCollectble(PlayerInteractBehaviour player)
    {
        if (currentCollectble == null)
            return;
        AudioController.Instance.Play(plugAudio, AudioController.SoundType.SoundEffect2D);
        currentCollectble.OnRemovedFromReceiver();
        player.CollectItem(currentCollectble);
        currentCollectble = null;
        renderer.sprite = inactiveSprite;
        animator.SetTrigger(CHANGE_CAP);
        SetDependentObjectsActive(false);
    }

    public void SetDependentObjectsActive(bool active)
    {
        for (int i = 0; i < objsToActivate.Length; i++)
        {
            objsToActivate[i].ChangeState(active);
        }

        for (int i = 0; i < objsToDeactivate.Length; i++)
        {
            objsToDeactivate[i].ChangeState(!active);
        }

    }

    private void onPlayerEnter(PlayerDetectorBehaviour detector, PlayerInteractBehaviour player)
    {
        player.currentReceiver = this;
    }

    private void onPlayerExit(PlayerDetectorBehaviour detector, PlayerInteractBehaviour player)
    {
        if (player.currentReceiver == this)
            player.currentReceiver = null;
    }

    
}
