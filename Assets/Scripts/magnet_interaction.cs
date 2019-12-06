using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnet_interaction : MonoBehaviour
{
    public Rigidbody2D this_body;
    public Transform this_transform;
    public float charge;


    magnet_interaction[] interactions;
    // Start is called before the first frame update
    void Start()
    {
        interactions = FindObjectsOfType<magnet_interaction>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        foreach (magnet_interaction interaction in interactions)
        {
            if(this != interaction)
            {
                Vector2 force_vector = interaction.this_transform.position - this_transform.position;
                Vector2 single_force = -force_vector.normalized * interaction.charge * charge / Mathf.Pow(force_vector.magnitude, 2);
                this_body.AddForce(single_force);

            }
        }
    }
}
