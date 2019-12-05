using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    public UnityEditor.Animations.AnimatorController neutral;
    public UnityEditor.Animations.AnimatorController negative;
    public UnityEditor.Animations.AnimatorController positive;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    int color = 0;

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            Debug.Log("Crouch");
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        // Mouse
        if (Input.GetMouseButtonDown(0)) // Left Click
        {

        }
        else if(Input.GetMouseButtonDown(1)) // Right Click
        {

        }

        if (Input.GetButtonDown("Q"))
        {
            if(color == 1)
            {
                color = 0;
                animator.runtimeAnimatorController = neutral;
            }
            else
            {
                color = 1;
                animator.runtimeAnimatorController = negative;
            }

        }
        else if (Input.GetButtonDown("E"))
        {
            if (color == 2)
            {
                color = 0;
                animator.runtimeAnimatorController = neutral;
            }
            else
            {
                color = 2;
                animator.runtimeAnimatorController = positive;
            }
        }

    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouch(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    public void OnFall(bool isFalling)
    {
        animator.SetBool("IsFalling", isFalling);
    }
    

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}