using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_over_trigger : MonoBehaviour
{

    void OnTriggerEnter(Collider collision)
    {
        
        if(collision.gameObject.name=="Sphere")
        {
            string levelName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(levelName);

        }
    }
}
