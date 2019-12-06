using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D coll;
    public pressure_plate[] plates;
    public bool condition = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        condition = true;
        foreach(pressure_plate plate in plates)
        {
            if(plate.valid_collision_count == 0)
            {
                condition = false;
                break;
            }
        }
        animator.SetBool("open condition", condition);
        coll.enabled = !condition;
    }
}
