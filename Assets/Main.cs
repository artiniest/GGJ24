using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main
{
    private static Main instance;

    public MouseInput MouseInput => _mouseInput;
    private MouseInput _mouseInput;

    private int _score = 0;
    public int Score => _score;
    
    private Main()
    {
        //Initialization?
        var obj = new GameObject("MouseInput");
        obj.AddComponent<MouseInput>();
        _mouseInput = obj.GetComponent<MouseInput>();
    }

    public static Main Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Main();
            }
            return instance;
        }
    }

    public void AddToScore()
    {
        _score ++;
        if (_score >= 2)
        {
            LoadScene.Instance.LoadSceneByName("Game");
        }
    }
}
