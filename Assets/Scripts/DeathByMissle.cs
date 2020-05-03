using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathByMissle : MonoBehaviour
{
    //Blow animation
    public GameObject blow;

    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.name != "Sphere")
        {
            Instantiate(blow, gameObject.transform.position, Quaternion.identity);
            Destroy(transform.gameObject, 0.1f);
            return;
        }

        Instantiate(blow, gameObject.transform.position, Quaternion.identity);
        string levelName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(levelName);
        
    }
}
