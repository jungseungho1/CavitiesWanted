using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    public int countdown = 0;
    public string levelToLoad;
    public float seconds = 2f;


    void Update()
    {
        if (countdown == 4)
        {
            Invoke("loadIt", seconds); 
        }
    }

    void loadIt()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}