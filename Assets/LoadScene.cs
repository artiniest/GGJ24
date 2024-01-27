using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene
{
    private static LoadScene instance;

    private LoadScene()
    {
        //initialization..
    }

        public static LoadScene Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new LoadScene();
            }
            return instance;
        }
    }

    public void LoadSceneByName(string sceneName)
    {
         SceneManager.LoadScene(sceneName);
    }
}
