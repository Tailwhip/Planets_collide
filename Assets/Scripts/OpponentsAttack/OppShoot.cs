using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppShoot : MonoBehaviour
{
    //Players object
    protected Transform player;
    //Players position
    private Vector3 XYZPlayerPos;
    //Missle rotation
    private Quaternion missleRot;

    //Opponents sight angle
    public float sightAngle = 160f;

    //Position of an object the opponent is looking at
    protected Vector3 hitPoint;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    //Function responsible for targetting a player
    protected bool Targeting()
    {
        if (player != null)
        {
            //opponents rotation angle relative to the player
            float angle = Quaternion.Angle(player.rotation, transform.rotation);
            
            //checking if player is already in opponents sight angle
            if (angle >= sightAngle)
            {
                return true;
            }
        }
        return false;
    }

    //Function which basing on players position returns a Quaternion to change opponents position where it moves
    public Quaternion GetMissleRot()
    {
        //Players position
        XYZPlayerPos = new Vector3(player.position.x, player.position.y, player.position.z);

        missleRot = Quaternion.LookRotation(XYZPlayerPos - transform.position);
        return missleRot;
    }
}
