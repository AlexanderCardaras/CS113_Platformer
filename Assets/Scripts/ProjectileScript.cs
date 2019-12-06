using System.Collections;
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
            Vector3 up = transform.TransformDirection(Vector3.up) * 1;
            Vector3 ray_position1 = transform.position + (forward * 0.015f) + (up * 0.045f);
            Vector3 ray_position2 = transform.position + (forward * 0.015f) - (up * 0.045f);

            Debug.DrawRay(ray_position1, forward, Color.blue);
            Debug.DrawRay(ray_position2, forward, Color.green);

            RaycastHit2D hit1 = Physics2D.Raycast(ray_position1, forward, 10, LayerMask.GetMask("Ground"));
            RaycastHit2D hit2 = Physics2D.Raycast(ray_position2, forward, 10, LayerMask.GetMask("Ground"));

            // If it hits something...
            if (hit1.collider != null)
            {
                target_hit = hit1;
            }

            // If it hits something...
            if (hit2.collider != null)
            {
                if(hit2.distance < hit1.distance)
                {
                    target_hit = hit2;
                }
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

    Vector2 Rotate(Vector2 aPoint, float aDegree)
    {
        float rad = aDegree * Mathf.Deg2Rad;
        float s = Mathf.Sin(rad);
        float c = Mathf.Cos(rad);
        return new Vector2( aPoint.x * c - aPoint.y * s, aPoint.y * c + aPoint.x * s );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            float x_rot = (-90 * target_hit.normal.x);
            float y_rot = (90 * target_hit.normal.y * (-target_hit.normal.y + 1));

            transform.rotation = Quaternion.FromToRotation(Vector3.left, Vector2.Perpendicular(target_hit.normal));
            if (target_hit.normal.y == -1.0) { transform.Rotate(new Vector3(0, 0, 180)); }
       
            transform.position = target_hit.point;
            transform.Translate(Vector3.up * 0.25f);
            transform.parent = collision.transform;
            animator.SetBool("moving", false);
            moving = false;


            GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }

}
