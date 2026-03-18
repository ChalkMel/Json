using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reaload : MonoBehaviour
{
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
