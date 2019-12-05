using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private Animator animator;
    public float speed;
    private bool moving = true;
    private Vector3 target_rot;
    private Vector3 target_pos;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("moving", true);

        
    }

    void FixedUpdate()
    {
        if (moving)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            animator.SetBool("moving", false);
            moving = false;
        }
    }

}
