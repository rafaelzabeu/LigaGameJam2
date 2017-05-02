using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ActivatedObjectBehaviour))]
public class EnemyBeheviour : MonoBehaviour
{
    const string WAKE = "Wake";
    const string SHUT_DOWN = "ShutDown";

    public PathFindAI pathFind;

    public new Rigidbody2D rigidbody;
    public Animator animator;

    public PlayerDetectorBehaviour playerDetector;
    public new SpriteRenderer renderer;

    private bool m_active = true;

    private ActivatedObjectBehaviour m_activatedBehaviour;
    private GameController m_controller;

    private void Awake()
    {
        m_controller = FindObjectOfType<GameController>();
        playerDetector.callback_OnPlayerEnter = OnPlayerEnter;
        m_activatedBehaviour = GetComponent<ActivatedObjectBehaviour>();
        m_activatedBehaviour.callback_ChangedState = OnStateChange;
    }

    private void Update()
    {
        if (rigidbody.velocity.x > 0)
            renderer.flipX = false;
        else if (rigidbody.velocity.x < 0)
            renderer.flipX = true;
    }

    private void OnStateChange(bool state)
    {
        m_active = state;
        pathFind.CanMove = state;

        if (state)
        {
            animator.SetTrigger(WAKE);
        }
        else
        {
            animator.SetTrigger(SHUT_DOWN);
        }
    }

    private void OnPlayerEnter(PlayerDetectorBehaviour detec, PlayerInteractBehaviour player)
    {
        if (m_active)
            m_controller.OnDie();
    }

}
