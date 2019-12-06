﻿#if UNITY_EDITOR
using UnityEngine;
using UnityEditor.Animations;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    public AnimatorController neutral;
    public AnimatorController negative;
    public AnimatorController positive;

    public GameObject red_projectile;
    public GameObject blue_projectile;

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
            FireProjectile(blue_projectile);
        }
        else if(Input.GetMouseButtonDown(1)) // Right Click
        {
            FireProjectile(red_projectile);
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

    public void FireProjectile(GameObject projectile)
    {
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z; // select distance = 10 units from the camera
        Vector2 target = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = target - myPos;
        direction.Normalize();
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        GameObject go = Instantiate(projectile, myPos, rotation);

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
#endif