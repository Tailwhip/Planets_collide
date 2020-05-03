using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleMotor : MonoBehaviour
{
    public float velocity = 10f;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void FixedUpdate()
    {
        transform.Translate(transform.forward * velocity * Time.deltaTime, Space.World);
    }
}
