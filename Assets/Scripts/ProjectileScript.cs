﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private Animator animator;
    public float speed;
    private bool moving = true;
    private RaycastHit2D target_hit;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("moving", true);

        
    }

    private void Update()
    {
        if(target_hit.collider == null)
        {
            Vector3 forward = transform.TransformDirection(Vector3.right) * 10;
            Vector3 ray_position = transform.position + (forward * 1 * Time.deltaTime);
            Debug.DrawRay(ray_position, forward, Color.green);

            // Cast a ray straight down.LayerMask mask = LayerMask.GetMask("Wall");
            //RaycastHit2D hit = Physics2D.Raycast(ray_position, forward);
            RaycastHit2D hit = Physics2D.Raycast(ray_position, forward, 10, LayerMask.GetMask("Ground"));


            // If it hits something...
            if (hit.collider != null)
            {
                target_hit = hit;
                Debug.Log(target_hit.transform.name + ": " + target_hit.normal);
            }
        }
        
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
            float x_rot = (-90 * target_hit.normal.x);
            float y_rot = (90 * target_hit.normal.y * (target_hit.normal.y - 1));

            transform.eulerAngles = new Vector3(0, 0, x_rot + y_rot);
            transform.position = target_hit.point;
            transform.Translate(Vector3.up * 0.25f);
            transform.parent = collision.transform;
            animator.SetBool("moving", false);
            moving = false;

            GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }

}
