using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Checks if either the player or a suitable game object is contacting it. (Magnus blobs are too light)
public class pressure_plate : MonoBehaviour
{
    public int valid_collision_count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PressureValid")
        {
            Debug.Log("entered");
            valid_collision_count++;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PressureValid")
        {
            Debug.Log("exited");
            valid_collision_count--;
        }
    }

}
