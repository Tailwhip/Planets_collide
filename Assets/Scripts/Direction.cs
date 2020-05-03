using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{
    public bool rightDirection = true;
    public float speed = 0.5f;

    void OnTriggerStay(Collider collision)
    {
        GameObject thing = collision.gameObject;
        Rigidbody rigidbody = thing.GetComponent<Rigidbody>();
        Vector3 velocity = rigidbody.velocity;

        if (rightDirection)
        {
            velocity.x += speed;
        }
        else
        {
            velocity.x += -speed;
        }

        rigidbody.velocity = velocity;
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
