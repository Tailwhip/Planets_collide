using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape_to_menu : MonoBehaviour
{

	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
        }
	}
}
