using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMotor : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float drag = 0.5f;
    public float terminalRotationSpeed = 25.0f;
    public Vector3 MoveVector;

    public Rigidbody ammo;
    
    private Rigidbody thisRigidbody;
    private Collider thisCollider;
    private Transform camTransform;
    private bool grounded;


    // Use this for initialization
    void Start()
    {
        thisRigidbody = gameObject.GetComponent<Rigidbody>();
        thisRigidbody.maxAngularVelocity = terminalRotationSpeed;
        thisRigidbody.drag = drag;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();

        if (grounded==true)//(grounded(thisRigidbody))
        {            
            // Get the original Input
            MoveVector = PoolInput();
            // Rotate our MoveVector
            MoveVector = RotateWithView();
            // Move
            Move();
        }

        if (Input.GetButtonDown("Jump") && grounded==true)
        {
            thisRigidbody.velocity = new Vector3(thisRigidbody.velocity.x, 8f, thisRigidbody.velocity.z);
        }
      
    }

    private void Move()
    {
        thisRigidbody.AddForce((MoveVector * moveSpeed));
    }

    private Vector3 PoolInput()
    {
        Vector3 dir = Vector3.zero;

        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");

        if (dir.magnitude > 1)
            dir.Normalize();

        return dir;
    }

    private Vector3 RotateWithView()
    {
        if(camTransform!=null)
        {
            Vector3 dir = camTransform.TransformDirection(MoveVector);
            dir.Set(dir.x, 0, dir.z);
            return dir.normalized*MoveVector.magnitude;
        }
        else
        {
            camTransform = Camera.main.transform;
            return MoveVector;         
        }
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody ammoInstance;
            ammoInstance = Instantiate(ammo, thisRigidbody.transform.position + new Vector3(0f, 0.7f, 0f), Camera.main.transform.rotation) as Rigidbody;
            ammoInstance.AddForce(Camera.main.transform.forward + new Vector3(0f, 0.1f, 0f));        
        }
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name != "Sphere")
        {
            grounded = true;
        }
    }
    void OnCollisionExit(Collision col)
    {
        grounded = false;
    }

    bool groundedd(Rigidbody rb)
    {
        if (rb.velocity.y <= 0.1 && rb.velocity.y >= 0.00)
        {
            return true;
        }
        else { return false; }
    }

}
