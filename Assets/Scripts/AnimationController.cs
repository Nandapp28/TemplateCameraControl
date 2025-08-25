using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [Header("Animation")]
    public Animator animator;

    private PlayerMovement playerMovement;

    public enum AnimState
    {
        Idle,
        Run,
        Jump,
        Walk
    }

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();

        if (playerMovement == null)
        {
            Debug.LogError("PlayerAnimationController requires PlayerMovement component on the same GameObject!");
        }
    }

    private void Update()
    {
        if (playerMovement != null)
        {
            HandleMovementAnimation();
        }
    }

    private void HandleAnimation(AnimState state)
    {
        ResetAnimationStates();

        switch (state)
        {
            case AnimState.Idle:
                animator.SetBool("isIdle", true);
                break;
            case AnimState.Run:
                //animator.SetBool("isRun", true);
                animator.SetFloat("speed", playerMovement.currentMoveSpeed);
                break;
            case AnimState.Jump:
                animator.SetBool("isJump", true);
                //animator.SetTrigger("jumping");
                break;
            case AnimState.Walk:
                animator.SetBool("isWalk", true);
                break;
        }
    }

    private void ResetAnimationStates()
    {
        animator.SetBool("isJump", false);
        animator.SetBool("isWalk", false);
        animator.SetBool("isRun", false);
        animator.SetBool("isIdle", false);
    }

    private void HandleMovementAnimation()
    {
        // Handle jump animation
        if (!playerMovement.IsGrounded || playerMovement.IsJumping)
        {
            HandleAnimation(AnimState.Jump);
            return;
        }

        // Handle ground movement animations
        float currentSpeed = playerMovement.CurrentSpeed;
        bool isSprintPressed = playerMovement.IsSprintPressed;

        // Determine animation state based on speed and sprint input
        if (currentSpeed < 0.1f)
        {
            HandleAnimation(AnimState.Idle);
        }
        else if (currentSpeed > 0.1f && !isSprintPressed)
        {
            HandleAnimation(AnimState.Walk);
        }
        else if (currentSpeed > 0.1f && isSprintPressed)
        {
            HandleAnimation(AnimState.Run);
        }
    }
}