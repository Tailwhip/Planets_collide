using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentDeath : MonoBehaviour
{
    //Death animation
    public GameObject death;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name != "Ammo(Clone)")
        {
            return;
        }

        Instantiate(death, gameObject.transform.position, Quaternion.identity);
        Destroy(transform.parent.gameObject, 0.1f);
        
    }
}
