using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleShoot : OppShoot
{
    //time till next shoot
    public float wait = 1f;
    //Countdown till next shoot
    private float nextShootCounter = 0f;

    //Missle object
    public GameObject missle;

    //Function for shoot
    public void shoot()
    {
        //Shoot countdown
        nextShootCounter -= Time.deltaTime;

        //Shoot after counter is zero
        if (nextShootCounter <= 0 && Targeting())
        {
            //Ustawienie licznika na nowo.
            nextShootCounter = wait;

            //Launching a missle
            Instantiate(missle, transform.position + transform.forward, GetMissleRot());
        }
    }
}
