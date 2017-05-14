using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour {

    void Awake()
    {
        Screen.SetResolution(640, 360, false);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void GameStart()
    {
        SceneManager.LoadScene("Game");
    }
}
