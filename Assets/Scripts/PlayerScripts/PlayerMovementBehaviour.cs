using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{

    readonly int XVEL = Animator.StringToHash("XVelocity");
    readonly int YVEL = Animator.StringToHash("YVelocity");
    readonly int JUMP = Animator.StringToHash("Jump");
    readonly int GROUNDED = Animator.StringToHash("Grounded");
    readonly int DIE_ENE = Animator.StringToHash("DieEnemy");
    readonly int DIE_ELE = Animator.StringToHash("DieEle");
    readonly int DOUBLE_JUMP = Animator.StringToHash("DoubleJump");

    public PlayerIndex playerIndex;

    public Animator animator;
    public SpriteRenderer bodyRenderer;
    public new Rigidbody2D rigidbody;
    public CollisionVerifierBehaviour groundCollider;

    public bool IsGrounded { get { return m_grounded; } }
    public Vector2 Velocity { get { return rigidbody.velocity; } }

    public float playerVelocity;
    public float dashForce;
    public float dashTime;

    public float jumpForce;
    public float jumpTime;

    /// <summary>
    /// If the script listens to player input for movement.
    /// If set to false the player keeps momentum.
    /// </summary>
    public bool canMove;
    public bool canDash;
    private bool m_grounded;
    private bool m_jumping;
    private bool m_doubleJump;
    private bool m_finishedJump;

    public bool canDoubleJump;

    //public ParticleSystem[] particles;

    private AudioClip walkSE;
    private AudioClip jumpSE;
    private AudioClip fallSE;

    #region dash
    public SpriteRenderer dashRenderer;
    public float m_dashSpeed = 10f;
    public float m_dashDuration = 1.5f;
    private float m_dashSign;
    private DashState m_dashState;
    private float m_dashTime;
    #endregion

    private void Start()
    {
        m_grounded = false;
        m_jumping = false;
        m_doubleJump = false;
        m_finishedJump = false;
        groundCollider.TagToFilter = "Stage";
        groundCollider.callback_OnCollisionEnter = onColliderGroundEnter;
        groundCollider.callback_OnCollisionExit = onColliderGroundExit;
        walkSE = Resources.Load<AudioClip>("SoundEffects/Player/Walk/Walk");
        jumpSE = Resources.Load<AudioClip>("SoundEffects/Player/Jump/Jump");
        fallSE = Resources.Load<AudioClip>("SoundEffects/Player/Jump/Fall");
    }

    /// <summary>
    /// Stops the player current movement and stops listening to futher input.
    /// </summary>
    public void StopPlayerMovement()
    {
        canMove = false;
        rigidbody.velocity = Vector2.zero;
    }

    private void Update()
    {
        if (canMove)
        {
            if (m_dashState != DashState.Dashing)
            {
                if (!m_jumping && m_grounded && InputSystem.Jump(playerIndex))
                {
                    AudioController.Instance.Play(jumpSE, AudioController.SoundType.SoundEffect2D, 0.1f);
                    m_jumping = true;
                    m_finishedJump = false;
                    rigidbody.AddForce(new Vector2(0f, jumpForce));
                    animator.SetTrigger(JUMP);
                    StartCoroutine(JumpRoutine());
                    //particles[3].Clear();
                    //particles[3].Play();
                }
                else if (!m_jumping && !m_grounded && InputSystem.Jump(playerIndex))
                {
                    AudioController.Instance.Play(jumpSE, AudioController.SoundType.SoundEffect2D, 0.1f);
                    m_jumping = true;
                    m_doubleJump = true;
                    rigidbody.AddForce(new Vector2(0f, jumpForce));
                    StartCoroutine(JumpRoutine());
                }

                if (!m_doubleJump && m_jumping && m_finishedJump && InputSystem.Jump(playerIndex) && canDoubleJump)
                {
                    AudioController.Instance.Play(jumpSE, AudioController.SoundType.SoundEffect2D, 0.1f);
                    m_doubleJump = true;
                    animator.SetTrigger(DOUBLE_JUMP);
                    rigidbody.AddForce(new Vector2(0f, jumpForce));
                    StartCoroutine(JumpRoutine());
                }

                Vector2 vel = InputSystem.LeftAnalogic(playerIndex);

                rigidbody.velocity = new Vector2(vel.x * playerVelocity, rigidbody.velocity.y);
                if (rigidbody.velocity.x > 0)
                    bodyRenderer.flipX = false;
                else if (rigidbody.velocity.x < 0)
                    bodyRenderer.flipX = true;
            }

            #region MovementParticles
            //if (IsGrounded)
            //{
            //    if (rigidbody.velocity.x > 0)
            //    {
            //        particles[1].gameObject.SetActive(true);
            //        particles[0].gameObject.SetActive(false);
            //    }
            //    else if (rigidbody.velocity.x < 0)
            //    {
            //        particles[0].gameObject.SetActive(true);
            //        particles[1].gameObject.SetActive(false);
            //    }
            //    else
            //    {
            //        particles[0].gameObject.SetActive(false);
            //        particles[1].gameObject.SetActive(false);
            //    }
            //}
            //else
            //{
            //    particles[0].gameObject.SetActive(false);
            //    particles[1].gameObject.SetActive(false);
            //} 
            #endregion

            if (canDash)
                dash();

        }
        else
        {
            rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y);
        }

        animator.SetFloat(XVEL, Mathf.Abs(rigidbody.velocity.x));
        animator.SetFloat(YVEL, Mathf.Abs(rigidbody.velocity.y));
        animator.SetBool(GROUNDED, m_grounded);
    }

    IEnumerator JumpRoutine()
    {
        rigidbody.velocity = Vector2.zero;
        float timer = 0;

        while (InputSystem.JumpPressing(playerIndex) && timer < jumpTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        rigidbody.velocity = Vector2.zero;

        //m_jumping = false;
        m_finishedJump = true;
    }

    private void dash()
    {
        switch (m_dashState)
        {
            case DashState.Ready:
                //Dash can be only used in movement 
                if (System.Math.Round(rigidbody.velocity.x, 2) == 0) return;

                if (InputSystem.Dash(playerIndex))
                {
                    //Hide the body
                    //bodyRenderer.SetActive(false);
                    //Set the sprite to right side
                    dashRenderer.flipX = rigidbody.velocity.x < 0;
                    dashRenderer.gameObject.SetActive(true);

                    m_dashSign = Mathf.Sign(rigidbody.velocity.x);

                    m_dashTime = 0;

                    m_dashState = DashState.Dashing;
                }
                break;
            case DashState.Dashing:
                m_dashTime += Time.deltaTime;

                //Do the dash!
                //rigidbody.AddForce(new Vector2(Mathf.Sign(rigidbody.velocity.x) * m_dashSpeed * Time.deltaTime, 0), ForceMode2D.Force);

                rigidbody.velocity = new Vector2(m_dashSign * m_dashSpeed, rigidbody.velocity.y);

                if (m_dashTime >= m_dashDuration)
                {
                    m_dashTime = 0;
                    //bodyRenderer.SetActive(true);
                    dashRenderer.gameObject.SetActive(false);
                    m_dashState = DashState.DashingCooldown;
                }

                break;
            case DashState.DashingCooldown:
                m_dashTime += Time.deltaTime;

                //Small delay;
                if (m_dashTime >= m_dashDuration)
                {
                    m_dashTime = 0;
                    m_dashState = DashState.Ready;
                }
                break;
        }

    }

    private IEnumerator Wait(float time, System.Action onWaitEnd)
    {
        yield return new WaitForSeconds(time);
        onWaitEnd();
    }

    private void onColliderGroundEnter(GameObject ground)
    {
        m_jumping = false;
        m_doubleJump = false;
        m_grounded = true;
        animator.ResetTrigger(JUMP);
        animator.ResetTrigger(DOUBLE_JUMP);

        if (rigidbody.velocity.y < 0)
        {
            AudioController.Instance.Play(fallSE, AudioController.SoundType.SoundEffect2D, 0.1f);
            //particles[2].Clear();
            //particles[2].Play();
        }
    }

    private void onColliderGroundExit(GameObject ground)
    {
        m_grounded = false;
    }

    public void PlayWalkSound()
    {
        if (m_grounded)
        {
            AudioController.Instance.Play(walkSE, AudioController.SoundType.SoundEffect2D, 0.2f);
        }
    }

    private enum DashState
    {
        Ready = 0,
        DashingCooldown = 1,
        Dashing = 2
    }

}
