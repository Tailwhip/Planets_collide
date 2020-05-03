using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour
{
    //Opponents rotation velocity
    public float rotVelocity = 6.0f;
    //Opponents smooth rotation
    public bool smoothRot = true;
    //Opponents movement speed
    public float movementSpeed = 5.0f;
    //Opponents sight range
    public float sightRange = 30f;
    //Opponents stop range from player 
    public float stopRange = 2f;

    

    private Transform opponentObject;
    //private GameObject playerObject;
    private Transform player;
    private bool lookAtPlayer = false;
    private Vector3 XYZPlayerPos;

    private MissleShoot shooting;

    // Use this for initialization
    void Start ()
    {
        opponentObject = transform;
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
        shooting = (MissleShoot)gameObject.GetComponent<MissleShoot>();
    }

	// Update is called once per frame
	void Update ()
    {
        player = GameObject.FindWithTag("Player").transform;

        XYZPlayerPos = new Vector3(player.position.x, player.position.y, player.position.z);

        //Calculating a distance between opponent and a player
        float dist = Vector3.Distance(opponentObject.position, player.position);

        lookAtPlayer = false;

        //checking if the player is in opponents sight range:
        if ((dist <= sightRange) && (dist > stopRange))
        {
            lookAtPlayer = true;
            opponentObject.position = Vector3.MoveTowards(opponentObject.position, XYZPlayerPos, movementSpeed * Time.deltaTime);
            shooting.shoot();
        }
        else if(dist <= stopRange)
        {
            lookAtPlayer = true;
            shooting.shoot();
        }

        LookAtPlayer();

	}

    void LookAtPlayer()
    {
        if (smoothRot && lookAtPlayer == true)
        {
            Quaternion rotation = Quaternion.LookRotation(XYZPlayerPos - opponentObject.position);
            opponentObject.rotation = Quaternion.Slerp(opponentObject.rotation, rotation, Time.deltaTime * rotVelocity);
        }
        else if(!smoothRot && lookAtPlayer == true)
        {
            transform.LookAt(XYZPlayerPos);
        }
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        if (UnityEditor.Selection.activeTransform == transform)
        {
            Gizmos.DrawWireSphere(transform.position, sightRange);
        }

        
    }
#endif


}
